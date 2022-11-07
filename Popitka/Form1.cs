using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Laba1_3sem;

namespace Popitka
{
    public partial class Form1 : Form
    {
        Company company = new Company();
        public Form1()
        {
            InitializeComponent();
            
            //"stateOfListSale.json" "stateOfListHour.json"
        }
        private async Task Deserealize_ListOfWorkerSale()
        {
            List<Worker_sale>? workers = null;
            using (FileStream fileread_ListOfWorkers = new FileStream("stateOfListSale.json", FileMode.OpenOrCreate))
            {
                if(new FileInfo("stateOfListSale.json").Length ==0)
                {
                    return;
                }
               workers  = await JsonSerializer.DeserializeAsync<List<Worker_sale>>(fileread_ListOfWorkers);
            }
            foreach (Worker_sale w in workers)
            {
                company.Add_worker_sale(w);
                listBox_Workers_Sale.Items.Add(w.Name);
            }
        }
        private async Task Deserealize_ListOfWorkerHour()
        {
            List<Worker_hour>? workers = null;
            using (FileStream fileread_ListOfWorkers = new FileStream("stateOfListHour.json", FileMode.OpenOrCreate))
            {
                if (new FileInfo("stateOfListHour.json").Length == 0)
                {
                    return;
                }
                workers = await JsonSerializer.DeserializeAsync<List<Worker_hour>>(fileread_ListOfWorkers);
            }
            foreach (Worker_hour w in workers)
            {
                company.Add_worker_hour(w);
                listBox_Workers_Hour.Items.Add(w.Name);
            }
        }


        private void button_add_Worker_Sale_Click(object sender, EventArgs e)
        {
            bool gender;

            if(radioButton_male.Checked)
            {gender = true;}
            else if(radioButton_female.Checked){ gender = false; }
            else { MessageBox.Show("Вы не выбрали пол"); return; }


            try
            {
                Worker_sale worker = new Worker_sale(textBox_name.Text, gender,
                Convert.ToInt32(textBox_salary.Text),
                Convert.ToDouble(textBox_percentage.Text));
                company.Add_worker_sale(worker);
                listBox_Workers_Sale.Items.Add(worker.Name);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка : {ex.Message}");
            }
            

        }

        private void button_add_Worker_Hour_Click(object sender, EventArgs e)
        {
            bool gender;

            if (radioButton_male.Checked)
            { gender = true; }
            else if (radioButton_female.Checked) { gender = false; }
            else { MessageBox.Show("Вы не выбрали пол"); return; }


            try
            {
                Worker_hour worker = new Worker_hour(textBox_name.Text, gender,
                Convert.ToInt32(textBox_hour_salary.Text),
                Convert.ToInt32(textBox_rework_salary.Text));
                company.Add_worker_hour(worker);
                listBox_Workers_Hour.Items.Add(worker.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка : {ex.Message}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            label10.Text = "Затраты за введенное кол-во дней: " +
                company.Simulate_work(Convert.ToInt32(textBox_modelWork.Text)).ToString();
        }
        private void button_DeleteWorker_Click(object sender, EventArgs e)
        {
            try
            {
                company.Delete_worker(textBox_DeleteWorker.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
            listBox_Workers_Sale.Items.Remove(textBox_DeleteWorker.Text);
            listBox_Workers_Hour.Items.Remove(textBox_DeleteWorker.Text);
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using(FileStream filewrite_ListOfWorkersSale = new FileStream("stateOfListSale.json", FileMode.Truncate))
            {
                await JsonSerializer.SerializeAsync<List<Worker_sale>>(filewrite_ListOfWorkersSale,company.GetWorkersSales());
            }

            using (FileStream filewrite_ListOfWorkersHour = new FileStream("stateOfListHour.json", FileMode.Truncate))
            {
                await JsonSerializer.SerializeAsync<List<Worker_hour>>(filewrite_ListOfWorkersHour, company.GetWorkersHour());
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Deserealize_ListOfWorkerHour();
            await Deserealize_ListOfWorkerSale();
        }
    }
}
