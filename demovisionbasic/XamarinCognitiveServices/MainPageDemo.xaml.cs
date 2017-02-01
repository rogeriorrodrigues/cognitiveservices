using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Plugin.Media;
using Xamarin.Forms;

namespace XamarinCognitiveServices
{
	public partial class MainPageDemo : ContentPage
	{
		public MainPageDemo()
		{
			InitializeComponent();
		}

		async void selectPicture()
		{
			if (CrossMedia.Current.IsPickPhotoSupported)
			{
				var image = await CrossMedia.Current.PickPhotoAsync();
				var stream = image.GetStream();
				SelectedImage.Source = ImageSource.FromStream(() =>
				{
					return stream;
				});
				var result = await GetImageDescription(image.GetStream());
				image.Dispose();
				foreach (string tag in result.Description.Tags)
				{
					InfoLabel.Text = InfoLabel.Text + "\n" + tag;
				}

			}
		}


		public async Task<AnalysisResult> GetImageDescription(Stream imageStream)
		{
			VisionServiceClient visionClient = new VisionServiceClient("SUA_CHAVE_AQUI");
			VisualFeature[] features = { VisualFeature.Tags, VisualFeature.Categories, VisualFeature.Description };
			return await visionClient.AnalyzeImageAsync(imageStream, features.ToList(), null);
		}


		void Handle_Clicked(object sender, System.EventArgs e)
		{
			selectPicture();
		}
	}
}
