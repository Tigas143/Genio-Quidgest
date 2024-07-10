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

namespace GenioMVC.ViewModels.Mate
{
	public class Mateprof_ViewModel : FormViewModel<Models.Mate>
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
		/// Title: "Crew name" | Type: "CE"
		/// </summary>
		public string ValCodcrew { get; set; }

		#endregion
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Crew name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Crew> TableCrewCrewname { get; set; }
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

		public string ValCodmate { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Mateprof_ViewModel() : base(null!) { }

		public Mateprof_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FMATEPROF", nestedForm) { }

		public Mateprof_ViewModel(UserContext userContext, Models.Mate row, bool nestedForm = false) : base(userContext, "FMATEPROF", row, nestedForm) { }

		public Mateprof_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("mate", id);
			Model = Models.Mate.Find(id, userContext, "FMATEPROF", fieldsToQuery: fieldsToLoad);
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
			Models.Mate model = new Models.Mate(userContext) { Identifier = "FMATEPROF" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FMATEPROF");
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
			Models.Mate model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Mate m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Mate) to ViewModel (Mateprof) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValCodcrew = ViewModelConversion.ToString(m.ValCodcrew);
				ValName = ViewModelConversion.ToString(m.ValName);
				funcAirlnValName = () => ViewModelConversion.ToString(m.Airln.ValName);
				ValCodmate = ViewModelConversion.ToString(m.ValCodmate);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Mate) to ViewModel (Mateprof) - Error during mapping");
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
		public override void MapToModel(Models.Mate m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Mateprof) to Model (Mate) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				m.ValCodcrew = ViewModelConversion.ToString(ValCodcrew);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodmate = ViewModelConversion.ToString(ValCodmate);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Mateprof) to Model (Mate) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "mate.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "mate.codcrew":
						this.ValCodcrew = ViewModelConversion.ToString(_value);
						break;
					case "mate.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "mate.codmate":
						this.ValCodmate = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Mateprof) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Mateprof)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Mate.Find(id ?? Navigation.GetStrValue("mate"), m_userContext, "FMATEPROF"); }
			finally { Model ??= new Models.Mate(m_userContext) { Identifier = "FMATEPROF" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Mate.Find(Navigation.GetStrValue("mate"), m_userContext, "FMATEPROF");
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

			Model.Identifier = "FMATEPROF";
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

		protected override void LoadDocumentsProperties(Models.Mate row)
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
				Model = Models.Mate.Find(Navigation.GetStrValue("mate"), m_userContext, "FMATEPROF");
				if (Model == null)
				{
					Model = new Models.Mate(m_userContext) { Identifier = "FMATEPROF" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("mate");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Mateprofcrew_crewname(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL MATEPROF]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW MATEPROF]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 20);
			validator.StringLength("AirlnValName", Resources.Resources.AIRLINE57868, AirlnValName, 9);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE MATEPROF]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY MATEPROF]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE MATEPROF]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY MATEPROF]/
		public override void Destroy(string id)
		{
			Model = Models.Mate.Find(id, m_userContext, "FMATEPROF");
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
		/// TableCrewCrewname -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Mateprofcrew_crewname(NameValueCollection qs, bool lazyLoad = false)
		{
			bool mateprofcrew_crewnameDoLoad = true;
			CriteriaSet mateprofcrew_crewnameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("crew", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					mateprofcrew_crewnameConds.Equal(CSGenioAcrew.FldCodcrew, hValue);
					this.ValCodcrew = DBConversion.ToString(hValue);
				}
			}

			TableCrewCrewname = new TableDBEdit<Models.Crew>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_crew") != null)
				{
					this.ValCodcrew = Navigation.GetStrValue("RETURN_crew");
					Navigation.CurrentLevel.SetEntry("RETURN_crew", null);
				}
				FillDependant_MateprofTableCrewCrewname(lazyLoad);
				//Check if foreignkey comes from history
				TableCrewCrewname.FilledByHistory = Navigation.CheckFilledByHistory("crew");
				return;
			}

			if (mateprofcrew_crewnameDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCrewCrewname, "sTableCrewCrewname", "dTableCrewCrewname", qs, "crew");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcrew.FldCrewname), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCrewCrewname_tableFilters"]))
					TableCrewCrewname.TableFilters = bool.Parse(qs["TableCrewCrewname_tableFilters"]);
				else
					TableCrewCrewname.TableFilters = false;

				query = qs["qTableCrewCrewname"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcrew.FldCrewname, query + "%");
				}
				mateprofcrew_crewnameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCrewCrewname"] != null ? qs["pTableCrewCrewname"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcrew.FldCodcrew, CSGenioAcrew.FldCrewname, CSGenioAcrew.FldZzstate };

