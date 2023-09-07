using System;
using System.IO;

namespace TicketingA1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while(!done)
            {
                Console.WriteLine("What do you want to do?\n1. Read data from file\n2. Create file from data\n3. Exit");
                var inp = Console.ReadLine();
                switch (inp)
                {
                    case "1":
                        if (File.Exists("tickets.csv"))
                        {
                            StreamReader sr = new StreamReader("tickets.csv");
                            sr.ReadLine(); // I want to ignore the first line, this seemed like the easiest way.
                            while(sr.EndOfStream != true)
                            {
                                var line = sr.ReadLine();
                                Console.WriteLine(line);
                            }
                            sr.Close();
                        }
                    break;
                    case "2":
                        StreamWriter sw = new StreamWriter("tickets.csv", true);
                        Console.WriteLine("Enter Ticket ID");
                        var ID = Console.ReadLine();
                        Console.WriteLine("Enter Summary");
                        var summary = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Status");
                        var status = Console.ReadLine();
                        Console.WriteLine("Enter Priority");
                        var priority = Console.ReadLine();
                        Console.WriteLine("Enter Submitter");
                        var submitter = Console.ReadLine();
                        Console.WriteLine("Enter Assigned");
                        var assigned = Console.ReadLine();
                        String nameinp = "";
                        String names = "";
                        Console.WriteLine("Enter name of watcher, or N to exit:");
                        nameinp = Console.ReadLine();
                        if (nameinp.ToUpper() != "N") { 
                            names += nameinp;
                        }
                        while (nameinp.ToUpper() != "N")
                        {
                            
                            Console.WriteLine("Enter name of watcher, or N to exit:");
                            nameinp = Console.ReadLine();
                           if(nameinp.ToUpper() != "N")
                            {
                                names += "|";
                                names += nameinp;
                                
                            }
                        }
                        sw.WriteLine($"{ID},{summary},{status},{priority},{submitter},{assigned},{names}");
                        sw.Close();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
