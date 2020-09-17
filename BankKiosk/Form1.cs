using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form, INotifyTheFeds
    {
        BankAccount _account;
        public Form1()
        {
            InitializeComponent();
            _account = new BankAccount(
                new StandardBonusCalculator(new StandardCutoffClock(new SystemTime())),
                this
                );
            UpdateUi();
        }

        private void UpdateUi()
        {
            this.Text = $"Your balance is {_account.GetBalance():c}";
        }
        public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show($"Notifying the feds of your withdrawal of {amountToWithdraw:c}");
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


    }
}
