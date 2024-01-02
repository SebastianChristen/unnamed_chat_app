namespace da_bbeest_aappp;

public partial class Chats : ContentPage
{
	public Chats()
	{
		InitializeComponent();
	}

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as string;
        if (currentSelection != null)
        {
            // Use absolute routing with the triple-slash (///)
            await Shell.Current.GoToAsync($"///ChatDetailPage?name={Uri.EscapeDataString(currentSelection)}");
        }
    }

}