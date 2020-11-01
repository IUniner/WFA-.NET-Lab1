using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.NET_Lab1
{
    public class Employer
    {    
        public string name;
        public string lastName;
        public int age;
        public double stature;
        public int staff;

        public Employer() { }
        public Employer(string Name, string LastName, int Age = 0, double Stature = 0.0, int Staff = 0) 
        {
            name = Name;
            lastName = LastName;
            age = Age;
            stature = Stature;
            staff = Staff;
        }
    }
}
