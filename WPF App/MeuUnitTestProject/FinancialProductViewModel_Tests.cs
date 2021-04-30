using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF_App;
using WPF_App.Model;

namespace WPF_App.ViewModel
{ 
    //Nota: Tive que adicionar pelo NuGet a biblioteca System.Data.SQLite.Core
    [TestClass]
    public class FinancialProductViewModel_Tests
    {
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

        [TestMethod]
        public void AddShareToList_AçãoVaziaEInseridaSQLiteCRUD()
        {
            //Arrange
            SQLiteCRUD sqlitecrud = new SQLiteCRUD();
            FinancialProductViewModel FPVM = new FinancialProductViewModel(sqlitecrud);
            bool resultadoEsperado = true;
            bool resultadoRetornado;

            //Act
            resultadoRetornado = FPVM.AddShareToList();

            //Assert
            Assert.IsTrue(resultadoEsperado == resultadoRetornado);
        }

        [TestMethod]
        public void DeleteFinancialProduct_ProdutoVazioERemovido(IFinancialProduct financialProduct)
        {
            //Mensagem:
            //    Test method WPF_App.ViewModel.FinancialProductViewModel_Tests.DeleteFinancialProduct_ProdutoVazioERemovido threw exception:
            //    Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.ObjectModel.TestFailedException: Only data driven test methods can have parameters. Did you intend to use[DataRow] or[DynamicData] ?
            // Rastreamento de Pilha:
            //    ThreadOperations.ExecuteWithAbortSafety(Action action)

            //Arrange
            FinancialProductViewModel FPVM = new FinancialProductViewModel(new SimpleCRUD());
            bool resultadoEsperado = true;
            bool resultadoRetornado;
            //financialProduct = new Stock();

            //Act
            FPVM.AddShareToList();
            resultadoRetornado = FPVM.DeleteFinancialProduct(financialProduct);

            //Assert
            Assert.IsTrue(resultadoEsperado == resultadoRetornado);
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
