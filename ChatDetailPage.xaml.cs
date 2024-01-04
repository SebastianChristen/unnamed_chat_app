using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace da_bbeest_aappp;

[QueryProperty("Name", "name")]
public partial class ChatDetailPage : ContentPage
{
    // Define your MessageViewModel class inside ChatDetailPage for simplicity
    public class MessageViewModel : INotifyPropertyChanged
    {

        public string Text { get; set; }
        public bool IsIncoming { get; set; }
        public string SenderImage => "pfp.jpg";
        //public Color MessageColor => IsIncoming ? Color.Blue : Color.LightBlue;
        public LayoutOptions HorizontalLayoutOptions => IsIncoming ? LayoutOptions.Start : LayoutOptions.End;
        public bool IsNotIncoming => !IsIncoming;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public ObservableCollection<MessageViewModel> MessageViewModels { get; set; }

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

        MessageViewModels = new ObservableCollection<MessageViewModel>
        {
            new MessageViewModel { Text = "Hallo!", IsIncoming = true },
            new MessageViewModel { Text = "Wie gehts?", IsIncoming = false },
            new MessageViewModel { Text = "Gut, dir?", IsIncoming = true },
            new MessageViewModel { Text = "mir gehts gut", IsIncoming = false },
            new MessageViewModel { Text = "was machst du?", IsIncoming = true },
            // Add more messages here, setting IsIncoming appropriately
        };

        MessagesCollectionView.ItemsSource = MessageViewModels;
    }

    private void OnSendClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(MessageEntry.Text))
        {
            MessageViewModels.Add(new MessageViewModel { Text = MessageEntry.Text, IsIncoming = false });
            MessageEntry.Text = string.Empty;
            MessageErrorLabel.IsVisible = false;
            // Scroll to the new message
            MessagesCollectionView.ScrollTo(MessageViewModels.Count - 1);
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