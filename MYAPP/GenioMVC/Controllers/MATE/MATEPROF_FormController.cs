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
using GenioMVC.ViewModels.Mate;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER MATE]/

namespace GenioMVC.Controllers
{
	public partial class MateController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MATEPROF_CANCEL = new("CABIN_CREWMATE42251", "Mateprof_Cancel", "Mate") { vueRouteName = "form-MATEPROF", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MATEPROF_SHOW = new("CABIN_CREWMATE42251", "Mateprof_Show", "Mate") { vueRouteName = "form-MATEPROF", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MATEPROF_NEW = new("CABIN_CREWMATE42251", "Mateprof_New", "Mate") { vueRouteName = "form-MATEPROF", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MATEPROF_EDIT = new("CABIN_CREWMATE42251", "Mateprof_Edit", "Mate") { vueRouteName = "form-MATEPROF", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MATEPROF_DUPLICATE = new("CABIN_CREWMATE42251", "Mateprof_Duplicate", "Mate") { vueRouteName = "form-MATEPROF", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MATEPROF_DELETE = new("CABIN_CREWMATE42251", "Mateprof_Delete", "Mate") { vueRouteName = "form-MATEPROF", mode = "DELETE" };

		#endregion

		#region Mateprof private

		private void FormHistoryLimits_Mateprof()
		{

		}

		#endregion

		#region Mateprof_Show

// USE /[MANUAL PJF CONTROLLER_SHOW MATEPROF]/

		[HttpPost]
		public ActionResult Mateprof_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mateprof_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Show_GET",
				AreaName = "mate",
				Location = ACTION_MATEPROF_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mateprof();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW MATEPROF]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Mateprof_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Mateprof_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_New_GET",
				AreaName = "mate",
				FormName = "MATEPROF",
				Location = ACTION_MATEPROF_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Mateprof();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW MATEPROF]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Mate/Mateprof_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_New([FromBody]Mateprof_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_New",
				ViewName = "Mateprof",
				AreaName = "mate",
				Location = ACTION_MATEPROF_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW MATEPROF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX MATEPROF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX MATEPROF]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Mateprof_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mateprof_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Edit_GET",
				AreaName = "mate",
				FormName = "MATEPROF",
				Location = ACTION_MATEPROF_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mateprof();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT MATEPROF]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Mate/Mateprof_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_Edit([FromBody]Mateprof_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Edit",
				ViewName = "Mateprof",
				AreaName = "mate",
				Location = ACTION_MATEPROF_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT MATEPROF]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT MATEPROF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX MATEPROF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX MATEPROF]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Mateprof_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mateprof_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Delete_GET",
				AreaName = "mate",
				FormName = "MATEPROF",
				Location = ACTION_MATEPROF_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mateprof();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE MATEPROF]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Mate/Mateprof_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mateprof_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Delete",
				ViewName = "Mateprof",
				AreaName = "mate",
				Location = ACTION_MATEPROF_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE MATEPROF]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Mateprof_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MATEPROF");
		}

		#endregion

		#region Mateprof_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET MATEPROF]/

		[HttpPost]
		public ActionResult Mateprof_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Mateprof_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Duplicate_GET",
				AreaName = "mate",
				FormName = "MATEPROF",
				Location = ACTION_MATEPROF_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE MATEPROF]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Mate/Mateprof_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST MATEPROF]/
		[HttpPost]
		public ActionResult Mateprof_Duplicate([FromBody]Mateprof_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_Duplicate",
				ViewName = "Mateprof",
				AreaName = "mate",
				Location = ACTION_MATEPROF_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE MATEPROF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX MATEPROF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX MATEPROF]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Mateprof_Cancel

		//
		// GET: /Mate/Mateprof_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET MATEPROF]/
		public ActionResult Mateprof_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Mate(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("mate");

// USE /[MANUAL PJF BEFORE_CANCEL MATEPROF]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL MATEPROF]/

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

				Navigation.SetValue("ForcePrimaryRead_mate", "true", true);
			}

			Navigation.ClearValue("mate");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Mate/Mateprof_CrewValCrewname
		// POST: /Mate/Mateprof_CrewValCrewname
		[ActionName("Mateprof_CrewValCrewname")]
		public ActionResult Mateprof_CrewValCrewname([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_crew")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_crew");
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
			Mateprof_CrewValCrewname_ViewModel model = new Mateprof_CrewValCrewname_ViewModel(UserContext.Current);

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


		// POST: /Mate/Mateprof_SaveEdit
		[HttpPost]
		public ActionResult Mateprof_SaveEdit([FromBody]Mateprof_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mateprof_SaveEdit",
				ViewName = "Mateprof",
				AreaName = "mate",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT MATEPROF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT MATEPROF]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
