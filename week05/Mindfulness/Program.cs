using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => new Activity("Invalid", "", 0)
            };

            if (activity == null) break;
            if (activity.Name != "Invalid")
                activity.Run();
            else
                Console.WriteLine("Invalid selection. Try again.");
        }
    }

    // Enhancement:
    // This program includes a spinner animation, a countdown timer,
    // and a performance tracker for the Listing activity.
    // Exceeds core requirements.
}
