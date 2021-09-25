using NotesApp.CommandLine.Models;
using System;
using System.Collections.Generic;

namespace NotesApp.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Note> Notes = new List<Note>();

            var run = true;
            while (run)
            {
                Console.WriteLine(  
                 @"
                1.Vaata märkmeid
                2.Lisa
                3.Muuda
                4.Kustuta
                5.Exit
                            ");
                var answer = int.Parse(Console.ReadLine());

                switch(answer)
                {
                    case 1:
                        foreach (Note note in Notes)
                        {
                            Console.WriteLine($"Pealkiri: {note.Heading}");
                            Console.WriteLine($"Kirjeldus: {note.Content} ");
                            Console.WriteLine($"Aeg: {note.ChangeDateTime} \n");
                        }                        
                        break;

                    case 2:
                        Console.WriteLine("Pealkiri: ");
                        var title = Console.ReadLine();
                        Console.WriteLine("Kirjeldus: ");
                        var desc = Console.ReadLine();
                        var n = new Note(Guid.NewGuid().ToString(), title, desc, DateTime.Now);
                        Notes.Add(n);
                        Console.WriteLine("Märge lisatud!");
                        break;

                    case 3:
                        for (int i = 0; i < Notes.Count; i++)
                        {
                            Console.WriteLine($"{i}: {Notes[i].Heading}");
                        }
                        answer = int.Parse(Console.ReadLine());
                        Console.WriteLine("1. Pealkiri\n2. Kirjeldus");
                        int answer2 = int.Parse(Console.ReadLine());
                        if (answer2 == 1)
                        {
                            Console.WriteLine("Uus pealkiri: ");
                            Notes[answer].Heading = Console.ReadLine();
                        } else if (answer2 == 2)
                        {
                            Console.WriteLine("Uus kirjeldus: ");
                            Notes[answer].Content = Console.ReadLine();
                        }
                        break;

                    case 4:
                        for (int i = 0; i < Notes.Count; i++)
                        {
                            Console.WriteLine($"{i}: {Notes[i].Heading}");
                        }
                        answer = int.Parse(Console.ReadLine());
                        Notes.RemoveAt(answer);
                        Console.WriteLine("Edukalt eemaldatud!");
                        break;

                    case 5:
                        Console.WriteLine("say goodbye");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("rebel.");
                        break;
                }
            }            
        }
    }
}
