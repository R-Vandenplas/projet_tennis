using System.Collections.Generic;
using System.Windows;

namespace projet.view
{
    public partial class PlayerRankingWindow : Window
    {
        /*private ScheduleType scheduleType;

        public PlayerRankingWindow(ScheduleType scheduleType)
        {
            InitializeComponent();
            this.scheduleType = scheduleType;

            // Call the method to get player rankings for the specified schedule type
            List<string> playerRankings = GetPlayerRankings();

            // Display player rankings in the ListBox
            foreach (string ranking in playerRankings)
            {
                playerRankingListBox.Items.Add(ranking);
            }
        }

        private List<string> GetPlayerRankings()
        {
            Tournament tournament = MainWindow.CurrentTournament;

            // Check if the tournament is not null
            if (tournament != null)
            {
                // Find the schedule of the specified type in the tournament
                Schedule schedule = tournament.Schedules.Find(s => s.Type == scheduleType);

                if (schedule != null)
                {
                    // Call the GetPlayerRankings method for the found schedule
                    return schedule.GetPlayerRankings();
                }
            }

            return new List<string>(); // Return an empty list if the tournament or schedule is null
        }


        private void BackToWinnersWindow_Click(object sender, RoutedEventArgs e)
        {
            // Close the PlayerRankingWindow
            this.Close();
        }
    }*/

        private Tournament tournament;
        private ScheduleType scheduleType;
        private Schedule schedule;

        

        public PlayerRankingWindow(Tournament tournament, ScheduleType scheduleType)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.scheduleType = scheduleType;

            // Find the schedule of the specified type in the tournament
            this.schedule = tournament.Schedules.Find(s => s.Type == scheduleType);

            // Display the schedule type and player rankings
            DisplayRankings();
        }

        private void DisplayRankings()
        {

            scheduleTypeTextBlock.Text = $"Schedule Type: {scheduleType}";

            // Get the standings for the schedule
            var playerRankings = schedule.GetPlayerRankings();

            rankingsListBox.ItemsSource = playerRankings;
        }

        private void BackToWinnersWindow_Click(object sender, RoutedEventArgs e)
        {
            WinnersWindow winnersWindow = new WinnersWindow(tournament);
            winnersWindow.Show();
            this.Close();
        }


        /* private List<string> GetPlayerRankings(ScheduleType scheduleType)
         {
             // Implement the logic to get player rankings based on the schedule type
             // You may need to modify this method based on your data structure
             List<string> playerRankings = new List<string>();

             // Example: Iterate through players and create ranking strings
             foreach (Player player in tournament.Players)
             {
                 string rankingText = $"Rank: {player.Rank}, Player: {player.ToString()}";
                 playerRankings.Add(rankingText);
             }

             return playerRankings;
         }*/

    }
}