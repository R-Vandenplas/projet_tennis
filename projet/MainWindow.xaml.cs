using DAO;
using projet.DAO;
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

            /*Tournament tournament = new Tournament(1, "Roland Garros");
            Console.WriteLine($"date debut : {DateTime.Now}");
            tournament.Play();
            foreach (Schedule schedule in tournament.Schedules)
            {
                Console.WriteLine(schedule.GetWinner().ToString());
            }
            Console.WriteLine($"date fin : {tournament.Date}");

            */


        }

        private void LaunchTournament_Click(object sender, RoutedEventArgs e)
        {
            // Create and play the tournament
            currentTournament = new Tournament(idTournament: 1, name: "Roland Garros");
            currentTournament.Play();

            // Clear the ListBox before adding winners
            winnersListBox.Items.Clear();

            // Display winners by schedule type
            foreach (Schedule schedule in currentTournament.Schedules)
            {
                string winnerText = $"Winner for {schedule.ScheduleType}: {schedule.GetWinner()?.ToString() ?? "No Winner"}";
                winnersListBox.Items.Add(winnerText);
            }

        }

    }
}
