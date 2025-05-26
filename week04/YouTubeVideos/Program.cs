using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        var video1 = new Video("Intro to C#", "Code Guru", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Loved the examples."));
        video1.AddComment(new Comment("Clara", "This helped a lot."));

        // Video 2
        var video2 = new Video("Top 5 VS Code Extensions", "TechyTom", 420);
        video2.AddComment(new Comment("Dan", "Number 3 is my favorite."));
        video2.AddComment(new Comment("Ella", "Very informative."));
        video2.AddComment(new Comment("Frank", "Just what I needed!"));

        // Video 3
        var video3 = new Video("What is .NET?", "DotNet Dave", 750);
        video3.AddComment(new Comment("Gina", "Thanks for simplifying this."));
        video3.AddComment(new Comment("Henry", "Excellent content."));
        video3.AddComment(new Comment("Ivy", "Subbed and liked!"));

        // Add to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video info
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments ({video.GetNumberOfComments()}):");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}