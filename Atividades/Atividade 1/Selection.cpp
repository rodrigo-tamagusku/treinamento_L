//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar um algoritmo Selection Sort.
#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;
void swapping(int &a, int &b) {         //swap the content of a and b
   int temp;
   temp = a;
   a = b;
   b = temp;
}
void display(int *array, int size) { 	//only 10 first
   for(int i = 0; i<size; i++){
      cout << array[i] << " ";
      if(i >= 10-1){
      	break;
	  }
	}
}
void selectionSort(int *array, int size) {
   int i, j, imin;
   for(i = 0; i<size-1; i++) {
      imin = i;   //get index of minimum data
      for(j = i+1; j<size; j++)		// não importa melhor e pior caso
         if(array[j] < array[imin]) // Acho um novo menor
            imin = j;
         //placing in correct position
         swap(array[i], array[imin]);
   }
}

int main() {
   int n;
   n = 10000;
   int *arr;     //create an array with given number of elements
   arr = (int*) malloc (n*sizeof(int));
   for(int i = 0; i<n; i++) {
      arr[i] = rand()%n;
   }
   cout << "Array before Sorting: " << endl;
   display(arr, n);  
   clock_t begin = clock();
   selectionSort(arr, n);
   clock_t end = clock();
   double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Array after Sorting: " << endl;
   display(arr, n);
   cout << endl << "Time Spent: " << time_spent << endl;
   free(arr);
   cout << endl;
   system("PAUSE");
}