// USE /[MANUAL PJF OVERRQ MATEPROF_CREWCREWNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("crew", FormMode.New) || Navigation.checkFormMode("crew", FormMode.Duplicate))
					mateprofcrew_crewnameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcrew.FldZzstate, 0)
						.Equal(CSGenioAcrew.FldCodcrew, Navigation.GetStrValue("crew")));
				else
					mateprofcrew_crewnameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcrew.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("crew", "crewname");
				ListingMVC<CSGenioAcrew> listing = Models.ModelBase.Where<CSGenioAcrew>(m_userContext, false, mateprofcrew_crewnameConds, fields, offset, numberItems, sorts, "LED_MATEPROFCREW_CREWNAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCrewCrewname.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCrewCrewname.Query = query;
				TableCrewCrewname.Elements = listing.RowsForViewModel<GenioMVC.Models.Crew>((r) => new GenioMVC.Models.Crew(m_userContext, r, true, _fieldsToSerialize_MATEPROFCREW_CREWNAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_crew") != null)
				{
					this.ValCodcrew = Navigation.GetStrValue("RETURN_crew");
					Navigation.CurrentLevel.SetEntry("RETURN_crew", null);
				}

				TableCrewCrewname.List = new SelectList(TableCrewCrewname.Elements.ToSelectList(x => x.ValCrewname, x => x.ValCodcrew,  x => x.ValCodcrew == this.ValCodcrew), "Value", "Text", this.ValCodcrew);
				FillDependant_MateprofTableCrewCrewname();

				//Check if foreignkey comes from history
				TableCrewCrewname.FilledByHistory = Navigation.CheckFilledByHistory("crew");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCrewCrewname (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Crew</param>
		public ConcurrentDictionary<string, object> GetDependant_MateprofTableCrewCrewname(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcrew.FldCodcrew, CSGenioAcrew.FldCrewname, CSGenioAairln.FldCodairln, CSGenioAairln.FldName];

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

			CSGenioAcrew tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcrew.FldCodcrew, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCrewCrewname (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_MateprofTableCrewCrewname(bool lazyLoad = false)
		{
			var row = GetDependant_MateprofTableCrewCrewname(this.ValCodcrew);
			try
			{
				this.ValCodairln = (string)row["airln.codairln"];
				this.funcAirlnValName = () => (string)row["airln.name"];

				// Fill List fields
				this.ValCodcrew = ViewModelConversion.ToString(row["crew.codcrew"]);
				TableCrewCrewname.Value = (string)row["crew.crewname"];
				if (GlobalFunctions.emptyG(this.ValCodcrew) == 1)
				{
					this.ValCodcrew = "";
					TableCrewCrewname.Value = "";
					Navigation.ClearValue("crew");
				}
				else if (lazyLoad)
				{
					TableCrewCrewname.SetPagination(1, 0, false, false, 1);
					TableCrewCrewname.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcrew),
							Text = Convert.ToString(TableCrewCrewname.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcrew);
				}

				TableCrewCrewname.Selected = this.ValCodcrew;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCrewCrewname): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_MATEPROFCREW_CREWNAME = ["Crew", "Crew.ValCodcrew", "Crew.ValZzstate", "Crew.ValCrewname"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"mate.codairln" => ViewModelConversion.ToString(modelValue),
				"mate.codcrew" => ViewModelConversion.ToString(modelValue),
				"mate.name" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"mate.codmate" => ViewModelConversion.ToString(modelValue),
				"crew.codcrew" => ViewModelConversion.ToString(modelValue),
				"crew.crewname" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM MATEPROF]/

		#endregion
	}
}
