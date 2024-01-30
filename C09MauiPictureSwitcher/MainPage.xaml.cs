namespace C09MauiPictureSwitcher
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            SetImage(count);
        }

        private void SetImage(int val)
        { // 10 / 3 = 1 zb 1
            int imgIndex = val % 3;
            imgMain.Source = 
                "image" + imgIndex + ".jpg";
            /*
            switch (imgIndex)
            {
                case 0: imgMain.Source = "felicia.jpg"; break;
                case 1: imgMain.Source = "mercedes.jpg"; break;
                case 2: imgMain.Source = "ferrari.jpg"; break;
            }
            */
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            count++;
            SetImage(count);
        }
    }
}