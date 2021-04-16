//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Orientação a objetos: implementar as estruturas de dados anteriores com coneitos de OO: herança, sobrecarga de métodos, sobrecarga de operadores, polimorfismo
//Herança: Feito em outro arquivo (mas Pilha é Lista e Fila é Lista).
//Sobrecarga de Métodos: Check (Construtor de Node). 
//Sobrecarga de Operadores: Check (Fila-- e Pilha--)
//Polimorfismo: Check (Função display, diferente pra se for lista, pilha ou fila)
#include<iostream>
#include <algorithm>
#include<time.h>

//Notação: Lista simple encadeada. Pilha insere e remove no início (inicio é o topo) da lista. Fila insere no fim e remove no início da lista.

using namespace std;

////////////////////////////////////////////////////////////////////////////////////
//////////////Classes
////////////////////////////////////////////////////////////////////////////////////

class Node {
   private: //dados sigilosos
  	 int data;
  	 Node *next;
   public:
 	 Node();
 	 Node(int);
  	 int getData();
  	 void setData(int);
  	 Node* getNext();
  	 void setNext(Node* N);
};

class Lista{
	public:	
		Lista();
		void TesteHardCode();
		int tamanho();
		void display();
		void insertFirst(int);
		void insertLast(int val);
		void removeFirst();
		void removeLast();			
		Node* getLast();
		void setLast(Node* N);	
		Node* getFirst();
		void setFirst(Node* N);
	private:	
		Node *fim;
		Node *inicio;
};

class Pilha{
	private:
		Lista *P;	//instancio uma Lista dentro da minha Pilha. Usarei ela e suas funções.
	public:
		void TesteHardCode();
		void push(int); 
		void pop();
		void display();			//polimorfismo
		Pilha();
		void operator--();		//sobrecarga operador
};

class Fila{
	private:	
		Lista *F;	//instancio uma Lista dentro da minha Fila. Usarei ela e suas funções.
	public:
		void TesteHardCode();
		void display(); 		//polimorfismo
		Fila();
		void operator--();		//sobrecarga operador
		void remove();
		void insert(int);	
		Node* getLast();
		void setLast(Node* N);	
};

////////////////////////////////////////////////////////////////////////////////////
//////////////Funções de Node
////////////////////////////////////////////////////////////////////////////////////
Node::Node(){
	setNext(NULL);
	setData(0);
}
Node::Node(int val){
	setNext(NULL);
	setData(val);
}

int Node::getData(){
	return(data);
}
void Node::setData(int val){
	data=val;
}
Node* Node::getNext(){
	return(next);
}

void Node::setNext(Node* N){
	next=N;
}

////////////////////////////////////////////////////////////////////////////////////
//////////////Funções de Lista
////////////////////////////////////////////////////////////////////////////////////

void Lista::display() {		//equivalente void diplay(Lista *L){
   Node* ptr;
   if(inicio==NULL)
   		cout<<"List is empty";
   else {
      ptr = inicio;
      cout<<"List: ";
      while (ptr!=NULL) {
         cout<< ptr->getData() <<" ";
         ptr = ptr->getNext();
      }
   }
   cout << endl;
}

int Lista::tamanho() {
   struct Node* ptr;
   int contador=0;
   if(inicio==NULL)
   	  return 0;
   else {
      ptr = inicio;
      while (ptr != NULL) {
         contador++;
         ptr = ptr->getNext();
      }
   }
   return contador;
}

void Lista::removeFirst() {
   if(inicio==NULL)
   cout<<"Empty"<<endl;
   else {
      //cout<<"The removed element is "<< inicio->getData() <<endl
      Node* ptr=inicio;
      inicio = ptr->getNext();
      free(ptr);
      ptr=NULL;
   }
}

Node* Lista::getFirst(){
	return inicio;
}
void Lista::setFirst(Node* N){
	inicio=N;
}

Lista::Lista(){
	setFirst(NULL);
	setLast(NULL);
}

void Lista::insertFirst(int val) {
   //Node* newnode = (Node*) malloc(sizeof(Node));
   Node* newnode = new Node();
   if(getLast()==NULL){ //se vazio
   	  setLast(newnode);
   }
   newnode->setData(val);
   newnode->setNext(getFirst());
   setFirst(newnode);
}

