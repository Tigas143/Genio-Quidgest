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
using GenioMVC.ViewModels.Plane;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER PLANE]/

namespace GenioMVC.Controllers
{
	public partial class PlaneController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_WPLANE_CANCEL = new("AIRCRAFTS00038", "Wplane_Cancel", "Plane") { vueRouteName = "form-WPLANE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_WPLANE_SHOW = new("AIRCRAFTS00038", "Wplane_Show", "Plane") { vueRouteName = "form-WPLANE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_WPLANE_NEW = new("AIRCRAFTS00038", "Wplane_New", "Plane") { vueRouteName = "form-WPLANE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_WPLANE_EDIT = new("AIRCRAFTS00038", "Wplane_Edit", "Plane") { vueRouteName = "form-WPLANE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_WPLANE_DUPLICATE = new("AIRCRAFTS00038", "Wplane_Duplicate", "Plane") { vueRouteName = "form-WPLANE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_WPLANE_DELETE = new("AIRCRAFTS00038", "Wplane_Delete", "Plane") { vueRouteName = "form-WPLANE", mode = "DELETE" };

		#endregion

		#region Wplane private

		private void FormHistoryLimits_Wplane()
		{

		}

		#endregion

		#region Wplane_Show

// USE /[MANUAL PJF CONTROLLER_SHOW WPLANE]/

		[HttpPost]
		public ActionResult Wplane_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wplane_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Show_GET",
				AreaName = "plane",
				Location = ACTION_WPLANE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wplane();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW WPLANE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Wplane_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET WPLANE]/
		[HttpPost]
		public ActionResult Wplane_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Wplane_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_New_GET",
				AreaName = "plane",
				FormName = "WPLANE",
				Location = ACTION_WPLANE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Wplane();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW WPLANE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Plane/Wplane_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST WPLANE]/
		[HttpPost]
		public ActionResult Wplane_New([FromBody]Wplane_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_New",
				ViewName = "Wplane",
				AreaName = "plane",
				Location = ACTION_WPLANE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW WPLANE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX WPLANE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX WPLANE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Wplane_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET WPLANE]/
		[HttpPost]
		public ActionResult Wplane_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wplane_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Edit_GET",
				AreaName = "plane",
				FormName = "WPLANE",
				Location = ACTION_WPLANE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wplane();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT WPLANE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Plane/Wplane_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST WPLANE]/
		[HttpPost]
		public ActionResult Wplane_Edit([FromBody]Wplane_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Edit",
				ViewName = "Wplane",
				AreaName = "plane",
				Location = ACTION_WPLANE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT WPLANE]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT WPLANE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX WPLANE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX WPLANE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Wplane_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET WPLANE]/
		[HttpPost]
		public ActionResult Wplane_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wplane_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Delete_GET",
				AreaName = "plane",
				FormName = "WPLANE",
				Location = ACTION_WPLANE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wplane();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE WPLANE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Plane/Wplane_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST WPLANE]/
		[HttpPost]
		public ActionResult Wplane_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wplane_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Delete",
				ViewName = "Wplane",
				AreaName = "plane",
				Location = ACTION_WPLANE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE WPLANE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Wplane_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("WPLANE");
		}

		#endregion

		#region Wplane_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET WPLANE]/

		[HttpPost]
		public ActionResult Wplane_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Wplane_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Duplicate_GET",
				AreaName = "plane",
				FormName = "WPLANE",
				Location = ACTION_WPLANE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE WPLANE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Plane/Wplane_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST WPLANE]/
		[HttpPost]
		public ActionResult Wplane_Duplicate([FromBody]Wplane_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_Duplicate",
				ViewName = "Wplane",
				AreaName = "plane",
				Location = ACTION_WPLANE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE WPLANE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX WPLANE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX WPLANE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Wplane_Cancel

		//
		// GET: /Plane/Wplane_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET WPLANE]/
		public ActionResult Wplane_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Plane(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("plane");

// USE /[MANUAL PJF BEFORE_CANCEL WPLANE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL WPLANE]/

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

				Navigation.SetValue("ForcePrimaryRead_plane", "true", true);
			}

			Navigation.ClearValue("plane");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Plane/Wplane_ValListplan
		// POST: /Plane/Wplane_ValListplan
		[ActionName("Wplane_ValListplan")]
		public ActionResult Wplane_ValListplan([FromBody]RequestLookupModel requestModel)
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

			Wplane_ValListplan_ViewModel model = new Wplane_ValListplan_ViewModel(UserContext.Current);

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


		// POST: /Plane/Wplane_SaveEdit
		[HttpPost]
		public ActionResult Wplane_SaveEdit([FromBody]Wplane_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wplane_SaveEdit",
				ViewName = "Wplane",
				AreaName = "plane",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT WPLANE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT WPLANE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
