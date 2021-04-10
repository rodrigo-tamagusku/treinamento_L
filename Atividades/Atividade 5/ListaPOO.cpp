//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Orientação a objetos: implementar as estruturas de dados anteriores com coneitos de OO: herança, sobrecarga de métodos, sobrecarga de operadores, polimorfismo
//Herança: Check (Pilha é Lista e Fila é Lista, porém tem métodos a mais).
//Sobrecarga de Métodos: Check (Construtor de Node). No insertFirst usa o construtor sem nada. No insertLast usa o construtor que leva int.
//Sobrecarga de Operadores: Check (Fila-- e Pilha--)
//Polimorfismo: Check (Função display, diferente pra se for lista, pilha ou fila)
#include<iostream>
#include <algorithm>
#include<time.h>

//Notação: Lista simple encadeada. Pilha insere e remove no início da lista. Fila insere no fim e remove no início da lista.

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
		//int tamanho;
		virtual void display();
		int tamanho();
		Lista();
		void insertFirst(int val);
		void insertLast(int val);
		void removeFirst();
		Node* getFirst();
		void setFirst(Node* N);
		Node* getLast();
		void setLast(Node* N);
		void rotinaTeste();
	private:
		Node *inicio;
		Node *fim;
		void removeLast();
};

class Pilha: public Lista{
	public:
		void display();
		Pilha();
		void operator--();
};
class Fila: public Lista{
	public:
		void display();
		Fila();
		void operator--();
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

void Lista::display() {
   struct Node* ptr;
   if(inicio==NULL)
   cout<<"List is empty";
   else {
      ptr = inicio;
      cout<<"List elements are: ";
      while (ptr != fim->getNext()) {
         cout<< ptr->getData() <<" ";
         ptr = ptr->getNext();
      }
   }
   cout<<endl;
}

int Lista::tamanho() {
   struct Node* ptr;
   int contador=0;
   if(inicio==NULL)
   	  return 0;
   else {
      ptr = inicio;
      while (ptr != fim->getNext()) {
         contador++;
         ptr = ptr->getNext();
      }
   }
   return contador;
}

Lista::Lista(){
	setFirst(NULL);
	setLast(NULL);
}

void Lista::insertFirst(int val) {
   //Node* newnode = (Node*) malloc(sizeof(Node));
   Node* newnode = new Node();
   if(fim==NULL){ //se vazio
   	  fim=newnode;
   }
   newnode->setData(val);
   newnode->setNext(inicio);
   inicio = newnode;
}
void Lista::insertLast(int val) {
   //Node* newnode = (Node*) malloc(sizeof(Node));
   Node* newnode = new Node(val);
   Node* ptr=fim;
   if(inicio==NULL){ //se vazio
   	  inicio=newnode;
   }
   else 
   	  ptr->setNext(newnode);
   //newnode->setData(val);
   newnode->setNext(NULL);
   fim=newnode;
}

void Lista::removeFirst() {
   if(inicio==NULL)
   cout<<"Empty"<<endl;
   else {
      //cout<<"The removed element is "<< inicio->getData() <<endl;
      if(inicio->getNext()==NULL){ //1 elemento só
      	fim=NULL;
	  }
      Node* ptr=inicio;
      inicio = ptr->getNext();
      free(ptr);
      ptr=NULL;
   }
}
void Lista::removeLast() {
   Node* ptr=inicio;
   if(ptr==NULL)
   cout<<"Empty"<<endl;
   else {
   	  while(ptr->getNext()!=fim){ //chego no penúltimo
   	  	 ptr=ptr->getNext();
   	  }
      cout<<"The removed element is "<< ptr->getNext()->getData() <<endl;
      if(inicio->getNext()==NULL){ //1 elemento só
      	inicio=NULL;
	  }
	  free(fim);
	  fim=ptr;
	}
}
Node* Lista::getFirst(){
	return inicio;
}
void Lista::setFirst(Node* N){
	inicio=N;
}

Node* Lista::getLast(){
	return fim;
}
void Lista::setLast(Node* N){
	fim = N;
}

void Lista::rotinaTeste(){
	display();
	insertFirst(1);	display();
	insertFirst(2);	display();
	insertFirst(3);	display();
	insertFirst(4);	display();
	removeFirst(); 	display();
	insertLast(5); 	display();
	insertLast(6); 	display();
	insertLast(7); 	display();
	insertLast(8);	display();
	insertLast(9);	display();
	cout << endl;
}
////////////////////////////////////////////////////////////////////////////////////
//////////////Pilha
////////////////////////////////////////////////////////////////////////////////////

void Pilha::display(){
   Pilha* aux = new Pilha;	//Pilha auxiliar para armazenar a Pilha principal. Ordem de O(n). Para manter a inserção e remoção na frente
   //Node* ptr;
   if(getFirst()==NULL)
   	  cout<<"Stack is empty";
   else {
      //ptr = getFirst();
      cout<<"Stack from top to bottom: ";
      while (getFirst()!=NULL) {
         cout<< getFirst()->getData() <<" ";
         aux->insertFirst((getFirst())->getData());
		 removeFirst();
      }
      while (aux->getFirst()!=NULL) {
         insertFirst((aux->getFirst())->getData());
		 aux->removeFirst();
      }
   }
   delete aux;
   cout<<endl;
   /*
   //Nota: Quebra regra de pilha. Deveria criar uma pilha temporária para fazer leitura e reconstrução.
   struct Node* ptr;
   if(getFirst()==NULL)
      cout<<"Stack is empty";
   else {
      ptr = getFirst();
      cout<<"Stack from top to bottom: ";
      while (ptr != getLast()->getNext()) {
         cout<< ptr->getData() <<" ";
         ptr = ptr->getNext();
      }
   }
   cout<<endl;
   */
}

Pilha::Pilha(){
	setFirst(NULL);
	setLast(NULL);
}

void Pilha::operator--(){
	removeFirst();
}

////////////////////////////////////////////////////////////////////////////////////
//////////////Fila
////////////////////////////////////////////////////////////////////////////////////

void Fila::display(){
   Fila* aux = new Fila;	//Fila auxiliar para armazenar a fila principal. Ordem de O(n). Para manter a inserção atrás e remoção na frente
   //Node* ptr;
   if(getFirst()==NULL)
   	  cout<<"Queue is empty";
   else {
      //ptr = getFirst();
      cout<<"Queue from first to last: ";
      while (getFirst()!=NULL) {
         cout<< getFirst()->getData() <<" ";
         aux->insertLast((getFirst())->getData());
		 removeFirst();
      }
      while (aux->getFirst()!=NULL) {
         insertLast((aux->getFirst())->getData());
		 aux->removeFirst();
      }
   }
   delete aux;
   cout<<endl;
   /*
   //Nota: Quebra regra de Fila. 
   struct Node* ptr;
   if(getFirst()==NULL)
     cout<<"Queue is empty";
   else {
      ptr = getFirst();
      cout<<"Queue from first to last: ";
      while (ptr != getLast()->getNext()) {
         cout<< ptr->getData() <<" ";
         ptr = ptr->getNext();
      }
   }
   cout<<endl;
   */
}

Fila::Fila(){
	setFirst(NULL);
	setLast(NULL);
}

void Fila::operator--(){
	removeFirst();
}

////////////////////////////////////////////////////////////////////////////////////
//////////////Main
////////////////////////////////////////////////////////////////////////////////////

int main() {
   //srand (time(NULL));
   //system("PAUSE");
   int option = 0;
   Lista *L;
   Pilha *P;
   Fila *F;
   do{
	   cout << "Escolha a estrutura de dados: " << endl;
	   cout << "   1 - Criar Lista " << endl;
	   cout << "   2 - Criar Pilha " << endl;
	   cout << "   3 - Criar Fila " << endl;
	   cout << "   0 - Sair " << endl;
	   cin >> option;
	   system("CLS");
	   switch(option){
	   	   case 1:
			  L= new Lista();		//Onde eu crio a minha Lista
			  L->rotinaTeste();
			  delete L;
			  break;
		   case 2:
		   	  P= new Pilha();		//Onde eu crio a minha Pilha
		   	  P->rotinaTeste();
		   	  P->operator--();		//Há maneira de puxar como P--; ?
		   	  P->display();
		   	  delete P;
		   	  break;
		   case 3:
		   	  F= new Fila();		//Onde eu crio a minha Fila
		   	  F->rotinaTeste();
		   	  F->operator--();
		   	  F->display();
		   	  delete F;
		   	  break;
		   default:
		   	  option=0;
	   }
   } while(option!=0);
   cout << endl;
   system("PAUSE");
}
