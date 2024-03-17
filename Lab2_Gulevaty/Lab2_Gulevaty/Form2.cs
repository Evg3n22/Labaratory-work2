using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Lab2_Gulevaty
{
    public partial class Form2 : Form
    {
        private List<Client> clientList;
        private Dictionary<int, int> haircuts;
        private int totalMoney = 0;
        private int chek = 0;

        public Form2(List<Client> clients, Dictionary<int, int> haircutPrices)
        {
            InitializeComponent();

            clientList = clients;
            haircuts = haircutPrices;

            if (clientList != null)
            {
                foreach (var client in clientList)
                {
                    listBox1.Items.Add(client);
                }
                using (var stream = File.OpenWrite("data.txt"))
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var item in clientList)
                    {
                        writer.WriteLine($"{item.Name},{item.Date},{" --- "},{item.ClientId}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedClient = clientList[listBox1.SelectedIndex];
                int cost;

                if (haircuts.TryGetValue(selectedClient.ClientId, out cost))
                {
                    totalMoney += cost;
                }

                using (var stream = File.OpenWrite("data.txt"))
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{totalMoney}");
                }

                textBox1.Text = "";
                textBox1.Text = totalMoney.ToString();

                clientList.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                chek++;
            }
        }
    }
}

