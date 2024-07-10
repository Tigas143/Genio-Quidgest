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

namespace GenioMVC.ViewModels.Plane
{
	public class Planes_ViewModel : FormViewModel<Models.Plane>
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
		/// Title: "Current Airport" | Type: "CE"
		/// </summary>
		public string ValAircr { get; set; }
		/// <summary>
		/// Title: "Airline" | Type: "CE"
		/// </summary>
		public string ValCodairln { get; set; }

		#endregion
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.ViewModels.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "Model" | Type: "C"
		/// </summary>
		public string ValId { get; set; }
		/// <summary>
		/// Title: "ID" | Type: "C"
		/// </summary>
		public string ValModel { get; set; }
		/// <summary>
		/// Title: "Airline" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Airln> TableAirlnName { get; set; }
		/// <summary>
		/// Title: "Number of engines" | Type: "N"
		/// </summary>
		public decimal? ValEngines { get; set; }
		/// <summary>
		/// Title: "Manufacturer" | Type: "C"
		/// </summary>
		public string ValManufact { get; set; }
		/// <summary>
		/// Title: "Capacity" | Type: "N"
		/// </summary>
		public decimal? ValCapacity { get; set; }
		/// <summary>
		/// Title: "Date of manufacture" | Type: "D"
		/// </summary>
		public DateTime? ValYear { get; set; }
		/// <summary>
		/// Title: "Age" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValAge { get; set; }
		/// <summary>
		/// Title: "Current Airport" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Aircr> TableAircrName { get; set; }
		/// <summary>
		/// Title: "Status" | Type: "AC"
		/// </summary>
		public string ValStatus { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValStatus { get; set; }
		/// <summary>
		/// Title: "Status of maintenance" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValMaint { get; set; }
		/// <summary>
		/// Title: "" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValIsmaint { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodplane { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Planes_ViewModel() : base(null!) { }

		public Planes_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPLANES", nestedForm) { }

		public Planes_ViewModel(UserContext userContext, Models.Plane row, bool nestedForm = false) : base(userContext, "FPLANES", row, nestedForm) { }

		public Planes_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("plane", id);
			Model = Models.Plane.Find(id, userContext, "FPLANES", fieldsToQuery: fieldsToLoad);
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
			Models.Plane model = new Models.Plane(userContext) { Identifier = "FPLANES" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPLANES");
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
			Models.Plane model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Plane m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Plane) to ViewModel (Planes) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAircr = ViewModelConversion.ToString(m.ValAircr);
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValId = ViewModelConversion.ToString(m.ValId);
				ValModel = ViewModelConversion.ToString(m.ValModel);
				ValEngines = ViewModelConversion.ToNumeric(m.ValEngines);
				ValManufact = ViewModelConversion.ToString(m.ValManufact);
				ValCapacity = ViewModelConversion.ToNumeric(m.ValCapacity);
				ValYear = ViewModelConversion.ToDateTime(m.ValYear);
				ValAge = ViewModelConversion.ToNumeric(m.ValAge);
				ValStatus = ViewModelConversion.ToString(m.ValStatus);
				ValMaint = ViewModelConversion.ToNumeric(m.ValMaint);
				ValIsmaint = ViewModelConversion.ToLogic(m.ValIsmaint);
				ValCodplane = ViewModelConversion.ToString(m.ValCodplane);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Plane) to ViewModel (Planes) - Error during mapping");
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
		public override void MapToModel(Models.Plane m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Planes) to Model (Plane) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAircr = ViewModelConversion.ToString(ValAircr);
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValId = ViewModelConversion.ToString(ValId);
				m.ValModel = ViewModelConversion.ToString(ValModel);
				m.ValEngines = ViewModelConversion.ToNumeric(ValEngines);
				m.ValManufact = ViewModelConversion.ToString(ValManufact);
				m.ValCapacity = ViewModelConversion.ToNumeric(ValCapacity);
				m.ValYear = ViewModelConversion.ToDateTime(ValYear);
				m.ValStatus = ViewModelConversion.ToString(ValStatus);
				m.ValCodplane = ViewModelConversion.ToString(ValCodplane);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValAge = ViewModelConversion.ToNumeric(ValAge);
				m.ValMaint = ViewModelConversion.ToNumeric(ValMaint);
				m.ValIsmaint = ViewModelConversion.ToLogic(ValIsmaint);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Planes) to Model (Plane) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "plane.aircr":
						this.ValAircr = ViewModelConversion.ToString(_value);
						break;
					case "plane.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "plane.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "plane.id":
						this.ValId = ViewModelConversion.ToString(_value);
						break;
					case "plane.model":
						this.ValModel = ViewModelConversion.ToString(_value);
						break;
					case "plane.engines":
						this.ValEngines = ViewModelConversion.ToNumeric(_value);
						break;
					case "plane.manufact":
						this.ValManufact = ViewModelConversion.ToString(_value);
						break;
					case "plane.capacity":
						this.ValCapacity = ViewModelConversion.ToNumeric(_value);
						break;
					case "plane.year":
						this.ValYear = ViewModelConversion.ToDateTime(_value);
						break;
					case "plane.status":
						this.ValStatus = ViewModelConversion.ToString(_value);
						break;
					case "plane.codplane":
						this.ValCodplane = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Planes) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Planes)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Plane.Find(id ?? Navigation.GetStrValue("plane"), m_userContext, "FPLANES"); }
			finally { Model ??= new Models.Plane(m_userContext) { Identifier = "FPLANES" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Plane.Find(Navigation.GetStrValue("plane"), m_userContext, "FPLANES");
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

			Model.Identifier = "FPLANES";
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

		protected override void LoadDocumentsProperties(Models.Plane row)
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
				Model = Models.Plane.Find(Navigation.GetStrValue("plane"), m_userContext, "FPLANES");
				if (Model == null)
				{
					Model = new Models.Plane(m_userContext) { Identifier = "FPLANES" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("plane");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Planes__airlnname____(qs, lazyLoad);
			Load_Planes__aircrname____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL PLANES]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW PLANES]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValId", Resources.Resources.MODEL27263, ValId, 20);
			validator.Required("ValId", Resources.Resources.MODEL27263, ViewModelConversion.ToString(ValId), FieldType.TEXTO.Formatting);
			validator.StringLength("ValModel", Resources.Resources.ID48520, ValModel, 30);
			validator.Required("ValModel", Resources.Resources.ID48520, ViewModelConversion.ToString(ValModel), FieldType.TEXTO.Formatting);
			validator.StringLength("ValManufact", Resources.Resources.MANUFACTURER50759, ValManufact, 30);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE PLANES]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY PLANES]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE PLANES]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY PLANES]/
		public override void Destroy(string id)
		{
			Model = Models.Plane.Find(id, m_userContext, "FPLANES");
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
		public void Load_Planes__airlnname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool planes__airlnname____DoLoad = true;
			CriteriaSet planes__airlnname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("airln", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					planes__airlnname____Conds.Equal(CSGenioAairln.FldCodairln, hValue);
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
				FillDependant_PlanesTableAirlnName(lazyLoad);
				//Check if foreignkey comes from history
				TableAirlnName.FilledByHistory = Navigation.CheckFilledByHistory("airln");
				return;
			}

			if (planes__airlnname____DoLoad)
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
				planes__airlnname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAirlnName"] != null ? qs["pTableAirlnName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAairln.FldCodairln, CSGenioAairln.FldName, CSGenioAairln.FldZzstate };

