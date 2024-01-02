namespace da_bbeest_aappp;

[QueryProperty("Name", "name")]
public partial class ChatDetailPage : ContentPage

{

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
	}

    private void LoadChat(string name)
    {
        // Set the text of the NameLabel to the passed name
        NameLabel.Text = name;

        // ... Load chat messages for the person with the given name ...
    }






}