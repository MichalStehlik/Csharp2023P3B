namespace C16Db.Views;

public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
        BindingContext = (Application.Current.MainPage! as AppShell).MVM;
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void Save_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}