using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectingActivity()
            : base("Reflecting Activity",
                  "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions:");
            ShowSpinner(3);

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            Random rand = new Random();

            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion(rand);
                Console.Write($"> {question} ");
                ShowSpinner(5);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            Random rand = new Random();
            int index = rand.Next(_prompts.Count);
            return _prompts[index];
        }

        private string GetRandomQuestion(Random rand)
        {
            int index = rand.Next(_questions.Count);
            return _questions[index];
        }
    }
}