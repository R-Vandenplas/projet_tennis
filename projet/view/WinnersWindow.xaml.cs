using System.Collections.Generic;
using System.Windows;
using System;
using System.Windows.Controls;
using projet.modele;

namespace projet.view
{
    public partial class WinnersWindow : Window
    {
       
        private Tournament tournament;


        public WinnersWindow(Tournament tournament)
        {
            InitializeComponent();
            this.tournament = tournament;

            // Display winners for each schedule type
            DisplayWinners();
        }

        private void DisplayWinners()
        {
            foreach (Schedule schedule in tournament.Schedules)
            {
                // Get the winner for the current schedule
                Opponent winner = schedule.GetWinner();

                // Create a WinnerInfo object to store the winner text and schedule type
                WinnerInfo winnerInfo = new WinnerInfo
                {
                    WinnerText = $"Winner for {schedule.Type}: {winner?.ToString() ?? "No Winner"}",
                    ScheduleType = schedule.Type
                };

                // Add the WinnerInfo object to the ListBox
                winnersListBox.Items.Add(winnerInfo);
            }
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            // Close the WinnersWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void ShowRankingButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the "Show Ranking" button click
            Button clickedButton = (Button)sender;

            // Extract the WinnerInfo object from the button's tag
            if (clickedButton.Tag is ScheduleType scheduleType1)
            {
                // Access the schedule type from the WinnerInfo object
                ScheduleType scheduleType = scheduleType1;

                // Navigate to the RankingWindow and pass the schedule type
                PlayerRankingWindow rankingWindow = new PlayerRankingWindow(tournament, scheduleType);
                rankingWindow.Show();
                this.Close();
            }
            else
            {
                // Handle the case where the button's tag is not of type WinnerInfo
                MessageBox.Show("Invalid button tag.");
            }
        }
    } 
}

