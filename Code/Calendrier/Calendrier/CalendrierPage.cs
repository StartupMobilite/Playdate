using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Calendrier
{
	public class CalendrierPage : ContentPage
	{
		CalendarView calendarView;
		StackLayout stackLayout;

		public CalendrierPage ()
		{
			//Definition du titre de la page
			Title = "Planning";

			stackLayout = new StackLayout ();
			Content = stackLayout;

			//Definition du calendrier
			calendarView = new CalendarView
			{
				MinDate = CalendarView.FirstDayOfMonth(new DateTime(2014, 1, 1)),
				MaxDate = CalendarView.LastDayOfMonth(DateTime.Now.AddYears(2)),
				ShouldHighlightDaysOfWeekLabels = true,
				SelectionBackgroundStyle = CalendarView.BackgroundStyle.CircleFill,
				ShowNavigationArrows = true,
				HeightRequest= 800,
				WidthRequest= 800
			};

			//Ajout du calendrier dans la vue
			stackLayout.Children.Add(calendarView);

			//Evenement lorsque l'on clique sur une date
			calendarView.DateSelected += async (object sender, DateTime e) =>
			{
				await Navigation.PushModalAsync(new AjoutEvenement(e.ToString()));
			};

			//Ajoute des points si il y a des evenements a une date donnée
			
		}
	}
}