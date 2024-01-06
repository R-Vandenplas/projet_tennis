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


            // Show winners in WinnersWindow
            WinnersWindow winnersWindow = new WinnersWindow(CurrentTournament);
            winnersWindow.Show();
            this.Close();
        }

    }
}
