using TakeNoteApp;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace TakeNoteApp
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    class Management

    {
        List<Note> note;
        public Management()
        {
            note = new List<Note>()
                {
                    new Note { Id = 1, Title="Meeting", Description="Meeting with Client @ 9AM", Date=DateTime.Now},
                    new Note { Id = 2, Title="Pay Bills", Description="Pay Electricity Bills", Date=DateTime.Now },
                };
        }

        public void CreateNote(Note note1)
        {
            note.Add(note1);
        }

        public int GenerateNoteId(string title)
        {
            Random ran = new Random();
            int rnum = ran.Next(1, 9999);
            return rnum;
        }

        public Note ViewNote(int id)
        {
            foreach (Note n in note)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }

        public bool UpdateNote(int id)
        {
            foreach (Note n in note)
            {
                if (n.Id == id)
                {
                    Console.WriteLine("Enter the New Details");
                    Console.WriteLine("Enter title");
                    n.Title = Console.ReadLine();
                    Console.WriteLine("Enter description");
                    n.Description = Console.ReadLine();
                    n.Date = DateTime.Now;
                    return true;
                }
            }
            return false;
        }

        public List<Note> ViewNote()
        {
            return note;
        }

        public bool DeleteNote(int id)
        {
            foreach (Note n in note)
            {
                if (n.Id == id)
                {
                    note.Remove(n);
                    return true;
                }
            }
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Management obj = new Management();
                string ans = "";
                do
                {
                    Console.WriteLine("Welcome to Take Note App");
                    Console.WriteLine("1. Create Note");
                    Console.WriteLine("2. View Note By Id");
                    Console.WriteLine("3. View All Notes");
                    Console.WriteLine("4. Update Nate By Id");
                    Console.WriteLine("5. Delete Note By Id");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter Title");
                                string title = Console.ReadLine();
                                Console.WriteLine("Enter Discription");
                                string description = Console.ReadLine();
                                int nid = obj.GenerateNoteId(title);
                                Console.WriteLine($"Your Id: {nid}");
                                DateTime date = DateTime.Now;
                                Console.WriteLine($"Date: {date}");
                                obj.CreateNote(new Note() { Id = nid, Title = title, Description = description, Date = date });
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter Customer Id");
                                int id = Convert.ToInt16(Console.ReadLine());
                                Note? n = obj.ViewNote(id);
                                if (n == null)
                                {
                                    Console.WriteLine("Note with specified id does not exists");
                                }
                                else
                                {
                                    Console.WriteLine($"{n.Id} {n.Title} {n.Description} {n.Date}");
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("id\ttitle\t\t\tdescription\t\t\tdate");
                                int count = 0;
                                foreach (var c in obj.ViewNote())
                                {
                                    Console.WriteLine($"{c.Id}\t {c.Title}\t {c.Description}\t {c.Date}");
                                    ++count;
                                }
                                Console.WriteLine($"Total Notes: {count}");
                                break;

                            }
                        case 4:
                            {
                                Console.WriteLine("Enter Note ID");
                                int id = Convert.ToInt16(Console.ReadLine());
                                if (obj.UpdateNote(id))

                                {
                                    Console.WriteLine("Note Updated Successfully!!");
                                }
                                else
                                {
                                    Console.WriteLine("Note with specified id does not exist");
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Enter Customer Id");
                                int id = Convert.ToInt16(Console.ReadLine());
                                if (obj.DeleteNote(id))
                                {
                                    Console.WriteLine("Note Deleted Successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Note with specified id does not exist");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice!!");
                                break;
                            }

                    }
                    Console.WriteLine("Do you wish to continue? [y/n] ");
                    ans = Console.ReadLine();
                } while (ans.ToLower() == "y");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            finally { Console.WriteLine("Program Ends."); }
        }
    }
}
