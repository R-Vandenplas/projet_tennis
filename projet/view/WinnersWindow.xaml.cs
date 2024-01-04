using System.Collections.Generic;
using System.Windows;
using System;
using System.Windows.Controls;



namespace projet.view
{
    public partial class WinnersWindow : Window
    {
        private List<string> winnersList = new List<string>();

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

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            // Close the WinnersWindow
            this.Close();


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
        }


    }
}

