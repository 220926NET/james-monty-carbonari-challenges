//method to get the first number from the user, and converts it from a string to a 32 bit integer before returning it
static int getNum1()
{
    System.Console.WriteLine("Enter a number");
    string? num = Console.ReadLine();
    int.TryParse(num, out int num1);
    return num1;
}
//method to get the second number from the user, and converts it from a string to a 32 bit integer before returning it
static int getNum2()
{
    System.Console.WriteLine("Enter a number larger than the first number you entered.");
    string? num = Console.ReadLine();
    int.TryParse(num, out int num2);
    return num2;
}

//method to get the number of outputs per line to print from the user, and converts it from a string to a 32 bit integer before returning it
static int getPerLine()
{
    System.Console.WriteLine("How many numbers should print per line? Enter a number between 5 and 30, inclusive.");
    string? num = Console.ReadLine();
    int.TryParse(num, out int perLine);
    return perLine;
}

// instantiates the integer variables by setting them to 0, and making sure they are in the correct scope for later use
int num1 = 0;
int num2 = 0;
int num3 = 0;
int perLine = 0;
int lineIterator = 0;
int iterator = 0;

int sweetCount = 0;
int saltyCount = 0;
int sweetNSaltyCount = 0;


//checks that num2 is larger than num1 but not by more than 1000 digits, looping itself if the user gives invalid input, 
//and also giving them an error message based on the state of the integer variables

do
{
    //Sets the method inputs to the integer variables
    num1 = getNum1();
    num2 = getNum2();
    //Prints a message telling the user the reason we're asking them to input those numbers again
    if (num2 > num1 + 1000)
    { System.Console.WriteLine("I'm sorry, that number was more than 1000 larger than the first number, please try again."); }
    else if (num2 < num1) { System.Console.WriteLine("I'm sorry, that number was smaller than the first number, please try again."); }
    // set num3 to be equal to num1 so we can preserve num1 after adding to its integer variable
    num3 = num1;
} while (num2 < num1 || num2 > num1 + 1000);

// perLine starts at 0, so the condition in the while loop is already met, as it is less than 5
// this while loop checks if the integer variable perLine is less than 5 or more than 30
// rerunning the request for input until the user inputs a valid number
while (5 > perLine || perLine > 30)
{
    //Sets the method input to the integer variables
    perLine = getPerLine();
    //Prints a message telling the user the reason we're asking them to input that number again
    if (5 > perLine)
    { System.Console.WriteLine("I'm sorry, that number less than 5, please try again."); }
    else if (perLine > 30) { System.Console.WriteLine("I'm sorry, that number was more than 30, please try again."); }
}

//Logic for printing Salty, Sweet, or Sweet'nSalty
//setting the iterator to equal the difference between the numbers, minus plus one for the final step
iterator = (num2 - (num1 - 1));

// Checks that the iterator has not hit 0, breaking out of the loop once it does
while (iterator > 0)
{
    // checks that the line iterator has not hit 0, breaking out of this loop once it has
    while (lineIterator > 0)
    {
        // check if the number is equally divisible to 3 and 5 first, 
        // prints to the line, and bumping up the counter
        if (num3 % 3 == 0 && num3 % 5 == 0)
        { Console.Write("Sweet'nSalty "); sweetNSaltyCount++; }
        else
        {
            // in the case of the first check being negative, we check if the number is divisible by 3, then 5, 
            // bumping the appropriate counters, and printing the appropriate messages
            if (num3 % 3 == 0)
            { Console.Write("Salty "); saltyCount++; }
            else if (num3 % 5 == 0)
            { Console.Write("Sweet "); sweetCount++; }
            else
            { Console.Write("{0} ", num3); }
        }
        // bumps the iterators in the appropriate direction
        lineIterator--;
        num3++;
        iterator--;
    }
    // Adds a line break once the line count iterator ticks over
    System.Console.Write("\r\n");
    // resets the line count iterator
    lineIterator = perLine;
}

// prints the counter returns
System.Console.WriteLine("");
System.Console.WriteLine("Sweet count {0}", sweetCount);
System.Console.WriteLine("Salty count {0}", saltyCount);
System.Console.WriteLine("Sweet'NSalty count {0}", sweetNSaltyCount);

// checks used earlier in production
System.Console.WriteLine("Num1 {0}", num1);
System.Console.WriteLine("Num2 {0}", num2);
System.Console.WriteLine("Numbers Per Line {0}", perLine);