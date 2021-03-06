// Oefentoets.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "BinarySearchTree.h"


int main() {
	BST<int> tree = BST<int>();

	tree.insert(6);
	tree.insert(8);
	tree.insert(1);
	tree.insert(4);
	tree.insert(3);
	tree.insert(6);
	tree.insert(9);
	tree.insert(10);

	tree.traverse();

	BST<double> tree2 = BST<double>();
	
	tree2.insert(3.4);
	tree2.insert(8.4);
	tree2.insert(9.1);
	tree2.insert(8.3);
	tree2.insert(0.9);
	tree2.insert(6.3);
	tree2.insert(3.4);
	tree2.insert(5.4);

	tree2.traverse();

	BST<char> tree3 = BST<char>();

	tree3.insert('c');
	tree3.insert('a');
	tree3.insert('y');
	tree3.insert('c');

	tree3.traverse();


	return 0;
}