// USE /[MANUAL PJF OVERRQ PLANES_AIRLNNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("airln", FormMode.New) || Navigation.checkFormMode("airln", FormMode.Duplicate))
					planes__airlnname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAairln.FldZzstate, 0)
						.Equal(CSGenioAairln.FldCodairln, Navigation.GetStrValue("airln")));
				else
					planes__airlnname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAairln.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("airln", "name");
				ListingMVC<CSGenioAairln> listing = Models.ModelBase.Where<CSGenioAairln>(m_userContext, false, planes__airlnname____Conds, fields, offset, numberItems, sorts, "LED_PLANES__AIRLNNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAirlnName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAirlnName.Query = query;
				TableAirlnName.Elements = listing.RowsForViewModel<GenioMVC.Models.Airln>((r) => new GenioMVC.Models.Airln(m_userContext, r, true, _fieldsToSerialize_PLANES__AIRLNNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_airln") != null)
				{
					this.ValCodairln = Navigation.GetStrValue("RETURN_airln");
					Navigation.CurrentLevel.SetEntry("RETURN_airln", null);
				}

				TableAirlnName.List = new SelectList(TableAirlnName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairln,  x => x.ValCodairln == this.ValCodairln), "Value", "Text", this.ValCodairln);
				FillDependant_PlanesTableAirlnName();

				//Check if foreignkey comes from history
				TableAirlnName.FilledByHistory = Navigation.CheckFilledByHistory("airln");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAirlnName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Airln</param>
		public ConcurrentDictionary<string, object> GetDependant_PlanesTableAirlnName(string PKey)
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
		public void FillDependant_PlanesTableAirlnName(bool lazyLoad = false)
		{
			var row = GetDependant_PlanesTableAirlnName(this.ValCodairln);
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

		private readonly string[] _fieldsToSerialize_PLANES__AIRLNNAME____ = ["Airln", "Airln.ValCodairln", "Airln.ValZzstate", "Airln.ValName"];

		/// <summary>
		/// TableAircrName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Planes__aircrname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool planes__aircrname____DoLoad = true;
			CriteriaSet planes__aircrname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("aircr", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					planes__aircrname____Conds.Equal(CSGenioAaircr.FldCodairpt, hValue);
					this.ValAircr = DBConversion.ToString(hValue);
				}
			}

			TableAircrName = new TableDBEdit<Models.Aircr>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_aircr") != null)
				{
					this.ValAircr = Navigation.GetStrValue("RETURN_aircr");
					Navigation.CurrentLevel.SetEntry("RETURN_aircr", null);
				}
				FillDependant_PlanesTableAircrName(lazyLoad);
				//Check if foreignkey comes from history
				TableAircrName.FilledByHistory = Navigation.CheckFilledByHistory("aircr");
				return;
			}

			if (planes__aircrname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAircrName, "sTableAircrName", "dTableAircrName", qs, "aircr");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAaircr.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAircrName_tableFilters"]))
					TableAircrName.TableFilters = bool.Parse(qs["TableAircrName_tableFilters"]);
				else
					TableAircrName.TableFilters = false;

				query = qs["qTableAircrName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAaircr.FldName, query + "%");
				}
				planes__aircrname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAircrName"] != null ? qs["pTableAircrName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAaircr.FldCodairpt, CSGenioAaircr.FldName, CSGenioAaircr.FldZzstate };

