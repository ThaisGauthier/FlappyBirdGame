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
    class MasterPipe : Image
    {
        public int x;//position
        public int y;
        public Bird bird;
        public Canvas canvas;


        public int getx()
        { return x; }
        public void setx(int newx)
        { x = newx; }

        public int gety()
        { return y; }
        public void sety(int newy)
        { y = newy; }


        public void changepositionx(int change)
        {
            x = x + change;
        }

        //method that allows to reuse each pipes in continuous
        public void movePipe(int newPosition)
        {
            Canvas.SetLeft(this, Canvas.GetLeft(this) + newPosition);
            changepositionx(newPosition);
            if (x == 200)
            {
                bird.setscore();
                canvas.Children.Remove(bird.getshowscore());
                bird.setshowscore();
                Color color = Color.FromRgb(255, 0, 0);
                bird.getshowscore().Foreground = new SolidColorBrush(color);
                Canvas.SetLeft(bird.getshowscore(), 20);
                Canvas.SetTop(bird.getshowscore(), 20);
                canvas.Children.Add(bird.getshowscore());
            }
            if (x == -100)
            {
                changepositionx(1500);
                Canvas.SetLeft(this, Canvas.GetLeft(this) + 1500);
            }
        }


    }
}
