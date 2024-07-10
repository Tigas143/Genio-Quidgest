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
using GenioMVC.ViewModels.Pilot;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER PILOT]/

namespace GenioMVC.Controllers
{
	public partial class PilotController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PILOT_CANCEL = new("PILOT61493", "Pilot_Cancel", "Pilot") { vueRouteName = "form-PILOT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PILOT_SHOW = new("PILOT61493", "Pilot_Show", "Pilot") { vueRouteName = "form-PILOT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PILOT_NEW = new("PILOT61493", "Pilot_New", "Pilot") { vueRouteName = "form-PILOT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PILOT_EDIT = new("PILOT61493", "Pilot_Edit", "Pilot") { vueRouteName = "form-PILOT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PILOT_DUPLICATE = new("PILOT61493", "Pilot_Duplicate", "Pilot") { vueRouteName = "form-PILOT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PILOT_DELETE = new("PILOT61493", "Pilot_Delete", "Pilot") { vueRouteName = "form-PILOT", mode = "DELETE" };

		#endregion

		#region Pilot private

		private void FormHistoryLimits_Pilot()
		{

		}

		#endregion

		#region Pilot_Show

// USE /[MANUAL PJF CONTROLLER_SHOW PILOT]/

		[HttpPost]
		public ActionResult Pilot_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pilot_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Show_GET",
				AreaName = "pilot",
				Location = ACTION_PILOT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pilot();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW PILOT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pilot_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET PILOT]/
		[HttpPost]
		public ActionResult Pilot_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pilot_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_New_GET",
				AreaName = "pilot",
				FormName = "PILOT",
				Location = ACTION_PILOT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pilot();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW PILOT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pilot/Pilot_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST PILOT]/
		[HttpPost]
		public ActionResult Pilot_New([FromBody]Pilot_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_New",
				ViewName = "Pilot",
				AreaName = "pilot",
				Location = ACTION_PILOT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW PILOT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX PILOT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX PILOT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pilot_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET PILOT]/
		[HttpPost]
		public ActionResult Pilot_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pilot_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Edit_GET",
				AreaName = "pilot",
				FormName = "PILOT",
				Location = ACTION_PILOT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pilot();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT PILOT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pilot/Pilot_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST PILOT]/
		[HttpPost]
		public ActionResult Pilot_Edit([FromBody]Pilot_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Edit",
				ViewName = "Pilot",
				AreaName = "pilot",
				Location = ACTION_PILOT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT PILOT]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT PILOT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX PILOT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX PILOT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pilot_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET PILOT]/
		[HttpPost]
		public ActionResult Pilot_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pilot_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Delete_GET",
				AreaName = "pilot",
				FormName = "PILOT",
				Location = ACTION_PILOT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pilot();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE PILOT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pilot/Pilot_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST PILOT]/
		[HttpPost]
		public ActionResult Pilot_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pilot_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Delete",
				ViewName = "Pilot",
				AreaName = "pilot",
				Location = ACTION_PILOT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE PILOT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pilot_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PILOT");
		}

		#endregion

		#region Pilot_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET PILOT]/

		[HttpPost]
		public ActionResult Pilot_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pilot_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Duplicate_GET",
				AreaName = "pilot",
				FormName = "PILOT",
				Location = ACTION_PILOT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE PILOT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pilot/Pilot_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST PILOT]/
		[HttpPost]
		public ActionResult Pilot_Duplicate([FromBody]Pilot_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_Duplicate",
				ViewName = "Pilot",
				AreaName = "pilot",
				Location = ACTION_PILOT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE PILOT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX PILOT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX PILOT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pilot_Cancel

		//
		// GET: /Pilot/Pilot_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET PILOT]/
		public ActionResult Pilot_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pilot(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pilot");

// USE /[MANUAL PJF BEFORE_CANCEL PILOT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL PILOT]/

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

				Navigation.SetValue("ForcePrimaryRead_pilot", "true", true);
			}

			Navigation.ClearValue("pilot");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Pilot/Pilot_AirlnValName
		// POST: /Pilot/Pilot_AirlnValName
		[ActionName("Pilot_AirlnValName")]
		public ActionResult Pilot_AirlnValName([FromBody]RequestLookupModel requestModel)
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
			Pilot_AirlnValName_ViewModel model = new Pilot_AirlnValName_ViewModel(UserContext.Current);

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


		// POST: /Pilot/Pilot_SaveEdit
		[HttpPost]
		public ActionResult Pilot_SaveEdit([FromBody]Pilot_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pilot_SaveEdit",
				ViewName = "Pilot",
				AreaName = "pilot",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT PILOT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT PILOT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
