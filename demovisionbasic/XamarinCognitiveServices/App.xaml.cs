using Xamarin.Forms;

namespace XamarinCognitiveServices
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPageDemo();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

