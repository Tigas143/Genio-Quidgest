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
using GenioMVC.ViewModels.Maint;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER MAINT]/

namespace GenioMVC.Controllers
{
	public partial class MaintController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MAINTEN_CANCEL = new("MAINTENANCERECORD19043", "Mainten_Cancel", "Maint") { vueRouteName = "form-MAINTEN", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MAINTEN_SHOW = new("MAINTENANCERECORD19043", "Mainten_Show", "Maint") { vueRouteName = "form-MAINTEN", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MAINTEN_NEW = new("MAINTENANCERECORD19043", "Mainten_New", "Maint") { vueRouteName = "form-MAINTEN", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MAINTEN_EDIT = new("MAINTENANCERECORD19043", "Mainten_Edit", "Maint") { vueRouteName = "form-MAINTEN", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MAINTEN_DUPLICATE = new("MAINTENANCERECORD19043", "Mainten_Duplicate", "Maint") { vueRouteName = "form-MAINTEN", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MAINTEN_DELETE = new("MAINTENANCERECORD19043", "Mainten_Delete", "Maint") { vueRouteName = "form-MAINTEN", mode = "DELETE" };

		#endregion

		#region Mainten private

		private void FormHistoryLimits_Mainten()
		{

		}

		#endregion

		#region Mainten_Show

// USE /[MANUAL PJF CONTROLLER_SHOW MAINTEN]/

		[HttpPost]
		public ActionResult Mainten_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mainten_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Show_GET",
				AreaName = "maint",
				Location = ACTION_MAINTEN_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mainten();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW MAINTEN]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Mainten_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Mainten_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_New_GET",
				AreaName = "maint",
				FormName = "MAINTEN",
				Location = ACTION_MAINTEN_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Mainten();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW MAINTEN]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Maint/Mainten_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_New([FromBody]Mainten_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_New",
				ViewName = "Mainten",
				AreaName = "maint",
				Location = ACTION_MAINTEN_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW MAINTEN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX MAINTEN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX MAINTEN]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Mainten_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mainten_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Edit_GET",
				AreaName = "maint",
				FormName = "MAINTEN",
				Location = ACTION_MAINTEN_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mainten();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT MAINTEN]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Maint/Mainten_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_Edit([FromBody]Mainten_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Edit",
				ViewName = "Mainten",
				AreaName = "maint",
				Location = ACTION_MAINTEN_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT MAINTEN]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT MAINTEN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX MAINTEN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX MAINTEN]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Mainten_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mainten_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Delete_GET",
				AreaName = "maint",
				FormName = "MAINTEN",
				Location = ACTION_MAINTEN_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mainten();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE MAINTEN]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Maint/Mainten_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mainten_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Delete",
				ViewName = "Mainten",
				AreaName = "maint",
				Location = ACTION_MAINTEN_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE MAINTEN]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Mainten_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MAINTEN");
		}

		#endregion

		#region Mainten_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET MAINTEN]/

		[HttpPost]
		public ActionResult Mainten_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Mainten_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Duplicate_GET",
				AreaName = "maint",
				FormName = "MAINTEN",
				Location = ACTION_MAINTEN_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE MAINTEN]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Maint/Mainten_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST MAINTEN]/
		[HttpPost]
		public ActionResult Mainten_Duplicate([FromBody]Mainten_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_Duplicate",
				ViewName = "Mainten",
				AreaName = "maint",
				Location = ACTION_MAINTEN_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE MAINTEN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX MAINTEN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX MAINTEN]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Mainten_Cancel

		//
		// GET: /Maint/Mainten_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET MAINTEN]/
		public ActionResult Mainten_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Maint(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("maint");

// USE /[MANUAL PJF BEFORE_CANCEL MAINTEN]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL MAINTEN]/

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

				Navigation.SetValue("ForcePrimaryRead_maint", "true", true);
			}

			Navigation.ClearValue("maint");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Maint/Mainten_PlaneValModel
		// POST: /Maint/Mainten_PlaneValModel
		[ActionName("Mainten_PlaneValModel")]
		public ActionResult Mainten_PlaneValModel([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_plane")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_plane");
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
			Mainten_PlaneValModel_ViewModel model = new Mainten_PlaneValModel_ViewModel(UserContext.Current);

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


		// POST: /Maint/Mainten_SaveEdit
		[HttpPost]
		public ActionResult Mainten_SaveEdit([FromBody]Mainten_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mainten_SaveEdit",
				ViewName = "Mainten",
				AreaName = "maint",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT MAINTEN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT MAINTEN]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
