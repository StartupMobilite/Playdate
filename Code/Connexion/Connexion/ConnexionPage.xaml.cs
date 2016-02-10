using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Media;
using System.Threading.Tasks;

namespace Connexion
{
	public partial class ConnexionPage : TabbedPage
	{
		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

		private IMediaPicker mediaPicker;

		private string _status;

		public ConnexionPage()
		{
			InitializeComponent ();

			Poster.Source = ImageSource.FromFile("NoOne.jpg");

			var profilImage = new TapGestureRecognizer ();
			profilImage.Tapped += async (sender, e) => {
				System.Diagnostics.Debug.WriteLine("Image Clicked !!!");

				var action =  await DisplayActionSheet("Choose action", "Cancel", null, "Take a picture", "Choose a picture");

				if (action == "Choose a picture") 
				{
					await SelectPicture();
				}
				else if (action == "Take a picture") 
				{
					await TakePicture();
				} 
				else 
				{
					//Poster.Source = ImageSource.FromFile ("NoOne.jpg");
				}
			};

			Poster.GestureRecognizers.Add(profilImage);
		}

		private async Task SelectPicture()
		{

			mediaPicker = DependencyService.Get<IMediaPicker>();

			Poster.Source = null;
				
			try
			{
				var mediaFile = await mediaPicker.SelectPhotoAsync (new CameraMediaStorageOptions {
					DefaultCamera = CameraDevice.Front,
					MaxPixelDimension = 400
				});
				Poster.Source = ImageSource.FromStream (() => mediaFile.Source);
			}
			catch (System.Exception ex) 
			{
				Poster.Source = ImageSource.FromFile ("NoOne.jpg");
				System.Diagnostics.Debug.WriteLine("Erreur : " + ex.Message);
			}
		}
			
		private async Task<MediaFile> TakePicture()
		{
			Poster.Source = null;

			return await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { 
				DefaultCamera = CameraDevice.Front,
				MaxPixelDimension = 400 }).ContinueWith(t =>
				{
					if (t.IsFaulted)
					{
							Poster.Source = ImageSource.FromFile ("NoOne.jpg");
						//Status = t.Exception.InnerException.ToString();
					}
					else if (t.IsCanceled)
					{
							Poster.Source = ImageSource.FromFile ("NoOne.jpg");
						//Status = "Canceled";
					}
					else
					{
						var mediaFile = t.Result;

						Poster.Source = ImageSource.FromStream(() => mediaFile.Source);

						return mediaFile;
					}

					return null;
				}, _scheduler);
		}
	}
}