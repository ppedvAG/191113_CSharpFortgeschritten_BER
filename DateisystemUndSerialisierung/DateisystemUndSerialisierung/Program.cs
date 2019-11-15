using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateisystemUndSerialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arbeiten mit dem Dateisystem
            //// Stream, FileStream, StreamWriter/Reader   File/Directory

            ////Schreiben:

            //// Binär (WIN + . für mehr 💩💩💩💩💩💩)
            //string text = "Hallo Welt 😎";
            //FileStream stream = new FileStream("demo.😍", FileMode.Create);
            //byte[] textData = Encoding.Unicode.GetBytes(text);
            //stream.Write(textData, 0, textData.Length);

            //stream.Flush();
            //stream.Close();

            //// Strings: StreamReader/StreamWriter

            //StreamReader sr = new StreamReader("demo.😍");
            //string alles = sr.ReadToEnd();
            //Console.WriteLine(alles);
            //sr.Close();

            //// Alles: (File/Directory)
            //if(File.Exists("demo.😍"))
            //    Console.WriteLine("Datei ist da");

            //File.SetCreationTime("demo.😍", new DateTime(2848, 3, 13, 12, 59, 33)); 
            #endregion

            // Serialisierung

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
