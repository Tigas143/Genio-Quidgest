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

namespace GenioMVC.ViewModels.Maint
{
	public class Mainten_ViewModel : FormViewModel<Models.Maint>
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
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodairln { get; set; }
		/// <summary>
		/// Title: "Model" | Type: "CE"
		/// </summary>
		public string ValCodplane { get; set; }

		#endregion
		/// <summary>
		/// Title: "Model" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Plane> TablePlaneModel { get; set; }
		/// <summary>
		/// Title: "Maintanace Valid Untill" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "Status" | Type: "AN"
		/// </summary>
		public decimal ValStatus { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValStatus { get; set; }
		/// <summary>
		/// Title: "Airline" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string AirlnValName 
		{
			get
			{
				return funcAirlnValName != null ? funcAirlnValName() : _auxAirlnValName;
			}
			set { funcAirlnValName = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcAirlnValName { get; set; }

		private string _auxAirlnValName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodmaint { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Mainten_ViewModel() : base(null!) { }

		public Mainten_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FMAINTEN", nestedForm) { }

		public Mainten_ViewModel(UserContext userContext, Models.Maint row, bool nestedForm = false) : base(userContext, "FMAINTEN", row, nestedForm) { }

		public Mainten_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("maint", id);
			Model = Models.Maint.Find(id, userContext, "FMAINTEN", fieldsToQuery: fieldsToLoad);
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
			Models.Maint model = new Models.Maint(userContext) { Identifier = "FMAINTEN" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FMAINTEN");
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
			Models.Maint model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Maint m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Maint) to ViewModel (Mainten) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValCodplane = ViewModelConversion.ToString(m.ValCodplane);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValStatus = ViewModelConversion.ToNumeric(m.ValStatus);
				funcAirlnValName = () => ViewModelConversion.ToString(m.Airln.ValName);
				ValCodmaint = ViewModelConversion.ToString(m.ValCodmaint);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Maint) to ViewModel (Mainten) - Error during mapping");
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
		public override void MapToModel(Models.Maint m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Mainten) to Model (Maint) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				m.ValCodplane = ViewModelConversion.ToString(ValCodplane);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValStatus = ViewModelConversion.ToNumeric(ValStatus);
				m.ValCodmaint = ViewModelConversion.ToString(ValCodmaint);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Mainten) to Model (Maint) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "maint.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "maint.codplane":
						this.ValCodplane = ViewModelConversion.ToString(_value);
						break;
					case "maint.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "maint.status":
						this.ValStatus = ViewModelConversion.ToNumeric(_value);
						break;
					case "maint.codmaint":
						this.ValCodmaint = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Mainten) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Mainten)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Maint.Find(id ?? Navigation.GetStrValue("maint"), m_userContext, "FMAINTEN"); }
			finally { Model ??= new Models.Maint(m_userContext) { Identifier = "FMAINTEN" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Maint.Find(Navigation.GetStrValue("maint"), m_userContext, "FMAINTEN");
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

			Model.Identifier = "FMAINTEN";
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

		protected override void LoadDocumentsProperties(Models.Maint row)
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
				Model = Models.Maint.Find(Navigation.GetStrValue("maint"), m_userContext, "FMAINTEN");
				if (Model == null)
				{
					Model = new Models.Maint(m_userContext) { Identifier = "FMAINTEN" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("maint");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Mainten_planemodel___(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL MAINTEN]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW MAINTEN]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.Required("ValCodplane", Resources.Resources.MODEL27263, ViewModelConversion.ToString(ValCodplane), FieldType.CHAVE_ESTRANGEIRA.Formatting);
			validator.StringLength("AirlnValName", Resources.Resources.AIRLINE57868, AirlnValName, 9);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE MAINTEN]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY MAINTEN]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE MAINTEN]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY MAINTEN]/
		public override void Destroy(string id)
		{
			Model = Models.Maint.Find(id, m_userContext, "FMAINTEN");
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
		/// TablePlaneModel -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Mainten_planemodel___(NameValueCollection qs, bool lazyLoad = false)
		{
			bool mainten_planemodel___DoLoad = true;
			CriteriaSet mainten_planemodel___Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("plane", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					mainten_planemodel___Conds.Equal(CSGenioAplane.FldCodplane, hValue);
					this.ValCodplane = DBConversion.ToString(hValue);
				}
			}

			TablePlaneModel = new TableDBEdit<Models.Plane>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_plane") != null)
				{
					this.ValCodplane = Navigation.GetStrValue("RETURN_plane");
					Navigation.CurrentLevel.SetEntry("RETURN_plane", null);
				}
				FillDependant_MaintenTablePlaneModel(lazyLoad);
				//Check if foreignkey comes from history
				TablePlaneModel.FilledByHistory = Navigation.CheckFilledByHistory("plane");
				return;
			}

			if (mainten_planemodel___DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePlaneModel, "sTablePlaneModel", "dTablePlaneModel", qs, "plane");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAplane.FldModel), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePlaneModel_tableFilters"]))
					TablePlaneModel.TableFilters = bool.Parse(qs["TablePlaneModel_tableFilters"]);
				else
					TablePlaneModel.TableFilters = false;

				query = qs["qTablePlaneModel"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAplane.FldModel, query + "%");
				}
				mainten_planemodel___Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePlaneModel"] != null ? qs["pTablePlaneModel"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAplane.FldCodplane, CSGenioAplane.FldModel, CSGenioAplane.FldZzstate };

