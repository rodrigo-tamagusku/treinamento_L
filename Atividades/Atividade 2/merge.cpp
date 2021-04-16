//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Criar e testar um algoritmo Merge Sort.
#include<iostream>
#include <algorithm>
#include<time.h>

using namespace std;

void swapping(int &a, int &b) {     //swap the content of a and b
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
void merge(int *array, int l, int m, int r) {
   int i, j, k, nl, nr;
   //size of left and right sub-arrays
   nl = m-l+1; nr = r-m;
   int larr[nl], rarr[nr];
   //fill left and right sub-arrays
   for(i = 0; i<nl; i++)
      larr[i] = array[l+i];
   for(j = 0; j<nr; j++)
      rarr[j] = array[m+1+j];
   i = 0; j = 0; k = l;
   //merge temp arrays to real array
   while(i < nl && j<nr) {
      if(larr[i] <= rarr[j]) {
         array[k] = larr[i];
         i++;
      }else{
         array[k] = rarr[j];
         j++;
      }
      k++;
   }
   while(i<nl) {       //extra element in left array
      array[k] = larr[i];
      i++; k++;
   }
   while(j<nr) {     //extra element in right array
      array[k] = rarr[j];
      j++; k++;
   }
}
void mergeSort(int *array, int l, int r) {	//O(n log n) no pior, melhor e médio caso
   int m;
   if(l < r) {
      int m = l+(r-l)/2;
      // Sort first and second arrays
      mergeSort(array, l, m);
      mergeSort(array, m+1, r);
      merge(array, l, m, r);
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
		      mergeSort(arr,  0, n-1);
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
			   mergeSort(arr, 0, n-1);
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
