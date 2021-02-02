using DependencyInjection.Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Service
{
    public class App
    {
        // Setup Dependency Injection
        readonly ICharacterDependency _character;

        public App(ICharacterDependency character)
        {
            _character = character;
        }

        // Run Application
        public void Run()
        {
            _ = _character.CreateCharacter();
        }
    }
}
