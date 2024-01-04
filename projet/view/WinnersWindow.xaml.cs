using System.Collections.Generic;
using System.Windows;

namespace projet.view
{
    public partial class WinnersWindow : Window
    {
        private List<string> winnersList;

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
    }
}
