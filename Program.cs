using NotesListSharp;

NoteList MyNoteList = new NoteList();
ConsoleKeyInfo key;
string tempStr;
using (MyNoteList)
{
    do
    {
        Console.Clear();
        Console.WriteLine($"Currently present {MyNoteList.Count} note(s)");
        Console.WriteLine("1 - Add note\n2 - Remove note\n3 - Edit note\n4 - Find notes by priority\n5 - Find duplicates by name\n6 - Sort notes by date\n7 - Read all notes\nEsc - exit");
        key = Console.ReadKey(true);
        if (key.KeyChar == '1')
        {
            Console.Clear();
            Note temp = new Note();
            Console.WriteLine("Enter Note title");
            tempStr = Console.ReadLine();
            temp.Title = tempStr;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Note priority:\n1 - Low\n2 - Medium\n3 - High");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    temp.Priority = "Low";
                    Console.WriteLine("Success");
                }
                else if (key.KeyChar == '2')
                {
                    temp.Priority = "Medium";
                    Console.WriteLine("Success");
                }
                else if (key.KeyChar == '3')
                {
                    temp.Priority = "Medium";
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
                Console.ReadKey(true);
            } while (temp.Priority == null);
            Console.Clear();
            Console.WriteLine("Enter Note body");
            tempStr = Console.ReadLine();
            temp.Body = tempStr;
            MyNoteList.Add(temp);
            Console.Clear();
            Console.WriteLine("Note Saved");
            Console.ReadKey(true);
        }
        else if (key.KeyChar == '2')
        {
            Console.Clear();
            Console.WriteLine("Enter note title you wish to remove");
            tempStr = Console.ReadLine();
            if (MyNoteList.RemoveByTitle(tempStr))
            {
                Console.Clear();
                Console.WriteLine("Success");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No relevant notes found");
            }
            Console.ReadKey(true);
        }
        else if (key.KeyChar == '3')
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter note title you wish to edit");
                tempStr = Console.ReadLine();
                int temp = MyNoteList.FindIndexByTitle(tempStr);
                if (temp != -1)
                {
                    Console.Clear();
                    Console.WriteLine(MyNoteList[temp]);
                    Console.WriteLine("\n\nChoose what do you want to edit:\n1 - Title\n2 - Priority\n3 - Body");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new title");
                        tempStr = Console.ReadLine();
                        MyNoteList[temp].Title = tempStr;
                        Console.WriteLine("Success");
                    }
                    else if (key.KeyChar == '2')
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Note priority:\n1 - Low\n2 - Medium\n3 - High");
                            key = Console.ReadKey(true);
                            if (key.KeyChar == 1)
                            {
                                MyNoteList[temp].Priority = "Low";
                                Console.WriteLine("Success");
                            }
                            else if (key.KeyChar == 2)
                            {
                                MyNoteList[temp].Priority = "Medium";
                                Console.WriteLine("Success");
                            }
                            else if (key.KeyChar == 3)
                            {
                                MyNoteList[temp].Priority = "Medium";
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Invalid value");
                            }
                        } while (MyNoteList[temp].Priority.Length == 0);
                    }
                    else if (key.KeyChar == '3')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new body");
                        tempStr = Console.ReadLine();
                        MyNoteList[temp].Body = tempStr;
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid command");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No relevant notes found");
                }
                Console.ReadKey(true);
                break;
            } while (true);
        }
        else if (key.KeyChar == '4')
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Note priority you wish to view:\n1 - Low\n2 - Medium\n3 - High");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    Console.WriteLine("Relevant notes:");
                    MyNoteList.FindPriority("Low").ForEach(x => Console.WriteLine(x + "\n"));
                }
                else if (key.KeyChar == '2')
                {
                    Console.WriteLine("Relevant notes:");
                    MyNoteList.FindPriority("Medium").ForEach(x => Console.WriteLine(x + "\n"));
                }
                else if (key.KeyChar == '3')
                {
                    Console.WriteLine("Relevant notes:");
                    MyNoteList.FindPriority("High").ForEach(x => Console.WriteLine(x + "\n"));
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
                Console.ReadKey(true);
                break;
            } while (true);
        }
        else if (key.KeyChar == '5')
        {
            Console.Clear();
            Console.WriteLine("Enter Note title you wish to view:");
            tempStr = Console.ReadLine();
            Console.WriteLine("Relevant notes:");
            MyNoteList.FindDuplicates(tempStr).ForEach(x => Console.WriteLine(x + "\n"));
            Console.ReadKey(true);
        }
        else if (key.KeyChar == '6')
        {
            Console.Clear();
            MyNoteList.Sort();
            Console.WriteLine("Success");
            Console.ReadKey(true);
        }
        else if (key.KeyChar == '7')
        {
            Console.Clear();
            MyNoteList.Sort();
            MyNoteList.ForEach(x => Console.WriteLine(x + "\n"));
            Console.ReadKey(true);
        }
        else if (key.KeyChar == 27)
        {
            Console.Clear();
            Console.WriteLine("Exiting...");
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid command");
            Console.ReadKey(false);
        }
    } while (true);
}
