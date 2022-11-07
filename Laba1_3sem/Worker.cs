using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laba1_3sem
{
    public abstract class Worker
    {
        protected string full_name;
        protected bool gender;

        public Worker(string name, bool gender)
        {
            full_name = name;
            this.gender = gender;
        }
        public Worker() { }

        public string Name {
            get{ return full_name;}
             set
            {full_name = value;}
        }
        public bool Gender {
            get{return gender;}
             set
            {gender = value;}
        }
        public abstract double calculate_salary();
    }
}
