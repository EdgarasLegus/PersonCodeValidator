using PersonCodeValidator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.Contracts.Entities
{
    public class PersonCode
    {
        public PersonCodeDomain InputPersonCode { get; set; }

        public PersonCode(string inputGenderParameter, string personCode)
        {
            InputPersonCode = new PersonCodeDomain(inputGenderParameter, personCode);
        }
    }


}
