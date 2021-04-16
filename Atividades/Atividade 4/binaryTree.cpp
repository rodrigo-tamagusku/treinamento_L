//Rodrigo Minoru Tamagusku
//rodrigo.tamagusku@gmail.com

//Objetivo: Implementar uma Estrutura de dados �rvore Bin�ria.
//Nota: Ver imagem ABB.png como refer�ncia visual
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

void createTree(Tree *T){
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
	traversePreOrder(T->root);	//Pode ser usado para duplicar uma �rvore. Cria-se um array e se insere numa �rvore vazia.
}
void InOrder(Tree *T){
	traverseInOrder(T->root);	//Pode ser usado para imprimir em ordem crescente.
}
void PostOrder(Tree *T){
	traversePostOrder(T->root); //Pode ser usado para deletar a �rvore, pois acessa folhas antes dos demais.
}

node* minValueNode(node* N){				//O(log n)
   node* current = N;
   while (current && current->left != NULL)
      current = current->left;
   return current;
}
node* maxValueNode(node* N){				//O(log n)
   node* current = N;
   while (current && current->right != NULL)
      current = current->right;
   return current;
}

node* deleteNode(node *N, int key){
	if(N==NULL){
		return N;
	}
	if(key < N->data){						//se n� atual tem valor maior
		N->left = deleteNode(N->left,key);	//procuro na esquerda
	}else if(key > N->data){		
		N->right = deleteNode(N->right,key);
	}else {									//key == N->data, achei o valor
		if(N->left==NULL){					//n�o h� sub-arvore � esquerda. Inclui o caso de N ser folha.
			node *temp = N->right;			
	        free(N);
	        N=NULL;
	        return temp;
		}
		else if(N->right==NULL){			//n�o h� sub-arvore a direita.
			node *temp = N->left;			
	        free(N);
	        N=NULL;
	        return temp;
		}									//caso que h� duas sub-arvores
		node *temp=N->right;				//Vou procurar � direita o menor valor de n�
		if(temp->left==NULL){				//esse primeiro n� � o menor
			N->right=temp->right;			//penduro o restante da sub-�rvore adequadamente
		}
		else {
			node *hold;						//hold tem o papel de n� exatamente anterior ao temp
			while(temp->left!=NULL){		//caminho at� achar o n� que n�o tem filho � esquerda. Significa que � o menor n� da sub�rvore de N->right
				hold = temp;
				temp=temp->left;
			}								//achei o menor valor temp
			hold->left=temp->right;			// quando eu removo temp, eu quero pendurar a sua �nica sub-�rvore(que � temp-> right) no hold.
		}
		temp->left=N->left;
		temp->right=N->right;
		free(N);
		return temp;						//retorno o n� temp que � "o novo N"
	}
}

node* deleteNode_old(node *N, int key){
	if(N==NULL){				//Se cheguei em um nulo
	   return N;				//n�o tem o key na sub�rvore
	}
    if (key < N->data)							//Se meu n� atual � maior que key, procuro key na sub�rvore � esquerda
         N->left = deleteNode(N->left, key);
    else if (key > N->data)					//Se meu n� atual � menor que key, procuro key na sub�rvore � direita
         	N->right = deleteNode(N->right, key);
	    else{										//Se achei o n� N com key
	      if (N->left == NULL){						//Se achei o n� N com key, e ele n�o tem esquerda
			 node *temp = N->right;					//Reconstruo a sub�rvore sem problemas
	         free(N);
	         N=NULL;
	         return temp;
	      }
	      else if (N->right == NULL){				//Se achei o n� N com key, e ele n�o tem direita
			 node *temp = N->left;					//Reconstruo a sub�rvore sem problemas
	         free(N);
	         N=NULL;
	         return temp;
	      }											//Achei o n� N com key, mas ele tem as duas sub�rvore esquerda e direita n�o nulas
	      node* temp = minValueNode(N->right);		//Escolho olhar na direita. Busco o n� que tem o menor valor pra pendurar no lugar.
	      if(temp==NULL){							//Se n�o h� sub-�rvore na direita
	      	temp=maxValueNode(N->left);				//Procuro um n� na esquerda se n�o tiver nada na direita
	      	if(temp!=NULL){
	      		N->data=temp->data;
	      		N->left=deleteNode(N->left,temp->data);
			}
		  }
		  else{
			  N->data = temp->data;							//troco os valores
		      N->right = deleteNode(N->right, temp->data);	//deleto o n� que tinha o menor valor procurado.
	      }
		}
    return N;
}

void deleteValueFromTree(Tree *T, int value){
	if(T->root->data==value){
		T->root=deleteNode(T->root,value);
	}
	else deleteNode(T->root,value);
}

void deleteNodePostOrder(node* temp){
	if(temp!=NULL){
	    deleteNodePostOrder(temp->left);
    	deleteNodePostOrder(temp->right);
    	//cout << " delete " << temp->data;
    	free(temp);
    	temp=NULL;
	}
}
void deleteTree(Tree *T){
	deleteNodePostOrder(T->root);				 //M�todo O(n)
	T->root=NULL;
	/*										     //M�todo O(n log n)
	cout << endl <<"Deletando arvore" <<endl;
	while(T->root!=NULL){	//repete remo��o de raiz
		cout << "Deletado valor " << T->root->data << endl;
		T->root = deleteNode(T->root,T->root->data);
	}
	*/
}

int getInt(){
	int n;
	cin >> n;
	while (cin.fail()){
		cout << "Valor invalido. Digite um numero inteiro: ";
		while(cin.fail()){
			cin.clear();
			cin.ignore();
			cin >> n;
		}
	}
	return n;
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
	//Aqui tem imagem de refer�ncia ABB.png
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
	//deleteValueFromTree(T,14);
	//deleteValueFromTree(T,13);		//Nota: Remover o �ltimo d� problema. Provavelmente o T->root n�o fica NULL quando devia
	cout << "\n\nPreorder traversal: ";
	PreOrder(T);
	cout << "\nInorder traversal: ";
	InOrder(T);
	cout << "\nPostorder traversal: ";
	PostOrder(T);
}

int main() {
	int option=0,n=0;
	Tree arvoreBin;
	createTree(&arvoreBin);
	do{
	   cout << "Escolha como usar a arvore binaria: " << endl;
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
		      for(int i = 0; i<n; i++) {
		      	 insertTree(&arvoreBin,getInt());
		      }
		      cout << "\n\nPreorder traversal: ";
	   		  PreOrder(&arvoreBin);
			  cout << "\nInorder traversal: ";
			  InOrder(&arvoreBin);
		 	  cout << "\nPostorder traversal: ";
			  PostOrder(&arvoreBin);
			  deleteTree(&arvoreBin);
   		      cout << endl <<endl;
			  break;
		   case 2:
			  testTree(&arvoreBin);
 			  cout << endl<<endl;
			  deleteTree(&arvoreBin);
		   	  break;		   	  
		   default:
		   	  option=0;
	   }
   } while(option!=0);
   system("PAUSE");

}
