 
#include <bits/stdc++.h>//biblioteca abstrata
#include "Lista.h"

using namespace std;
  
// Classe para implementar pilha usando Lista
class Pilha : public Lista {
public:

    // push para empurrar o elemento no topo da pilha
    // usando inserir na �ltima fun��o do Lista
    void push(int item)
    {
        insereFim(item);
    }
 
    // pop para remover o elemento no topo da pilha
    // usando remove a �ltima fun��o do Lista
    void pop()
    {
        removeFim();
    }
    
};
 
// classe para implementar a fila usando o Lista
class Queue : public Lista {
public:
    // enfileirar para inserir o elemento no final
    // usando inserir na �ltima fun��o da Lista
    void enqueue(int item) //sobrecarga de metodo
    {
        insereFim(item);
    }
 
    // Lista para remover o primeiro elemento
    // usando remove na primeira fun��o do Lista
    void dequeue() //sobrecarga de metodo
    {
        removeInicio();
    }
};

int main()
{   
    // Objeto pilha
    Pilha stk;
    // Inserindo 8, 10, 4, 5 na pilha
    stk.push(8);      //O(1) Pois o processo � direto
    stk.push(10);     //O(1) Pois o processo � direto
    stk.push(4);      //O(1) Pois o processo � direto
    stk.push(5);      //O(1) Pois o processo � direto
    cout << "Pilha: ";
    stk.exibe();      //O(n) Pois o algoritmo ser de percurso � linear simples
 
    // removendo o ultimo elemento do topo
    stk.pop();       //O(1) Pois o processo � direto
    cout << "Pilha: ";
    stk.exibe();      //O(n) Pois o algoritmo ser de percurso � linear simples
    stk.removeFim();
    stk.exibe();      //O(n) Pois o algoritmo ser de percurso � linear simples

    // Objeto fila
    Queue que;
 
    // insirerindo 8, 10, 4, 5 na fila
    que.enqueue(8);   //O(1) Pois o processo � direto
    que.enqueue(10);  //O(1) Pois o processo � direto
    que.enqueue(4);   //O(1) Pois o processo � direto
    que.enqueue(5);   //O(1) Pois o processo � direto
    cout << "Queue: ";
    que.exibe();     //O(n) Pois o algoritmo ser de percurso simples
 
    // deleta um elemento da fila
    que.dequeue();  //O(1) Pois o processo � direto
    cout << "Queue: ";
    que.exibe();    //O(n) Pois o algoritmo ser de percurso � linear simples
 
    cout << "O tamanho da pilha e: " << stk.contNo() << endl; //O(n) posso alterar para O(1) por�m perco em complexidade espacial!
    cout << "O tamanho da filha e: " << que.contNo() << endl; //O(n) posso alterar para O(1) por�m perco em complexidade espacial!

    return 0;
}
