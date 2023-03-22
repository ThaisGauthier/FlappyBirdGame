using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flappy_Bird
{
    class Bird : Image
    {
        //attribut
        private int x; //position
        private int y;
        private double score;
        private TextBlock showscore;


        public Bird(int x, int y, double score, TextBlock showscore) //Constructeur
        {
            Source = new BitmapImage(new Uri(@"/Ressources/Bird.png", UriKind.Relative));
            //Position of the image on the canvas
            Canvas.SetLeft(this, 250);
            Canvas.SetTop(this, 250);
            this.x = x; //sauvgarde la position
            this.y = y;
            this.score = score;
            this.showscore = showscore;
            //Height of the image
            this.Width = 130;
            this.Height = 130;
        }

        public int getx()
        { return x; }
        public void setx(int newx)
        { x = newx; }

        public int gety()
        { return y; }
        public void sety(int newy)
        { y = newy; }

        public double getscore()
        { return score; }
        public void setscore()
        { score = score + 0.5; }

        public TextBlock getshowscore()
        { return showscore; }
        public TextBlock setshowscore()
        { showscore.Text = "SCORE = " + score; return showscore; }


        public void changepositiony(int change)
        {
            y = y + change;
        }


        //Bird going down automatically
        public void automaticDown() 
        {
            while (true)
            {
                Thread.Sleep(300);
                this.Dispatcher.Invoke(() =>
                {
                    moveBird(30);
                });
            }
        }


        //position of the bird
        public void moveBird(int newPosition)
        {
            Canvas.SetTop(this, Canvas.GetTop(this) + newPosition);
            changepositiony(newPosition);
        }

    }
}