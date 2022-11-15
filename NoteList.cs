using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotesListSharp
{
    internal class NoteList : List<Note>, IDisposable
    {
        private string Path = "NotesList.json";
        public NoteList()
        {
            List<Note>? temp = new List<Note>();
            string tempStr;
            if (File.Exists(Path))
            {
                tempStr = File.ReadAllText(Path);
                if (tempStr.Length > 0)
                {
                    tempStr = File.ReadAllText(Path);
                    temp = JsonSerializer.Deserialize<List<Note>>(tempStr);
                }
            }
            this.AddRange(temp);
        }
        public List<Note> FindPriority(string priority)
        {
            List<Note>? temp = FindAll(x => x.Priority.Equals(priority));
            return temp;
        }
        public List<Note> FindDuplicates(string title) 
        {
            List<Note> temp = FindAll(x => x.Title.Equals(title));
            return temp;
        }

        public int FindIndexByTitle(string title) 
        {
            int temp = FindIndex(x => x.Title.Equals(title));
            return temp;
        }
        public bool RemoveByTitle(string title) 
        {
            Note temp = Find(x => x.Title.Equals(title));
            if (temp != null)
            {
                Remove(temp);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string temp = "";
            foreach (Note item in this)
            {
                temp += item + "\n";
            }
            return temp;
        }
        public void Dispose()
        {
            File.WriteAllText(Path, JsonSerializer.Serialize(this));
        }
    }
}
