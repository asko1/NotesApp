using NotesApp.CommandLine.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.CommandLine
{
    public class SqlService
    {
        public SqlService()
        {
            
        }

        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();
            return sqlite_conn;
        }

        public void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string create_sql = "CREATE TABLE IF NOT EXISTS NotesTable (id TEXT, heading TEXT, content TEXT, datetime TEXT )";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = create_sql;
            sqlite_cmd.ExecuteNonQuery();
        }

        public void InsertData(SQLiteConnection conn, Note note)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"INSERT INTO NotesTable (id, heading, content, datetime) VALUES ('{note.Id}', '{note.Heading}', '{note.Content}', '{note.Datetime}')";
            sqlite_cmd.ExecuteNonQuery();
        }

        public List<Note> ReadData(SQLiteConnection conn)
        {
            var notesList = new List<Note>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT * FROM NotesTable";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                var note = new Note(sqlite_datareader.GetString(0), 
                    sqlite_datareader.GetString(1), 
                    sqlite_datareader.GetString(2),
                    DateTime.Parse(sqlite_datareader.GetString(3)));                
                notesList.Add((Note)note);
            }
            return notesList;
        }

        public void ModifyData(SQLiteConnection conn, Note note)
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"UPDATE NotesTable SET heading = '{note.Heading}', content = '{note.Content}' WHERE id= '{note.Id}'";
            sqlite_cmd.ExecuteNonQuery();
        }

        public void DeleteData(SQLiteConnection conn, Note note)
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"DELETE FROM NotesTable WHERE id= '{note.Id}'";
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
