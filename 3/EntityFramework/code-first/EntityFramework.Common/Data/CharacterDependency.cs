using EntityFramework.Common.Data.Interfaces;
using EntityFramework.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Common.Data
{
    public class CharacterDependency : ICharacterDependency
    {
        static Random random = new Random();

        public Character CreateCharacter()
        {
            return new Character()
            {
                Title = GenerateTitle(),
                Health = GenerateHealth(),
                Grade = GenerateGrade()
            };
        }

        public ICollection<Character> CreateCharacterCollection(int length)
        {
            Character[] collection = new Character[length];

            for (int i = 0; i < length; i++)
            {
                collection[i] = CreateCharacter();
            }

            return collection;
        }

        static string GenerateTitle()
        {
            string[] collection = new string[] { "Ariana", "Autumn", "Bartle", "Bohn", "Catherine", "Cloud", "Dalila", "Delta", "Diana", "Elit", "Emeline", "Finn", "Franklin", "Gorge", "Indigo", "Itham", "Libero", "Lillian", "Orion", "Ozotl", "Noel", "Rod", "Shel", "Stone", "Tiena", "Vivian", "Zagno" };
            return collection[random.Next(0, collection.Length)];
        }

        static string GenerateGrade()
        {
            string[] collection = new string[] { "Centaur", "Demon", "Elf", "Gnome", "God", "Golem", "Guardian", "Hunter", "Knight", "Nephilim", "Orc", "Robot", "Witch", "Wizard", "Zombie" };
            return collection[random.Next(0, collection.Length)];
        }

        static int GenerateHealth()
        {
            return random.Next(60, 180);
        }
    }
}
