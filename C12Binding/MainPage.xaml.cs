using C12Binding.Model;

namespace C12Binding
{
    public partial class MainPage : ContentPage
    {
        public string Name { get; set; } = "Alice";

        public Human Tonda { get; set; }
        public MainPage()
        {
            Tonda = new Human { Name = "Antonín" };
            InitializeComponent();
            lblName.BindingContext = Tonda;
            //lblName.Text = Name;
            lblName.SetBinding(Label.TextProperty, nameof(Human.Name));
            entName.BindingContext = Tonda;
            entName.SetBinding(Entry.TextProperty, nameof(Human.Name), BindingMode.TwoWay);
        }

        private void btnRes_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                object x;
                if (Resources.TryGetValue("MainColor", out x))
                {
                    (sender as Button).BackgroundColor = (Color)x;
                }
            }
        }
    }
}