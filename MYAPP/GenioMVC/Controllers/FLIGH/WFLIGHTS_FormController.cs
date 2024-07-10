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
using GenioMVC.ViewModels.Fligh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER FLIGH]/

namespace GenioMVC.Controllers
{
	public partial class FlighController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_WFLIGHTS_CANCEL = new("FLIGHTS28324", "Wflights_Cancel", "Fligh") { vueRouteName = "form-WFLIGHTS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_WFLIGHTS_SHOW = new("FLIGHTS28324", "Wflights_Show", "Fligh") { vueRouteName = "form-WFLIGHTS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_WFLIGHTS_NEW = new("FLIGHTS28324", "Wflights_New", "Fligh") { vueRouteName = "form-WFLIGHTS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_WFLIGHTS_EDIT = new("FLIGHTS28324", "Wflights_Edit", "Fligh") { vueRouteName = "form-WFLIGHTS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_WFLIGHTS_DUPLICATE = new("FLIGHTS28324", "Wflights_Duplicate", "Fligh") { vueRouteName = "form-WFLIGHTS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_WFLIGHTS_DELETE = new("FLIGHTS28324", "Wflights_Delete", "Fligh") { vueRouteName = "form-WFLIGHTS", mode = "DELETE" };

		#endregion

		#region Wflights private

		private void FormHistoryLimits_Wflights()
		{

		}

		#endregion

		#region Wflights_Show

// USE /[MANUAL PJF CONTROLLER_SHOW WFLIGHTS]/

		[HttpPost]
		public ActionResult Wflights_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wflights_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Show_GET",
				AreaName = "fligh",
				Location = ACTION_WFLIGHTS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wflights();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW WFLIGHTS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Wflights_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Wflights_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_New_GET",
				AreaName = "fligh",
				FormName = "WFLIGHTS",
				Location = ACTION_WFLIGHTS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Wflights();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW WFLIGHTS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Fligh/Wflights_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_New([FromBody]Wflights_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_New",
				ViewName = "Wflights",
				AreaName = "fligh",
				Location = ACTION_WFLIGHTS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW WFLIGHTS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX WFLIGHTS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX WFLIGHTS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Wflights_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wflights_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Edit_GET",
				AreaName = "fligh",
				FormName = "WFLIGHTS",
				Location = ACTION_WFLIGHTS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wflights();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT WFLIGHTS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Fligh/Wflights_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_Edit([FromBody]Wflights_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Edit",
				ViewName = "Wflights",
				AreaName = "fligh",
				Location = ACTION_WFLIGHTS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT WFLIGHTS]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT WFLIGHTS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX WFLIGHTS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX WFLIGHTS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Wflights_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wflights_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Delete_GET",
				AreaName = "fligh",
				FormName = "WFLIGHTS",
				Location = ACTION_WFLIGHTS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wflights();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE WFLIGHTS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Fligh/Wflights_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wflights_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Delete",
				ViewName = "Wflights",
				AreaName = "fligh",
				Location = ACTION_WFLIGHTS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE WFLIGHTS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Wflights_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("WFLIGHTS");
		}

		#endregion

		#region Wflights_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET WFLIGHTS]/

		[HttpPost]
		public ActionResult Wflights_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Wflights_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Duplicate_GET",
				AreaName = "fligh",
				FormName = "WFLIGHTS",
				Location = ACTION_WFLIGHTS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE WFLIGHTS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Fligh/Wflights_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST WFLIGHTS]/
		[HttpPost]
		public ActionResult Wflights_Duplicate([FromBody]Wflights_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_Duplicate",
				ViewName = "Wflights",
				AreaName = "fligh",
				Location = ACTION_WFLIGHTS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE WFLIGHTS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX WFLIGHTS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX WFLIGHTS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Wflights_Cancel

		//
		// GET: /Fligh/Wflights_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET WFLIGHTS]/
		public ActionResult Wflights_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Fligh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("fligh");

// USE /[MANUAL PJF BEFORE_CANCEL WFLIGHTS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL WFLIGHTS]/

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

				Navigation.SetValue("ForcePrimaryRead_fligh", "true", true);
			}

			Navigation.ClearValue("fligh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Fligh/Wflights_ValListflit
		// POST: /Fligh/Wflights_ValListflit
		[ActionName("Wflights_ValListflit")]
		public ActionResult Wflights_ValListflit([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_fligh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_fligh");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Wflights_ValListflit_ViewModel model = new Wflights_ValListflit_ViewModel(UserContext.Current);

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


		// POST: /Fligh/Wflights_SaveEdit
		[HttpPost]
		public ActionResult Wflights_SaveEdit([FromBody]Wflights_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wflights_SaveEdit",
				ViewName = "Wflights",
				AreaName = "fligh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT WFLIGHTS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT WFLIGHTS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
