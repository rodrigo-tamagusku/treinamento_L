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
      Display();
   }
}
void Delete() {
   if (front == - 1 || front > rear) {
      cout<<"Queue Underflow ";
      return ;
   } else {
      cout<<"Element deleted from queue is : "<< queue[front] <<endl;
      front++;;
      Display();
   }
}
int main() {
   //srand (time(NULL));
   //system("PAUSE");
   queue = (int*) malloc (n*sizeof(int));
   clock_t begin = clock();
   //cout << "Queue before Sorting: " << endl;
   Display();
   Insert(1);
   Insert(2);
   Insert(3);
   Insert(4);
   Delete();
   Delete();
   Insert(5);
   Insert(6);
   Insert(7);
   Insert(8);	
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   //cout << endl << "Queue after Sorting: " << endl;
   cout << endl << "Time Spent: " << time_spent << endl;
   free(queue);
}
