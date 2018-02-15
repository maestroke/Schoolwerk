// LesOpgave4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Stack.h"
#include "BinarySearchTree.h"

void StackTest();
void BSTTest();

void StackStressTest();
void BSTStressTest();

int main() {
	//StackTest();
	//BSTTest();

	//StackStressTest();
	//BSTStressTest();

	return 0;
}

void StackTest() {
	cout << "Stack: " << endl;
	Stack *stack = new Stack();

	stack->push(5);
	stack->push(10);
	stack->push(3);
	stack->push(8);

	stack->print();

	cout << "Stacksize = " << stack->size() << endl;
	cout << "Stacksum = " << stack->sum() << endl;
}

void BSTTest() {
	cout << "BinarySearchTree:" << endl;

	BinarySearchTree* tree = new BinarySearchTree();

	tree->insert(4);
	tree->insert(2);
	tree->insert(6);
	tree->insert(1);
	tree->insert(3);

	cout << "Treedepth = " << tree->depth() << endl;
	cout << "Tree has node 4 = " << tree->is_present(4) << endl;
	cout << "Tree has node 5 = " << tree->is_present(5) << endl;
	cout << "Tree in order:" << endl;
	tree->travers();
	cout << "Tree:" << endl;
	tree->print();
}

void StackStressTest() {
	cout << "Stack Stress Test" << endl;

	Stack *stack = new Stack();

	for (int i = 0; i < 2500; i++)
		stack->push(i);

	cout << "Press a key to delete the stack" << endl;
	
	char c;
	cin >> c;

	delete stack;
}

void BSTStressTest() {
	cout << "BinarySearchTree Stress Test:" << endl;

	BinarySearchTree* tree = new BinarySearchTree();

	for (int i = 0; i < 2500; i++)
		tree->insert(i);

	cout << "Press a key to delete the tree" << endl;

	char c;
	cin >> c;

	delete tree;
}
