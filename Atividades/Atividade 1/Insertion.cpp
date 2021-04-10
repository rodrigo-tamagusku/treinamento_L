//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar um algoritmo Insertion Sort.
#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;
void display(int *array, int size) {	//only 10 first
   for(int i = 0; i<size; i++){
      cout << array[i] << " ";
      if(i >= 10-1){
      	break;
	  }
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
   n = 100;
   int *arr;     //create an array with given number of elements
   arr = (int*) malloc (n*sizeof(int));
   for(int i = 0; i<n; i++) {
      arr[i] = rand()%n;		//random numbers 0 to n
   }
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