// USE /[MANUAL PJF OVERRQ MAINTEN_PLANEMODEL]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("plane", FormMode.New) || Navigation.checkFormMode("plane", FormMode.Duplicate))
					mainten_planemodel___Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAplane.FldZzstate, 0)
						.Equal(CSGenioAplane.FldCodplane, Navigation.GetStrValue("plane")));
				else
					mainten_planemodel___Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAplane.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("plane", "model");
				ListingMVC<CSGenioAplane> listing = Models.ModelBase.Where<CSGenioAplane>(m_userContext, false, mainten_planemodel___Conds, fields, offset, numberItems, sorts, "LED_MAINTEN_PLANEMODEL___", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePlaneModel.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePlaneModel.Query = query;
				TablePlaneModel.Elements = listing.RowsForViewModel<GenioMVC.Models.Plane>((r) => new GenioMVC.Models.Plane(m_userContext, r, true, _fieldsToSerialize_MAINTEN_PLANEMODEL___));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_plane") != null)
				{
					this.ValCodplane = Navigation.GetStrValue("RETURN_plane");
					Navigation.CurrentLevel.SetEntry("RETURN_plane", null);
				}

				TablePlaneModel.List = new SelectList(TablePlaneModel.Elements.ToSelectList(x => x.ValModel, x => x.ValCodplane,  x => x.ValCodplane == this.ValCodplane), "Value", "Text", this.ValCodplane);
				FillDependant_MaintenTablePlaneModel();

				//Check if foreignkey comes from history
				TablePlaneModel.FilledByHistory = Navigation.CheckFilledByHistory("plane");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePlaneModel (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Plane</param>
		public ConcurrentDictionary<string, object> GetDependant_MaintenTablePlaneModel(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAplane.FldCodplane, CSGenioAplane.FldModel, CSGenioAairln.FldCodairln, CSGenioAairln.FldName];

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

			CSGenioAplane tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAplane.FldCodplane, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePlaneModel (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_MaintenTablePlaneModel(bool lazyLoad = false)
		{
			var row = GetDependant_MaintenTablePlaneModel(this.ValCodplane);
			try
			{
				this.ValCodairln = (string)row["airln.codairln"];
				this.funcAirlnValName = () => (string)row["airln.name"];

				// Fill List fields
				this.ValCodplane = ViewModelConversion.ToString(row["plane.codplane"]);
				TablePlaneModel.Value = (string)row["plane.model"];
				if (GlobalFunctions.emptyG(this.ValCodplane) == 1)
				{
					this.ValCodplane = "";
					TablePlaneModel.Value = "";
					Navigation.ClearValue("plane");
				}
				else if (lazyLoad)
				{
					TablePlaneModel.SetPagination(1, 0, false, false, 1);
					TablePlaneModel.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodplane),
							Text = Convert.ToString(TablePlaneModel.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodplane);
				}

				TablePlaneModel.Selected = this.ValCodplane;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePlaneModel): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_MAINTEN_PLANEMODEL___ = ["Plane", "Plane.ValCodplane", "Plane.ValZzstate", "Plane.ValModel"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"maint.codairln" => ViewModelConversion.ToString(modelValue),
				"maint.codplane" => ViewModelConversion.ToString(modelValue),
				"maint.date" => ViewModelConversion.ToDateTime(modelValue),
				"maint.status" => ViewModelConversion.ToNumeric(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"maint.codmaint" => ViewModelConversion.ToString(modelValue),
				"plane.codplane" => ViewModelConversion.ToString(modelValue),
				"plane.model" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM MAINTEN]/

		#endregion
	}
}
