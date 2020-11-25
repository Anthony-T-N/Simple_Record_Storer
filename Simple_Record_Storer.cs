using System;
using System.IO;

namespace Simple_Record_Storer
{
    class Simple_Record_Storer
    {
        static void Main(string[] args)
        {
            Simple_Record_Storer main_program = new Simple_Record_Storer();
            while (true)
            {
                Console.WriteLine("Enter 'e' to escape");
                Console.Write("Enter record: ");
                string record = Console.ReadLine();
                if (record == "e")
                {
                    System.Environment.Exit(0);
                }
                main_program.write_text(record);
            }
        }
        public void write_text(string record)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "[record].txt");
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine(" ");
                Console.WriteLine("[*] Text file does not exist. Creating a new one.");
                Console.WriteLine(" ");
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("<<<< Record Text File >>>>");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(" ");
                sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                sw.WriteLine(record);
            }
            string[] lines = System.IO.File.ReadAllLines(path);
            // Ensures maximum number of records shown back is kept at 15 lines (5 Records).
            if (lines.Length > 15)
            {
                for (int i = 15; i > 0; i--)
                {
                    string last_lines = lines[lines.Length - i];
                    System.Console.WriteLine(last_lines);
                }
            }
            else if (lines.Length < 15)
            {
                for (int i = lines.Length; i > 0; i--)
                {
                    string last_lines = lines[lines.Length - i];
                    System.Console.WriteLine(last_lines);
                }
            }
            Console.WriteLine(" ");
        }
    }
}
