using System;
using System.Collections.Generic;
using System.Windows;

namespace projet
{
    public partial class MainWindow : Window
    {
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
            Tournament currentTournament = new Tournament(idTournament: 1, name: tournamentName);
            currentTournament.Play();

            // Clear the ListBox before adding winners
            List<string> winnersListBox = new List<string>;
            winnersListBox.Items.Clear();

            // Display winners by schedule type
            foreach (Schedule schedule in currentTournament.Schedules)
            {
                string winnerText = $"Winner for {schedule.ScheduleType}: {schedule.GetWinner()?.ToString() ?? "No Winner"}";
                winnersListBox.Items.Add(winnerText);
            }

            // Show winners in MessageBox
            foreach (string winner in winnersListBox.Items)
            {
                MessageBox.Show(winner);
            }
        }
    }
}
