using NetCore.Common.Infra.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Common.Infra.Interfaces
{
    public interface ICharacterDependency
    {
        Character CreateCharacter();
        ICollection<Character> CreateCharacterCollection(int length);
    }
}
