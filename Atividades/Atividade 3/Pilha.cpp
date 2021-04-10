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
      display();
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

int main() {
   //srand (time(NULL));
   //system("PAUSE");
   stack = (int*) malloc (n*sizeof(int));
   clock_t begin = clock();
   //cout << "Queue before Sorting: " << endl;
   display();
   push(1);
   push(2);
   push(3);
   push(4);
   pop();
   pop();
   push(5);
   push(6);
   push(7);
   push(8);	
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   //cout << endl << "Queue after Sorting: " << endl;
   cout << endl << "Time Spent: " << time_spent << endl;
   free(stack);
}
