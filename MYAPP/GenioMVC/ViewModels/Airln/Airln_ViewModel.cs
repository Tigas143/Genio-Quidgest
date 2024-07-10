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

namespace GenioMVC.ViewModels.Airln
{
	public class Airln_ViewModel : FormViewModel<Models.Airln>
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
		/// Title: "Airport" | Type: "CE"
		/// </summary>
		public string ValCodairhb { get; set; }
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
		/// <summary>
		/// Title: "Airport" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Airhb> TableAirhbName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodairln { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Airln_ViewModel() : base(null!) { }

		public Airln_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FAIRLN", nestedForm) { }

		public Airln_ViewModel(UserContext userContext, Models.Airln row, bool nestedForm = false) : base(userContext, "FAIRLN", row, nestedForm) { }

		public Airln_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("airln", id);
			Model = Models.Airln.Find(id, userContext, "FAIRLN", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Airln model = new Models.Airln(userContext) { Identifier = "FAIRLN" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FAIRLN");
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
			Models.Airln model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Airln m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Airln) to ViewModel (Airln) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodairhb = ViewModelConversion.ToString(m.ValCodairhb);
				ValCodcity = ViewModelConversion.ToString(m.ValCodcity);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Airln) to ViewModel (Airln) - Error during mapping");
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
		public override void MapToModel(Models.Airln m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Airln) to Model (Airln) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodairhb = ViewModelConversion.ToString(ValCodairhb);
				m.ValCodcity = ViewModelConversion.ToString(ValCodcity);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Airln) to Model (Airln) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "airln.codairhb":
						this.ValCodairhb = ViewModelConversion.ToString(_value);
						break;
					case "airln.codcity":
						this.ValCodcity = ViewModelConversion.ToString(_value);
						break;
					case "airln.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "airln.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Airln) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Airln)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Airln.Find(id ?? Navigation.GetStrValue("airln"), m_userContext, "FAIRLN"); }
			finally { Model ??= new Models.Airln(m_userContext) { Identifier = "FAIRLN" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Airln.Find(Navigation.GetStrValue("airln"), m_userContext, "FAIRLN");
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

			Model.Identifier = "FAIRLN";
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

		protected override void LoadDocumentsProperties(Models.Airln row)
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
				Model = Models.Airln.Find(Navigation.GetStrValue("airln"), m_userContext, "FAIRLN");
				if (Model == null)
				{
					Model = new Models.Airln(m_userContext) { Identifier = "FAIRLN" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("airln");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Airln___city_city____(qs, lazyLoad);
			Load_Airln___airhbname____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL AIRLN]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW AIRLN]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 9);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE AIRLN]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY AIRLN]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE AIRLN]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY AIRLN]/
		public override void Destroy(string id)
		{
			Model = Models.Airln.Find(id, m_userContext, "FAIRLN");
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
		public void Load_Airln___city_city____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool airln___city_city____DoLoad = true;
			CriteriaSet airln___city_city____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("city", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					airln___city_city____Conds.Equal(CSGenioAcity.FldCodcity, hValue);
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
				FillDependant_AirlnTableCityCity(lazyLoad);
				//Check if foreignkey comes from history
				TableCityCity.FilledByHistory = Navigation.CheckFilledByHistory("city");
				return;
			}

			if (airln___city_city____DoLoad)
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
				airln___city_city____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCityCity"] != null ? qs["pTableCityCity"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAcity.FldZzstate };

// USE /[MANUAL PJF OVERRQ AIRLN_CITYCITY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("city", FormMode.New) || Navigation.checkFormMode("city", FormMode.Duplicate))
					airln___city_city____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcity.FldZzstate, 0)
						.Equal(CSGenioAcity.FldCodcity, Navigation.GetStrValue("city")));
				else
					airln___city_city____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcity.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("city", "city");
				ListingMVC<CSGenioAcity> listing = Models.ModelBase.Where<CSGenioAcity>(m_userContext, false, airln___city_city____Conds, fields, offset, numberItems, sorts, "LED_AIRLN___CITY_CITY____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCityCity.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCityCity.Query = query;
				TableCityCity.Elements = listing.RowsForViewModel<GenioMVC.Models.City>((r) => new GenioMVC.Models.City(m_userContext, r, true, _fieldsToSerialize_AIRLN___CITY_CITY____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}

				TableCityCity.List = new SelectList(TableCityCity.Elements.ToSelectList(x => x.ValCity, x => x.ValCodcity,  x => x.ValCodcity == this.ValCodcity), "Value", "Text", this.ValCodcity);
				FillDependant_AirlnTableCityCity();

				//Check if foreignkey comes from history
				TableCityCity.FilledByHistory = Navigation.CheckFilledByHistory("city");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of City</param>
		public ConcurrentDictionary<string, object> GetDependant_AirlnTableCityCity(string PKey)
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
		public void FillDependant_AirlnTableCityCity(bool lazyLoad = false)
		{
			var row = GetDependant_AirlnTableCityCity(this.ValCodcity);
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

		private readonly string[] _fieldsToSerialize_AIRLN___CITY_CITY____ = ["City", "City.ValCodcity", "City.ValZzstate", "City.ValCity"];

		/// <summary>
		/// TableAirhbName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Airln___airhbname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool airln___airhbname____DoLoad = true;
			CriteriaSet airln___airhbname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("airhb", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					airln___airhbname____Conds.Equal(CSGenioAairhb.FldCodairpt, hValue);
					this.ValCodairhb = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			airln___airhbname____DoLoad &= AddCriteriaAreaLimit(airln___airhbname____Conds, CSGenio.business.CSGenioAcity.FldCodcity, "city", this.ValCodcity, true);

			TableAirhbName = new TableDBEdit<Models.Airhb>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_airhb") != null)
				{
					this.ValCodairhb = Navigation.GetStrValue("RETURN_airhb");
					Navigation.CurrentLevel.SetEntry("RETURN_airhb", null);
				}
				FillDependant_AirlnTableAirhbName(lazyLoad);
				//Check if foreignkey comes from history
				TableAirhbName.FilledByHistory = Navigation.CheckFilledByHistory("airhb");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcity))
				airln___airhbname____DoLoad = false;

			if (airln___airhbname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAirhbName, "sTableAirhbName", "dTableAirhbName", qs, "airhb");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAairhb.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAirhbName_tableFilters"]))
					TableAirhbName.TableFilters = bool.Parse(qs["TableAirhbName_tableFilters"]);
				else
					TableAirhbName.TableFilters = false;

				query = qs["qTableAirhbName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAairhb.FldName, query + "%");
				}
				airln___airhbname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAirhbName"] != null ? qs["pTableAirhbName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAairhb.FldCodairpt, CSGenioAairhb.FldName, CSGenioAairhb.FldZzstate };

// USE /[MANUAL PJF OVERRQ AIRLN_AIRHBNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("airhb", FormMode.New) || Navigation.checkFormMode("airhb", FormMode.Duplicate))
					airln___airhbname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAairhb.FldZzstate, 0)
						.Equal(CSGenioAairhb.FldCodairpt, Navigation.GetStrValue("airhb")));
				else
					airln___airhbname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAairhb.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("airhb", "name");
				ListingMVC<CSGenioAairhb> listing = Models.ModelBase.Where<CSGenioAairhb>(m_userContext, false, airln___airhbname____Conds, fields, offset, numberItems, sorts, "LED_AIRLN___AIRHBNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAirhbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAirhbName.Query = query;
				TableAirhbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Airhb>((r) => new GenioMVC.Models.Airhb(m_userContext, r, true, _fieldsToSerialize_AIRLN___AIRHBNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_airhb") != null)
				{
					this.ValCodairhb = Navigation.GetStrValue("RETURN_airhb");
					Navigation.CurrentLevel.SetEntry("RETURN_airhb", null);
				}

				TableAirhbName.List = new SelectList(TableAirhbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairpt,  x => x.ValCodairpt == this.ValCodairhb), "Value", "Text", this.ValCodairhb);
				FillDependant_AirlnTableAirhbName();

				//Check if foreignkey comes from history
				TableAirhbName.FilledByHistory = Navigation.CheckFilledByHistory("airhb");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAirhbName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Airhb</param>
		public ConcurrentDictionary<string, object> GetDependant_AirlnTableAirhbName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAairhb.FldCodairpt, CSGenioAairhb.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("city");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAairhb.FldCodcity, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAairhb tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAairhb.FldCodairpt, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAirhbName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AirlnTableAirhbName(bool lazyLoad = false)
		{
			var row = GetDependant_AirlnTableAirhbName(this.ValCodairhb);
			try
			{

				// Fill List fields
				this.ValCodairhb = ViewModelConversion.ToString(row["airhb.codairpt"]);
				TableAirhbName.Value = (string)row["airhb.name"];
				if (GlobalFunctions.emptyG(this.ValCodairhb) == 1)
				{
					this.ValCodairhb = "";
					TableAirhbName.Value = "";
					Navigation.ClearValue("airhb");
				}
				else if (lazyLoad)
				{
					TableAirhbName.SetPagination(1, 0, false, false, 1);
					TableAirhbName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodairhb),
							Text = Convert.ToString(TableAirhbName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodairhb);
				}

				TableAirhbName.Selected = this.ValCodairhb;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAirhbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_AIRLN___AIRHBNAME____ = ["Airhb", "Airhb.ValCodairpt", "Airhb.ValZzstate", "Airhb.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"airln.codairhb" => ViewModelConversion.ToString(modelValue),
				"airln.codcity" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				"city.codcity" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				"airhb.codairpt" => ViewModelConversion.ToString(modelValue),
				"airhb.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM AIRLN]/

		#endregion
	}
}
