// LesOpgave4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Stack.h"
#include "BinarySearchTree.h"
#include "Fraction.h"

void StackTest();
void BSTTest();
void DummyTest();
void BoxTest();
void FractionTest();

void StackStressTest();
void BSTStressTest();

class dummy {
	// FUNCTIONS
public:
	dummy(int d) {
		x = d;
	}

	dummy(int a, int b) {
		x = a;
		*y = b;
	}

	dummy() {}

	dummy(const dummy &dummy2) {
		x = dummy2.x;
		y = new int(*dummy2.y);
	}



	~dummy() {
		if (y != NULL) {
			delete y;
			y = NULL;
		}
	}

	// VARIABLES
public:
	int x;
	int *y;
};

class Box {
public:
	double getVolume(void) { return this->length * this->breadth * this->height; }
	void setLength(double len) { this->length = len; }
	void setBreadth(double bre) { this->breadth = bre; }
	void seTHeight(double hei) { this->height = hei; }

	Box Add(const Box &b) {
		Box box;
		box.length = this->length + b.length;
		box.breadth = this->breadth + b.breadth;
		box.height = this->height + b.height;
		return box;
	}

	Box Mutliply(int f) {
		this->height *= f;
		return *this;
	}

	Box operator *(const double &b) {
		Box c;

		c.height = this->height * b;
		c.length = this->length * b;
		c.breadth = this->breadth * b;

		return c;
	}

	Box() {}

	Box(double a, double b, double c) {
		length = a;
		breadth = b;
		height = c;
	}

	Box& operator= (const Box &b) {
		if (&b != this) {
			length = b.length;
			breadth = b.breadth;
			height = b.height;
		}
		return *this;
	}

	double length, breadth, height;
};

int main() {
	//StackTest();
	//BSTTest();
	//DummyTest();
	//BoxTest();
	FractionTest();

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

	cout << "Popping the stack: " << stack->pop() << endl;

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

void DummyTest() {
	dummy a;

	a.x = 2;
	a.y = new int(3);
	{
		dummy b(a);
		cout << a.x << " " << *a.y << " - " << &a << endl;
		cout << b.x << " " << *b.y << " - " << &b << endl << endl;
		a.x = 5;
		cout << a.x << " " << *a.y << " - " << &a << endl;
		cout << b.x << " " << *b.y << " - " << &b << endl << endl;
		*a.y = 8;
		cout << a.x << " " << *a.y << " - " << &a << endl;
		cout << b.x << " " << *b.y << " - " << &b << endl << endl;
	}
	cout << a.x << " " << *a.y << " - " << &a << endl;
}

void BoxTest() {
	Box b(2, 3, 4);

	cout << b.height << endl;

	//b.Mutliply(4);

	Box c = b * 4;

	cout << c.height << endl;
}

void FractionTest() {
	Fraction a(3, 5);

	Fraction b(2, 4);

	Fraction c = a - b;

	cout << c.getNom() << "/" << c.getDenom() << endl << endl;

	Fraction d = c / 5;

	cout << d.getNom() << "/" << d.getDenom() << endl;
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
