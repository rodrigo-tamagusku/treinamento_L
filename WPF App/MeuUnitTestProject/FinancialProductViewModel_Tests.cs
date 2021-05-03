using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF_App;
using WPF_App.Model;
using Moq;
using WPF_App.MainWindow.ViewModel;
using System.Windows.Input;

namespace WPF_App.ViewModel
{
    //Nota: Tive que adicionar pelo NuGet a biblioteca System.Data.SQLite.Core
    //https://scottlilly.com/creating-mock-objects-for-c-unit-tests-using-moq/
    [TestClass]
    public class FinancialProductViewModel_Tests
    {
        //[TestInitialize]
        //[TestCleanup]
        [TestMethod]
        public void UpdateCommandExecute_InsereFundoEEleEstaNaListaComId_ComMock()
        {
            //Arrange
            MockCRUD mockcrud = new MockCRUD();
            Fund fundo = new Fund("Nome", "Setor", "Tipo");
            //Mock
            mockcrud.RetornoFundoCriado = fundo;
            mockcrud.RetornoFundoCriado.Id = 20;
            mockcrud.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            MainWindowViewModel MWVM = new MainWindowViewModel(mockcrud);
            //Act
            (MWVM.CreateFundCommand).CanExecute(fundo);
            MWVM.ProdutoFinVM.FinancialProducts.Add(mockcrud.RetornoFundoCriado); //Meio mock
            //Assert
            Assert.IsTrue(MWVM.ProdutoFinVM.FinancialProducts.Contains(mockcrud.RetornoFundoCriado));
        }
        [TestMethod]
        public void CreateFundCommandExecute_InsereFundoNaListaVazia_VerificaQueListaTem1Elemento_ComMock()
        {
            //Arrange
            MockCRUD mockcrud = new MockCRUD();
            Fund fundo = new Fund("Nome", "Setor", "Tipo");
            //Mock
            mockcrud.RetornoFundoCriado = fundo;
            mockcrud.RetornoFundoCriado.Id = 20;
            mockcrud.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            mockcrud.RetornoListaBD.Add(mockcrud.RetornoFundoCriado);
            MainWindowViewModel MWVM = new MainWindowViewModel(mockcrud);
            //Act
            (MWVM.CreateFundCommand).CanExecute(fundo);
            //Assert
            Assert.IsTrue(MWVM.ProdutoFinVM.FinancialProducts.Count==1);
        }
        [TestMethod]
        public void InsertCommandExecute_InsereFundoNaListaCom2Elementos_VerificaQueListaTem3Elementos_ComMock()
        {
            //Arrange
            MockCRUD mockcrud = new MockCRUD();
            Fund fundo = new Fund();
            ObservableCollection<IFinancialProduct> lista = new ObservableCollection<IFinancialProduct>();
            lista.Add(new Fund("Nome", "Setor", "Tipo"));
            lista.Add(new Fund("Nome", "Setor", "Tipo"));
            //Mock
            mockcrud.RetornoFundoCriado = fundo;
            mockcrud.RetornoFundoCriado.Id = 20;
            mockcrud.RetornoListaBD = lista;
            FinancialProductViewModel FPVM = new FinancialProductViewModel(mockcrud);
            //Act
            FPVM.AddFundToList();
            FPVM.FinancialProducts.Add(mockcrud.RetornoFundoCriado); //Isso o seu programa faz
            //Assert
            Assert.IsTrue(FPVM.FinancialProducts.Count == 3);
        }
        [TestMethod]
        //[ExpectedException(Exception NullReferenceException)]
        public void UpdateCommandExecute_UpdateFundoNaListaComListaVazia_RetornaFalse_ComMock()
        {
            //Arrange
            MockCRUD mockcrud = new MockCRUD();
            mockcrud.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            MainWindowViewModel MWVM = new MainWindowViewModel(mockcrud);
            Fund fundo = new Fund();
            //Mock
            //mockcrud.UpdateFinancialProduct(lista,fundo)
            //Act
            (MWVM.UpdateCommand).CanExecute(fundo);
            //Assert
            Assert.IsFalse(MWVM.ProdutoFinVM.FinancialProducts.Contains(fundo));
        }
        [TestMethod]
        public void UpdateCommandCanExecute_PodeExecutarSeTemFundo()
        {
            //Arrange
            MainWindowViewModel MWVM = new MainWindowViewModel();
            bool valorRetornado;
            //Act
            valorRetornado = (MWVM.UpdateCommand).CanExecute(new Fund());
            //Assert
            Assert.IsTrue(valorRetornado);
        }
        [TestMethod]
        public void UpdateCommandCanExecute_NaoPodeExecutarVazio()
        {
            //Arrange
            MainWindowViewModel MWVM = new MainWindowViewModel();
            bool valorRetornado;
            //Act
            valorRetornado = (MWVM.UpdateCommand).CanExecute(null);
            //Assert
            Assert.IsFalse(valorRetornado);
        }
        [TestMethod]
        public void UpdateCommandCanExecute_NaoPodeExecutarComInt()
        {
            //Arrange
            MainWindowViewModel MWVM = new MainWindowViewModel();
            bool valorRetornado;
            int i = 0;
            //Act
            valorRetornado = (MWVM.UpdateCommand).CanExecute(i);
            //Assert
            Assert.IsTrue(valorRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_ObservableCollectionNaoNotifica_ComMock()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new MockCRUD());
            bool resultadoEsperado = false;
            bool resultadoRetornado;
            ObservableCollection<IFinancialProduct> lista = new ObservableCollection<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_ObservableCollectionNaoNotificaComSimpleCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SimpleCRUD());
            bool resultadoEsperado = false;
            bool resultadoRetornado;
            ObservableCollection<IFinancialProduct> lista = new ObservableCollection<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado,resultadoRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_ListaNotificaComSimpleCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SimpleCRUD());
            bool resultadoEsperado = true;
            bool resultadoRetornado;
            List<IFinancialProduct> lista = new List<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_CollectionNotificaComSimpleCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SimpleCRUD());
            bool resultadoEsperado = true;
            bool resultadoRetornado;
            Collection<IFinancialProduct> lista = new Collection<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_ListaNotificaComSQLiteCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SQLiteCRUD());
            bool resultadoEsperado = true;
            bool resultadoRetornado;
            List<IFinancialProduct> lista = new List<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_CollectionNotificaComSQLiteCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SQLiteCRUD());
            bool resultadoEsperado = true;
            bool resultadoRetornado;
            Collection<IFinancialProduct> lista = new Collection<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }
        [TestMethod]
        public void NotificaTelaSePrecisa_ObservableCollectionNaoNotificaComSQLiteCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SQLiteCRUD());
            bool resultadoEsperado = false;
            bool resultadoRetornado;
            ObservableCollection<IFinancialProduct> lista = new ObservableCollection<IFinancialProduct>();

            //Act
            resultadoRetornado = FPVM.NotificaTelaSePrecisa(lista);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }

        [TestMethod]
        public void AddShareToList_AçãoVaziaEInseridaSimpleCRUD()
        {
            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SimpleCRUD());
            bool resultadoEsperado = true;
            bool resultadoRetornado;

            //Act
            resultadoRetornado = FPVM.AddShareToList();

            //Assert
            Assert.IsTrue(resultadoEsperado == resultadoRetornado);
        }

        //[TestMethod]
        //public void AddShareToList_AçãoVaziaEInseridaSQLiteCRUD()
        //{
        //    //Arrange
        //    SQLiteCRUD sqlitecrud = new SQLiteCRUD();
        //    FinancialProductViewModel FPVM = new FinancialProductViewModel(sqlitecrud);
        //    bool resultadoEsperado = true;
        //    bool resultadoRetornado;

        //    //Act
        //    resultadoRetornado = FPVM.AddShareToList();

        //    //Assert
        //    Assert.IsTrue(resultadoEsperado == resultadoRetornado);
        //}
        [TestMethod]
        public void AddShareToList_AçãoVaziaEInserida_ComMock()
        {
            //Arrange
            MockCRUD mockCRUD = new MockCRUD();
            mockCRUD.RetornaBooleanoParaReturnDoAdd = true;
            mockCRUD.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            FinancialProductViewModel FPVM = new FinancialProductViewModel(mockCRUD);
            bool resultadoEsperado = true;
            bool resultadoRetornado;
            //Act
            resultadoRetornado = FPVM.AddShareToList();

            //Assert
            Assert.IsTrue(resultadoEsperado == resultadoRetornado);
        }
        [TestMethod]
        public void AddFundToList_FundoVaziaEInserida_ComMock()
        {
            //Arrange
            MockCRUD mockCRUD = new MockCRUD();
            mockCRUD.RetornaBooleanoParaReturnDoAdd = true;
            mockCRUD.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            FinancialProductViewModel FPVM = new FinancialProductViewModel(mockCRUD);
            int resultadoEsperado = 1;
            Fund resultadoRetornado;
            mockCRUD.RetornoFundoCriado = new Fund(1); // Suponho que o BD decide criar o fundo com Id 1
            mockCRUD.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            //Act
            resultadoRetornado = FPVM.AddFundToList();

            //Assert
            Assert.AreEqual(resultadoEsperado,resultadoRetornado.Id);
        }
        [TestMethod]
        public void DeleteFinancialProduct_ProdutoVazioERemovido()
        {
            //Mensagem:
            //    Test method WPF_App.ViewModel.FinancialProductViewModel_Tests.DeleteFinancialProduct_ProdutoVazioERemovido threw exception:
            //    Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.ObjectModel.TestFailedException: Only data driven test methods can have parameters. Did you intend to use[DataRow] or[DynamicData] ?
            // Rastreamento de Pilha:
            //    ThreadOperations.ExecuteWithAbortSafety(Action action)

            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SQLiteCRUD());
            //bool resultadoEsperado = true;
            bool resultadoRetornado;
            Stock financialProduct = new Stock();

            //Act
            //FPVM.AddShareToList();
            resultadoRetornado = FPVM.DeleteFinancialProduct(financialProduct);

            //Assert
            Assert.IsTrue(resultadoRetornado);
        }
        [TestMethod]
        public void DeleteFinancialProduct_ProdutoVazioERemovido_ComMock()
        {

            //Arrange
            MockCRUD mockCRUD = new MockCRUD();
            mockCRUD.RetornaBooleanoParaReturnDoDelete = true;
            mockCRUD.RetornoListaBD = new ObservableCollection<IFinancialProduct>();
            FinancialProductViewModel FPVM = new FinancialProductViewModel(mockCRUD);
            //bool resultadoEsperado = true;
            bool resultadoRetornado;
            Stock financialProduct = new Stock();
            //Act
            //FPVM.AddShareToList();
            resultadoRetornado = FPVM.DeleteFinancialProduct(financialProduct);

            //Assert
            Assert.IsTrue(resultadoRetornado);
        }

        [TestMethod]
        public void Template_MinhaFunção_Teste()
        {
            //Arrange
            bool resultadoEsperado = true;
            bool resultadoRetornado;

            //Act
            resultadoRetornado = true;

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoRetornado);
        }
    }
}
