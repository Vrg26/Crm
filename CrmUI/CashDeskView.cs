using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    class CashDeskView
    {
        CashDesk cashDesk;
        public Label CashDesckName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QeueuLenght { get; set; }

        public Label LeaveCustomersCount { get; set; }
        public CashDeskView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            CashDesckName = new Label();
            Price = new NumericUpDown();
            QeueuLenght = new ProgressBar();
            LeaveCustomersCount = new Label();


            CashDesckName.AutoSize = true;
            CashDesckName.Location = new System.Drawing.Point(x, y);
            CashDesckName.Name = "label" + number;
            CashDesckName.Size = new System.Drawing.Size(35, 13);
            CashDesckName.TabIndex = number;
            CashDesckName.Text = cashDesk.ToString();

            Price.Location = new System.Drawing.Point(x + 100, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000000;

            QeueuLenght.Location = new System.Drawing.Point(x + 250, y);
            QeueuLenght.Maximum = cashDesk.MaxQueueLenght;
            QeueuLenght.Name = "progressBar" + number;
            QeueuLenght.Size = new System.Drawing.Size(100, 23);
            QeueuLenght.TabIndex = number;
            QeueuLenght.Value = 0;

            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.CheckClosed += Cash_CheckClosed;
        }

        private void Cash_CheckClosed(object sender, Check e)
        {

            Price.Invoke((Action)delegate {

                Price.Value += e.Price;
                QeueuLenght.Value = cashDesk.Count; //Исправить значение выходит за рамки
                LeaveCustomersCount.Text = cashDesk.ExitCustomer.ToString();

            });//Из асинхроного потока в основной
        }
    }
}
