using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultProject.Common.Domain
{
    public class Character
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public int Health { get; set; }
        public int Magic { get; set; }
        public int Strength { get; set; }
        public int Armor { get; set; }
        public decimal Heigth { get; set; }
        public decimal Weigth { get; set; }

        // public object Artefatos  { get; set; }
        // public object Aparencia { get; set; }
        // public object Atributos { get; set; }
    }
}
