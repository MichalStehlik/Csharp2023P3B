using C10MauiNumbers.Services;

namespace C10MauiNumbers
{
    public partial class MainPage : ContentPage
    {
        int _number = 42;
        RESTService _rest = new RESTService();

        public MainPage()
        {
            InitializeComponent();
            sliNumber.Value = _number;
            lblNumber.Text = _number.ToString();
        }

        private void sliNumber_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _number = (int)e.NewValue;
            lblNumber.Text = _number.ToString();
        }

        private async void btnGo_Clicked(object sender, EventArgs e)
        {
            lblDescription.Text = await _rest.Fetch(_number.ToString());
        }
    }
}