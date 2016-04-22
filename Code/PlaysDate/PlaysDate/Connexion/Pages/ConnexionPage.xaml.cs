using Playsdate;

using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;

using Plugin.Media;
using Plugin.Media.Abstractions;

using Xamarin.Forms;

namespace PlaysDate
{
	public partial class ConnexionPage : TabbedPage
	{
		public static string personConnecte;

		public static string filePath;

		private PersonneBaseDeDonnees _database;

		public ConnexionPage()
		{
			InitializeComponent ();

			personConnecte = "";

			Poster.Source = ImageSource.FromFile("NoOne.jpg");

			var profilImage = new TapGestureRecognizer ();
			profilImage.Tapped += async (sender, e) => {
				
				var action =  await DisplayActionSheet("Choisir une action", "Annuler", null, "Phototheque", "Prendre une photo");

				if (action == "Phototheque") 
				{
					await SelectPicture();
				}
				else if (action == "Prendre une photo") 
				{
					await TakePicture();
				} 
				else 
				{
					Poster.Source = ImageSource.FromFile ("NoOne.jpg");
				}
			};

			emailEntry.Text = "";

			Poster.GestureRecognizers.Add(profilImage);
		}

		private async Task TakePicture()
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("Pas de Camera", "Camera non disponible.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
				{
					SaveToAlbum = true
				});

			if (file == null)
				return;

			await DisplayAlert("Emplacement du fichier", file.Path, "OK");

			Poster.Source = ImageSource.FromStream(() =>
				{
					var stream = file.GetStream();
					file.Dispose();
					return stream;
				}); 
		}

		private async Task SelectPicture()
		{
			var file = await CrossMedia.Current.PickPhotoAsync ();

			Poster.Source = ImageSource.FromStream(() =>
				{
					var stream = file.GetStream();
					file.Dispose();
					return stream;
				}); 
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
				personConnecte = userNameConnexionEntry.Text;

				App.Current.MainPage = new MainPage ();
			}
		}
	}
}