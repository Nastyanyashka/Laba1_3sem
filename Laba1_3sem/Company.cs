using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    public class Company
    {
        List<Worker_hour> Workers1 = new List<Worker_hour>();
        List<Worker_sale> Workers2 = new List<Worker_sale>();
        int days_after_salary = 0;

        public void Add_worker_hour(Worker_hour worker1) => Workers1.Add(worker1);
        public void Add_worker_sale(Worker_sale worker2) => Workers2.Add(worker2);

        private int Binarysearch(List<Worker_hour> list, int n, string Name)
        {
            int low = 1;
             int high = n;
            int mid;
            while (low<=high)
            {
                mid = low + (high - low) / 2;
                if (list[mid].Name == Name)
                    return mid;
                else if(String.Compare(Name,list[mid].Name)>0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;             
        }
        private int Binarysearch(List<Worker_sale> list, int n, string Name)
        {
            int low = 1;
            int high = n;
            int mid;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (list[mid].Name == Name)
                    return mid;
                else if (String.Compare(Name, list[mid].Name) > 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
        public void Delete_worker(string full_name)
        {
            int num;
            Workers1.Sort((x, y) => x.Name.CompareTo(y.Name));
            num = Binarysearch(Workers1, Workers1.Count, full_name);
            if (num!=-1)
            {
                Workers1.RemoveAt(num);
                return;
            }
            Workers2.Sort((x, y) => x.Name.CompareTo(y.Name));
            num = Binarysearch(Workers2, Workers2.Count, full_name);
            if(num!=-1)
            {
                Workers2.RemoveAt(num);
                return;
            }
        }

        public double Simulate_work(int days)
        {
            double expenses = 0;
            Random hours = new Random();
            Random sales = new Random();
            for (; days > 0; days--, days_after_salary++)
            {
                for (int i = 0; i < Workers1.Count; i++)
                {
                    Workers1[i].Work(hours.Next(1, 10));
                }
                for(int i = 0;i<Workers2.Count;i++)
                {
                    Workers2[i].Sale(sales.Next(10000, 100000));
                }
                if(days_after_salary ==15)
                {
                    days_after_salary = 0;
                    for (int i = 0; i < Workers1.Count; i++)
                    {
                        expenses += Workers1[i].calculate_salary();
                    }
                    for (int i = 0; i < Workers2.Count; i++)
                    {
                        expenses += Workers2[i].calculate_salary();
                    }  
                }

            }
            return expenses;
        }
    }
}
