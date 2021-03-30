using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.Interfaces
{
    public interface IValidatable<T> where T: class
    {
        string Validate(T personCodeUserInput);
    }
}
