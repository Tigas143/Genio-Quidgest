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
using GenioMVC.ViewModels.Airln;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER AIRLN]/

namespace GenioMVC.Controllers
{
	public partial class AirlnController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AIRLN_CANCEL = new("AIRLINE57868", "Airln_Cancel", "Airln") { vueRouteName = "form-AIRLN", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AIRLN_SHOW = new("AIRLINE57868", "Airln_Show", "Airln") { vueRouteName = "form-AIRLN", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AIRLN_NEW = new("AIRLINE57868", "Airln_New", "Airln") { vueRouteName = "form-AIRLN", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AIRLN_EDIT = new("AIRLINE57868", "Airln_Edit", "Airln") { vueRouteName = "form-AIRLN", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AIRLN_DUPLICATE = new("AIRLINE57868", "Airln_Duplicate", "Airln") { vueRouteName = "form-AIRLN", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AIRLN_DELETE = new("AIRLINE57868", "Airln_Delete", "Airln") { vueRouteName = "form-AIRLN", mode = "DELETE" };

		#endregion

		#region Airln private

		private void FormHistoryLimits_Airln()
		{

		}

		#endregion

		#region Airln_Show

// USE /[MANUAL PJF CONTROLLER_SHOW AIRLN]/

		[HttpPost]
		public ActionResult Airln_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airln_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airln_Show_GET",
				AreaName = "airln",
				Location = ACTION_AIRLN_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Airln();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW AIRLN]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Airln_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET AIRLN]/
		[HttpPost]
		public ActionResult Airln_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Airln_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airln_New_GET",
				AreaName = "airln",
				FormName = "AIRLN",
				Location = ACTION_AIRLN_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Airln();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW AIRLN]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Airln/Airln_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST AIRLN]/
		[HttpPost]
		public ActionResult Airln_New([FromBody]Airln_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airln_New",
				ViewName = "Airln",
				AreaName = "airln",
				Location = ACTION_AIRLN_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW AIRLN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX AIRLN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX AIRLN]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Airln_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET AIRLN]/
		[HttpPost]
		public ActionResult Airln_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airln_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airln_Edit_GET",
				AreaName = "airln",
				FormName = "AIRLN",
				Location = ACTION_AIRLN_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Airln();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT AIRLN]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Airln/Airln_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST AIRLN]/
		[HttpPost]
		public ActionResult Airln_Edit([FromBody]Airln_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airln_Edit",
				ViewName = "Airln",
				AreaName = "airln",
				Location = ACTION_AIRLN_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT AIRLN]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT AIRLN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX AIRLN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX AIRLN]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Airln_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET AIRLN]/
		[HttpPost]
		public ActionResult Airln_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airln_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airln_Delete_GET",
				AreaName = "airln",
				FormName = "AIRLN",
				Location = ACTION_AIRLN_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Airln();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE AIRLN]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Airln/Airln_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST AIRLN]/
		[HttpPost]
		public ActionResult Airln_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Airln_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Airln_Delete",
				ViewName = "Airln",
				AreaName = "airln",
				Location = ACTION_AIRLN_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE AIRLN]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Airln_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AIRLN");
		}

		#endregion

		#region Airln_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET AIRLN]/

		[HttpPost]
		public ActionResult Airln_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Airln_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Airln_Duplicate_GET",
				AreaName = "airln",
				FormName = "AIRLN",
				Location = ACTION_AIRLN_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE AIRLN]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Airln/Airln_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST AIRLN]/
		[HttpPost]
		public ActionResult Airln_Duplicate([FromBody]Airln_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airln_Duplicate",
				ViewName = "Airln",
				AreaName = "airln",
				Location = ACTION_AIRLN_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE AIRLN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX AIRLN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX AIRLN]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Airln_Cancel

		//
		// GET: /Airln/Airln_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET AIRLN]/
		public ActionResult Airln_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Airln(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("airln");

// USE /[MANUAL PJF BEFORE_CANCEL AIRLN]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL AIRLN]/

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

				Navigation.SetValue("ForcePrimaryRead_airln", "true", true);
			}

			Navigation.ClearValue("airln");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Airln/Airln_CityValCity
		// POST: /Airln/Airln_CityValCity
		[ActionName("Airln_CityValCity")]
		public ActionResult Airln_CityValCity([FromBody]RequestLookupModel requestModel)
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
			Airln_CityValCity_ViewModel model = new Airln_CityValCity_ViewModel(UserContext.Current);

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
		// GET: /Airln/Airln_AirhbValName
		// POST: /Airln/Airln_AirhbValName
		[ActionName("Airln_AirhbValName")]
		public ActionResult Airln_AirhbValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_airhb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_airhb");
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
			Airln_AirhbValName_ViewModel model = new Airln_AirhbValName_ViewModel(UserContext.Current);

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


		// POST: /Airln/Airln_SaveEdit
		[HttpPost]
		public ActionResult Airln_SaveEdit([FromBody]Airln_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Airln_SaveEdit",
				ViewName = "Airln",
				AreaName = "airln",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT AIRLN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT AIRLN]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
