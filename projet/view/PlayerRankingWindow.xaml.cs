using System.Collections.Generic;
using System.Windows;

namespace projet.view
{
    public partial class PlayerRankingWindow : Window
    {
       
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


    }
}