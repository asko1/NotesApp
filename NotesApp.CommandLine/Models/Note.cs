using System;
using System.Collections.Generic;

namespace NotesApp.CommandLine.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public DateTime ChangeDateTime { get; set; }

        public Note(string id, string heading, string content, DateTime datetime)
        {
            Id = id;
            Heading = heading;
            Content = content;
            ChangeDateTime = datetime;
        }
    }
}
