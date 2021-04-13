//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Implementar uma Estrutura de dados Árvore Binária.
//Nota: Ver imagem ABB.png como referência visual
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
  node *node = (struct node *)malloc(sizeof(node));
  node->data = data;
  node->left = NULL;
  node->right = NULL;
  return (node);
}

// Traverse Preorder
void traversePreOrder(node *temp) {
  if (temp != NULL) {
    cout << " " << temp->data;
    traversePreOrder(temp->left);
    traversePreOrder(temp->right);
  }
}

// Traverse Inorder
void traverseInOrder(node *temp) {
  if (temp != NULL) {
    traverseInOrder(temp->left);
    cout << " " << temp->data;
    traverseInOrder(temp->right);
  }
}

// Traverse Postorder
void traversePostOrder(node *temp) {
  if (temp != NULL) {
    traversePostOrder(temp->left);
    traversePostOrder(temp->right);
    cout << " " << temp->data;
  }
}

node* insertOrdered(node *no,int val){
   if(no==NULL){ //achei o lugar
   	  node *newNode = (node *)malloc(sizeof(node));
   	  newNode->data=val;
   	  newNode->left=NULL;
   	  newNode->right=NULL;
   	  no=newNode;
   	  return(no);
   	  cout << "Colocado " << val << endl;
   }
   else{   //procura o lugar
   	  if(no->data==val){
   	  	if(no->left==NULL){
   	  	   no->left = insertOrdered(no->left,val);
		}
		else insertOrdered(no->left,val);
	  }
	  else if(no->data>val){
	  	if(no->left==NULL){
   	  	   no->left = insertOrdered(no->left,val);
		}
		else insertOrdered(no->left,val);
	  }
	  else if(no->data<val){
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
	traversePreOrder(T->root);	//Pode ser usado para duplicar uma árvore. Cria-se um array e se insere numa árvore vazia.
}
void InOrder(Tree *T){
	traverseInOrder(T->root);	//Pode ser usado para imprimir em ordem crescente.
}
void PostOrder(Tree *T){
	traversePostOrder(T->root); //Pode ser usado para deletar a árvore, pois acessa folhas antes dos demais.
}

node* minValueNode(node* N){
   node* current = N;
   while (current && current->left != NULL)
      current = current->left;
   return current;
}
node* maxValueNode(node* N){
   node* current = N;
   while (current && current->right != NULL)
      current = current->right;
   return current;
}

node* deleteNode(node *N, int key){
	if(N==NULL){				//Se cheguei em um nulo
	   return N;				//não tem o key na subárvore
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
      if(temp==NULL){
      	temp=maxValueNode(N->left);
      	if(temp!=NULL){
      		N->data=temp->data;
      		N->left=deleteNode(N->left,temp->data);
		}
	  }
	  else{
	  N->data = temp->data;							//troco os valores
      N->right = deleteNode(N->right, temp->data);	//deleto o nó que tinha o menor valor procurado.
      }
	}
    return N;
}

void deleteValueFromTree(Tree *T, int value){
	deleteNode(T->root,value);
}

void deleteTree(Tree *T){
	cout <<"Deletando arvore" <<endl;
	while(T->root!=NULL){
		cout << "Deletado valor " << T->root->data << endl;
		T->root = deleteNode(T->root,T->root->data);
	}
}

void testTree(Tree *T){
	insertTree(T,8);
	insertTree(T,4);
	insertTree(T,2);
	cout << "\nPreorder traversal: ";
	PreOrder(T);
	cout << "\nInorder traversal: ";
	InOrder(T);
	cout << "\nPostorder traversal: ";
	PostOrder(T);
	insertTree(T,1);
	insertTree(T,3);
	insertTree(T,6);
	insertTree(T,5);
	insertTree(T,7);
	insertTree(T,12);
	insertTree(T,10);
	insertTree(T,9);
	insertTree(T,11);
	insertTree(T,14);
	insertTree(T,13);
	insertTree(T,15);
	cout << "\n\nPreorder traversal: ";
	PreOrder(T);
	cout << "\nInorder traversal: ";
	InOrder(T);
	cout << "\nPostorder traversal: ";
	PostOrder(T);
	//Aqui tem imagem de referência ABB.png
	deleteValueFromTree(T,8);
	deleteValueFromTree(T,9);
	deleteValueFromTree(T,5);
	deleteValueFromTree(T,12);
	deleteValueFromTree(T,10);
	deleteValueFromTree(T,11);
	deleteValueFromTree(T,1);
	deleteValueFromTree(T,6);
	deleteValueFromTree(T,2);
	cout << "\n\nPreorder traversal: ";
	PreOrder(T);
	cout << "\nInorder traversal: ";
	InOrder(T);
	cout << "\nPostorder traversal: ";
	PostOrder(T);
	deleteValueFromTree(T,3);
	deleteValueFromTree(T,7);
	deleteValueFromTree(T,4);
	deleteValueFromTree(T,15);
	deleteValueFromTree(T,14);
	//deleteValueFromTree(T,13);		//Nota: Remover o último dá problema. Provavelmente o T->root não fica NULL quando devia
	cout << "\n\nPreorder traversal: ";
	PreOrder(T);
	cout << "\nInorder traversal: ";
	InOrder(T);
	cout << "\nPostorder traversal: ";
	PostOrder(T);
}
int main() {
	Tree arvoreBin;
	createTree(&arvoreBin);
	testTree(&arvoreBin);
   cout << endl<<endl;
   deleteTree(&arvoreBin);
   system("PAUSE");

}
