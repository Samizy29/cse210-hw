using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letterGrade = "";
        string gradesign = ""; 

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Determine the sign of the letter grade
       if (letterGrade != "A" && letterGrade != "F") // No "+" or "-" for A or F
        {
            int lastDigit = gradePercentage % 10;

            if (lastDigit >= 7)
            {
                gradesign = "+";
            }
            else if (lastDigit < 3)
            {
                gradesign = "-";
            }
        }

        // handle the special case for A
        if (letterGrade == "A" && gradePercentage < 93)
        {
            gradesign = "-";
        }

        // handle the special case for F (no "+" or "-")
        if (letterGrade == "F")
        {
            gradesign = "";
        }

        Console.WriteLine($"Your letter grade is {letterGrade}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course.");
        }
    }
}