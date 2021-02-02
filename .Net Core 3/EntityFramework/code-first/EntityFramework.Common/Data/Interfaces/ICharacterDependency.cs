using EntityFramework.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Common.Data.Interfaces
{
    public interface ICharacterDependency
    {
        Character CreateCharacter();
        ICollection<Character> CreateCharacterCollection(int length);
    }
}
