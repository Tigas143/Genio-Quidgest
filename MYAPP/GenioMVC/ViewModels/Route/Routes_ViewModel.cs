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

namespace GenioMVC.ViewModels.Route
{
	public class Routes_ViewModel : FormViewModel<Models.Route>
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
		/// Title: "Destination Airport" | Type: "CE"
		/// </summary>
		public string ValAirds { get; set; }
		/// <summary>
		/// Title: "Airline" | Type: "CE"
		/// </summary>
		public string ValCodairln { get; set; }
		/// <summary>
		/// Title: "Source Airport" | Type: "CE"
		/// </summary>
		public string ValAirsc { get; set; }

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
		/// Title: "Source Airport" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Airsc> TableAirscName { get; set; }
		/// <summary>
		/// Title: "Destination Airport" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Airds> TableAirdsName { get; set; }
		/// <summary>
		/// Title: "Estimated duration" | Type: "T"
		/// </summary>
		public string ValDuration { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodroute { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Routes_ViewModel() : base(null!) { }

		public Routes_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FROUTES", nestedForm) { }

		public Routes_ViewModel(UserContext userContext, Models.Route row, bool nestedForm = false) : base(userContext, "FROUTES", row, nestedForm) { }

		public Routes_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("route", id);
			Model = Models.Route.Find(id, userContext, "FROUTES", fieldsToQuery: fieldsToLoad);
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
			Models.Route model = new Models.Route(userContext) { Identifier = "FROUTES" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FROUTES");
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
			Models.Route model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Route m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Route) to ViewModel (Routes) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAirds = ViewModelConversion.ToString(m.ValAirds);
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValAirsc = ViewModelConversion.ToString(m.ValAirsc);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValDuration = ViewModelConversion.ToString(m.ValDuration);
				ValCodroute = ViewModelConversion.ToString(m.ValCodroute);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Route) to ViewModel (Routes) - Error during mapping");
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
		public override void MapToModel(Models.Route m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Routes) to Model (Route) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAirds = ViewModelConversion.ToString(ValAirds);
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				m.ValAirsc = ViewModelConversion.ToString(ValAirsc);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDuration = ViewModelConversion.ToString(ValDuration);
				m.ValCodroute = ViewModelConversion.ToString(ValCodroute);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Routes) to Model (Route) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "route.airds":
						this.ValAirds = ViewModelConversion.ToString(_value);
						break;
					case "route.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "route.airsc":
						this.ValAirsc = ViewModelConversion.ToString(_value);
						break;
					case "route.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "route.duration":
						this.ValDuration = ViewModelConversion.ToString(_value);
						break;
					case "route.codroute":
						this.ValCodroute = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Routes) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Routes)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Route.Find(id ?? Navigation.GetStrValue("route"), m_userContext, "FROUTES"); }
			finally { Model ??= new Models.Route(m_userContext) { Identifier = "FROUTES" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Route.Find(Navigation.GetStrValue("route"), m_userContext, "FROUTES");
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

			Model.Identifier = "FROUTES";
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

		protected override void LoadDocumentsProperties(Models.Route row)
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
				Model = Models.Route.Find(Navigation.GetStrValue("route"), m_userContext, "FROUTES");
				if (Model == null)
				{
					Model = new Models.Route(m_userContext) { Identifier = "FROUTES" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("route");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Routes__airlnname____(qs, lazyLoad);
			Load_Routes__airscname____(qs, lazyLoad);
			Load_Routes__airdsname____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL ROUTES]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW ROUTES]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 10);
			validator.Required("ValName", Resources.Resources.NAME31974, ViewModelConversion.ToString(ValName), FieldType.TEXTO.Formatting);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE ROUTES]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY ROUTES]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE ROUTES]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY ROUTES]/
		public override void Destroy(string id)
		{
			Model = Models.Route.Find(id, m_userContext, "FROUTES");
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
		public void Load_Routes__airlnname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool routes__airlnname____DoLoad = true;
			CriteriaSet routes__airlnname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("airln", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					routes__airlnname____Conds.Equal(CSGenioAairln.FldCodairln, hValue);
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
				FillDependant_RoutesTableAirlnName(lazyLoad);
				//Check if foreignkey comes from history
				TableAirlnName.FilledByHistory = Navigation.CheckFilledByHistory("airln");
				return;
			}

			if (routes__airlnname____DoLoad)
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
				routes__airlnname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAirlnName"] != null ? qs["pTableAirlnName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAairln.FldCodairln, CSGenioAairln.FldName, CSGenioAairln.FldZzstate };