void Lista::insertLast(int val) {
   //Node* newnode = (Node*) malloc(sizeof(Node));
   Node* newnode = new Node(val);
   Node* ptr=getLast();
   if(getFirst()==NULL){ //se vazio
   	  setFirst(newnode);
   }
   else 
   	  ptr->setNext(newnode);
   //newnode->setData(val);
   newnode->setNext(NULL);
   setLast(newnode);
}

void Lista::removeLast() {
   Node* ptr=getFirst();
   if(ptr==NULL){
   		cout<<"Empty"<<endl;
   		return;
   }
   if(getFirst()->getNext()==NULL){ //1 elemento só
      	free(getFirst());
		setFirst(NULL);
      	setLast(NULL);
      	return;
	}
   else {
   	  while(ptr->getNext()!=getLast()){ //chego no penúltimo
   	  	 ptr=ptr->getNext();
   	  }
      //cout<<"The removed element is "<< ptr->getNext()->getData() <<endl;
	  free(getLast());
	  setLast(ptr);
	  ptr->setNext(NULL);
	}
}
void Lista::TesteHardCode(){
	display();
	cout<<"   Insere no primeiro: "; insertFirst(1);	display();
	cout<<"   Insere no primeiro: "; insertFirst(2);	display();
	cout<<"   Insere no primeiro: "; insertFirst(3);	display();
	cout<<"   Insere no primeiro: "; insertFirst(4);	display();
	cout<<"   Remove o primeiro: "; removeFirst(); 	display();
	cout<<"   Remove o ultimo: "; removeLast(); 	display();
	cout<<"   Insere no ultimo: "; insertLast(5); 	display();
	cout<<"   Insere no ultimo: ";insertLast(6); 	display();
	cout<<"   Insere no ultimo: ";insertLast(7); 	display();
	cout<<"   Insere no ultimo: ";insertLast(8);	display();
	cout<<"   Insere no ultimo: ";insertLast(9);	display();
	cout<<"   Remove o ultimo: ";removeLast(); 	display();
	cout << endl;
}
Node* Lista::getLast(){
	return fim;
}
void Lista::setLast(Node* N){
	fim = N;
}
////////////////////////////////////////////////////////////////////////////////////
//////////////Pilha
////////////////////////////////////////////////////////////////////////////////////

void Pilha::TesteHardCode(){
	display();
	push(1);	display();
	push(2);	display();
	push(3);	display();
	push(4);	display();
	pop(); 	display();
	cout << endl;
}

void Pilha::push(int val) {
   P->insertFirst(val);
}

void Pilha::pop(){
	P->removeFirst();
}
void Pilha::display(){
    P->display();
}

Pilha::Pilha(){
	P=new Lista();
}

void Pilha::operator--(){
	P->removeFirst();
}

////////////////////////////////////////////////////////////////////////////////////
//////////////Fila
////////////////////////////////////////////////////////////////////////////////////
void Fila::TesteHardCode(){
	display();
	//insertFirst(1);	display(); //erro pois não existe inserção no início da fila
	remove(); 	display();
	insert(1); 	display();
	remove(); 	display();
	insert(2); 	display();
	insert(3); 	display();
	insert(4);	display();
	insert(5);	display();
	remove(); 	display();
	cout << endl;
}

void Fila::insert(int val){
	F->insertLast(val);
}
void Fila::remove(){
	F->removeFirst();
}

void Fila::display(){
   F->display();
}

Fila::Fila(){
	F = new Lista();
}

void Fila::operator--(){
	F->removeFirst();
}

////////////////////////////////////////////////////////////////////////////////////
//////////////Main
////////////////////////////////////////////////////////////////////////////////////

