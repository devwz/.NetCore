using DefaultProject.Common.Data.Interfaces;
using DefaultProject.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultProject.Common.Data
{
    public class KindDependency : IKindDependency
    {
        string[] data = new string[] { "Centaur", "Demon", "Elf", "Gnome", "God", "Golem", "Guardian", "Hunter", "Knight", "Nephilim", "Orc", "Robot", "Witch", "Wizard", "Zombie" };

        public ICollection<Kind> CreateTypeCollection()
        {
            Kind[] col = new Kind[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                col[i] = new Kind() { Id = i + 1, Title = data[i] };
            }

            return col;
        }
    }
}
