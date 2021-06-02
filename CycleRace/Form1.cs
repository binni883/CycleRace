using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleRace
{
    public partial class Form1 : Form
    {
        //Creating the objects of classes
        TrackSetup[] cycles = new TrackSetup[4];//instance of tracksetup class
        ClientClass[] guys = new ClientClass[3];//object of client class
        public Form1()
        {
            InitializeComponent();
            RaceTrackSetting();//calling the set race track funtion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttonBets_Click(object sender, EventArgs e)
        {
            int GuyNumber = 0;

            if (radioButtonBinni.Checked)
            {
                GuyNumber = 0;//when radio button bikram is checked then set its id is 0
            }
            if (radioButtonSunny.Checked)
            {
                GuyNumber = 1;//when radio button sunny is checked then set its id is 1
            }
            if (radioButtonKamal.Checked)
            {
                GuyNumber = 2;//when radio button kamal is checked then set its id is 2
            }

            guys[GuyNumber].PlaceBet((int)numericUpDownBets.Value, (int)numericUpDownCar.Value);//when any radio button is checked then place bet function is called and bet is placed and show amount and car number
            guys[GuyNumber].UpdateLabels();//with this code line the labels are updated
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            CycleRaceStart();//calling the function of cycle race start with this function when we click on the race button the race will start
        }
        private void RaceTrackSetting()//this funtion is for setting the race track
        {
            MinimumBet.Text = string.Format("Minimum Bet $1", (int)numericUpDownBets.Minimum);//Showing the minimum bet rate in label

            int startingPosition = racer1.Right - cycleTrack.Left; //Setting the variable for starting position from cycle 1
            int raceTrackLength = cycleTrack.Size.Width;//Setting the variable of length of cycletrack

            //Setting values of the array of the class greyhound for racing for the first part of the game as suggested in assignment
            cycles[0] = new TrackSetup()
            {
                MyPictureBox = racer1,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };

            cycles[1] = new TrackSetup()
            {
                MyPictureBox = racer2,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };
            cycles[2] = new TrackSetup()
            {
                MyPictureBox = racer3,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };
            cycles[3] = new TrackSetup()
            {
                MyPictureBox = racer4,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };

            //this part is for assigning the constructor values which is created in guy class
            guys[0] = new ClientClass("Binni", null, 60, radioButtonBinni, labelJoesBet);
            guys[1] = new ClientClass("Sunny", null, 85, radioButtonSunny, labelBobsBet);
            guys[2] = new ClientClass("Kamal", null, 55, radioButtonKamal, labelAlsBet);

            foreach (ClientClass guy in guys)
            {
                guy.UpdateLabels();//using the foreach loop for assigning the values of labels for bet
            }
        }

        private void CycleRaceStart()//this is function for starting the race
        {
            bool NoWinner = true;
            int winningCycle;
            btnRace.Enabled = false;//Button will be false whenever race is continue

            while (NoWinner)
            {
                Application.DoEvents();
                for (int i = 0; i < cycles.Length; i++)//loop start and it will continue whenever length of tracksetup class or track is not finished
                {
                    Thread.Sleep(1);//sleep function for the speed of cars
                    if (cycles[i].Run())//here run function is called from greyhound class for running the cycle and condition is checked for three random cycles
                    {
                        winningCycle = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Cycle #" + winningCycle);
                        foreach (ClientClass guy in guys)
                        {
                            if (guy.MyBet != null)//condition is checked for betting
                            {
                                guy.Collect(winningCycle);
                                guy.MyBet = null;
                                guy.UpdateLabels();
                            }
                        }

                        foreach (TrackSetup cycle in cycles)
                        {
                            cycle.TakeStartingPosition();
                        }

                        break;
                    }
                }

            }

            btnRace.Enabled = true;//here race button is enabled when race is finished

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
