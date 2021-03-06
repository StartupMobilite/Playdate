﻿using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PlaysDate
{
	public class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		ListView listView;

		public MasterPage ()
		{
			var masterPageItems = new List<MasterPageItem> ();
			masterPageItems.Add (new MasterPageItem {
				Title = "Profil",
				//IconSource = "contacts.png",
				TargetType = typeof(ProfilPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Actualités",
				//IconSource = "Actualite.png",
				TargetType = typeof(ActualitePage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Calendrier",
				//IconSource = "contacts.png",
				TargetType = typeof(CalendrierPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Maps",
				//IconSource = "reminders.png",
				TargetType = typeof(MapPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Messagerie",
				//IconSource = "todo.png",
				TargetType = typeof(DefaultPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Deconnexion",
				//IconSource = "todo.png",
				TargetType = typeof(DeconnexionPage)

			});

			listView = new ListView {
				ItemsSource = masterPageItems,
				ItemTemplate = new DataTemplate (() => {
					var imageCell = new ImageCell ();
					imageCell.SetBinding (TextCell.TextProperty, "Title");
					imageCell.SetBinding (ImageCell.ImageSourceProperty, "IconSource");
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Padding = new Thickness (0, 40, 0, 0);
			//Icon = "hamburger.png";
			Title = "Menu";
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					listView
				}
			};
		}
	}
}