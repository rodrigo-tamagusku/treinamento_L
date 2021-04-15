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
	   cout << "Escolha como usar o Insertion Sort: " << endl;
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
		      selectionSort(arr, n);
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
			   selectionSort(arr, n);
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
