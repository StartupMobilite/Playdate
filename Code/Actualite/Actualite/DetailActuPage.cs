using System;

using Xamarin.Forms;

namespace Actualite
{
	public class DetailActuPage : ContentPage
	{
		public DetailActuPage ()
		{


			var webimage = new Image { Aspect = Aspect.AspectFit };
			webimage.Source = ImageSource.FromUri (new Uri ("http://nouvellecaledonie.la1ere.fr/sites/regions_outremer/files/styles/top_big/public/assets/images/2015/08/18/actu-en-bref2015_660x367_1.png?itok=MrFW1r47"));

			StackLayout stackLayout = new StackLayout
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
					new Image
					{
						Source = webimage.Source
					},
					new Label
					{
						Text = "1er Actu !!!"
					}
				}
			};

			this.Content = stackLayout;
		}
	}
}