using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 50; i++)
            {
                
                Set set = new Set();
                int winner = set.Play();
                if (winner == 1)
                {
                    Console.WriteLine("Le joueur 1 a gagné");
                    Console.WriteLine($"score du match : {set.ScoreOp1}  {set.ScoreOp2}");
                }
                else
                {
                    Console.WriteLine("Le joueur 2 a gagné");
                    Console.WriteLine($"score du match : {set.ScoreOp2}  {set.ScoreOp1}");
                }
            }

        }
    }
}
