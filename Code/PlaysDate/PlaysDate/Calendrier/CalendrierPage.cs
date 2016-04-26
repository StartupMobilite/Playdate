using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace PlaysDate
{
	public class CalendrierPage : ContentPage
	{
		CalendarView calendarView;
		RelativeLayout relativeLayout;
		StackLayout stackLayout;

		public CalendrierPage ()
		{
			//Definition du titre de la page
			Title = "Calendrier";

			relativeLayout = new RelativeLayout() {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			Content = relativeLayout;

			//Definition du calendrier
			calendarView = new CalendarView ()
			{
				MinDate = CalendarView.FirstDayOfMonth(DateTime.Now),
				MaxDate = CalendarView.LastDayOfMonth(DateTime.Now.AddMonths(3)),
				HighlightedDateBackgroundColor = Color.FromRgb(227	,227,	227	),
				ShouldHighlightDaysOfWeekLabels = false,
				SelectionBackgroundStyle = CalendarView.BackgroundStyle.CircleFill,
				TodayBackgroundStyle = CalendarView.BackgroundStyle.CircleOutline,
				HighlightedDaysOfWeek = new DayOfWeek[]{DayOfWeek.Saturday,DayOfWeek.Sunday},
				ShowNavigationArrows = true,
				MonthTitleFont = Font.OfSize("Open 24 Display St",NamedSize.Medium)
			};

			//Ajout du calendrier dans la vue
			relativeLayout.Children.Add(calendarView,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent(p => p.Width),
				Constraint.RelativeToParent(p => p.Height * 2/3));

			stackLayout = new StackLayout() {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			relativeLayout.Children.Add(stackLayout,
				Constraint.Constant(0),
				Constraint.RelativeToParent(p => p.Height *2/3),
				Constraint.RelativeToParent(p => p.Width),
				Constraint.RelativeToParent(p => p.Height *1/3)
			);

			//Evenement lorsque l'on clique sur une date
			calendarView.DateSelected += async (object sender, DateTime e) =>
			{
				await Navigation.PushAsync(new AjoutEvenement(e.ToString()));
			};

			//Ajoute des points si il y a des evenements a une date donnée

		}
	}
}