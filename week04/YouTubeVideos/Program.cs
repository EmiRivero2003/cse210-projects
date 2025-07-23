using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to use classes in C#", "Emiliano Rivero", 530);
        v1.AddComment(new Comment("Juan", "Great content!"));
        v1.AddComment(new Comment("Romina", "This really helped me with my homework."));
        v1.AddComment(new Comment("Christopher", "Could you make one about inheritance?"));

        Video v2 = new Video("Understanding Encapsulation in C#", "Emi Dev", 310);
        v2.AddComment(new Comment("Carolina", "Crystal clear, thank you!"));
        v2.AddComment(new Comment("Tatiana", "Awesome explanation."));
        v2.AddComment(new Comment("Ivan", "When are you posting one on polymorphism?"));

        Video v3 = new Video("My first console app", "Emi Dev", 150);
        v3.AddComment(new Comment("Alma", "Loved it!"));
        v3.AddComment(new Comment("Alejandro", "You made loops easy to understand, legend."));
        v3.AddComment(new Comment("Leticia", "Can I use VS Code for this?"));
        
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (Video v in videos)
        {
            v.DisplayVideo();
        }
    }

}