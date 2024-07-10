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
using GenioMVC.ViewModels.Crew;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER CREW]/

namespace GenioMVC.Controllers
{
	public partial class CrewController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CREW_CANCEL = new("CABIN_CREW13410", "Crew_Cancel", "Crew") { vueRouteName = "form-CREW", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CREW_SHOW = new("CABIN_CREW13410", "Crew_Show", "Crew") { vueRouteName = "form-CREW", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CREW_NEW = new("CABIN_CREW13410", "Crew_New", "Crew") { vueRouteName = "form-CREW", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CREW_EDIT = new("CABIN_CREW13410", "Crew_Edit", "Crew") { vueRouteName = "form-CREW", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CREW_DUPLICATE = new("CABIN_CREW13410", "Crew_Duplicate", "Crew") { vueRouteName = "form-CREW", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CREW_DELETE = new("CABIN_CREW13410", "Crew_Delete", "Crew") { vueRouteName = "form-CREW", mode = "DELETE" };

		#endregion

		#region Crew private

		private void FormHistoryLimits_Crew()
		{

		}

		#endregion

		#region Crew_Show

// USE /[MANUAL PJF CONTROLLER_SHOW CREW]/

		[HttpPost]
		public ActionResult Crew_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Crew_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Crew_Show_GET",
				AreaName = "crew",
				Location = ACTION_CREW_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Crew();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW CREW]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Crew_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET CREW]/
		[HttpPost]
		public ActionResult Crew_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Crew_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Crew_New_GET",
				AreaName = "crew",
				FormName = "CREW",
				Location = ACTION_CREW_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Crew();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW CREW]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Crew/Crew_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST CREW]/
		[HttpPost]
		public ActionResult Crew_New([FromBody]Crew_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Crew_New",
				ViewName = "Crew",
				AreaName = "crew",
				Location = ACTION_CREW_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW CREW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX CREW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX CREW]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Crew_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET CREW]/
		[HttpPost]
		public ActionResult Crew_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Crew_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Crew_Edit_GET",
				AreaName = "crew",
				FormName = "CREW",
				Location = ACTION_CREW_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Crew();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT CREW]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Crew/Crew_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST CREW]/
		[HttpPost]
		public ActionResult Crew_Edit([FromBody]Crew_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Crew_Edit",
				ViewName = "Crew",
				AreaName = "crew",
				Location = ACTION_CREW_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT CREW]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT CREW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX CREW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX CREW]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Crew_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET CREW]/
		[HttpPost]
		public ActionResult Crew_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Crew_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Crew_Delete_GET",
				AreaName = "crew",
				FormName = "CREW",
				Location = ACTION_CREW_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Crew();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE CREW]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Crew/Crew_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST CREW]/
		[HttpPost]
		public ActionResult Crew_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Crew_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Crew_Delete",
				ViewName = "Crew",
				AreaName = "crew",
				Location = ACTION_CREW_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE CREW]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Crew_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CREW");
		}

		#endregion

		#region Crew_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET CREW]/

		[HttpPost]
		public ActionResult Crew_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Crew_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Crew_Duplicate_GET",
				AreaName = "crew",
				FormName = "CREW",
				Location = ACTION_CREW_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE CREW]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Crew/Crew_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST CREW]/
		[HttpPost]
		public ActionResult Crew_Duplicate([FromBody]Crew_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Crew_Duplicate",
				ViewName = "Crew",
				AreaName = "crew",
				Location = ACTION_CREW_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE CREW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX CREW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX CREW]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Crew_Cancel

		//
		// GET: /Crew/Crew_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET CREW]/
		public ActionResult Crew_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Crew(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("crew");

// USE /[MANUAL PJF BEFORE_CANCEL CREW]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL CREW]/

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

				Navigation.SetValue("ForcePrimaryRead_crew", "true", true);
			}

			Navigation.ClearValue("crew");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Crew/Crew_AirlnValName
		// POST: /Crew/Crew_AirlnValName
		[ActionName("Crew_AirlnValName")]
		public ActionResult Crew_AirlnValName([FromBody]RequestLookupModel requestModel)
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
			Crew_AirlnValName_ViewModel model = new Crew_AirlnValName_ViewModel(UserContext.Current);

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


		// POST: /Crew/Crew_SaveEdit
		[HttpPost]
		public ActionResult Crew_SaveEdit([FromBody]Crew_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Crew_SaveEdit",
				ViewName = "Crew",
				AreaName = "crew",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT CREW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT CREW]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