// USE /[MANUAL PJF OVERRQ ROUTES_AIRLNNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("airln", FormMode.New) || Navigation.checkFormMode("airln", FormMode.Duplicate))
					routes__airlnname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAairln.FldZzstate, 0)
						.Equal(CSGenioAairln.FldCodairln, Navigation.GetStrValue("airln")));
				else
					routes__airlnname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAairln.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("airln", "name");
				ListingMVC<CSGenioAairln> listing = Models.ModelBase.Where<CSGenioAairln>(m_userContext, false, routes__airlnname____Conds, fields, offset, numberItems, sorts, "LED_ROUTES__AIRLNNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAirlnName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAirlnName.Query = query;
				TableAirlnName.Elements = listing.RowsForViewModel<GenioMVC.Models.Airln>((r) => new GenioMVC.Models.Airln(m_userContext, r, true, _fieldsToSerialize_ROUTES__AIRLNNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_airln") != null)
				{
					this.ValCodairln = Navigation.GetStrValue("RETURN_airln");
					Navigation.CurrentLevel.SetEntry("RETURN_airln", null);
				}

				TableAirlnName.List = new SelectList(TableAirlnName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairln,  x => x.ValCodairln == this.ValCodairln), "Value", "Text", this.ValCodairln);
				FillDependant_RoutesTableAirlnName();

				//Check if foreignkey comes from history
				TableAirlnName.FilledByHistory = Navigation.CheckFilledByHistory("airln");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAirlnName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Airln</param>
		public ConcurrentDictionary<string, object> GetDependant_RoutesTableAirlnName(string PKey)
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
		public void FillDependant_RoutesTableAirlnName(bool lazyLoad = false)
		{
			var row = GetDependant_RoutesTableAirlnName(this.ValCodairln);
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

		private readonly string[] _fieldsToSerialize_ROUTES__AIRLNNAME____ = ["Airln", "Airln.ValCodairln", "Airln.ValZzstate", "Airln.ValName"];

		/// <summary>
		/// TableAirscName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Routes__airscname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool routes__airscname____DoLoad = true;
			CriteriaSet routes__airscname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("airsc", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					routes__airscname____Conds.Equal(CSGenioAairsc.FldCodairpt, hValue);
					this.ValAirsc = DBConversion.ToString(hValue);
				}
			}

			TableAirscName = new TableDBEdit<Models.Airsc>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_airsc") != null)
				{
					this.ValAirsc = Navigation.GetStrValue("RETURN_airsc");
					Navigation.CurrentLevel.SetEntry("RETURN_airsc", null);
				}
				FillDependant_RoutesTableAirscName(lazyLoad);
				//Check if foreignkey comes from history
				TableAirscName.FilledByHistory = Navigation.CheckFilledByHistory("airsc");
				return;
			}

			if (routes__airscname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAirscName, "sTableAirscName", "dTableAirscName", qs, "airsc");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAairsc.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAirscName_tableFilters"]))
					TableAirscName.TableFilters = bool.Parse(qs["TableAirscName_tableFilters"]);
				else
					TableAirscName.TableFilters = false;

				query = qs["qTableAirscName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAairsc.FldName, query + "%");
				}
				routes__airscname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAirscName"] != null ? qs["pTableAirscName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAairsc.FldCodairpt, CSGenioAairsc.FldName, CSGenioAairsc.FldZzstate };

// USE /[MANUAL PJF OVERRQ ROUTES_AIRSCNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("airsc", FormMode.New) || Navigation.checkFormMode("airsc", FormMode.Duplicate))
					routes__airscname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAairsc.FldZzstate, 0)
						.Equal(CSGenioAairsc.FldCodairpt, Navigation.GetStrValue("airsc")));
				else
					routes__airscname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAairsc.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("airsc", "name");
				ListingMVC<CSGenioAairsc> listing = Models.ModelBase.Where<CSGenioAairsc>(m_userContext, false, routes__airscname____Conds, fields, offset, numberItems, sorts, "LED_ROUTES__AIRSCNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAirscName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAirscName.Query = query;
				TableAirscName.Elements = listing.RowsForViewModel<GenioMVC.Models.Airsc>((r) => new GenioMVC.Models.Airsc(m_userContext, r, true, _fieldsToSerialize_ROUTES__AIRSCNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_airsc") != null)
				{
					this.ValAirsc = Navigation.GetStrValue("RETURN_airsc");
					Navigation.CurrentLevel.SetEntry("RETURN_airsc", null);
				}

				TableAirscName.List = new SelectList(TableAirscName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairpt,  x => x.ValCodairpt == this.ValAirsc), "Value", "Text", this.ValAirsc);
				FillDependant_RoutesTableAirscName();

				//Check if foreignkey comes from history
				TableAirscName.FilledByHistory = Navigation.CheckFilledByHistory("airsc");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAirscName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Airsc</param>
		public ConcurrentDictionary<string, object> GetDependant_RoutesTableAirscName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAairsc.FldCodairpt, CSGenioAairsc.FldName];

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

			CSGenioAairsc tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAairsc.FldCodairpt, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAirscName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_RoutesTableAirscName(bool lazyLoad = false)
		{
			var row = GetDependant_RoutesTableAirscName(this.ValAirsc);
			try
			{

				// Fill List fields
				this.ValAirsc = ViewModelConversion.ToString(row["airsc.codairpt"]);
				TableAirscName.Value = (string)row["airsc.name"];
				if (GlobalFunctions.emptyG(this.ValAirsc) == 1)
				{
					this.ValAirsc = "";
					TableAirscName.Value = "";
					Navigation.ClearValue("airsc");
				}
				else if (lazyLoad)
				{
					TableAirscName.SetPagination(1, 0, false, false, 1);
					TableAirscName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValAirsc),
							Text = Convert.ToString(TableAirscName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValAirsc);
				}

				TableAirscName.Selected = this.ValAirsc;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAirscName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ROUTES__AIRSCNAME____ = ["Airsc", "Airsc.ValCodairpt", "Airsc.ValZzstate", "Airsc.ValName"];

		/// <summary>
		/// TableAirdsName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Routes__airdsname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool routes__airdsname____DoLoad = true;
			CriteriaSet routes__airdsname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("airds", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					routes__airdsname____Conds.Equal(CSGenioAairds.FldCodairpt, hValue);
					this.ValAirds = DBConversion.ToString(hValue);
				}
			}

			TableAirdsName = new TableDBEdit<Models.Airds>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_airds") != null)
				{
					this.ValAirds = Navigation.GetStrValue("RETURN_airds");
					Navigation.CurrentLevel.SetEntry("RETURN_airds", null);
				}
				FillDependant_RoutesTableAirdsName(lazyLoad);
				//Check if foreignkey comes from history
				TableAirdsName.FilledByHistory = Navigation.CheckFilledByHistory("airds");
				return;
			}

			if (routes__airdsname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAirdsName, "sTableAirdsName", "dTableAirdsName", qs, "airds");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAairds.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAirdsName_tableFilters"]))
					TableAirdsName.TableFilters = bool.Parse(qs["TableAirdsName_tableFilters"]);
				else
					TableAirdsName.TableFilters = false;

				query = qs["qTableAirdsName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAairds.FldName, query + "%");
				}
				routes__airdsname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAirdsName"] != null ? qs["pTableAirdsName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAairds.FldCodairpt, CSGenioAairds.FldName, CSGenioAairds.FldZzstate };

