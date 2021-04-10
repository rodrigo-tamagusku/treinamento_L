#ifndef MLISTH_H

#define MLISTH_H

#include <stdlib.h>

#include <iostream>

//Criacao de uma hierarquia de listas ligadas.

//O elemento da lista e' um inteiro

enum Boolean{FALSE,TRUE};


class no{ //este e' o no da lista ligada, so e' usado por ela

private:

int info; //informacao

no* prox; //ponteiro para o proximo

public:

no();

no(int i,no* p);

no* get_prox(void);

void set_prox(no* p);

int get_info(void);

void set_info(int i);

no* dobra(void);

~no(void);

} ;


class lista{ //esta e' a lista ligada comum.

protected: //"visivel hierarquia abaixo"

no* primeiro; //primeiro no da lista, aqui eu insiro e removo.

public:

lista(void);

Boolean vazia(void)const;

Boolean contem(int el)const;

void insere_primeiro(int elem);

int* remove_primeiro();

void mostra()const;

~lista(void);

}; //fim classe lista


class listaultimo:public lista { //essa e a lista util para

//implementar pilhas e filas.

protected: //protected e uma opcao outra e' get_ultimo() e set_...

no* ultimo;

public:

listaultimo(void);

void insere_ultimo(int elem); //nova

void insere_primeiro(int elem); //redefinicao

int* remove_primeiro();//redefinicao

~listaultimo(void);

//as operacoes nao redefinidas sao validas.

};


class listaordenada:public lista {

//essa e' a lista comum com aprimoramentos/especializacoes

public:

listaordenada(void);

Boolean contem(int el)const;

void insere_primeiro(int elem);

//insere em ordem

int* remove_elemento(int el);

//remove elemento el se existir

~listaordenada(void);

};


#endif
