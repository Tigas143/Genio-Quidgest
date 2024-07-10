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

		private static readonly NavigationLocation ACTION_PLANES_CANCEL = new("AIRCRAFT03780", "Planes_Cancel", "Plane") { vueRouteName = "form-PLANES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PLANES_SHOW = new("AIRCRAFT03780", "Planes_Show", "Plane") { vueRouteName = "form-PLANES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PLANES_NEW = new("AIRCRAFT03780", "Planes_New", "Plane") { vueRouteName = "form-PLANES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PLANES_EDIT = new("AIRCRAFT03780", "Planes_Edit", "Plane") { vueRouteName = "form-PLANES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PLANES_DUPLICATE = new("AIRCRAFT03780", "Planes_Duplicate", "Plane") { vueRouteName = "form-PLANES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PLANES_DELETE = new("AIRCRAFT03780", "Planes_Delete", "Plane") { vueRouteName = "form-PLANES", mode = "DELETE" };

		#endregion

		#region Planes private

		private void FormHistoryLimits_Planes()
		{

		}

		#endregion

		#region Planes_Show

// USE /[MANUAL PJF CONTROLLER_SHOW PLANES]/

		[HttpPost]
		public ActionResult Planes_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Planes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Planes_Show_GET",
				AreaName = "plane",
				Location = ACTION_PLANES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Planes();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW PLANES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Planes_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET PLANES]/
		[HttpPost]
		public ActionResult Planes_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Planes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Planes_New_GET",
				AreaName = "plane",
				FormName = "PLANES",
				Location = ACTION_PLANES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Planes();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW PLANES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Plane/Planes_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST PLANES]/
		[HttpPost]
		public ActionResult Planes_New([FromBody]Planes_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Planes_New",
				ViewName = "Planes",
				AreaName = "plane",
				Location = ACTION_PLANES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW PLANES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX PLANES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX PLANES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Planes_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET PLANES]/
		[HttpPost]
		public ActionResult Planes_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Planes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Planes_Edit_GET",
				AreaName = "plane",
				FormName = "PLANES",
				Location = ACTION_PLANES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Planes();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT PLANES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Plane/Planes_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST PLANES]/
		[HttpPost]
		public ActionResult Planes_Edit([FromBody]Planes_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Planes_Edit",
				ViewName = "Planes",
				AreaName = "plane",
				Location = ACTION_PLANES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT PLANES]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT PLANES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX PLANES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX PLANES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Planes_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET PLANES]/
		[HttpPost]
		public ActionResult Planes_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Planes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Planes_Delete_GET",
				AreaName = "plane",
				FormName = "PLANES",
				Location = ACTION_PLANES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Planes();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE PLANES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Plane/Planes_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST PLANES]/
		[HttpPost]
		public ActionResult Planes_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Planes_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Planes_Delete",
				ViewName = "Planes",
				AreaName = "plane",
				Location = ACTION_PLANES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE PLANES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Planes_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PLANES");
		}

		#endregion

		#region Planes_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET PLANES]/

		[HttpPost]
		public ActionResult Planes_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Planes_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Planes_Duplicate_GET",
				AreaName = "plane",
				FormName = "PLANES",
				Location = ACTION_PLANES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE PLANES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Plane/Planes_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST PLANES]/
		[HttpPost]
		public ActionResult Planes_Duplicate([FromBody]Planes_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Planes_Duplicate",
				ViewName = "Planes",
				AreaName = "plane",
				Location = ACTION_PLANES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE PLANES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX PLANES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX PLANES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Planes_Cancel

		//
		// GET: /Plane/Planes_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET PLANES]/
		public ActionResult Planes_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Plane(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("plane");

// USE /[MANUAL PJF BEFORE_CANCEL PLANES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL PLANES]/

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
		// GET: /Plane/Planes_AirlnValName
		// POST: /Plane/Planes_AirlnValName
		[ActionName("Planes_AirlnValName")]
		public ActionResult Planes_AirlnValName([FromBody]RequestLookupModel requestModel)
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
			Planes_AirlnValName_ViewModel model = new Planes_AirlnValName_ViewModel(UserContext.Current);

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
		// GET: /Plane/Planes_AircrValName
		// POST: /Plane/Planes_AircrValName
		[ActionName("Planes_AircrValName")]
		public ActionResult Planes_AircrValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_aircr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_aircr");
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
			Planes_AircrValName_ViewModel model = new Planes_AircrValName_ViewModel(UserContext.Current);

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


		// POST: /Plane/Planes_SaveEdit
		[HttpPost]
		public ActionResult Planes_SaveEdit([FromBody]Planes_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Planes_SaveEdit",
				ViewName = "Planes",
				AreaName = "plane",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT PLANES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT PLANES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
