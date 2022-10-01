using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    class Worker_sale
    {
        string full_name;
        bool gender;
        int salary;
        double percentage;
        int money_for_sales;

        public Worker_sale(string name, bool gender, int salary,double percentage)
        {
            full_name = name;
            this.gender = gender;
            this.salary = salary;
            this.percentage = percentage;
        }

        public string Name => full_name;
        public bool Gender => gender;
        public int Salary => salary;
        public double Percentage => percentage;

        public void Sale(int money) => money_for_sales += money;
        public double calculate_salary()
        {
            double salary = money_for_sales + (money_for_sales * percentage);
            money_for_sales = 0;
                return salary;
        }
    }
}
