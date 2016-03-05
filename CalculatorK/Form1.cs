using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorK
{
    public partial class Form1 : Form

    {
        public double ClickedNumbera;
        public bool isset;
        public string operation;
        public double memNum;
        public Form1()
        {
            InitializeComponent();
        }

        private void numbers_eventt_click(object sender, EventArgs e) // Функция нажатия на число 
        {
            Button btn_clicked = (Button)sender;

            if (btn_clicked.Text == ",") {


                if (!resultView.Text.Contains(","))
                {



                    this.resultView.Text += btn_clicked.Text;
                }
                return;

            }
            if (this.resultView.Text == "0"  || isset )
            {
                isset = false;

                this.resultView.Text = btn_clicked.Text;
            }
            else
            {
                this.resultView.Text += btn_clicked.Text;
            }

        }

        private void operation_Click(object sender, EventArgs e) // operation function
        {
            if (ClickedNumbera != 0) this.calculate_Click(sender, e); 

             ClickedNumbera = double.Parse(this.resultView.Text);
            isset = true; //определяет, установлена ли переменная.
                         
            operation = ((Button)sender).Text; ;
            

        }
       

        private void calculate_Click(object sender, EventArgs e)// sender eto button
        {

            double calculation = 0;
            if (operation == "+")
            {
                calculation = ClickedNumbera + double.Parse(this.resultView.Text);
            }
            else if (operation == "-")
            {
                calculation = ClickedNumbera - double.Parse(this.resultView.Text);
            }
            else if (operation == "X")
            {
                calculation = ClickedNumbera * double.Parse(this.resultView.Text);
            }
            else if (operation == "÷")
            {
                calculation = ClickedNumbera / double.Parse(this.resultView.Text);
            }
            else if (operation == "sqrt")
            {

                calculation = Math.Sqrt(double.Parse(this.resultView.Text));

            }
            else if (operation == "1/X")
            {

                calculation = 1 / double.Parse(this.resultView.Text);

            }



            // save = double.Parse(resultView.Text);

            this.resultView.Text = calculation.ToString();
            isset = true;
            ClickedNumbera= 0;
            
        }

        private void button13_Click(object sender, EventArgs e)// clear operatin
        {
            ClickedNumbera = 0;
           // save = 0;
            isset = false;
            operation = "";
            this.resultView.Text = "0";

        }

        private void button22_Click(object sender, EventArgs e)// for plus and minus
        {
            double cuur = double.Parse(this.resultView.Text);
            cuur *= -1;
            this.resultView.Text = cuur.ToString();
        }

        private void mOperations_click(object sender, EventArgs e)
        {
            Button mem = (Button)sender;
            if (mem.Text == "ms")//memory save
            {
                memNum = double.Parse(this.resultView.Text);
            }
            else if (mem.Text == "mr" )//memory recall
            {
                this.resultView.Text = memNum.ToString();
            }
            else if (mem.Text == "m+")
            {
                memNum += double.Parse(this.resultView.Text);
            }
            else if (mem.Text == "mc") //memory clear
            {
                memNum = 0;
            }
            else if (mem.Text == "m-")
            {
                memNum -= double.Parse(this.resultView.Text);
            }
           
        }

        private void Back_Click(object sender, EventArgs e) //backspace
        {
            if(resultView.Text.Length!=0 && this.resultView.Text != "0")
            {
                this.resultView.Text = resultView.Text.Substring(0, resultView.Text.Length - 1);

            }
            else
            {
                this.resultView.Text = "0";
            }
        }
    }
}
