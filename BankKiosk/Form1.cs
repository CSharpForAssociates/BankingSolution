using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        BankAccount _account;
        public Form1(BankAccount account)
        {
            InitializeComponent();
            _account = account;
            UpdateUi();
        }

        public Form1()
        {
        }

        private void UpdateUi()
        {
            this.Text = $"Your balance is {_account.GetBalance():c}";
        }


        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);

        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = int.Parse(txtAmount.Text);
                op(amount);
                UpdateUi();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a number, genius.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(OverdraftException)
            {
                MessageBox.Show("You don't have enough money, joker.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(NoNegativeTransactionsException)
            {
                MessageBox.Show("Are you a moron? Use positive numbers!", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            foreach(var x in Enumerable.Range(1,10000))
            {
                new SystemTime();
            }

            sw.Stop();
            MessageBox.Show($"That took {sw.ElapsedMilliseconds} milliseconds");
        }
    }
}
