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
    class Board : Image
    {
        Pipe[] array;
        PipeReverse[] array2;
        Bird bird;
        Canvas canvas;

        public Board(Pipe [] array, PipeReverse [] array2, Bird bird, Canvas canvas) //Constructeur
        {
            this.array = array;
            this.array2 = array2;
            this.bird = bird;
            this.canvas = canvas;
            Source = new BitmapImage(new Uri(@"/Ressources/Pipe.png", UriKind.Relative));
        }

        public Pipe[] getarray()
        { return array; }
        public PipeReverse[] getarray2()
        { return array2; }

        //method that allows the pipe and piperev to move to the left
        public void automaticLeft()
        {
            while (true)
            {
                Thread.Sleep(150);
                this.Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].movePipe(-20); 
                        array2[i].movePipe(-20);

                        if ((bird.getx() > array[i].getx() && bird.getx() < array[i].getx() + 100 && bird.gety() > array[i].gety() - 100) || (bird.getx() > array2[i].getx() && bird.getx() < array2[i].getx() + 100 && bird.gety() < array2[i].gety() + 150) || (bird.gety() < 0 || bird.gety() > 500))
                        {
                            for(int j = 0; j < array.Length; j++)
                            {
                                array[j].movePipe(-1);
                                array2[j].movePipe(-1);
                            }
                            canvas.Children.Clear();
                            TextBlock endgame = new TextBlock();
                            endgame.Text = "GAME OVER " + "\n" + "Your score is " + bird.getscore();
                            Color color = Color.FromRgb(255, 0, 0);
                            endgame.Foreground = new SolidColorBrush(color);
                            Canvas.SetLeft(endgame, 600);
                            Canvas.SetTop(endgame, 400);
                            canvas.Children.Add(endgame);
                        }                 
                    }
                });
            }
        }


    }
}

