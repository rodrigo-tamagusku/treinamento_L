#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;

void swapping(int &a, int &b) { //swap the content of a and b
   int temp;
   temp = a;
   a = b;
   b = temp;
}

void display(int *array, int size) {
   for(int i = 0; i<size; i++){
      cout << array[i] << " ";
      if(i >= 10-1){
      	break;
	  }
  	  //cout << endl;
	}
}

int partition(int *array, int lower, int upper) {
   //Hoare partitioning technique to find correct location for pivot
   int pivot, start, end;
   pivot = array[lower];      //first element as pivot
   start = lower; end = upper;

   while(start < end) {
      while(array[start] <= pivot && start<end) {
         start++;      //start pointer moves to right
      }

      while(array[end] > pivot) {
         end--;      //end pointer moves to left
      }

      if(start < end) {
         swap(array[start], array[end]); //swap smaller and bigger element
      }
   }

   array[lower] = array[end];
   array[end] = pivot;
   return end;
}

void quickSort(int *array, int left, int right) {
   int q;

   if(left < right) {
      q = partition(array, left, right);
      quickSort(array, left, q-1);    //sort left sub-array
      quickSort(array, q+1, right);   //sort right sub-array
   }
}

int main() {
    //srand (time(NULL));
   int n;
   //cout << "Enter the number of elements: ";
   //cin >> n;
   n = 1000;
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
	quickSort(arr, 0, n-1); //(n-1) for last index
   	clock_t end = clock();
	double time_spent = (double)(end - begin) / CLOCKS_PER_SEC;
   cout << endl << "Array after Sorting: " << endl;
   display(arr, n);
   cout << endl << "Time Spent: " << time_spent << endl;
   free(arr);
}
