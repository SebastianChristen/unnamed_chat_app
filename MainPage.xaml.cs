namespace da_bbeest_aappp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            // if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void GoToChatsButton_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                // Navigate to the Chats page
                await Shell.Current.GoToAsync("///Chats");
            }
            else
            {
                // Show error message
                ErrorLabel.IsVisible = true;
            }
        }

        private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if the new text value is not null or whitespace
            bool hasText = !string.IsNullOrWhiteSpace(e.NewTextValue);
            GoToChatsButton.IsEnabled = hasText;
            ErrorLabel.IsVisible = !hasText;
        }
    }
}