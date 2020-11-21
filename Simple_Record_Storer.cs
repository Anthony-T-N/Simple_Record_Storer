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
                    break;
                }
                main_program.write_text(record);
            }
        }
        public void write_text(string record)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "[record].txt");
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("Text file doesn't exist. Creating new one.");
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("<<Record Text File>>");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(" ");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                sw.WriteLine(record);
            }
            string text = System.IO.File.ReadAllText(path);
            System.Console.WriteLine(text);
        }
    }
}