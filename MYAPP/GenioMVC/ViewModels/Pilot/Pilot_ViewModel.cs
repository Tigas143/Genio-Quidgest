﻿using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Pilot
{
	public class Pilot_ViewModel : FormViewModel<Models.Pilot>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Airline" | Type: "CE"
		/// </summary>
		public string ValCodairln { get; set; }

		#endregion
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Airline" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Airln> TableAirlnName { get; set; }
		/// <summary>
		/// Title: "License number" | Type: "C"
		/// </summary>
		public string ValLicense { get; set; }
		/// <summary>
		/// Title: "Years of experience" | Type: "N"
		/// </summary>
		public decimal? ValExperien { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpilot { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Pilot_ViewModel() : base(null!) { }

		public Pilot_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPILOT", nestedForm) { }

		public Pilot_ViewModel(UserContext userContext, Models.Pilot row, bool nestedForm = false) : base(userContext, "FPILOT", row, nestedForm) { }

		public Pilot_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pilot", id);
			Model = Models.Pilot.Find(id, userContext, "FPILOT", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_10;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_90;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Pilot model = new Models.Pilot(userContext) { Identifier = "FPILOT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPILOT");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Pilot model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pilot m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pilot) to ViewModel (Pilot) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValLicense = ViewModelConversion.ToString(m.ValLicense);
				ValExperien = ViewModelConversion.ToNumeric(m.ValExperien);
				ValCodpilot = ViewModelConversion.ToString(m.ValCodpilot);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pilot) to ViewModel (Pilot) - Error during mapping");
				throw;
			}
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <param name="m">The Model to be filled.</param>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel(Models.Pilot m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pilot) to Model (Pilot) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValLicense = ViewModelConversion.ToString(ValLicense);
				m.ValExperien = ViewModelConversion.ToNumeric(ValExperien);
				m.ValCodpilot = ViewModelConversion.ToString(ValCodpilot);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Pilot) to Model (Pilot) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "pilot.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "pilot.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "pilot.license":
						this.ValLicense = ViewModelConversion.ToString(_value);
						break;
					case "pilot.experien":
						this.ValExperien = ViewModelConversion.ToNumeric(_value);
						break;
					case "pilot.codpilot":
						this.ValCodpilot = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Pilot) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Pilot)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Pilot.Find(id ?? Navigation.GetStrValue("pilot"), m_userContext, "FPILOT"); }
			finally { Model ??= new Models.Pilot(m_userContext) { Identifier = "FPILOT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Pilot.Find(Navigation.GetStrValue("pilot"), m_userContext, "FPILOT");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FPILOT";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Pilot row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Pilot.Find(Navigation.GetStrValue("pilot"), m_userContext, "FPILOT");
				if (Model == null)
				{
					Model = new Models.Pilot(m_userContext) { Identifier = "FPILOT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pilot");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pilot___airlnname____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL PILOT]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW PILOT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 10);
			validator.Required("ValName", Resources.Resources.NAME31974, ViewModelConversion.ToString(ValName), FieldType.TEXTO.Formatting);
			validator.StringLength("ValLicense", Resources.Resources.LICENSE_NUMBER26109, ValLicense, 30);
			validator.Required("ValLicense", Resources.Resources.LICENSE_NUMBER26109, ViewModelConversion.ToString(ValLicense), FieldType.TEXTO.Formatting);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE PILOT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY PILOT]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE PILOT]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY PILOT]/
		public override void Destroy(string id)
		{
			Model = Models.Pilot.Find(id, m_userContext, "FPILOT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableAirlnName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pilot___airlnname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pilot___airlnname____DoLoad = true;
			CriteriaSet pilot___airlnname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("airln", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pilot___airlnname____Conds.Equal(CSGenioAairln.FldCodairln, hValue);
					this.ValCodairln = DBConversion.ToString(hValue);
				}
			}

			TableAirlnName = new TableDBEdit<Models.Airln>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_airln") != null)
				{
					this.ValCodairln = Navigation.GetStrValue("RETURN_airln");
					Navigation.CurrentLevel.SetEntry("RETURN_airln", null);
				}
				FillDependant_PilotTableAirlnName(lazyLoad);
				//Check if foreignkey comes from history
				TableAirlnName.FilledByHistory = Navigation.CheckFilledByHistory("airln");
				return;
			}

			if (pilot___airlnname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAirlnName, "sTableAirlnName", "dTableAirlnName", qs, "airln");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAairln.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAirlnName_tableFilters"]))
					TableAirlnName.TableFilters = bool.Parse(qs["TableAirlnName_tableFilters"]);
				else
					TableAirlnName.TableFilters = false;

				query = qs["qTableAirlnName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAairln.FldName, query + "%");
				}
				pilot___airlnname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAirlnName"] != null ? qs["pTableAirlnName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAairln.FldCodairln, CSGenioAairln.FldName, CSGenioAairln.FldZzstate };

