//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar uma estrutura de dados Fila.
#include <iostream>
#include <time.h>
#include <algorithm>

using namespace std;

int n = 100, front = - 1, rear = - 1;
int *queue;     //create an array with given number of elements

void Display() {
   if (front == - 1)
   cout<<"Queue is empty"<<endl;
   else {
      cout<<"Queue elements are : ";
      for (int i = front; i <= rear; i++)
      cout<<queue[i]<<" ";
         cout<<endl;
   }
}
void Insert(int val) {
   if (rear == n - 1)
   cout<<"Queue Overflow"<<endl;
   else {
      if (front == - 1)
      front = 0;
      rear++;
      queue[rear] = val;
   }
}
void Delete() {
   if (front == - 1 || front > rear) {
      cout<<"Queue Underflow ";
      return ;
   } else {
      cout<<"Element deleted from queue is : "<< queue[front] <<endl;
      front++;;
   }
}

void Test(){
   Display();
   Insert(1);Display();
   Insert(2);Display();
   Insert(3);Display();
   Insert(4);Display();
   Delete(); Display();
   Delete(); Display();
   Insert(5);Display();
   Insert(6);Display();
   Insert(7);Display();
   Insert(8);Display();
   Delete(); Display();
}
int main() {
   queue = (int*) malloc (n*sizeof(int));
   clock_t begin = clock();
   Test();		//Aplica um teste visual
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Time Spent: " << time_spent << endl;
   free(queue);
   cout << endl;
   system("PAUSE");
}
