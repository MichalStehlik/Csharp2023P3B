namespace C05FirstMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            lblValue.Text = Value.ToString();
            lblValue.FontSize = Value;
        }

        public int Value { get; set; } = 10;

        private void btnInc1_Clicked(object sender, EventArgs e)
        {
            Value += 1;
            lblValue.Text = Value.ToString();
            lblValue.FontSize = Value;
        }

        private void btnDec1_Clicked(object sender, EventArgs e)
        {
            Value -= 1;
            lblValue.Text = Value.ToString();
            lblValue.FontSize = Value;
        }

        private void btnDec5_Clicked(object sender, EventArgs e)
        {
            Value -= 5;
            lblValue.Text = Value.ToString();
            lblValue.FontSize = Value;
        }

        private void btnInc5_Clicked(object sender, EventArgs e)
        {
            Value += 5;
            lblValue.Text = Value.ToString();
            lblValue.FontSize = Value;
        }
    }
}