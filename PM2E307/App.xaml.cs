using PM2E307.Controllers;

namespace PM2E307 {
    public partial class App : Application {
        public static FirebaseController db = new FirebaseController();


        public App() {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
