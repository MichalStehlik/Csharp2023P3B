namespace C07Components
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //lblText.Text = Random.Shared.Next(100).ToString();
            lblText.Text = entText.Text.Length.ToString();
            vsLayout.Children.Add(new Border
            {
                BackgroundColor = Colors.Red,
                Content = new Label { Text = "Nový text" },
            });
        }

        private void btnGo_Clicked(object sender, EventArgs e)
        {
            lblText.Text = (sender as Button).Text;
        }

        private void entText_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblText.Text = entText.Text.Length.ToString();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            lblChecked.TextColor = (sender as CheckBox).IsChecked == true 
                ? 
                Colors.Red 
                : 
                Colors.Chocolate;
        }
    }
}