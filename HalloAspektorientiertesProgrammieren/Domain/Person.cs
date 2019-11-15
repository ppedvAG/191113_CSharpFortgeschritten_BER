using System;
using System.Collections.Generic;

namespace Domain
{

    public abstract class Entity
    {
        public int ID { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public bool IsDeleted { get; set; }
    }

    public class Person : Entity
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
        // public List<Haustier> Haustiere { get; set; }
    }

    public class Haustier
    {
        public byte Alter { get; set; }
    }
}
