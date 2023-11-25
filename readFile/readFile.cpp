/*************************************************************
 * 1. Name:
 *    * Kevin Saunders / Kelly Payne
 * 2. Assignment Name:
 *    * Practice 05: Read and Write Files
 * 3. Assignment Description:
 *    * Write the C++ code to read the number from a file. Next, 
 * 		prompt the user for a new value.Finally, create a 
 *		function to write the new balance to the same file we 
 *		read from. 
 * 4. What was the hardest part? Be as specific as possible.
 *    * formatting the double to two decimal places. For some
 *		reason, the documentation for this was unusally hard to 
		find.
 * 5. How long did it take for you to complete the assignment?
 *    *  1 hour
 *****************************************************************/
#include <string>
#include <string.h>
#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;


/*********************************
* Read account balance from a file.
/*********************************/
double readBalance(ifstream & file)
{
	if (!file.fail())
	{

		double balance;
		file >> balance;
		return balance;

	} else {
		return 0.0;
	}
}

/***********************************
* Display given account balance.
/***********************************/
void displayBalance(double balance)
{
	cout << fixed;
	cout << setprecision(2);
	cout << "Account balance: $" << balance << endl;
	//cout << "Account balance: $" << to_string(balance) << endl;
}

/*********************************
* Update file contents.
/*********************************/
double updateBalance(double balance)
{
	double change;
	cout << "Change: $";
	cin >> change;
	cout << endl;
	return balance + change;
}

/*********************************
* Write given balance to the given file 
/*********************************/
void writeBalance(double balance, ofstream & file)
{
	if (file.fail())
		cout << "Unable to write balance to data.txt\n";
	else
		file << balance;
}

/*********************************
* Run total code to read, write, 
  and modify file contents.
/*********************************/
int main()
{
	ifstream fin;
	fin.open("data.txt");

	double balance = readBalance(fin);
	displayBalance(balance);

	fin.close();

	balance = updateBalance(balance);
	displayBalance(balance);

	ofstream fout;
	fout.open("data.txt");

	writeBalance(balance, fout);

	fout.close();
}