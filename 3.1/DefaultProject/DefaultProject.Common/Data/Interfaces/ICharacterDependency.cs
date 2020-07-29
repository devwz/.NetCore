using DefaultProject.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultProject.Common.Data.Interfaces
{
    public interface ICharacterDependency
    {
        Character CreateCharacter();
        ICollection<Character> CreateCharacterCollection(int length);
    }
}