// USE /[MANUAL PJF OVERRQ PILOT_AIRLNNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("airln", FormMode.New) || Navigation.checkFormMode("airln", FormMode.Duplicate))
					pilot___airlnname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAairln.FldZzstate, 0)
						.Equal(CSGenioAairln.FldCodairln, Navigation.GetStrValue("airln")));
				else
					pilot___airlnname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAairln.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("airln", "name");
				ListingMVC<CSGenioAairln> listing = Models.ModelBase.Where<CSGenioAairln>(m_userContext, false, pilot___airlnname____Conds, fields, offset, numberItems, sorts, "LED_PILOT___AIRLNNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAirlnName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAirlnName.Query = query;
				TableAirlnName.Elements = listing.RowsForViewModel<GenioMVC.Models.Airln>((r) => new GenioMVC.Models.Airln(m_userContext, r, true, _fieldsToSerialize_PILOT___AIRLNNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_airln") != null)
				{
					this.ValCodairln = Navigation.GetStrValue("RETURN_airln");
					Navigation.CurrentLevel.SetEntry("RETURN_airln", null);
				}

				TableAirlnName.List = new SelectList(TableAirlnName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairln,  x => x.ValCodairln == this.ValCodairln), "Value", "Text", this.ValCodairln);
				FillDependant_PilotTableAirlnName();

				//Check if foreignkey comes from history
				TableAirlnName.FilledByHistory = Navigation.CheckFilledByHistory("airln");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAirlnName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Airln</param>
		public ConcurrentDictionary<string, object> GetDependant_PilotTableAirlnName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAairln.FldCodairln, CSGenioAairln.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAairln tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAairln.FldCodairln, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAirlnName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PilotTableAirlnName(bool lazyLoad = false)
		{
			var row = GetDependant_PilotTableAirlnName(this.ValCodairln);
			try
			{

				// Fill List fields
				this.ValCodairln = ViewModelConversion.ToString(row["airln.codairln"]);
				TableAirlnName.Value = (string)row["airln.name"];
				if (GlobalFunctions.emptyG(this.ValCodairln) == 1)
				{
					this.ValCodairln = "";
					TableAirlnName.Value = "";
					Navigation.ClearValue("airln");
				}
				else if (lazyLoad)
				{
					TableAirlnName.SetPagination(1, 0, false, false, 1);
					TableAirlnName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodairln),
							Text = Convert.ToString(TableAirlnName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodairln);
				}

				TableAirlnName.Selected = this.ValCodairln;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAirlnName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PILOT___AIRLNNAME____ = ["Airln", "Airln.ValCodairln", "Airln.ValZzstate", "Airln.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pilot.codairln" => ViewModelConversion.ToString(modelValue),
				"pilot.name" => ViewModelConversion.ToString(modelValue),
				"pilot.license" => ViewModelConversion.ToString(modelValue),
				"pilot.experien" => ViewModelConversion.ToNumeric(modelValue),
				"pilot.codpilot" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM PILOT]/

		#endregion
	}
}
