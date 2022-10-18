﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    public class Worker_sale: Worker
    {
        int salary;
        double percentage;
        int money_for_sales;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender">true is male gender, false is female</param>
        /// <param name="money_per_hour"></param>
        /// <param name="money_for_rework"></param>
        public Worker_sale(string name, bool gender, int salary,double percentage)
            :base(name,gender)
        {
            this.salary = salary;
            this.percentage = percentage;
        }

        public int Salary => salary;
        public double Percentage => percentage;

        public void Sale(int money) => money_for_sales += money;
        public override double calculate_salary()
        {
            double salary = this.salary + (money_for_sales * percentage);
            money_for_sales = 0;
                return salary;
        }
    }
}
