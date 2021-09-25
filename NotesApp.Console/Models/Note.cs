using System;

namespace NotesApp.Console.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public DateTime ChangeDateTime { get; set; }
    }
}
