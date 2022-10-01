using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3sem
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.Add_worker_hour(new Worker_hour("tom", false, 10, 10));
            company.Add_worker_hour(new Worker_hour("stas", false, 10, 10));
            company.Add_worker_hour(new Worker_hour("gleb", false, 10, 10));
            company.Add_worker_hour(new Worker_hour("dima", false, 10, 10));
            company.Add_worker_hour(new Worker_hour("sanya", false, 10, 10));
            company.Add_worker_hour(new Worker_hour("anton", false, 10, 10));
            company.Delete_worker("stas");
            company.Add_worker_sale(new Worker_sale("stas", true, 1000, 1));
            

        }
    }
}
