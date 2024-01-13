using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace da_bbeest_aappp;

[QueryProperty("Name", "name")]
[QueryProperty("ImagePath", "imagePath")]
public partial class ChatDetailPage : ContentPage, INotifyPropertyChanged
{
    private string _name;
    private string _imagePath;

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged(nameof(Name));
                LoadChat(_name);
            }
        }
    }

    public string ImagePath
    {
        get => _imagePath;
        set
        {
            if (_imagePath != value)
            {
                _imagePath = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged(nameof(ImagePath));
                LoadChat(_name); 
            }
        }
    }

    public ObservableCollection<MessageViewModel> MessageViewModels { get; set; }

    public ChatDetailPage()
    {
        InitializeComponent();
        MessageViewModels = new ObservableCollection<MessageViewModel>();
        MessagesCollectionView.ItemsSource = MessageViewModels;
    }

    private void LoadChat(string name)
    {
        NameLabel.Text = name;
        MessageViewModels.Clear();
        MessageViewModels.Add(new MessageViewModel { Text = "Hallo!", IsIncoming = true, SenderImage = ImagePath });
        MessageViewModels.Add(new MessageViewModel { Text = "Wie gehts?", IsIncoming = false, SenderImage = ImagePath });
        
    }

    private void OnSendClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(MessageEntry.Text))
        {
            MessageViewModels.Add(new MessageViewModel { Text = MessageEntry.Text, IsIncoming = false, SenderImage = ImagePath });
            MessageEntry.Text = string.Empty;
            MessageErrorLabel.IsVisible = false;
            MessagesCollectionView.ScrollTo(MessageViewModels.Count - 1);
        }
        else
        {
            MessageErrorLabel.IsVisible = true;
        }
    }

    private void MessageEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        MessageErrorLabel.IsVisible = false;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Chats");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class MessageViewModel : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public bool IsIncoming { get; set; }

        private string _senderImage;
        public string SenderImage
        {
            get => _senderImage;
            set
            {
                if (_senderImage != value)
                {
                    _senderImage = value;
                    OnPropertyChanged(nameof(SenderImage));
                }
            }
        }

        public LayoutOptions HorizontalLayoutOptions => IsIncoming ? LayoutOptions.Start : LayoutOptions.End;
        public bool IsNotIncoming => !IsIncoming;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
