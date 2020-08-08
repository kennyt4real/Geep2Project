using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.DomainLayer.CustomAbstrations
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword);
        bool IsValid();
    }
}
