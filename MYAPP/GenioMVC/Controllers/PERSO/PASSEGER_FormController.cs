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
using GenioMVC.ViewModels.Perso;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER PERSO]/

namespace GenioMVC.Controllers
{
	public partial class PersoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PASSEGER_CANCEL = new("PASSENGER40365", "Passeger_Cancel", "Perso") { vueRouteName = "form-PASSEGER", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PASSEGER_SHOW = new("PASSENGER40365", "Passeger_Show", "Perso") { vueRouteName = "form-PASSEGER", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PASSEGER_NEW = new("PASSENGER40365", "Passeger_New", "Perso") { vueRouteName = "form-PASSEGER", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PASSEGER_EDIT = new("PASSENGER40365", "Passeger_Edit", "Perso") { vueRouteName = "form-PASSEGER", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PASSEGER_DUPLICATE = new("PASSENGER40365", "Passeger_Duplicate", "Perso") { vueRouteName = "form-PASSEGER", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PASSEGER_DELETE = new("PASSENGER40365", "Passeger_Delete", "Perso") { vueRouteName = "form-PASSEGER", mode = "DELETE" };

		#endregion

		#region Passeger private

		private void FormHistoryLimits_Passeger()
		{

		}

		#endregion

		#region Passeger_Show

// USE /[MANUAL PJF CONTROLLER_SHOW PASSEGER]/

		[HttpPost]
		public ActionResult Passeger_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Passeger_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Show_GET",
				AreaName = "perso",
				Location = ACTION_PASSEGER_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Passeger();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW PASSEGER]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Passeger_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Passeger_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_New_GET",
				AreaName = "perso",
				FormName = "PASSEGER",
				Location = ACTION_PASSEGER_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Passeger();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW PASSEGER]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Perso/Passeger_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_New([FromBody]Passeger_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_New",
				ViewName = "Passeger",
				AreaName = "perso",
				Location = ACTION_PASSEGER_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW PASSEGER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX PASSEGER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX PASSEGER]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Passeger_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Passeger_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Edit_GET",
				AreaName = "perso",
				FormName = "PASSEGER",
				Location = ACTION_PASSEGER_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Passeger();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT PASSEGER]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Perso/Passeger_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_Edit([FromBody]Passeger_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Edit",
				ViewName = "Passeger",
				AreaName = "perso",
				Location = ACTION_PASSEGER_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT PASSEGER]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT PASSEGER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX PASSEGER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX PASSEGER]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Passeger_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Passeger_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Delete_GET",
				AreaName = "perso",
				FormName = "PASSEGER",
				Location = ACTION_PASSEGER_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Passeger();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE PASSEGER]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Perso/Passeger_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Passeger_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Delete",
				ViewName = "Passeger",
				AreaName = "perso",
				Location = ACTION_PASSEGER_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE PASSEGER]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Passeger_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PASSEGER");
		}

		#endregion

		#region Passeger_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET PASSEGER]/

		[HttpPost]
		public ActionResult Passeger_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Passeger_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Duplicate_GET",
				AreaName = "perso",
				FormName = "PASSEGER",
				Location = ACTION_PASSEGER_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE PASSEGER]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Perso/Passeger_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST PASSEGER]/
		[HttpPost]
		public ActionResult Passeger_Duplicate([FromBody]Passeger_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_Duplicate",
				ViewName = "Passeger",
				AreaName = "perso",
				Location = ACTION_PASSEGER_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE PASSEGER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX PASSEGER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX PASSEGER]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Passeger_Cancel

		//
		// GET: /Perso/Passeger_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET PASSEGER]/
		public ActionResult Passeger_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Perso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("perso");

// USE /[MANUAL PJF BEFORE_CANCEL PASSEGER]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL PASSEGER]/

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

				Navigation.SetValue("ForcePrimaryRead_perso", "true", true);
			}

			Navigation.ClearValue("perso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Perso/Passeger_SaveEdit
		[HttpPost]
		public ActionResult Passeger_SaveEdit([FromBody]Passeger_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Passeger_SaveEdit",
				ViewName = "Passeger",
				AreaName = "perso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT PASSEGER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT PASSEGER]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
