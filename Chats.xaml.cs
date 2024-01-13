namespace da_bbeest_aappp;
using System.Collections.ObjectModel;

public partial class Chats : ContentPage
{
    public ObservableCollection<ChatUser> ChatUsers { get; set; }

    public Chats()
    {
        InitializeComponent();

        ChatUsers = new ObservableCollection<ChatUser>
        {
           new ChatUser { Name = "Melonhead", ImagePath = "pfp1.png" },
    new ChatUser { Name = "Java Jive", ImagePath = "pfp2.jpg" },
    new ChatUser { Name = "Rizzmaster", ImagePath = "pfp3.png" },
    new ChatUser { Name = "Sunny Em", ImagePath = "pfp4.png" },
    new ChatUser { Name = "Chillax Dude", ImagePath = "pfp5.png" },
    new ChatUser { Name = "Homework Hater", ImagePath = "pfp6.png" },
    new ChatUser { Name = "Brogrammer", ImagePath = "pfp7.png" },
    new ChatUser { Name = "Stack Underflow", ImagePath = "pfp8.png" },
    new ChatUser { Name = "Zoe", ImagePath = "pfp9.png" },
    new ChatUser { Name = "Cool Kyle", ImagePath = "pfpa.png" },
    new ChatUser { Name = "Noel Niemand", ImagePath = "pfpb.png" },
    new ChatUser { Name = "Nick Noob", ImagePath = "pfpc.png" },
            
        };

        BindingContext = this;
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedUser = e.CurrentSelection.FirstOrDefault() as ChatUser;
        if (selectedUser != null)
        {
            await Shell.Current.GoToAsync($"///ChatDetailPage?name={Uri.EscapeDataString(selectedUser.Name)}&imagePath={Uri.EscapeDataString(selectedUser.ImagePath)}");
        }
    }
}
