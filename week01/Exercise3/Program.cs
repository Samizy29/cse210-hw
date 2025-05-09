using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number that is always odd
            Random randomGenerator = new Random();
            int magicNumber;
            do
            {
                magicNumber = randomGenerator.Next(1, 101); // Generates a number between 1 and 100
            } while (magicNumber % 2 == 0); // Ensure the number is odd

            int guess = -1;
            int guessCount = 0; // Counter for the number of guesses
            const int maxAttempts = 5; // Maximum number of attempts allowed

            Console.WriteLine("Welcome to the Magic Number Game!");
            Console.WriteLine($"You have {maxAttempts} attempts to guess the magic number.");

            while (guess != magicNumber && guessCount < maxAttempts)
            {
                Console.Write("Guess the magic number (1-100): ");
                string input = Console.ReadLine();

                // Input validation
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 100.");
                    continue;
                }

                guessCount++; // Increment the guess counter

                if (guess < magicNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Too high!");
                }

                if (guessCount == maxAttempts && guess != magicNumber)
                {
                    Console.WriteLine("You've reached the maximum number of attempts!");
                    break;
                }
            }

            if (guess == magicNumber)
            {
                Console.WriteLine($"Congratulations! You guessed it in {guessCount} attempts!");
            }
            else
            {
                Console.WriteLine($"Sorry, you couldn't guess the magic number. It was {magicNumber}.");
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thank you for playing! Goodbye!");
    }
}