using System.Collections.Generic;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// PJF_Menu_11 Dashboard Viewmodel
	/// </summary>
	public class PJF_Menu_11_ViewModel : DashboardViewModel
	{
		public override string Uuid => "5d6542bb-4360-47f2-83d2-3e615c6bcaee";


		public PJF_Menu_11_ViewModel(UserContext userContext): base(userContext)
		{
			RoleToShow = CSGenio.framework.Role.AUTHORIZED;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
			};

			WidgetProviders =
			[
				new CustomWidgetProvider<CSGenio.business.CSGenioAfligh>
				{
					Id = "FLIGHT",
					Order = 2,
					Width = 6,
					Height = 5,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Group = "_FLIGHT",
					Form = "WFLIGHTS",
					Component = "QFormWflights",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAfligh>,
					ColoredLeftBorder = true,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.CSGenioAplane>
				{
					Id = "PLANES",
					Order = 1,
					Width = 6,
					Height = 5,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Group = "_PLANES",
					Form = "WPLANE",
					Component = "QFormWplane",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAplane>,
					ColoredLeftBorder = true,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			];

			IndependentWidgetInstances =
			[
			];
		}
	}
}
