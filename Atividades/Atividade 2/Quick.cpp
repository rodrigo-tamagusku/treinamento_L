//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar um algoritmo Quick Sort.
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

void quickSort(int *array, int left, int right) {	//O(n log n)
   int q;

   if(left < right) {
      q = partition(array, left, right);
      quickSort(array, left, q-1);    //sort left sub-array
      quickSort(array, q+1, right);   //sort right sub-array
   }
}

int getInt(){
	int n;
	cin >> n;
	while (cin.fail()){
		cout << "Valor invalido. Digite um numero inteiro: " << endl;
		while(cin.fail()){	 //ciclo pra limpar string
			cin.clear();
			cin.ignore();
			cin >> n;
		}
	}
	return n;
}

int main() {
   int n;
   int option=0;
   int *arr;    			 //create an array with given number of elements
   do{
	   cout << "Escolha como usar o Merge Sort: " << endl;
	   cout << "   1 - Entrar com dados manuais" << endl;
	   cout << "   2 - Testar exemplo automatico " << endl;
	   //cout << "   3 - ?" << endl;
	   cout << "   0 - Sair " << endl;
	   //cin >> option;
	   option = getInt();
	   system("CLS");
	   switch(option){
	   	   case 1:
			  cout << "Entre com a quantidade de elementos: ";
			  n = getInt();
			  cout << "Entre com elementos: " << endl;
			  arr = (int*) malloc (n*sizeof(int));
		      for(int i = 0; i<n; i++) {
		      	 arr[i]=getInt();
		         //cin >> arr[i];
		      }
		      cout << "Array before Sorting: " << endl;
		      display(arr, n);
		      quickSort(arr,  0, n-1);
   		      cout << endl << "Array after Sorting: " << endl;
   		      display(arr, n);
   		      cout << endl <<endl;
			  break;
		   case 2:
			   n = 1000;
		   	   arr = (int*) malloc (n*sizeof(int));
			   for(int i = 0; i<n; i++) {
			      arr[i] = rand()%n;	//random numbers 0 to n
			   }
			   cout << "Array before Sorting: " << endl;
			   display(arr, n);
			   quickSort(arr, 0, n-1);
			   cout << endl << "Array after Sorting: " << endl;
			   display(arr, n);
			   free(arr);
			   cout << endl <<endl;
		   	  break;		   	  
		   default:
		   	  option=0;
	   }
   } while(option!=0);
   system("PAUSE");
}
