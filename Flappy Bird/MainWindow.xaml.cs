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
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bird bird;
        Pipe pipe1;
        Pipe pipe2;
        Pipe pipe3;
        Pipe pipe4;
        Pipe pipe5;
        Pipe pipe6;
        PipeReverse piperev1;
        PipeReverse piperev2;
        PipeReverse piperev3;
        PipeReverse piperev4;
        PipeReverse piperev5;
        PipeReverse piperev6;

        Canvas canvas = new Canvas();

        public MainWindow()
        {
            InitializeComponent();
            PrepareScreen();

            // Get keyboard input
            EventManager.RegisterClassHandler(typeof(Window),
                    Keyboard.KeyDownEvent, new KeyEventHandler(keyDown), true);
        }


        private void PrepareScreen()
        {
            this.WindowState = System.Windows.WindowState.Maximized; // big screen

            //Background:
            BitmapImage mybackground = new BitmapImage(new Uri("C:/Users/thais/OneDrive/Documents/Thaïs Life/Esilv/3 - VIC/POO/Flappy Bird/Background.png", UriKind.Absolute));
            ImageBrush fond = new ImageBrush(mybackground);
            canvas.Background = fond;
            this.Content = canvas; //telling to the application that the canvas created is stored in the main window

            //Show the score
            TextBlock showscore = new TextBlock();
            showscore.Text = "SCORE = 0 ";
            Color color = Color.FromRgb(255, 0, 0);
            showscore.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(showscore, 20);
            Canvas.SetTop(showscore, 20);
            canvas.Children.Add(showscore);

            //Add bird
            bird = new Bird(250, 250, 0, showscore); //donner une valeur à l'attribut
            canvas.Children.Add(bird);

            //Add pipes
            pipe1 = new Pipe(400, 400, bird, canvas);
            canvas.Children.Add(pipe1);
            pipe2 = new Pipe(700, 400, bird, canvas);
            canvas.Children.Add(pipe2);
            pipe3 = new Pipe(1000, 400, bird, canvas);
            canvas.Children.Add(pipe3);
            pipe4 = new Pipe(1300, 400, bird, canvas);
            canvas.Children.Add(pipe4);
            pipe5 = new Pipe(1600, 400, bird, canvas);
            canvas.Children.Add(pipe5);
            pipe6 = new Pipe(1900, 400, bird, canvas);
            canvas.Children.Add(pipe6);

            //Add pipesrev
            piperev1 = new PipeReverse(400, 0, bird , canvas);
            canvas.Children.Add(piperev1);
            piperev2 = new PipeReverse(700, 0, bird, canvas);
            canvas.Children.Add(piperev2);
            piperev3 = new PipeReverse(1000, 0, bird, canvas);
            canvas.Children.Add(piperev3);
            piperev4 = new PipeReverse(1300, 0, bird, canvas);
            canvas.Children.Add(piperev4);
            piperev5 = new PipeReverse(1600, 0, bird, canvas);
            canvas.Children.Add(piperev5);
            piperev6 = new PipeReverse(1900, 0, bird, canvas);
            canvas.Children.Add(piperev6);

            //Add threads
            Thread thread = new Thread(bird.automaticDown);
            thread.Start();
            
            Pipe[] pipeArray = new Pipe[6] { pipe1, pipe2, pipe3, pipe4, pipe5, pipe6 };
            PipeReverse[] pipeReverseArray = new PipeReverse[6] { piperev1, piperev2, piperev3, piperev4, piperev5, piperev6 };
            Board board = new Board(pipeArray, pipeReverseArray, bird, canvas);
            Thread thread1 = new Thread(board.automaticLeft);
            thread1.Start();

        }


        private void keyDown(object sender, KeyEventArgs e) //method to make the bird flies
        {
            if (e.Key == Key.Up)
            {
                bird.moveBird(-40);
            }
        }

    }
}
