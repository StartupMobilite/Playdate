using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using Playsdate;

using Xamarin.Forms;
using XLabs.Platform.Services.Media;

namespace PlaysDate
{
	public partial class ConnexionPage : TabbedPage
	{
		private PersonneBaseDeDonnees _database;

		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

		private IMediaPicker mediaPicker;

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

			emailEntry.Text = "";

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

			return await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions 
				{ 
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

		public void OnInscriptionButtonClicked(object sender, EventArgs args)
		{
			_database = new PersonneBaseDeDonnees ();

			PersonBD pseudoExist = _database.GetData (userNameEntry.Text);

			//Gestion pour l'inscription
			Regex mailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

			Match mailMatch	= mailRegex.Match (emailEntry.Text);

			//Si tous les champs ne sont pas rempli, on renvoie un message d'erreur à l'utilisateur
			if (firstNameEntry.Text == null || lastNameEntry.Text == null || userNameEntry.Text == null || emailEntry.Text == null || passwordEntry.Text == null || VerifyPasswordEntry.Text == null || firstNameEntry.Text == "" || lastNameEntry.Text == "" || userNameEntry.Text == "" || emailEntry.Text == "" || passwordEntry.Text == "" || VerifyPasswordEntry.Text == "") 
			{
				erreurInscriptionMessageLabel.Text = "Vous devez remplir tous les champs !!!";
			}
			//Si l'addresse mail rentrer n'est pas valide, on renvoie un message d'erreur à l'utilisateur
			else if (!mailMatch.Success) 
			{
				erreurInscriptionMessageLabel.Text = "Adresse mail non valide !!!";
			}
			//Si le mot de passe et la verification de mot de passe ne corresponde pas, on renvoie un message d'erreur à l'utilisateur
			else if (passwordEntry.Text != VerifyPasswordEntry.Text)
			{
				erreurInscriptionMessageLabel.Text = "Les deux mot de passe ne sont pas les mêmes !!!";
			}
			//Si le pseudo existe deja, on renvoie un message d'erreur à l'utilisateur
			else if (pseudoExist != null)
			{
				erreurInscriptionMessageLabel.Text = "Ce pseudo existe déjà !";
			}
			//Sinon on effectue l'inscription dans la base de données
			else 
			{
				_database.AddData (firstNameEntry.Text, lastNameEntry.Text, userNameEntry.Text, emailEntry.Text, passwordEntry.Text);

				App.Current.MainPage = new ConnexionPage ();
			}
		}

		public void OnConnexionButtonClicked(object sender, EventArgs args)
		{
			//Gestion pour la connexion
			_database = new PersonneBaseDeDonnees ();

			PersonBD personExistForConnection = _database.PersonExistForConnexion(userNameConnexionEntry.Text, passwordConnexionEntry.Text);

			//Si tous les champs ne sont pas rempli, on renvoie un message d'erreur à l'utilisateur
			if (userNameConnexionEntry.Text == null || passwordConnexionEntry.Text == null || userNameConnexionEntry.Text == "" || passwordConnexionEntry.Text == "") 
			{
				erreurConnexionMessageLabel.Text = "Vous devez remplir tous les champs !!!";
			} 
			//Si le pseudo et/ou le mot de passe nexist(nt) pas dans la base de données, on revoie un message d'erreur à l'utilisateur
			else if (personExistForConnection == null)
			{
				erreurConnexionMessageLabel.Text = "Le pseudo et/ou le mot de passe n'existe(nt) pas !!!";
			}
			else 
			{
				App.Current.MainPage = new MainPage ();
			}
		}
	}
}