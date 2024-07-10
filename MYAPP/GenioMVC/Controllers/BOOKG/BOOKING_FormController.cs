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
using GenioMVC.ViewModels.Bookg;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER BOOKG]/

namespace GenioMVC.Controllers
{
	public partial class BookgController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_BOOKING_CANCEL = new("BOOKING10841", "Booking_Cancel", "Bookg") { vueRouteName = "form-BOOKING", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_BOOKING_SHOW = new("BOOKING10841", "Booking_Show", "Bookg") { vueRouteName = "form-BOOKING", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_BOOKING_NEW = new("BOOKING10841", "Booking_New", "Bookg") { vueRouteName = "form-BOOKING", mode = "NEW" };
		private static readonly NavigationLocation ACTION_BOOKING_EDIT = new("BOOKING10841", "Booking_Edit", "Bookg") { vueRouteName = "form-BOOKING", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_BOOKING_DUPLICATE = new("BOOKING10841", "Booking_Duplicate", "Bookg") { vueRouteName = "form-BOOKING", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_BOOKING_DELETE = new("BOOKING10841", "Booking_Delete", "Bookg") { vueRouteName = "form-BOOKING", mode = "DELETE" };

		#endregion

		#region Booking private

		private void FormHistoryLimits_Booking()
		{

		}

		#endregion

		#region Booking_Show

// USE /[MANUAL PJF CONTROLLER_SHOW BOOKING]/

		[HttpPost]
		public ActionResult Booking_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Booking_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Booking_Show_GET",
				AreaName = "bookg",
				Location = ACTION_BOOKING_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Booking();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW BOOKING]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Booking_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET BOOKING]/
		[HttpPost]
		public ActionResult Booking_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Booking_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Booking_New_GET",
				AreaName = "bookg",
				FormName = "BOOKING",
				Location = ACTION_BOOKING_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Booking();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW BOOKING]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Bookg/Booking_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST BOOKING]/
		[HttpPost]
		public ActionResult Booking_New([FromBody]Booking_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Booking_New",
				ViewName = "Booking",
				AreaName = "bookg",
				Location = ACTION_BOOKING_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW BOOKING]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX BOOKING]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX BOOKING]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Booking_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET BOOKING]/
		[HttpPost]
		public ActionResult Booking_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Booking_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Booking_Edit_GET",
				AreaName = "bookg",
				FormName = "BOOKING",
				Location = ACTION_BOOKING_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Booking();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT BOOKING]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Bookg/Booking_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST BOOKING]/
		[HttpPost]
		public ActionResult Booking_Edit([FromBody]Booking_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Booking_Edit",
				ViewName = "Booking",
				AreaName = "bookg",
				Location = ACTION_BOOKING_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT BOOKING]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT BOOKING]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX BOOKING]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX BOOKING]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Booking_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET BOOKING]/
		[HttpPost]
		public ActionResult Booking_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Booking_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Booking_Delete_GET",
				AreaName = "bookg",
				FormName = "BOOKING",
				Location = ACTION_BOOKING_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Booking();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE BOOKING]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Bookg/Booking_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST BOOKING]/
		[HttpPost]
		public ActionResult Booking_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Booking_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Booking_Delete",
				ViewName = "Booking",
				AreaName = "bookg",
				Location = ACTION_BOOKING_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE BOOKING]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Booking_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("BOOKING");
		}

		#endregion

		#region Booking_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET BOOKING]/

		[HttpPost]
		public ActionResult Booking_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Booking_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Booking_Duplicate_GET",
				AreaName = "bookg",
				FormName = "BOOKING",
				Location = ACTION_BOOKING_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE BOOKING]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Bookg/Booking_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST BOOKING]/
		[HttpPost]
		public ActionResult Booking_Duplicate([FromBody]Booking_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Booking_Duplicate",
				ViewName = "Booking",
				AreaName = "bookg",
				Location = ACTION_BOOKING_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE BOOKING]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX BOOKING]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX BOOKING]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Booking_Cancel

		//
		// GET: /Bookg/Booking_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET BOOKING]/
		public ActionResult Booking_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Bookg(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("bookg");

// USE /[MANUAL PJF BEFORE_CANCEL BOOKING]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL BOOKING]/

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

				Navigation.SetValue("ForcePrimaryRead_bookg", "true", true);
			}

			Navigation.ClearValue("bookg");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Bookg/Booking_FlighValFlighnum
		// POST: /Bookg/Booking_FlighValFlighnum
		[ActionName("Booking_FlighValFlighnum")]
		public ActionResult Booking_FlighValFlighnum([FromBody]RequestLookupModel requestModel)
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

			IsStateReadonly = true;
			Booking_FlighValFlighnum_ViewModel model = new Booking_FlighValFlighnum_ViewModel(UserContext.Current);

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
		// GET: /Bookg/Booking_PersoValName
		// POST: /Bookg/Booking_PersoValName
		[ActionName("Booking_PersoValName")]
		public ActionResult Booking_PersoValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
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
			Booking_PersoValName_ViewModel model = new Booking_PersoValName_ViewModel(UserContext.Current);

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


		// POST: /Bookg/Booking_SaveEdit
		[HttpPost]
		public ActionResult Booking_SaveEdit([FromBody]Booking_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Booking_SaveEdit",
				ViewName = "Booking",
				AreaName = "bookg",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT BOOKING]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT BOOKING]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
