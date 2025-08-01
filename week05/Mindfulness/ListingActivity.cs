using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("List as meny responses as you can to the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine("You may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();

            List<string> responses = GetListFromUser();

            Console.WriteLine($"You listed {responses.Count} items!");
            ShowSpinner(3);

            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            Random rand = new Random();
            int index = rand.Next(_prompts.Count);
            return _prompts[index];
        }

        private List<string> GetListFromUser()
        {
            List<string> responses = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response))
                {
                    responses.Add(response);
                }
            }

            return responses;
        }
    }
}