// USE /[MANUAL PJF OVERRQ PLANES_AIRCRNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("aircr", FormMode.New) || Navigation.checkFormMode("aircr", FormMode.Duplicate))
					planes__aircrname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAaircr.FldZzstate, 0)
						.Equal(CSGenioAaircr.FldCodairpt, Navigation.GetStrValue("aircr")));
				else
					planes__aircrname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAaircr.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("aircr", "name");
				ListingMVC<CSGenioAaircr> listing = Models.ModelBase.Where<CSGenioAaircr>(m_userContext, false, planes__aircrname____Conds, fields, offset, numberItems, sorts, "LED_PLANES__AIRCRNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAircrName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAircrName.Query = query;
				TableAircrName.Elements = listing.RowsForViewModel<GenioMVC.Models.Aircr>((r) => new GenioMVC.Models.Aircr(m_userContext, r, true, _fieldsToSerialize_PLANES__AIRCRNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_aircr") != null)
				{
					this.ValAircr = Navigation.GetStrValue("RETURN_aircr");
					Navigation.CurrentLevel.SetEntry("RETURN_aircr", null);
				}

				TableAircrName.List = new SelectList(TableAircrName.Elements.ToSelectList(x => x.ValName, x => x.ValCodairpt,  x => x.ValCodairpt == this.ValAircr), "Value", "Text", this.ValAircr);
				FillDependant_PlanesTableAircrName();

				//Check if foreignkey comes from history
				TableAircrName.FilledByHistory = Navigation.CheckFilledByHistory("aircr");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAircrName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Aircr</param>
		public ConcurrentDictionary<string, object> GetDependant_PlanesTableAircrName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAaircr.FldCodairpt, CSGenioAaircr.FldName];

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

			CSGenioAaircr tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAaircr.FldCodairpt, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAircrName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PlanesTableAircrName(bool lazyLoad = false)
		{
			var row = GetDependant_PlanesTableAircrName(this.ValAircr);
			try
			{

				// Fill List fields
				this.ValAircr = ViewModelConversion.ToString(row["aircr.codairpt"]);
				TableAircrName.Value = (string)row["aircr.name"];
				if (GlobalFunctions.emptyG(this.ValAircr) == 1)
				{
					this.ValAircr = "";
					TableAircrName.Value = "";
					Navigation.ClearValue("aircr");
				}
				else if (lazyLoad)
				{
					TableAircrName.SetPagination(1, 0, false, false, 1);
					TableAircrName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValAircr),
							Text = Convert.ToString(TableAircrName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValAircr);
				}

				TableAircrName.Selected = this.ValAircr;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAircrName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PLANES__AIRCRNAME____ = ["Aircr", "Aircr.ValCodairpt", "Aircr.ValZzstate", "Aircr.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"plane.aircr" => ViewModelConversion.ToString(modelValue),
				"plane.codairln" => ViewModelConversion.ToString(modelValue),
				"plane.photo" => ViewModelConversion.ToImage(modelValue),
				"plane.id" => ViewModelConversion.ToString(modelValue),
				"plane.model" => ViewModelConversion.ToString(modelValue),
				"plane.engines" => ViewModelConversion.ToNumeric(modelValue),
				"plane.manufact" => ViewModelConversion.ToString(modelValue),
				"plane.capacity" => ViewModelConversion.ToNumeric(modelValue),
				"plane.year" => ViewModelConversion.ToDateTime(modelValue),
				"plane.age" => ViewModelConversion.ToNumeric(modelValue),
				"plane.status" => ViewModelConversion.ToString(modelValue),
				"plane.maint" => ViewModelConversion.ToNumeric(modelValue),
				"plane.ismaint" => ViewModelConversion.ToLogic(modelValue),
				"plane.codplane" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"aircr.codairpt" => ViewModelConversion.ToString(modelValue),
				"aircr.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM PLANES]/

		#endregion
	}
}
