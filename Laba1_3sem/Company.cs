using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    public class Company
    {
        List<Worker_hour> Workers_hour = new List<Worker_hour>();
        List<Worker_sale> Workers_sale = new List<Worker_sale>();
        int days_after_salary = 0;

        public void Add_worker_hour(Worker_hour worker1) => Workers_hour.Add(worker1);
        public void Add_worker_sale(Worker_sale worker2) => Workers_sale.Add(worker2);

        public List<Worker_hour> GetWorkersHour()
        {
            if (Workers_hour == null)
            {
                throw new Exception("Рабочих нет");
            }
            return Workers_hour;
        }

        public List<Worker_sale> GetWorkersSales()
        {
            if (Workers_sale == null)
            {
                throw new Exception("Рабочих нет");
            }
            return Workers_sale;
        }


        private int Binarysearch(List<Worker_hour> list, int n, string Name)
        {
            int low = 0;
             int high = n-1;
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
            Workers_hour.Sort((x, y) => x.Name.CompareTo(y.Name));
            num = Binarysearch(Workers_hour, Workers_hour.Count, full_name);
            if (num!=-1)
            {
                Workers_hour.RemoveAt(num);
                return;
            }
            Workers_sale.Sort((x, y) => x.Name.CompareTo(y.Name));
            num = Binarysearch(Workers_sale, Workers_sale.Count, full_name);
            if(num!=-1)
            {
                Workers_sale.RemoveAt(num);
                return;
            }
            throw new Exception("Работник с таким именем не найден");
        }

        public double Simulate_work(int days)
        {
            if (days< 0)
            {
                throw new Exception("Количество дней не может быть отрицательным");
            }    
            double expenses = 0;
            Random hours = new Random();
            Random sales = new Random();
            for (; days > 0; days--, days_after_salary++)
            {
                for (int i = 0; i < Workers_hour.Count; i++)
                {
                    Workers_hour[i].Work(hours.Next(1, 10));
                }
                for(int i = 0;i<Workers_sale.Count;i++)
                {
                    Workers_sale[i].Sale(sales.Next(500, 100000));
                }
                if(days_after_salary ==15)
                {
                    days_after_salary = 0;
                    for (int i = 0; i < Workers_hour.Count; i++)
                    {
                        expenses += Workers_hour[i].calculate_salary();
                    }
                    for (int i = 0; i < Workers_sale.Count; i++)
                    {
                        expenses += Workers_sale[i].calculate_salary();
                    }  
                }

            }
            return expenses;
        }
    }
}
