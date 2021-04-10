//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar uma estrutura de dados Lista simples encadeada.
#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;

struct Node {
   int data;
   struct Node *next;
};

struct Lista{
	struct Node *inicio, *fim;
	int tamanho;
};

void display(Lista *L) {
   Node* ptr;
   if(L->inicio==NULL)
   cout<<"List is empty";
   else {
      ptr = L->inicio;
      cout<<"List elements are: ";
      while (ptr != L->fim->next) {
         cout<< ptr->data <<" ";
         ptr = ptr->next;
      }
   }
   cout<<endl;
}

int tamanho(Lista *L){
   Node* ptr;
   if(L->inicio==NULL)
   		return 0;
   else {
   	  int contador = 0;
      ptr = L->inicio;
      while (ptr != L->fim->next) {
         contador++;
         ptr = ptr->next;
      }
      return contador;
   }
}

void createList(struct Lista *L){
	L->inicio=NULL;
	L->fim=NULL;
}

void insertFirst(Lista *L,int val) {
   struct Node* newnode = (struct Node*) malloc(sizeof(struct Node));
   if(L->fim==NULL){ //se vazio
   	  L->fim=newnode;
   }
   newnode->data = val;
   newnode->next = L->inicio;
   L->inicio = newnode;
}
void insertLast(Lista *L,int val) {
   struct Node* newnode = (struct Node*) malloc(sizeof(struct Node));
   struct Node* ptr=L->fim;
   if(L->inicio==NULL){ //se vazio
   	  L->inicio=newnode;
   }
   ptr->next=newnode;
   newnode->data = val;
   newnode->next = NULL;
   L->fim=newnode;
}

void removeFirst(Lista *L) {
   if(L->inicio==NULL)
   cout<<"Empty"<<endl;
   else {
      cout<<"The removed element is "<< L->inicio->data <<endl;
      if(L->inicio->next==NULL){ //1 elemento só
      	L->fim=NULL;
	  }
      Node* ptr=L->inicio;
      L->inicio = ptr->next;
      free(ptr);
      ptr=NULL;
   }
}
void removeLast(Lista *L) {
   struct Node* ptr=L->inicio;
   if(ptr==NULL)
   cout<<"Empty"<<endl;
   else {
   	  while(ptr->next!=L->fim){ //chego no penúltimo
   	  	 ptr=ptr->next;			//Isso poderia ser melhor se fosse duplamente encadeada
   	  }
      cout<<"The removed element is "<< ptr->next->data <<endl;
      if(L->inicio->next==NULL){ //1 elemento só
      	L->inicio=NULL;
	  }
	  free(L->fim);
	  L->fim=ptr;
	}
}
void test(Lista *L){
   display(L);
   insertFirst(L,1);display(L);
   insertFirst(L,2);display(L);
   insertFirst(L,3);display(L);
   insertFirst(L,4);display(L);
   removeFirst(L);  display(L);
   insertLast(L,5); display(L);
   insertLast(L,6); display(L);
   insertLast(L,7); display(L);
   insertLast(L,8); display(L);
   removeLast(L);   display(L);
   insertLast(L,9); display(L);
}
int main() {
   Lista L;
   createList(&L);
   clock_t begin = clock();
   test(&L);
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Time Spent: " << time_spent << endl;
   cout << endl;
   system("PAUSE");
}
