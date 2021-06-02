using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleRace
{
    class TrackSetup
    {
        //Global variables
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()//Run funtion for running the car pictures
        {
            MyRandom = new Random();//make a random variable
            int distance = MyRandom.Next(1, 5);//set the value of distance vaiable

            MoveMyPictureBox(distance);//calling the movepicturebox funtion

            Location += distance;//increasing the value of distance is assigned in location it means location is changed
            if (Location >= (RacetrackLength - StartingPosition))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()//this is for aetting the starting position
        {
            MoveMyPictureBox(-Location);
            Location = 0;
        }

        public void MoveMyPictureBox(int distance)//this function for moving the picture boxes
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
        }
    }
}
