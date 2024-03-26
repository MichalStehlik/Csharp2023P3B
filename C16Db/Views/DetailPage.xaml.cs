using C16Db.Models;

namespace C16Db.Views;

[QueryProperty(nameof(Item), "item")]
public partial class DetailPage : ContentPage
{
	private ShoppingItem _item;
	public ShoppingItem Item {
		get {return _item;}
		set { _item = value; OnPropertyChanged(); }
	}
	public DetailPage()
	{
		InitializeComponent();
        BindingContext = (Application.Current.MainPage! as AppShell).MVM;
		lblName.Text = Item.Name;
	}
}