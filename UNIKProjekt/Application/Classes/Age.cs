using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Classes
{
    public class Age
    {
        private int age;
        public int Value { get { return age; } set { age = value; } }
        public Age(DateTime dateOfBirth)
        {
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear) 
            { 
                age = age - 1;
            }
        }
    }
}
