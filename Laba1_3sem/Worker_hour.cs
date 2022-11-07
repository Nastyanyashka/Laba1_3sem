using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    public class Worker_hour : Worker
    {
        int hours_to_pay;
        int money_per_hour;
        int money_for_rework;
        int norm_hours = 6*15;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender">true is male gender, false is female</param>
        /// <param name="money_per_hour"></param>
        /// <param name="money_for_rework"></param>
        public Worker_hour(string name, bool gender, int money_per_hour, int money_for_rework)
            :base(name,gender)
        {
            if (money_per_hour < 0)
            {
                throw new Exception("Зарплата отрицательная");
            }
            if (money_for_rework<0)
            {
                throw new Exception("Зарплата за переработку отрицательная");
            }
            this.money_per_hour = money_per_hour;
            this.money_for_rework = money_for_rework;
        }
        public Worker_hour(){ }

        public int Money_per_hour {
            get
            {return money_per_hour;}
             set
            {
                if (money_per_hour < 0)
                {
                    throw new Exception("Зарплата отрицательная");
                }
                money_per_hour = value;
            }
        }
        public int Norm_hours
        {
            get { return norm_hours; }
             set
            {
                if (value < 0)
                {
                    throw new Exception("Норма часов не может быть отрицательной");
                }
            }
        }
        public int Money_for_rework
        {
            get { return money_for_rework; }
             set {
                if (value < 0)
                {
                    throw new Exception("Зарплата за переработку отрицательная");
                }
                money_for_rework = value; }
        }
        public void Work(int hours)
        {
            if (hours < 0)
            {
                throw new Exception("Нельзя работать отрицательное кол-во часов");
            }
            hours_to_pay += hours;
        }
        public override double calculate_salary()
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
