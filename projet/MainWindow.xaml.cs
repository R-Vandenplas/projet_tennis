using System.Collections.Generic;
using System.Windows;
using projet.view;

namespace projet
{
    public partial class MainWindow : Window
    {
        // Static property to store the current tournament instance
        public static Tournament CurrentTournament { get; private set; } = new Tournament(1,"default");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchTournament_Click(object sender, RoutedEventArgs e)
        {
            // Get tournament name from TextBox
            string tournamentName = tournamentNameTextBox.Text;

            // Validate if tournament name is entered
            if (string.IsNullOrWhiteSpace(tournamentName))
            {
                MessageBox.Show("Please enter a valid tournament name.");
                return;
            }

            // Create and play the tournament
            CurrentTournament = new Tournament(idTournament: 1, name: tournamentName);
            CurrentTournament.Play();

             // ListBox before adding winners
            // List<string> winnersListBox = new List<string>();

             // Display winners by schedule type
           /*  foreach (Schedule schedule in CurrentTournament.Schedules)
             {
                 string winnerText = $"Winner for {schedule.Type}: {schedule.GetWinner()?.ToString() ?? "No Winner"}";
                 winnersListBox.Add(winnerText);
             }
           */


            // Show winners in WinnersWindow
           /* WinnersWindow winnersWindow = new WinnersWindow(winnersListBox);*/
            WinnersWindow winnersWindow = new WinnersWindow(CurrentTournament);
            winnersWindow.Show();
        }

       /* private void LaunchTournament_Click(object sender, RoutedEventArgs e)
        {
            // Get tournament name from TextBox
            string tournamentName = tournamentNameTextBox.Text;

            List<Opponent> winnersListBox = new List<Opponent>();

            // Validate if tournament name is entered
            if (string.IsNullOrWhiteSpace(tournamentName))
            {
                MessageBox.Show("Please enter a valid tournament name.");
                return;
            }

            // Create and play the tournament
            CurrentTournament = new Tournament(idTournament: 1, name: tournamentName);
            CurrentTournament.Play();


            // Display winners by schedule type
             foreach (Schedule schedule in CurrentTournament.Schedules)
            {
                Opponent op = schedule.GetWinner();
                winnersListBox.Add(op);
            }

           

            // Show winners in WinnersWindow
            WinnersWindow winnersWindow = new WinnersWindow(winnersList);
            winnersWindow.Show();
        }*/

    }
}
