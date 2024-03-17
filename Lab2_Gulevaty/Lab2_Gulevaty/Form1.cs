using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab2_Gulevaty
{
    public partial class Form1 : MaterialForm
    {
        private int clientId = 0;
        private List<Client> clientList = new List<Client>();
        private Dictionary<int, int> haircuts = new Dictionary<int, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            DateTime date = dateTimePicker1.Value;

            if (!radioButton1.Checked && !radioButton2.Checked &&
                !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Choose your haircut");
                return;
            }

            int haircutCost = 0;
            if (radioButton1.Checked)
            {
                haircutCost = 200;
            }
            else if (radioButton2.Checked)
            {
                haircutCost = 150;
            }
            else if (radioButton3.Checked)
            {
                haircutCost = 300;
            }
            else if (radioButton4.Checked)
            {
                haircutCost = 5;
            }

            Client client = new Client(name, date, clientId++, haircutCost);
            clientList.Add(client);
            haircuts.Add(client.ClientId, haircutCost);

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            textBox1.Text = "";

            Form2 formReceiver = new Form2(clientList, haircuts);
            formReceiver.Show();
        }
    }
}


public class Person
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public Person(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Name} - {Date}";
    }
}

sealed public class Client : Person
{
    public int ClientId { get; set; }
    public int HaircutCost { get; set; }

    public Client(string name, DateTime date, int clientId, int haircutCost)
      : base(name, date)
    {
        ClientId = clientId;
        HaircutCost = haircutCost;
    }


}