// USE /[MANUAL PJF OVERRQ ROUTES_AIRDSNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("airds", FormMode.New) || Navigation.checkFormMode("airds", FormMode.Duplicate))
					routes__airdsname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAairds.FldZzstate, 0)
						.Equal(CSGenioAairds.FldCodairpt, Navigation.GetStrValue("airds")));
				else
					routes__airdsname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAairds.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("airds", "name");
				ListingMVC<CSGenioAairds> listing = Models.ModelBase.Where<CSGenioAairds>(m_userContext, false, routes__airdsname____Conds, fields, offset, numberItems, sorts, "LED_ROUTES__AIRDSNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAirdsName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAirdsName.Query = query;
				TableAirdsName.Elements = listing.RowsForViewModel<GenioMVC.Models.Airds>((r) => new GenioMVC.Models.Airds(m_userContext, r, true, _fieldsToSerialize_ROUTES__AIRDSNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_airds") != null)
				{
					this.ValAirds = Navigation.GetStrValue("RETURN_airds");
					Navigation.CurrentLevel.SetEntry("RETURN_airds", null);
				}

				TableAirdsName.List = new SelectList(TableAirdsName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairpt,  x => x.ValCodairpt == this.ValAirds), "Value", "Text", this.ValAirds);
				FillDependant_RoutesTableAirdsName();

				//Check if foreignkey comes from history
				TableAirdsName.FilledByHistory = Navigation.CheckFilledByHistory("airds");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAirdsName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Airds</param>
		public ConcurrentDictionary<string, object> GetDependant_RoutesTableAirdsName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAairds.FldCodairpt, CSGenioAairds.FldName];

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

			CSGenioAairds tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAairds.FldCodairpt, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAirdsName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_RoutesTableAirdsName(bool lazyLoad = false)
		{
			var row = GetDependant_RoutesTableAirdsName(this.ValAirds);
			try
			{

				// Fill List fields
				this.ValAirds = ViewModelConversion.ToString(row["airds.codairpt"]);
				TableAirdsName.Value = (string)row["airds.name"];
				if (GlobalFunctions.emptyG(this.ValAirds) == 1)
				{
					this.ValAirds = "";
					TableAirdsName.Value = "";
					Navigation.ClearValue("airds");
				}
				else if (lazyLoad)
				{
					TableAirdsName.SetPagination(1, 0, false, false, 1);
					TableAirdsName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValAirds),
							Text = Convert.ToString(TableAirdsName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValAirds);
				}

				TableAirdsName.Selected = this.ValAirds;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAirdsName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ROUTES__AIRDSNAME____ = ["Airds", "Airds.ValCodairpt", "Airds.ValZzstate", "Airds.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"route.airds" => ViewModelConversion.ToString(modelValue),
				"route.codairln" => ViewModelConversion.ToString(modelValue),
				"route.airsc" => ViewModelConversion.ToString(modelValue),
				"route.name" => ViewModelConversion.ToString(modelValue),
				"route.duration" => ViewModelConversion.ToString(modelValue),
				"route.codroute" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"airsc.codairpt" => ViewModelConversion.ToString(modelValue),
				"airsc.name" => ViewModelConversion.ToString(modelValue),
				"airds.codairpt" => ViewModelConversion.ToString(modelValue),
				"airds.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM ROUTES]/

		#endregion
	}
}
