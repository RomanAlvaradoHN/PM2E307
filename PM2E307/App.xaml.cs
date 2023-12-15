using PM2E307.Controllers;
using PM2E307.Models;
using PM2E307.Views;
using Plugin.Maui.Audio;

namespace PM2E307 {
    public partial class App : Application {
        public static FirebaseController db = new FirebaseController();
        public static Notas nota;

        public App() {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new CapturaDatos(AudioManager.Current));
        }

    }
}
