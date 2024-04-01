using C16Db.Models;

namespace C16Db.Views;

[QueryProperty(nameof(Value), "value")]
public partial class DetailPage : ContentPage
{
    private string _value = "xxx";
	public string Value {
		get {return _value;}
		set { _value = value; OnPropertyChanged(); }
	}
	public DetailPage()
	{
		InitializeComponent();
        BindingContext = (Application.Current.MainPage! as AppShell).MVM /*this*/;
        lblName.Text = Value.ToString();
    }
}