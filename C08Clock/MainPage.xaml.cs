namespace C08Clock
{
    public partial class MainPage : ContentPage
    {
        private int number;
        public MainPage()
        {
            InitializeComponent();
            this.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            return true;
        }
    }
}