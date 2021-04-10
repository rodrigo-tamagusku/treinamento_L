#include <stdlib.h>
#include <iostream>

using namespace std;

struct node {
  int data;
  struct node *left;
  struct node *right;
};

struct Tree{
  struct node *root;
};

void createTree(struct Tree *T){
	T->root=NULL;
}

// New node creation
struct node *newNode(int data) {
  struct node *node = (struct node *)malloc(sizeof(struct node));
  node->data = data;
  node->left = NULL;
  node->right = NULL;
  return (node);
}

// Traverse Preorder
void traversePreOrder(struct node *temp) {
  if (temp != NULL) {
    cout << " " << temp->data;
    traversePreOrder(temp->left);
    traversePreOrder(temp->right);
  }
}

// Traverse Inorder
void traverseInOrder(struct node *temp) {
  if (temp != NULL) {
    traverseInOrder(temp->left);
    cout << " " << temp->data;
    traverseInOrder(temp->right);
  }
}

// Traverse Postorder
void traversePostOrder(struct node *temp) {
  if (temp != NULL) {
    traversePostOrder(temp->left);
    traversePostOrder(temp->right);
    cout << " " << temp->data;
  }
}

node* insertOrdered(node *no,int val){
   if(no==NULL){ //achei o lugar
   	  struct node *newNode = (struct node *)malloc(sizeof(struct node));
   	  newNode->data=val;
   	  newNode->left=NULL;
   	  newNode->right=NULL;
   	  no=newNode;
   	  return(no);
   	  cout << "Colocado " << val << endl;
   }
   else{   //procura o lugar
   	  if(no->data==val){
   	  	//cout << no->data << " Igual que " << val << endl;
   	  	if(no->left==NULL){
   	  	   no->left = insertOrdered(no->left,val);
		}
		else insertOrdered(no->left,val);
	  }
	  else if(no->data>val){
	  	//cout << no->data << " Maior que " << val << endl;
	  	if(no->left==NULL){
   	  	   no->left = insertOrdered(no->left,val);
		}
		else insertOrdered(no->left,val);
	  }
	  else if(no->data<val){
	    //cout << no->data << " Menor que " << val << endl;
	    if(no->right==NULL){
   	  	   no->right = insertOrdered(no->right,val);
		}
		else insertOrdered(no->right,val);
	  }
   }
}

void insertTree(Tree *T,int val){
	if(T->root==NULL){
		T->root=insertOrdered(T->root,val);
	}
	else insertOrdered(T->root,val);
}

void PreOrder(Tree *T){
	traversePreOrder(T->root);
}
void InOrder(Tree *T){
	traverseInOrder(T->root);
}
void PostOrder(Tree *T){
	traversePostOrder(T->root);
}

node* minValueNode(struct node* N){
   struct node* current = N;
   while (current && current->left != NULL)
      current = current->left;
   return current;
}

node* deleteNode(node *N, int key){
	if(N==NULL){	//não tem o key na subárvore
	   return N;
	}
    if (key < N->data)							//Se meu nó atual é maior que key, procuro key na subárvore à esquerda
         N->left = deleteNode(N->left, key);
      else if (key > N->data)					//Se meu nó atual é menor que key, procuro key na subárvore à direita
         N->right = deleteNode(N->right, key);
    else{										//Se achei o nó N com key
      if (N->left == NULL){						//Se achei o nó N com key, e ele não tem esquerda
         node *temp = N->right;					//Reconstruo a subárvore sem problemas
         free(N);
         N=NULL;
         return temp;
      }
      else if (N->right == NULL){				//Se achei o nó N com key, e ele não tem direita
         node *temp = N->left;					//Reconstruo a subárvore sem problemas
         free(N);
         N=NULL;
         return temp;
      }											//Achei o nó N com key, mas ele tem as duas subárvore esquerda e direita não nulas
      node* temp = minValueNode(N->right);		//Escolho olhar na direita. Busco o nó que tem o menor valor pra pendurar no lugar.
      N->data = temp->data;							//troco os valores
      N->right = deleteNode(N->right, temp->data);	//deleto o nó que tinha o menor valor procurado.
    }
    return N;
}

void deleteValueFromTree(Tree *T, int value){
	deleteNode(T->root,value);
}

int main() {
	Tree arvoreBin;
	createTree(&arvoreBin);
	insertTree(&arvoreBin,8);
	insertTree(&arvoreBin,4);
	insertTree(&arvoreBin,2);
	insertTree(&arvoreBin,1);
	insertTree(&arvoreBin,3);
	insertTree(&arvoreBin,6);
	insertTree(&arvoreBin,5);
	insertTree(&arvoreBin,7);
	insertTree(&arvoreBin,12);
	insertTree(&arvoreBin,10);
	insertTree(&arvoreBin,9);
	insertTree(&arvoreBin,11);
	insertTree(&arvoreBin,14);
	insertTree(&arvoreBin,13);
	insertTree(&arvoreBin,15);
	deleteValueFromTree(&arvoreBin,8);
	deleteValueFromTree(&arvoreBin,9);
	//deleteValueFromTree(&arvoreBin,5);
	cout << "preorder traversal: ";
	PreOrder(&arvoreBin);
	cout << "\nInorder traversal: ";
	InOrder(&arvoreBin);
	cout << "\nPostorder traversal: ";
	PostOrder(&arvoreBin);

}
