#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;
void display(int *array, int size) {
   for(int i = 0; i<size; i++){
      cout << array[i] << " ";
      if(i >= 10-1){
      	break;
	  }
  	  cout << endl;
	}
}
void insertionSort(int *array, int size) {
   int key, j;
   //considero primeiro item já ordenado, logo usa-se i=1 em vez de i=0
   for(int i = 1; i<size; i++) {
      key = array[i];//take value
      j = i;
      while(array[j-1]>key && j > 0) { // Achei o lugar de key?
         array[j] = array[j-1];
         j--;
      }
      array[j] = key;   //insert in right place
   }
}
int main() {
   //srand (time(NULL));
   int n;
   //cout << "Enter the number of elements: ";
   //cin >> n;
   n = 11;
   int *arr;     //create an array with given number of elements
   arr = (int*) malloc (n*sizeof(int));
   //cout << "Enter elements:" << endl;
   for(int i = 0; i<n; i++) {
      arr[i] = rand()%n;
   }
   //system("PAUSE");
   cout << "Array before Sorting: " << endl;
   display(arr, n);
	clock_t begin = clock();
   insertionSort(arr, n);
   	clock_t end = clock();
	double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Array after Sorting: " << endl;
   display(arr, n);
   cout << endl << "Time Spent: " << time_spent << endl;
   free(arr);
}
