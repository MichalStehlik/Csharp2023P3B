using C16Db.ViewModels;
using C16Db.Views;

namespace C16Db
{
    public partial class AppShell : Shell
    {
        public MainViewModel MVM { get; } = new MainViewModel();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            BindingContext = MVM;
        }
    }
}