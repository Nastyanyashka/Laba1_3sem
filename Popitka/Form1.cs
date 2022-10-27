using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba1_3sem;

namespace Popitka
{
    public partial class Form1 : Form
    {
        Company company = new Company();
        public Form1()
        {
            InitializeComponent();
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
    }
}
