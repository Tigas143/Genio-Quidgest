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

		private static readonly NavigationLocation ACTION_FLIGHT_CANCEL = new("FLIGHT55228", "Flight_Cancel", "Fligh") { vueRouteName = "form-FLIGHT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FLIGHT_SHOW = new("FLIGHT55228", "Flight_Show", "Fligh") { vueRouteName = "form-FLIGHT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FLIGHT_NEW = new("FLIGHT55228", "Flight_New", "Fligh") { vueRouteName = "form-FLIGHT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FLIGHT_EDIT = new("FLIGHT55228", "Flight_Edit", "Fligh") { vueRouteName = "form-FLIGHT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FLIGHT_DUPLICATE = new("FLIGHT55228", "Flight_Duplicate", "Fligh") { vueRouteName = "form-FLIGHT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FLIGHT_DELETE = new("FLIGHT55228", "Flight_Delete", "Fligh") { vueRouteName = "form-FLIGHT", mode = "DELETE" };

		#endregion

		#region Flight private

		private void FormHistoryLimits_Flight()
		{

		}

		#endregion

		#region Flight_Show

// USE /[MANUAL PJF CONTROLLER_SHOW FLIGHT]/

		[HttpPost]
		public ActionResult Flight_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Flight_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Flight_Show_GET",
				AreaName = "fligh",
				Location = ACTION_FLIGHT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Flight();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW FLIGHT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Flight_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET FLIGHT]/
		[HttpPost]
		public ActionResult Flight_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Flight_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Flight_New_GET",
				AreaName = "fligh",
				FormName = "FLIGHT",
				Location = ACTION_FLIGHT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Flight();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW FLIGHT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Fligh/Flight_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST FLIGHT]/
		[HttpPost]
		public ActionResult Flight_New([FromBody]Flight_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Flight_New",
				ViewName = "Flight",
				AreaName = "fligh",
				Location = ACTION_FLIGHT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW FLIGHT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX FLIGHT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX FLIGHT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Flight_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET FLIGHT]/
		[HttpPost]
		public ActionResult Flight_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Flight_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Flight_Edit_GET",
				AreaName = "fligh",
				FormName = "FLIGHT",
				Location = ACTION_FLIGHT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Flight();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT FLIGHT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Fligh/Flight_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST FLIGHT]/
		[HttpPost]
		public ActionResult Flight_Edit([FromBody]Flight_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Flight_Edit",
				ViewName = "Flight",
				AreaName = "fligh",
				Location = ACTION_FLIGHT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT FLIGHT]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT FLIGHT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX FLIGHT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX FLIGHT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Flight_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET FLIGHT]/
		[HttpPost]
		public ActionResult Flight_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Flight_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Flight_Delete_GET",
				AreaName = "fligh",
				FormName = "FLIGHT",
				Location = ACTION_FLIGHT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Flight();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE FLIGHT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Fligh/Flight_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST FLIGHT]/
		[HttpPost]
		public ActionResult Flight_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Flight_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Flight_Delete",
				ViewName = "Flight",
				AreaName = "fligh",
				Location = ACTION_FLIGHT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE FLIGHT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Flight_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLIGHT");
		}

		#endregion

		#region Flight_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET FLIGHT]/

		[HttpPost]
		public ActionResult Flight_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Flight_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Flight_Duplicate_GET",
				AreaName = "fligh",
				FormName = "FLIGHT",
				Location = ACTION_FLIGHT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE FLIGHT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Fligh/Flight_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST FLIGHT]/
		[HttpPost]
		public ActionResult Flight_Duplicate([FromBody]Flight_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Flight_Duplicate",
				ViewName = "Flight",
				AreaName = "fligh",
				Location = ACTION_FLIGHT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE FLIGHT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX FLIGHT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX FLIGHT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Flight_Cancel

		//
		// GET: /Fligh/Flight_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET FLIGHT]/
		public ActionResult Flight_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Fligh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("fligh");

// USE /[MANUAL PJF BEFORE_CANCEL FLIGHT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL FLIGHT]/

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
		// GET: /Fligh/Flight_PlaneValModel
		// POST: /Fligh/Flight_PlaneValModel
		[ActionName("Flight_PlaneValModel")]
		public ActionResult Flight_PlaneValModel([FromBody]RequestLookupModel requestModel)
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
			Flight_PlaneValModel_ViewModel model = new Flight_PlaneValModel_ViewModel(UserContext.Current);

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
		// GET: /Fligh/Flight_RouteValName
		// POST: /Fligh/Flight_RouteValName
		[ActionName("Flight_RouteValName")]
		public ActionResult Flight_RouteValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_route")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_route");
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
			Flight_RouteValName_ViewModel model = new Flight_RouteValName_ViewModel(UserContext.Current);

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
			// Map received value to field - The 'field' type limit
			model.ValNamesc = Navigation.GetValue<string>("fligh.namesc");
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Fligh/Flight_CrewValCrewname
		// POST: /Fligh/Flight_CrewValCrewname
		[ActionName("Flight_CrewValCrewname")]
		public ActionResult Flight_CrewValCrewname([FromBody]RequestLookupModel requestModel)
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
			Flight_CrewValCrewname_ViewModel model = new Flight_CrewValCrewname_ViewModel(UserContext.Current);

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
		// GET: /Fligh/Flight_PilotValName
		// POST: /Fligh/Flight_PilotValName
		[ActionName("Flight_PilotValName")]
		public ActionResult Flight_PilotValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pilot")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pilot");
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
			Flight_PilotValName_ViewModel model = new Flight_PilotValName_ViewModel(UserContext.Current);

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


		// POST: /Fligh/Flight_SaveEdit
		[HttpPost]
		public ActionResult Flight_SaveEdit([FromBody]Flight_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Flight_SaveEdit",
				ViewName = "Flight",
				AreaName = "fligh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT FLIGHT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT FLIGHT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
