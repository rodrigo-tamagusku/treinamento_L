//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar uma estrutura de dados Pilha.
#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;

int *stack, n=100, top=-1;
void display() {
   if(top>=0) {
      cout<<"Stack elements are:";
      for(int i=top; i>=0; i--)
      cout<<stack[i]<<" ";
      cout<<endl;
   } else
   cout<<"Stack is empty"<<endl;
}
void push(int val) {
   if(top>=n-1)
   cout<<"Stack Overflow"<<endl;
   else {
      top++;
      stack[top]=val;
   }
}
void pop() {
   if(top<=-1)
   cout<<"Stack Underflow"<<endl;
   else {
      cout<<"The popped element is "<< stack[top] <<endl;
      top--;
   }
}

void Test(){
   display();
   push(1);display();
   push(2);display();
   push(3);display();
   push(4);display();
   pop();  display();
   pop();  display();
   push(5);display();
   push(6);display();
   push(7);display();
   push(8);display();
   pop();  display();
}

int main() {
   stack = (int*) malloc (n*sizeof(int));
   clock_t begin = clock();
   Test(); 		//Aplica um teste visual
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Time Spent: " << time_spent << endl;
   free(stack);
   cout << endl;
   system("PAUSE");
}
