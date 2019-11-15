using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = new Person { Vorname = "Anna", Nachname = "Nass", Alter = 10, Kontostand = 100 };
            Person p3 = new Person { Vorname = "Peter", Nachname = "Silie", Alter = 10, Kontostand = 100 };

            Person[] data = { p1, p2, p3 };

            // Binär
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("person.bin", FileMode.Create);
            formatter.Serialize(stream, p1);
            formatter.Serialize(stream, p2);
            formatter.Serialize(stream, p3);
            stream.Close();

            // Deserialisieren
            stream = new FileStream("person.bin", FileMode.Open);
            var ob1 = formatter.Deserialize(stream);
            var ob2 = formatter.Deserialize(stream);
            var ob3 = formatter.Deserialize(stream);

            Console.WriteLine(ob1);

            // XML
            XmlSerializer xmlformatter = new XmlSerializer(typeof(Person[])); // nur Klassen und Properties, die public sind
            stream = new FileStream("person.xml", FileMode.Create);

            xmlformatter.Serialize(stream, data);
            stream.Close();

            // Deserialisieren
            stream = new FileStream("person.xml", FileMode.Open);

            object xml1 = xmlformatter.Deserialize(stream);
            stream.Close();

            // JSON:
            // Newtonsoft.JSON
            string json = JsonConvert.SerializeObject(p1);
            Console.WriteLine(json);

            Person jsonObject = JsonConvert.DeserializeObject<Person>(json);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    [Serializable]
    [XmlRoot("TopWichtigPerson")]
    public class Person
    {
        [XmlAttribute("Name")]
        public string Vorname { get; set; }
        [XmlAttribute("Name2")]
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }
}
