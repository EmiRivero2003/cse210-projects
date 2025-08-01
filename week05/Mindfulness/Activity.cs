using System;
using System.Threading;

namespace Mindfulness
{

    public class Activity
    {
        private string _name;
        private string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Welcome to the {_name}");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Enter duration in seconds: ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
            ShowSpinner(3);
            Console.WriteLine();
        }

        public void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);

            int index = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[index]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                index = (index + 1) % spinner.Length;
            }
            Console.WriteLine();
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Console.WriteLine();
            }
        }
    }
}    