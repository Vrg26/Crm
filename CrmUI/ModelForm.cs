using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var cashDesks = new List<CashDeskView>();

            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashDeskView(model.CashDesks[i], i, 10, 26 * i);
                cashDesks.Add(box);
                Controls.Add(box.CashDesckName);
                Controls.Add(box.Price);
                Controls.Add(box.QeueuLenght);
                Controls.Add(box.LeaveCustomersCount);

            }

            model.Start();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.CustomersSpeed;
            numericUpDown2.Value = model.CashDeskSpeed;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = (int)numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CustomersSpeed = (int)numericUpDown1.Value;

        }
    }
}
