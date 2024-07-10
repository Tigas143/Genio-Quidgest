using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Route;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER ROUTE]/

namespace GenioMVC.Controllers
{
	public partial class RouteController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ROUTES_CANCEL = new("ROUTE59240", "Routes_Cancel", "Route") { vueRouteName = "form-ROUTES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ROUTES_SHOW = new("ROUTE59240", "Routes_Show", "Route") { vueRouteName = "form-ROUTES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ROUTES_NEW = new("ROUTE59240", "Routes_New", "Route") { vueRouteName = "form-ROUTES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ROUTES_EDIT = new("ROUTE59240", "Routes_Edit", "Route") { vueRouteName = "form-ROUTES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ROUTES_DUPLICATE = new("ROUTE59240", "Routes_Duplicate", "Route") { vueRouteName = "form-ROUTES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ROUTES_DELETE = new("ROUTE59240", "Routes_Delete", "Route") { vueRouteName = "form-ROUTES", mode = "DELETE" };

		#endregion

		#region Routes private

		private void FormHistoryLimits_Routes()
		{

		}

		#endregion

		#region Routes_Show

// USE /[MANUAL PJF CONTROLLER_SHOW ROUTES]/

		[HttpPost]
		public ActionResult Routes_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Routes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Routes_Show_GET",
				AreaName = "route",
				Location = ACTION_ROUTES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Routes();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW ROUTES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Routes_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET ROUTES]/
		[HttpPost]
		public ActionResult Routes_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Routes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Routes_New_GET",
				AreaName = "route",
				FormName = "ROUTES",
				Location = ACTION_ROUTES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Routes();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW ROUTES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Route/Routes_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST ROUTES]/
		[HttpPost]
		public ActionResult Routes_New([FromBody]Routes_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Routes_New",
				ViewName = "Routes",
				AreaName = "route",
				Location = ACTION_ROUTES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW ROUTES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX ROUTES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX ROUTES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Routes_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET ROUTES]/
		[HttpPost]
		public ActionResult Routes_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Routes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Routes_Edit_GET",
				AreaName = "route",
				FormName = "ROUTES",
				Location = ACTION_ROUTES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Routes();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT ROUTES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Route/Routes_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST ROUTES]/
		[HttpPost]
		public ActionResult Routes_Edit([FromBody]Routes_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Routes_Edit",
				ViewName = "Routes",
				AreaName = "route",
				Location = ACTION_ROUTES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT ROUTES]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT ROUTES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX ROUTES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX ROUTES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Routes_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET ROUTES]/
		[HttpPost]
		public ActionResult Routes_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Routes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Routes_Delete_GET",
				AreaName = "route",
				FormName = "ROUTES",
				Location = ACTION_ROUTES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Routes();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE ROUTES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Route/Routes_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST ROUTES]/
		[HttpPost]
		public ActionResult Routes_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Routes_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Routes_Delete",
				ViewName = "Routes",
				AreaName = "route",
				Location = ACTION_ROUTES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE ROUTES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Routes_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ROUTES");
		}

		#endregion

		#region Routes_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET ROUTES]/

		[HttpPost]
		public ActionResult Routes_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Routes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Routes_Duplicate_GET",
				AreaName = "route",
				FormName = "ROUTES",
				Location = ACTION_ROUTES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE ROUTES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Route/Routes_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST ROUTES]/
		[HttpPost]
		public ActionResult Routes_Duplicate([FromBody]Routes_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Routes_Duplicate",
				ViewName = "Routes",
				AreaName = "route",
				Location = ACTION_ROUTES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE ROUTES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX ROUTES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX ROUTES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Routes_Cancel

		//
		// GET: /Route/Routes_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET ROUTES]/
		public ActionResult Routes_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Route(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("route");

// USE /[MANUAL PJF BEFORE_CANCEL ROUTES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL ROUTES]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_route", "true", true);
			}

			Navigation.ClearValue("route");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Route/Routes_AirlnValName
		// POST: /Route/Routes_AirlnValName
		[ActionName("Routes_AirlnValName")]
		public ActionResult Routes_AirlnValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_airln")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_airln");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Routes_AirlnValName_ViewModel model = new Routes_AirlnValName_ViewModel(UserContext.Current);

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableConfigurationIO.DetermineTableConfig(
				UserContext.Current.PersistentSupport,
				UserContext.Current.User,
				model.Uuid,
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Route/Routes_AirscValName
		// POST: /Route/Routes_AirscValName
		[ActionName("Routes_AirscValName")]
		public ActionResult Routes_AirscValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_airsc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_airsc");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Routes_AirscValName_ViewModel model = new Routes_AirscValName_ViewModel(UserContext.Current);

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableConfigurationIO.DetermineTableConfig(
				UserContext.Current.PersistentSupport,
				UserContext.Current.User,
				model.Uuid,
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Route/Routes_AirdsValName
		// POST: /Route/Routes_AirdsValName
		[ActionName("Routes_AirdsValName")]
		public ActionResult Routes_AirdsValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_airds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_airds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Routes_AirdsValName_ViewModel model = new Routes_AirdsValName_ViewModel(UserContext.Current);

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableConfigurationIO.DetermineTableConfig(
				UserContext.Current.PersistentSupport,
				UserContext.Current.User,
				model.Uuid,
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}


		// POST: /Route/Routes_SaveEdit
		[HttpPost]
		public ActionResult Routes_SaveEdit([FromBody]Routes_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Routes_SaveEdit",
				ViewName = "Routes",
				AreaName = "route",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT ROUTES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT ROUTES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
