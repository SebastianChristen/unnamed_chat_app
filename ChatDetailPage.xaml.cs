using System.Collections.ObjectModel;

namespace da_bbeest_aappp;

[QueryProperty("Name", "name")]
public partial class ChatDetailPage : ContentPage

{
    public ObservableCollection<string> Messages { get; set; }

    private string name;
    public string Name
    {
        set
        {
            name = Uri.UnescapeDataString(value ?? string.Empty);
            LoadChat(name);
        }
    }

    public ChatDetailPage()
	{
		InitializeComponent();

        Messages = new ObservableCollection<string>
        {
            "Hallo!",
            "Wie gehts?",
            "Mir geht es gut, danke!",
            "Was machst du gerade?",
            "Ich arbeite an meinem .NET MAUI Projekt."
        };

        MessagesCollectionView.ItemsSource = Messages;
    }
    private void OnSendClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(MessageEntry.Text))
        {
            Messages.Add(MessageEntry.Text);
            MessageEntry.Text = string.Empty;
            MessageErrorLabel.IsVisible = false;
            // Scroll to the new message
            MessagesCollectionView.ScrollTo(Messages.Count - 1);
        }
        else
        {
            // Show error message
            MessageErrorLabel.IsVisible = true;
        }
    }

    private void MessageEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Hide error message when the user starts typing
        MessageErrorLabel.IsVisible = false;
    }

    private void LoadChat(string name)
    {
        // Set the text of the NameLabel to the passed name
        NameLabel.Text = name;

        // ... Load chat messages for the person with the given name ...
    }


    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Use Shell navigation to go back to the previous page in the navigation stack
        await Shell.Current.GoToAsync("///Chats");
    }



}