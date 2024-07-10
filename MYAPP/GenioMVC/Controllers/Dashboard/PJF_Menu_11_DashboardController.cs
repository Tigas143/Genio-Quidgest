using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace GenioMVC.Controllers
{
	public partial class DashboardController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PJF_Menu_11 =
			new ("DASHBOARD51597", "PJF_Menu_11", "Dashboard");

		public ActionResult PJF_Menu_11()
		{
			DashboardViewModel vm = new PJF_Menu_11_ViewModel(UserContext.Current);
			vm.Load();

			bool isHomePage =
				RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			
			if (isHomePage)
				Navigation.SetValue("HomePage", "PJF_Menu_11");
			ViewBag.isHomePage = isHomePage;

			CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.Show);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return JsonERROR(result.Message);

			if (
				!isHomePage
				&& !Request.IsAjaxRequest()
				&& (
					Navigation.CurrentLevel == null
					|| !ACTION_PJF_Menu_11.IsSameAction(Navigation.CurrentLevel.Location)
				)
				&& Navigation.CurrentLevel.Location.Action != ACTION_PJF_Menu_11.Action
			)
				CSGenio.framework.Audit.registAction(
					UserContext.Current.User,
					Resources.Resources.MENU01948
						+ " "
						+ Navigation.CurrentLevel.Location.ShortDescription()
				);
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(
					UserContext.Current.User,
					Resources.Resources.MENU01948 + " " + ACTION_PJF_Menu_11.ShortDescription()
				);
			}

			return JsonOK(vm);
		}

		public ActionResult PJF_Menu_11_Save([FromBody]DashboardSaveRequest dto)
		{
			DashboardViewModel vm = new PJF_Menu_11_ViewModel(UserContext.Current);
			vm.Save(dto);

			return JsonOK();
		}

		public ActionResult PJF_Menu_11_GetWidgetData([FromBody]RequestWidgetModel requestModel)
		{
			DashboardViewModel vm = new PJF_Menu_11_ViewModel(UserContext.Current);
			object data = vm.GetWidgetData(requestModel.WidgetType, requestModel.WidgetId);

			return JsonOK(data);
		}
	}
}
