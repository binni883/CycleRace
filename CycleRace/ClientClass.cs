using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleRace
{
    public class ClientClass
    {
        //global variables declaration
        public string Name;
        public BetClass MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;
        //public Button MyButton;

        public ClientClass(string Name, BetClass MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel) //this is constructor
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }

        public void UpdateLabels()//this function is for update the vales of the labels 
        {
            if (MyBet == null)
            {
                MyLabel.Text = String.Format("{0} hasn't placed any bets", Name);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            MyRadioButton.Text = Name + " has " + Cash + " bucks";

            if (Cash == 0)//Code When bettor has no money to bet then it gets destroy
            {
                MyLabel.Text = String.Format("BUSTED");
                MyLabel.ForeColor = System.Drawing.Color.Red;
                MyRadioButton.Enabled = false;
            }

        }

        public void ClearBet() //this is for clearing the bet and reset the value of bet as 0
        {
            MyBet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int Cycle)//this function is for placing the bet 
        {
            if (Amount <= Cash)
            {
                //MyLabel.Text = "Busted";
                MyBet = new BetClass(Amount, Cycle, this);
                return true;
            }

            return false;
        }

        public void Collect(int Winner)//this function is for collecting the cash of winner
        {
            Cash += MyBet.PayOut(Winner);
        }
    }
}
