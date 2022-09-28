using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    class Payment_per_hour
    {
        string full_name;
        bool gender;
        int hours_to_pay;
        int money_per_hour;
        int money_for_rework;
        const int norm_hours = 8;
        

        public string Name
        {
            get {return full_name;}
        }

        public bool Gender
        {
            get{ return gender;}
        }

        public int Money_per_hour
        {
            get{return money_per_hour;}
        }

        public int Norm_hours
        {
            get {return norm_hours;}
        }

        public int Money_for_rework
        {
            get { return money_for_rework; }
        }

        public int calculate_salary()
        {
            return money_per_hour;
        }

    }
}
