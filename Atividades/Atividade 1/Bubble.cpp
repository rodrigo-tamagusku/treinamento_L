//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar um algoritmo Bubble Sort.
#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;
void swapping(int &a, int &b) {      //swap the content of a and b
   int temp;
   temp = a;
   a = b;
   b = temp;
}
void display(int *array, int size) { //only 10 first
   for(int i = 0; i<size; i++){
      cout << array[i] << " ";
      if(i >= 10-1){
      	break;
	  }
	}
}
void bubbleSort(int *array, int size) {
   for(int i = 0; i<size; i++) {
      int swaps = 0;         //flag to detect any swap is there or not
      for(int j = 0; j<size-i-1; j++) {
         if(array[j] > array[j+1]) {       //when the current item is bigger than next
            swapping(array[j], array[j+1]);
            swaps = 1;    //set swap flag
         }
      }
      if(!swaps)
         break;       // No swap in this pass, so array is sorted
   }
}
int main() {
   int n;
   n = 10000;
   int *arr;    			 //create an array with given number of elements
   arr = (int*) malloc (n*sizeof(int));
   for(int i = 0; i<n; i++) {
      arr[i] = rand()%n;	//random numbers 0 to n
   }
   cout << "Array before Sorting: " << endl;
   display(arr, n);
	clock_t begin = clock();
   bubbleSort(arr, n);
   	clock_t end = clock();
	double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Array after Sorting: " << endl;
   display(arr, n);
   cout << endl << "Time Spent: " << time_spent << endl;
   free(arr);
   cout << endl;
   system("PAUSE");
}
