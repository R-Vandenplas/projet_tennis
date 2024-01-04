using System.Collections.Generic;
using System.Windows;

namespace projet.view
{
    public partial class PlayerRankingWindow : Window
    {
        private ScheduleType scheduleType;

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
    }

}
