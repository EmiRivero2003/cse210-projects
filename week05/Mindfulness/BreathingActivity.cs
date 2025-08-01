using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity", 
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            int rounds =  _duration / 6; // Suponiendo 3 in, 3 out
            for (int i = 0; i < rounds; i++)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(3);
                Console.WriteLine("Breathe out...");
                ShowCountDown(3);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}