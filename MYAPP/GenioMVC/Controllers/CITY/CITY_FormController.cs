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
using GenioMVC.ViewModels.City;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER CITY]/

namespace GenioMVC.Controllers
{
	public partial class CityController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CITY_CANCEL = new("CITY42505", "City_Cancel", "City") { vueRouteName = "form-CITY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CITY_SHOW = new("CITY42505", "City_Show", "City") { vueRouteName = "form-CITY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CITY_NEW = new("CITY42505", "City_New", "City") { vueRouteName = "form-CITY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CITY_EDIT = new("CITY42505", "City_Edit", "City") { vueRouteName = "form-CITY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CITY_DUPLICATE = new("CITY42505", "City_Duplicate", "City") { vueRouteName = "form-CITY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CITY_DELETE = new("CITY42505", "City_Delete", "City") { vueRouteName = "form-CITY", mode = "DELETE" };

		#endregion

		#region City private

		private void FormHistoryLimits_City()
		{

		}

		#endregion

		#region City_Show

// USE /[MANUAL PJF CONTROLLER_SHOW CITY]/

		[HttpPost]
		public ActionResult City_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City_Show_GET",
				AreaName = "city",
				Location = ACTION_CITY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_City();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW CITY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region City_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET CITY]/
		[HttpPost]
		public ActionResult City_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new City_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City_New_GET",
				AreaName = "city",
				FormName = "CITY",
				Location = ACTION_CITY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_City();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW CITY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /City/City_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST CITY]/
		[HttpPost]
		public ActionResult City_New([FromBody]City_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City_New",
				ViewName = "City",
				AreaName = "city",
				Location = ACTION_CITY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW CITY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX CITY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX CITY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region City_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET CITY]/
		[HttpPost]
		public ActionResult City_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City_Edit_GET",
				AreaName = "city",
				FormName = "CITY",
				Location = ACTION_CITY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_City();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT CITY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /City/City_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST CITY]/
		[HttpPost]
		public ActionResult City_Edit([FromBody]City_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City_Edit",
				ViewName = "City",
				AreaName = "city",
				Location = ACTION_CITY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT CITY]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT CITY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX CITY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX CITY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region City_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET CITY]/
		[HttpPost]
		public ActionResult City_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City_Delete_GET",
				AreaName = "city",
				FormName = "CITY",
				Location = ACTION_CITY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_City();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE CITY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /City/City_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST CITY]/
		[HttpPost]
		public ActionResult City_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "City_Delete",
				ViewName = "City",
				AreaName = "city",
				Location = ACTION_CITY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE CITY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult City_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CITY");
		}

		#endregion

		#region City_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET CITY]/

		[HttpPost]
		public ActionResult City_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new City_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City_Duplicate_GET",
				AreaName = "city",
				FormName = "CITY",
				Location = ACTION_CITY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE CITY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /City/City_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST CITY]/
		[HttpPost]
		public ActionResult City_Duplicate([FromBody]City_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City_Duplicate",
				ViewName = "City",
				AreaName = "city",
				Location = ACTION_CITY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE CITY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX CITY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX CITY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region City_Cancel

		//
		// GET: /City/City_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET CITY]/
		public ActionResult City_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.City(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("city");

// USE /[MANUAL PJF BEFORE_CANCEL CITY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL CITY]/

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

				Navigation.SetValue("ForcePrimaryRead_city", "true", true);
			}

			Navigation.ClearValue("city");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /City/City_SaveEdit
		[HttpPost]
		public ActionResult City_SaveEdit([FromBody]City_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City_SaveEdit",
				ViewName = "City",
				AreaName = "city",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT CITY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
