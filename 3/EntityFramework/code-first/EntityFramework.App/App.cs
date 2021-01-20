using EntityFramework.Common.Data;
using EntityFramework.Common.Data.Interfaces;
using EntityFramework.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.App
{
    public class App
    {
        // Setup Dependency Injection
        private readonly ApplicationDbContext _context;
        private readonly ICharacterDependency _character;

        public App(ApplicationDbContext context,
            ICharacterDependency character)
        {
            _context = context;
            _character = character;
        }

        // Run Application
        public void Run()
        {
            Character character = _character.CreateCharacter();

            _context.Character.Add(character);
            _context.SaveChanges();
        }
    }
}
