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
             List<string> winnersListBox = new List<string>();

             // Display winners by schedule type
             foreach (Schedule schedule in CurrentTournament.Schedules)
             {
                 string winnerText = $"Winner for {schedule.Type}: {schedule.GetWinner()?.ToString() ?? "No Winner"}";
                 winnersListBox.Add(winnerText);
             }

           /* // ListBox before adding winners
            List<(ScheduleType ScheduleType, string WinnerText)> winnersListBox = new List<(ScheduleType, string)>();

            // Display winners by schedule type
            foreach (Schedule schedule in CurrentTournament.Schedules)
            {
                string winnerText = $"{schedule.GetWinner()?.ToString() ?? "No Winner"}";
                winnersListBox.Add((schedule.Type, winnerText));
            }*/


            // Show winners in WinnersWindow
            WinnersWindow winnersWindow = new WinnersWindow(winnersListBox);
            winnersWindow.Show();
        }
    }
}
