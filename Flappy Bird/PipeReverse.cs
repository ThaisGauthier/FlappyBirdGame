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
    class PipeReverse : MasterPipe
    {
        //Constructor
        public PipeReverse(int x, int y, Bird bird, Canvas canvas)
        {
            Source = new BitmapImage(new Uri(@"/Ressources/PipeReverse.png", UriKind.Relative));
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            this.x = x;
            this.y = y;
            this.bird = bird;
            this.canvas = canvas;
            this.Width = 200;
            this.Height = 200;
        }


    }
}