using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
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

namespace GenioMVC.ViewModels.Airpt
{
	public class Airports_ViewModel : FormViewModel<Models.Airpt>
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
		/// Title: "City" | Type: "CE"
		/// </summary>
		public string ValCodcity { get; set; }

		#endregion
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "City" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.City> TableCityCity { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodairpt { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Airports_ViewModel() : base(null!) { }

		public Airports_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FAIRPORTS", nestedForm) { }

		public Airports_ViewModel(UserContext userContext, Models.Airpt row, bool nestedForm = false) : base(userContext, "FAIRPORTS", row, nestedForm) { }

		public Airports_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("airpt", id);
			Model = Models.Airpt.Find(id, userContext, "FAIRPORTS", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_10;
			this.RoleToEdit = CSGenio.framework.Role.ADMINISTRATION;
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
			Models.Airpt model = new Models.Airpt(userContext) { Identifier = "FAIRPORTS" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FAIRPORTS");
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
			Models.Airpt model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Airpt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Airpt) to ViewModel (Airports) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcity = ViewModelConversion.ToString(m.ValCodcity);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValCodairpt = ViewModelConversion.ToString(m.ValCodairpt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Airpt) to ViewModel (Airports) - Error during mapping");
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
		public override void MapToModel(Models.Airpt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Airports) to Model (Airpt) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodcity = ViewModelConversion.ToString(ValCodcity);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodairpt = ViewModelConversion.ToString(ValCodairpt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Airports) to Model (Airpt) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "airpt.codcity":
						this.ValCodcity = ViewModelConversion.ToString(_value);
						break;
					case "airpt.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "airpt.codairpt":
						this.ValCodairpt = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Airports) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Airports)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Airpt.Find(id ?? Navigation.GetStrValue("airpt"), m_userContext, "FAIRPORTS"); }
			finally { Model ??= new Models.Airpt(m_userContext) { Identifier = "FAIRPORTS" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Airpt.Find(Navigation.GetStrValue("airpt"), m_userContext, "FAIRPORTS");
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

			Model.Identifier = "FAIRPORTS";
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

		protected override void LoadDocumentsProperties(Models.Airpt row)
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
				Model = Models.Airpt.Find(Navigation.GetStrValue("airpt"), m_userContext, "FAIRPORTS");
				if (Model == null)
				{
					Model = new Models.Airpt(m_userContext) { Identifier = "FAIRPORTS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("airpt");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Airportscity_city____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL AIRPORTS]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW AIRPORTS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.Required("ValCodcity", Resources.Resources.CITY42505, ViewModelConversion.ToString(ValCodcity), FieldType.CHAVE_ESTRANGEIRA.Formatting);
			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE AIRPORTS]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY AIRPORTS]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE AIRPORTS]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY AIRPORTS]/
		public override void Destroy(string id)
		{
			Model = Models.Airpt.Find(id, m_userContext, "FAIRPORTS");
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
		/// TableCityCity -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Airportscity_city____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool airportscity_city____DoLoad = true;
			CriteriaSet airportscity_city____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("city", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					airportscity_city____Conds.Equal(CSGenioAcity.FldCodcity, hValue);
					this.ValCodcity = DBConversion.ToString(hValue);
				}
			}

			TableCityCity = new TableDBEdit<Models.City>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}
				FillDependant_AirportsTableCityCity(lazyLoad);
				//Check if foreignkey comes from history
				TableCityCity.FilledByHistory = Navigation.CheckFilledByHistory("city");
				return;
			}

			if (airportscity_city____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCityCity, "sTableCityCity", "dTableCityCity", qs, "city");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcity.FldCity), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCityCity_tableFilters"]))
					TableCityCity.TableFilters = bool.Parse(qs["TableCityCity_tableFilters"]);
				else
					TableCityCity.TableFilters = false;

				query = qs["qTableCityCity"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcity.FldCity, query + "%");
				}
				airportscity_city____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCityCity"] != null ? qs["pTableCityCity"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAcity.FldZzstate };

// USE /[MANUAL PJF OVERRQ AIRPORTS_CITYCITY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("city", FormMode.New) || Navigation.checkFormMode("city", FormMode.Duplicate))
					airportscity_city____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcity.FldZzstate, 0)
						.Equal(CSGenioAcity.FldCodcity, Navigation.GetStrValue("city")));
				else
					airportscity_city____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcity.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("city", "city");
				ListingMVC<CSGenioAcity> listing = Models.ModelBase.Where<CSGenioAcity>(m_userContext, false, airportscity_city____Conds, fields, offset, numberItems, sorts, "LED_AIRPORTSCITY_CITY____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCityCity.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCityCity.Query = query;
				TableCityCity.Elements = listing.RowsForViewModel<GenioMVC.Models.City>((r) => new GenioMVC.Models.City(m_userContext, r, true, _fieldsToSerialize_AIRPORTSCITY_CITY____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}

				TableCityCity.List = new SelectList(TableCityCity.Elements.ToSelectList(x => x.ValCity, x => x.ValCodcity,  x => x.ValCodcity == this.ValCodcity), "Value", "Text", this.ValCodcity);
				FillDependant_AirportsTableCityCity();

				//Check if foreignkey comes from history
				TableCityCity.FilledByHistory = Navigation.CheckFilledByHistory("city");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of City</param>
		public ConcurrentDictionary<string, object> GetDependant_AirportsTableCityCity(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcity.FldCodcity, CSGenioAcity.FldCity];

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

			CSGenioAcity tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcity.FldCodcity, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AirportsTableCityCity(bool lazyLoad = false)
		{
			var row = GetDependant_AirportsTableCityCity(this.ValCodcity);
			try
			{

				// Fill List fields
				this.ValCodcity = ViewModelConversion.ToString(row["city.codcity"]);
				TableCityCity.Value = (string)row["city.city"];
				if (GlobalFunctions.emptyG(this.ValCodcity) == 1)
				{
					this.ValCodcity = "";
					TableCityCity.Value = "";
					Navigation.ClearValue("city");
				}
				else if (lazyLoad)
				{
					TableCityCity.SetPagination(1, 0, false, false, 1);
					TableCityCity.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcity),
							Text = Convert.ToString(TableCityCity.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcity);
				}

				TableCityCity.Selected = this.ValCodcity;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCityCity): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_AIRPORTSCITY_CITY____ = ["City", "City.ValCodcity", "City.ValZzstate", "City.ValCity"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"airpt.codcity" => ViewModelConversion.ToString(modelValue),
				"airpt.name" => ViewModelConversion.ToString(modelValue),
				"airpt.codairpt" => ViewModelConversion.ToString(modelValue),
				"city.codcity" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM AIRPORTS]/

		#endregion
	}
}
