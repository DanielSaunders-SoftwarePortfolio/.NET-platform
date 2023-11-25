/*************************************************************
 * 1. Name:
 *    *  Daniel (Kevin) Saunders
 * 2. Assignment Name:
 *    *  Lab 01: Hello World
 * 3. Assignment Description:
 *    *  A simple program to display a message on the screen
 * 4. What was the hardest part? Be as specific as possible.
 *    *  Very easy assignment. I'm not a fan of the way this IDE 
 *       But other than that, no issues.
 * 5. How long did it take for you to complete the assignment?
 *    *  25 minutes.
 *****************************************************************/
#include <iostream>
using namespace std;

template <class T>
T myMax(T one, T two)
{
	if (one > two) return one;
	else return two;
}

class Stack {
public:
	Stack() : numElements(0) {}
	// Add an element to the stack
	void push(double value)
	{
		if (numElements < 10) data[numElements++] = value;
	}

// Remove an element from the stack 
	void pop()
	{
		if (numElements) numElements--;
	}

// Retrieve the top-most element 
	double top()
	{
		if (numElements) return data[numElements - 1];
		return -1.0;
	}

private:
	double data[10]; int numElements;
};



/**********************************************************************
* Hello world on the screen
***********************************************************************/
int main()
{
	// display
	cout << myMax(12, 22) << endl;
	cout << myMax(12.0, 2.0) << endl;
	cout << myMax("12 A", "2 AA") << endl;
}
