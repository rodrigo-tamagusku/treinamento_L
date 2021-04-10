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

//Lista.tamanho;

//struct Node* lista = NULL; //head

void display(Lista *L) {
   struct Node* ptr;
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

//void tamanho(){}

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
   display(L);
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
   display(L);
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
   display(L);
}
void removeLast(Lista *L) {
   struct Node* ptr=L->inicio;
   if(ptr==NULL)
   cout<<"Empty"<<endl;
   else {
   	  while(ptr->next!=L->fim){ //chego no penúltimo
   	  	 ptr=ptr->next;
   	  }
      cout<<"The removed element is "<< ptr->next->data <<endl;
      if(L->inicio->next==NULL){ //1 elemento só
      	L->inicio=NULL;
	  }
	  free(L->fim);
	  L->fim=ptr;
	}
	display(L);
}

int main() {
   //srand (time(NULL));
   //system("PAUSE");
   Lista L;
   createList(&L);
   
   clock_t begin = clock();
   //cout << "Queue before Sorting: " << endl;
   display(&L);
   insertFirst(&L,1);
   insertFirst(&L,2);
   insertFirst(&L,3);
   insertFirst(&L,4);
   removeFirst(&L);
   insertLast(&L,5);
   insertLast(&L,6);
   insertLast(&L,7);
   insertLast(&L,8);	
   removeLast(&L);
   insertLast(&L,9);	
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   //cout << endl << "Queue after Sorting: " << endl;
   cout << endl << "Time Spent: " << time_spent << endl;
}
