using System.Collections.Generic;
using System.Windows;
using System;
using System.Windows.Controls;
using projet.modele;

namespace projet.view
{
    public partial class WinnersWindow : Window
    {
        /* private List<string> winnersList = new List<string>();

         public WinnersWindow()
         {
             InitializeComponent();
         }

         public WinnersWindow(List<string> winnersList)
         {
             InitializeComponent();
             this.winnersList = winnersList;

             // Display winners in the ListBox
             foreach (string winner in winnersList)
             {
                 winnersListBox.Items.Add(winner);
             }
         }

         


         }
         private void ShowRanking_Click(object sender, RoutedEventArgs e)
         {
             // Get the selected schedule type from the button's Tag
             if (sender is Button button && button.Tag is ScheduleType selectedScheduleType)
             {
                 // Open the PlayerRankingWindow for the selected schedule type
                 PlayerRankingWindow playerRankingWindow = new PlayerRankingWindow(selectedScheduleType);
                 playerRankingWindow.Show();
             }
             else
             {
                 // Handle the case where the button or its Tag is null or not of type ScheduleType
                 MessageBox.Show("Invalid button or schedule type.");
             }
         }*/


        private Tournament tournament;
        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            // Close the WinnersWindow
           MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

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

