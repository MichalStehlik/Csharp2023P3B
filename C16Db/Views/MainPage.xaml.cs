using C16Db.Models;

namespace C16Db.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = (Application.Current.MainPage! as AppShell).MVM;
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AddPage));
        }

        private void btnDetail_Clicked(object sender, EventArgs e)
        {
            ShoppingItem item = new ShoppingItem { Name = "Jahoda" };
            //Shell.Current.GoToAsync(
            //    nameof(DetailPage),
            //   new Dictionary<string, object>
            //   {
            //      { "item", item}
            //  });
            Shell.Current.GoToAsync($"DetailPage?item={item}");
        }

        private void lvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ShoppingItem;
            if (selectedItem is not ShoppingItem)
            {
                return;
            }
            var navigationParameter = new Dictionary<string, object>
            {
                { "value", selectedItem.Id }
            };
            Shell.Current.GoToAsync($"DetailPage?value=franc");
            //Shell.Current.GoToAsync(nameof(DetailPage), navigationParameter);
        }
    }
}