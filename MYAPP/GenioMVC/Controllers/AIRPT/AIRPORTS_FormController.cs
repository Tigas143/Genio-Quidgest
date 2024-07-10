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
using GenioMVC.ViewModels.Airpt;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER AIRPT]/

namespace GenioMVC.Controllers
{
	public partial class AirptController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AIRPORTS_CANCEL = new("AIRPORT52716", "Airports_Cancel", "Airpt") { vueRouteName = "form-AIRPORTS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AIRPORTS_SHOW = new("AIRPORT52716", "Airports_Show", "Airpt") { vueRouteName = "form-AIRPORTS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AIRPORTS_NEW = new("AIRPORT52716", "Airports_New", "Airpt") { vueRouteName = "form-AIRPORTS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AIRPORTS_EDIT = new("AIRPORT52716", "Airports_Edit", "Airpt") { vueRouteName = "form-AIRPORTS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AIRPORTS_DUPLICATE = new("AIRPORT52716", "Airports_Duplicate", "Airpt") { vueRouteName = "form-AIRPORTS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AIRPORTS_DELETE = new("AIRPORT52716", "Airports_Delete", "Airpt") { vueRouteName = "form-AIRPORTS", mode = "DELETE" };

		#endregion

		#region Airports private

		private void FormHistoryLimits_Airports()
		{

		}

		#endregion

		#region Airports_Show

// USE /[MANUAL PJF CONTROLLER_SHOW AIRPORTS]/

		[HttpPost]
		public ActionResult Airports_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airports_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airports_Show_GET",
				AreaName = "airpt",
				Location = ACTION_AIRPORTS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Airports();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW AIRPORTS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Airports_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Airports_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airports_New_GET",
				AreaName = "airpt",
				FormName = "AIRPORTS",
				Location = ACTION_AIRPORTS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Airports();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW AIRPORTS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Airpt/Airports_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_New([FromBody]Airports_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airports_New",
				ViewName = "Airports",
				AreaName = "airpt",
				Location = ACTION_AIRPORTS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW AIRPORTS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX AIRPORTS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX AIRPORTS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Airports_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airports_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airports_Edit_GET",
				AreaName = "airpt",
				FormName = "AIRPORTS",
				Location = ACTION_AIRPORTS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Airports();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT AIRPORTS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Airpt/Airports_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_Edit([FromBody]Airports_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airports_Edit",
				ViewName = "Airports",
				AreaName = "airpt",
				Location = ACTION_AIRPORTS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT AIRPORTS]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT AIRPORTS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX AIRPORTS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX AIRPORTS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Airports_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airports_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airports_Delete_GET",
				AreaName = "airpt",
				FormName = "AIRPORTS",
				Location = ACTION_AIRPORTS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Airports();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE AIRPORTS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Airpt/Airports_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airports_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Airports_Delete",
				ViewName = "Airports",
				AreaName = "airpt",
				Location = ACTION_AIRPORTS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE AIRPORTS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Airports_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AIRPORTS");
		}

		#endregion

		#region Airports_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET AIRPORTS]/

		[HttpPost]
		public ActionResult Airports_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Airports_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airports_Duplicate_GET",
				AreaName = "airpt",
				FormName = "AIRPORTS",
				Location = ACTION_AIRPORTS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE AIRPORTS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Airpt/Airports_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST AIRPORTS]/
		[HttpPost]
		public ActionResult Airports_Duplicate([FromBody]Airports_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airports_Duplicate",
				ViewName = "Airports",
				AreaName = "airpt",
				Location = ACTION_AIRPORTS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE AIRPORTS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX AIRPORTS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX AIRPORTS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Airports_Cancel

		//
		// GET: /Airpt/Airports_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET AIRPORTS]/
		public ActionResult Airports_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Airpt(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("airpt");

// USE /[MANUAL PJF BEFORE_CANCEL AIRPORTS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL AIRPORTS]/

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

				Navigation.SetValue("ForcePrimaryRead_airpt", "true", true);
			}

			Navigation.ClearValue("airpt");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Airpt/Airports_CityValCity
		// POST: /Airpt/Airports_CityValCity
		[ActionName("Airports_CityValCity")]
		public ActionResult Airports_CityValCity([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_city")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_city");
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
			Airports_CityValCity_ViewModel model = new Airports_CityValCity_ViewModel(UserContext.Current);

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


		// POST: /Airpt/Airports_SaveEdit
		[HttpPost]
		public ActionResult Airports_SaveEdit([FromBody]Airports_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airports_SaveEdit",
				ViewName = "Airports",
				AreaName = "airpt",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT AIRPORTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT AIRPORTS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
