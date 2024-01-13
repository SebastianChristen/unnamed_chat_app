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

        }

        private async void GoToChatsButton_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                await Shell.Current.GoToAsync("///Chats");
            }
            else
            {
                ErrorLabel.IsVisible = true;
            }
        }

        private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool hasText = !string.IsNullOrWhiteSpace(e.NewTextValue);
            GoToChatsButton.IsEnabled = hasText;
            ErrorLabel.IsVisible = !hasText;
        }
    }
}