int main() {
   //srand (time(NULL));
   //system("PAUSE");
   int option,digito = 0;
   Lista *L;
   Pilha *P;
   Fila *F;
   do{
	   cout << "Escolha a estrutura de dados: " << endl;
	   cout << "   1 - Lista automatica" << endl;
	   cout << "   2 - Pilha automatica" << endl;
	   cout << "   3 - Fila automatica" << endl;
	   cout << "   4 - Lista manual" << endl;
	   cout << "   5 - Pilha manual" << endl;
	   cout << "   6 - Fila manual" << endl;
	   cout << "   0 - Sair " << endl;
	   cin >> option;
	   system("CLS");
	   switch(option){
	   	   case 1:
			  L= new Lista();		//Onde eu crio a minha Lista
			  L->TesteHardCode();
			  delete L;
			  break;
		   case 2:
		   	  P= new Pilha();		//Onde eu crio a minha Pilha
		   	  P->TesteHardCode();
		   	  cout << "Aplicando operador --"<<endl;
		   	  P->operator--();		//Há maneira de puxar como P--; ?
		   	  P->display();
		   	  delete P;
		   	  break;
		   case 3:
		   	  F= new Fila();		//Onde eu crio a minha Fila
		   	  F->TesteHardCode();
		   	  cout << "Aplicando operador --"<<endl;
		   	  F->operator--();
		   	  F->display();
		   	  delete F;
		   	  break;
		   case 4:
		   	  L= new Lista();
		   	  while(option!=9 && option!=0){
				  cout << "Escolha a estrutura de dados: " << endl;
				  cout << "   1 - Inserir no inicio da Lista " << endl;
				  cout << "   2 - Inserir no fim da Lista " << endl;
				  cout << "   3 - Remover no inicio da Lista " << endl;
				  cout << "   4 - Remover no fim da Lista " << endl;
				  cout << "   9 - Voltar" << endl;
				  cout << "   0 - Sair " << endl;
				  cin >> option;
				  system("CLS");
				  switch(option){
				  	case 1:
				  		cout <<"Digite o numero: "<< endl;
				  		cin >> digito;
				  		L->insertFirst(digito);
				  		L->display();
				  		break;
				  	case 2:
				  		cout <<"Digite o numero: "<< endl;
				  		cin >> digito;
				  		L->insertLast(digito);
				  		L->display();
				  		break;
					case 3:
				  		L->removeFirst();
				  		L->display();
				  		break;
					case 4:
				  		L->removeLast();
				  		L->display();
				  		break;
					case 9:
				  		break;
				  	default:
				  		break;
				  }
				  cout << endl;
			  }
			  delete L;
			  break;
		   case 5:
		   	  P= new Pilha();		//Onde eu crio a minha Pilha
		   	  while(option!=9 && option!=0){
				  cout << "Escolha a estrutura de dados: " << endl;
				  cout << "   1 - Inserir no topo da Pilha " << endl;
				  cout << "   2 - Remover no topo da Pilha " << endl;
				  cout << "   9 - Voltar" << endl;
				  cout << "   0 - Sair " << endl;
				  cin >> option;
				  system("CLS");
				  switch(option){
				  	case 1:
				  		cout <<"Digite o numero: "<< endl;
				  		cin >> digito;
				  		P->push(digito);
				  		P->display();
				  		break;
				  	case 2:
				  		P->pop();
				  		P->display();
				  		break;
					case 9:
				  		break;
				  	default:
				  		break;
				  }
				  cout << endl;
			  }
		   	  delete P;
		   	  break;
		   case 6:
		   	  F= new Fila();		//Onde eu crio a minha Fila
		   	  while(option!=9 && option!=0){
				  cout << "Escolha a estrutura de dados: " << endl;
				  cout << "   1 - Inserir no fim da Fila " << endl;
				  cout << "   2 - Remover no inicio da Fila " << endl;
				  cout << "   9 - Voltar" << endl;
				  cout << "   0 - Sair " << endl;
				  cin >> option;
				  system("CLS");
				  switch(option){
				  	case 1:
				  		cout <<"Digite o numero: "<< endl;
				  		cin >> digito;
				  		F->insert(digito);
				  		F->display();
				  		break;
				  	case 2:
				  		F->remove();
				  		F->display();
				  		break;
					case 9:
				  		break;
				  	default:
				  		break;
				  }
				  cout << endl;
			  }
		   	  delete F;
		   	  break;
		   default:
		   	  option=0;
	   }
   } while(option!=0);
   cout << endl;
   system("PAUSE");
}
