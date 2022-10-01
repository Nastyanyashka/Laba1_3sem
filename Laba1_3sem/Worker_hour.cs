using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    class Worker_hour
    {
        string full_name;
        bool gender;
        int hours_to_pay;
        int money_per_hour;
        int money_for_rework;
        const int norm_hours = 6*15;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender">true is male gender, false is female</param>
        /// <param name="money_per_hour"></param>
        /// <param name="money_for_rework"></param>
        public Worker_hour(string name, bool gender, int money_per_hour, int money_for_rework)
        {
            full_name = name;
            this.gender = gender;
            this.money_per_hour = money_per_hour;
            this.money_for_rework = money_for_rework;
        }


        public string Name => full_name;
        public bool Gender => gender;

        public int Money_per_hour => money_per_hour;

        public int Norm_hours => norm_hours;

        public int Money_for_rework =>money_for_rework;
        public void Work(int hours) => hours_to_pay += hours;
        public int calculate_salary()
        {
            int salary;
            if(hours_to_pay > norm_hours)
            {
                salary = norm_hours * money_per_hour;
                salary += (hours_to_pay - norm_hours) * money_for_rework;
                hours_to_pay = 0;
                return salary;
            }
            salary = hours_to_pay * money_per_hour;
            hours_to_pay = 0;
            return salary;
        }

    }
}
