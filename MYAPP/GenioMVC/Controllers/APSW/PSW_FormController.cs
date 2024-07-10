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
using GenioMVC.ViewModels.Apsw;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PJF INCLUDE_CONTROLLER APSW]/

namespace GenioMVC.Controllers
{
	public partial class ApswController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PSW_CANCEL = new("PSW12932", "Psw_Cancel", "Apsw") { vueRouteName = "form-PSW", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PSW_SHOW = new("PSW12932", "Psw_Show", "Apsw") { vueRouteName = "form-PSW", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PSW_NEW = new("PSW12932", "Psw_New", "Apsw") { vueRouteName = "form-PSW", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PSW_EDIT = new("PSW12932", "Psw_Edit", "Apsw") { vueRouteName = "form-PSW", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PSW_DUPLICATE = new("PSW12932", "Psw_Duplicate", "Apsw") { vueRouteName = "form-PSW", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PSW_DELETE = new("PSW12932", "Psw_Delete", "Apsw") { vueRouteName = "form-PSW", mode = "DELETE" };

		#endregion

		#region Psw private

		private void FormHistoryLimits_Psw()
		{

		}

		#endregion

		#region Psw_Show

// USE /[MANUAL PJF CONTROLLER_SHOW PSW]/

		[HttpPost]
		public ActionResult Psw_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Psw_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Psw_Show_GET",
				AreaName = "apsw",
				Location = ACTION_PSW_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Psw();
// USE /[MANUAL PJF BEFORE_LOAD_SHOW PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_SHOW PSW]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Psw_New

// USE /[MANUAL PJF CONTROLLER_NEW_GET PSW]/
		[HttpPost]
		public ActionResult Psw_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Psw_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Psw_New_GET",
				AreaName = "apsw",
				FormName = "PSW",
				Location = ACTION_PSW_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Psw();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW PSW]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Apsw/Psw_New
// USE /[MANUAL PJF CONTROLLER_NEW_POST PSW]/
		[HttpPost]
		public ActionResult Psw_New([FromBody]Psw_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Psw_New",
				ViewName = "Psw",
				AreaName = "apsw",
				Location = ACTION_PSW_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_NEW PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_NEW PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_NEW_EX PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_NEW_EX PSW]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Psw_Edit

// USE /[MANUAL PJF CONTROLLER_EDIT_GET PSW]/
		[HttpPost]
		public ActionResult Psw_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Psw_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Psw_Edit_GET",
				AreaName = "apsw",
				FormName = "PSW",
				Location = ACTION_PSW_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Psw();
// USE /[MANUAL PJF BEFORE_LOAD_EDIT PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT PSW]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Apsw/Psw_Edit
// USE /[MANUAL PJF CONTROLLER_EDIT_POST PSW]/
		[HttpPost]
		public ActionResult Psw_Edit([FromBody]Psw_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Psw_Edit",
				ViewName = "Psw",
				AreaName = "apsw",
				Location = ACTION_PSW_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_EDIT PSW]/				
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_EDIT PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_EDIT_EX PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_EDIT_EX PSW]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Psw_Delete

// USE /[MANUAL PJF CONTROLLER_DELETE_GET PSW]/
		[HttpPost]
		public ActionResult Psw_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Psw_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Psw_Delete_GET",
				AreaName = "apsw",
				FormName = "PSW",
				Location = ACTION_PSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Psw();
// USE /[MANUAL PJF BEFORE_LOAD_DELETE PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DELETE PSW]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Apsw/Psw_Delete
// USE /[MANUAL PJF CONTROLLER_DELETE_POST PSW]/
		[HttpPost]
		public ActionResult Psw_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Psw_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Psw_Delete",
				ViewName = "Psw",
				AreaName = "apsw",
				Location = ACTION_PSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_DESTROY_DELETE PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_DESTROY_DELETE PSW]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Psw_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PSW");
		}

		#endregion

		#region Psw_Duplicate

// USE /[MANUAL PJF CONTROLLER_DUPLICATE_GET PSW]/

		[HttpPost]
		public ActionResult Psw_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Psw_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Psw_Duplicate_GET",
				AreaName = "apsw",
				FormName = "PSW",
				Location = ACTION_PSW_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE PSW]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Apsw/Psw_Duplicate
// USE /[MANUAL PJF CONTROLLER_DUPLICATE_POST PSW]/
		[HttpPost]
		public ActionResult Psw_Duplicate([FromBody]Psw_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Psw_Duplicate",
				ViewName = "Psw",
				AreaName = "apsw",
				Location = ACTION_PSW_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_SAVE_DUPLICATE PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_SAVE_DUPLICATE PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_LOAD_DUPLICATE_EX PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_LOAD_DUPLICATE_EX PSW]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Psw_Cancel

		//
		// GET: /Apsw/Psw_Cancel
// USE /[MANUAL PJF CONTROLLER_CANCEL_GET PSW]/
		public ActionResult Psw_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Apsw(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("apsw");

// USE /[MANUAL PJF BEFORE_CANCEL PSW]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PJF AFTER_CANCEL PSW]/

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

				Navigation.SetValue("ForcePrimaryRead_apsw", "true", true);
			}

			Navigation.ClearValue("apsw");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Apsw/Psw_AirlnValName
		// POST: /Apsw/Psw_AirlnValName
		[ActionName("Psw_AirlnValName")]
		public ActionResult Psw_AirlnValName([FromBody]RequestLookupModel requestModel)
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
			Psw_AirlnValName_ViewModel model = new Psw_AirlnValName_ViewModel(UserContext.Current);

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
		// GET: /Apsw/Psw_PswValNome
		// POST: /Apsw/Psw_PswValNome
		[ActionName("Psw_PswValNome")]
		public ActionResult Psw_PswValNome([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_psw");
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
			Psw_PswValNome_ViewModel model = new Psw_PswValNome_ViewModel(UserContext.Current);

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


		// POST: /Apsw/Psw_SaveEdit
		[HttpPost]
		public ActionResult Psw_SaveEdit([FromBody]Psw_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Psw_SaveEdit",
				ViewName = "Psw",
				AreaName = "apsw",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PJF BEFORE_APPLY_EDIT PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PJF AFTER_APPLY_EDIT PSW]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
