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

namespace GenioMVC.ViewModels.Fligh
{
	public class Flight_ViewModel : FormViewModel<Models.Fligh>
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
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodsourc { get; set; }
		/// <summary>
		/// Title: "Cabin Crew" | Type: "CE"
		/// </summary>
		public string ValCodcrew { get; set; }
		/// <summary>
		/// Title: "Pilot" | Type: "CE"
		/// </summary>
		public string ValCodpilot { get; set; }
		/// <summary>
		/// Title: "Aircraft" | Type: "CE"
		/// </summary>
		public string ValCodplane { get; set; }
		/// <summary>
		/// Title: "Route" | Type: "CE"
		/// </summary>
		public string ValCodroute { get; set; }

		#endregion
		/// <summary>
		/// Title: "Flight number identification" | Type: "C"
		/// </summary>
		public string ValFlighnum { get; set; }
		/// <summary>
		/// Title: "Aircraft" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Plane> TablePlaneModel { get; set; }
		/// <summary>
		/// Title: "Route" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Route> TableRouteName { get; set; }
		/// <summary>
		/// Title: "Departure" | Type: "DT"
		/// </summary>
		public DateTime? ValDepart { get; set; }
		/// <summary>
		/// Title: "Arrival" | Type: "DT"
		/// </summary>
		public DateTime? ValArrival { get; set; }
		/// <summary>
		/// Title: "Duracao em horas" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValDuration { get; set; }
		/// <summary>
		/// Title: "Source" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValNamesc { get; set; }
		/// <summary>
		/// Title: "Cabin Crew" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Crew> TableCrewCrewname { get; set; }
		/// <summary>
		/// Title: "Pilot" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pilot> TablePilotName { get; set; }
		/// <summary>
		/// Title: "Airsc" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string PlaneValAirsc 
		{
			get
			{
				return funcPlaneValAirsc != null ? funcPlaneValAirsc() : _auxPlaneValAirsc;
			}
			set { funcPlaneValAirsc = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcPlaneValAirsc { get; set; }

		private string _auxPlaneValAirsc { get; set; }
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

		public string ValCodfligh { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Flight_ViewModel() : base(null!) { }

		public Flight_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFLIGHT", nestedForm) { }

		public Flight_ViewModel(UserContext userContext, Models.Fligh row, bool nestedForm = false) : base(userContext, "FFLIGHT", row, nestedForm) { }

		public Flight_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("fligh", id);
			Model = Models.Fligh.Find(id, userContext, "FFLIGHT", fieldsToQuery: fieldsToLoad);
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
			Models.Fligh model = new Models.Fligh(userContext) { Identifier = "FFLIGHT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFLIGHT");
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
			Models.Fligh model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Fligh m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Fligh) to ViewModel (Flight) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValCodsourc = ViewModelConversion.ToString(m.ValCodsourc);
				ValCodcrew = ViewModelConversion.ToString(m.ValCodcrew);
				ValCodpilot = ViewModelConversion.ToString(m.ValCodpilot);
				ValCodplane = ViewModelConversion.ToString(m.ValCodplane);
				ValCodroute = ViewModelConversion.ToString(m.ValCodroute);
				ValFlighnum = ViewModelConversion.ToString(m.ValFlighnum);
				ValDepart = ViewModelConversion.ToDateTime(m.ValDepart);
				ValArrival = ViewModelConversion.ToDateTime(m.ValArrival);
				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
				ValNamesc = ViewModelConversion.ToString(m.ValNamesc);
				funcPlaneValAirsc = () => ViewModelConversion.ToString(m.Plane.ValAirsc);
				funcAirlnValName = () => ViewModelConversion.ToString(m.Airln.ValName);
				ValCodfligh = ViewModelConversion.ToString(m.ValCodfligh);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Fligh) to ViewModel (Flight) - Error during mapping");
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
		public override void MapToModel(Models.Fligh m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Flight) to Model (Fligh) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				m.ValCodcrew = ViewModelConversion.ToString(ValCodcrew);
				m.ValCodpilot = ViewModelConversion.ToString(ValCodpilot);
				m.ValCodplane = ViewModelConversion.ToString(ValCodplane);
				m.ValCodroute = ViewModelConversion.ToString(ValCodroute);
				m.ValFlighnum = ViewModelConversion.ToString(ValFlighnum);
				m.ValDepart = ViewModelConversion.ToDateTime(ValDepart);
				m.ValArrival = ViewModelConversion.ToDateTime(ValArrival);
				m.ValCodfligh = ViewModelConversion.ToString(ValCodfligh);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodsourc = ViewModelConversion.ToString(ValCodsourc);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValNamesc = ViewModelConversion.ToString(ValNamesc);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Flight) to Model (Fligh) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "fligh.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "fligh.codcrew":
						this.ValCodcrew = ViewModelConversion.ToString(_value);
						break;
					case "fligh.codpilot":
						this.ValCodpilot = ViewModelConversion.ToString(_value);
						break;
					case "fligh.codplane":
						this.ValCodplane = ViewModelConversion.ToString(_value);
						break;
					case "fligh.codroute":
						this.ValCodroute = ViewModelConversion.ToString(_value);
						break;
					case "fligh.flighnum":
						this.ValFlighnum = ViewModelConversion.ToString(_value);
						break;
					case "fligh.depart":
						this.ValDepart = ViewModelConversion.ToDateTime(_value);
						break;
					case "fligh.arrival":
						this.ValArrival = ViewModelConversion.ToDateTime(_value);
						break;
					case "fligh.codfligh":
						this.ValCodfligh = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Flight) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Flight)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Fligh.Find(id ?? Navigation.GetStrValue("fligh"), m_userContext, "FFLIGHT"); }
			finally { Model ??= new Models.Fligh(m_userContext) { Identifier = "FFLIGHT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Fligh.Find(Navigation.GetStrValue("fligh"), m_userContext, "FFLIGHT");
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

			Model.Identifier = "FFLIGHT";
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

		protected override void LoadDocumentsProperties(Models.Fligh row)
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
				Model = Models.Fligh.Find(Navigation.GetStrValue("fligh"), m_userContext, "FFLIGHT");
				if (Model == null)
				{
					Model = new Models.Fligh(m_userContext) { Identifier = "FFLIGHT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("fligh");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Flight__planemodel___(qs, lazyLoad);
			Load_Flight__routename____(qs, lazyLoad);
			Load_Flight__crew_crewname(qs, lazyLoad);
			Load_Flight__pilotname____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL FLIGHT]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW FLIGHT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.Required("ValCodpilot", Resources.Resources.PILOT61493, ViewModelConversion.ToString(ValCodpilot), FieldType.CHAVE_ESTRANGEIRA.Formatting);
			validator.Required("ValCodplane", Resources.Resources.AIRCRAFT03780, ViewModelConversion.ToString(ValCodplane), FieldType.CHAVE_ESTRANGEIRA.Formatting);
			validator.StringLength("ValFlighnum", Resources.Resources.FLIGHT_NUMBER_IDENTI52250, ValFlighnum, 15);
			validator.Required("ValFlighnum", Resources.Resources.FLIGHT_NUMBER_IDENTI52250, ViewModelConversion.ToString(ValFlighnum), FieldType.TEXTO.Formatting);
			validator.StringLength("ValNamesc", Resources.Resources.SOURCE49690, ValNamesc, 20);
			validator.StringLength("PlaneValAirsc", Resources.Resources.AIRSC12709, PlaneValAirsc, 20);
			validator.StringLength("AirlnValName", Resources.Resources.AIRLINE57868, AirlnValName, 9);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE FLIGHT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY FLIGHT]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE FLIGHT]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY FLIGHT]/
		public override void Destroy(string id)
		{
			Model = Models.Fligh.Find(id, m_userContext, "FFLIGHT");
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
		public void Load_Flight__planemodel___(NameValueCollection qs, bool lazyLoad = false)
		{
			bool flight__planemodel___DoLoad = true;
			CriteriaSet flight__planemodel___Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("plane", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					flight__planemodel___Conds.Equal(CSGenioAplane.FldCodplane, hValue);
					this.ValCodplane = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			object flight__planemodel____flimitplane_ismaint = "0";
			flight__planemodel___Conds.Equal(
				CSGenio.business.CSGenioAplane.FldIsmaint,
				flight__planemodel____flimitplane_ismaint);

			object flight__planemodel____flimitplane_status = "A";
			flight__planemodel___Conds.Equal(
				CSGenio.business.CSGenioAplane.FldStatus,
				flight__planemodel____flimitplane_status);

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
				FillDependant_FlightTablePlaneModel(lazyLoad);
				//Check if foreignkey comes from history
				TablePlaneModel.FilledByHistory = Navigation.CheckFilledByHistory("plane");
				return;
			}

			if (flight__planemodel___DoLoad)
			{
				{
					// The foreign key field with the unique value: 'CODPLANE' | non-duplication prefix field: ''
					// Apply the limit of the unique value field, to avoid choosing an option that is not valid.

					// First, apply the condition to see the records already used, except the record itself.
					var uniqueCondition = CriteriaSet.And()
							.Equal(CSGenioAfligh.FldCodplane, CSGenioAplane.FldCodplane)
							.NotEqual(CSGenioAfligh.FldCodfligh, Navigation.GetValue("fligh"))
							.Equal(CSGenioAfligh.FldZzstate, 0);

					// Apply the subquery that will filter the records to display only the available ones.
					var uniqueConditionSql = new SelectQuery()
						.Select(new SqlValue(1), "exists")
						.From(CSGenio.business.Area.AreaFLIGH)
						.Where(uniqueCondition);
					flight__planemodel___Conds.NotExists(uniqueConditionSql);
				}

				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePlaneModel, "sTablePlaneModel", "dTablePlaneModel", qs, "plane");
				if (requestedSort != null)
					sorts.Add(requestedSort);

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
				flight__planemodel___Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePlaneModel"] != null ? qs["pTablePlaneModel"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAplane.FldCodplane, CSGenioAplane.FldModel, CSGenioAplane.FldZzstate };

// USE /[MANUAL PJF OVERRQ FLIGHT_PLANEMODEL]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("plane", FormMode.New) || Navigation.checkFormMode("plane", FormMode.Duplicate))
					flight__planemodel___Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAplane.FldZzstate, 0)
						.Equal(CSGenioAplane.FldCodplane, Navigation.GetStrValue("plane")));
				else
					flight__planemodel___Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAplane.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("plane", "model");
				ListingMVC<CSGenioAplane> listing = Models.ModelBase.Where<CSGenioAplane>(m_userContext, false, flight__planemodel___Conds, fields, offset, numberItems, sorts, "LED_FLIGHT__PLANEMODEL___", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePlaneModel.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePlaneModel.Query = query;
				TablePlaneModel.Elements = listing.RowsForViewModel<GenioMVC.Models.Plane>((r) => new GenioMVC.Models.Plane(m_userContext, r, true, _fieldsToSerialize_FLIGHT__PLANEMODEL___));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_plane") != null)
				{
					this.ValCodplane = Navigation.GetStrValue("RETURN_plane");
					Navigation.CurrentLevel.SetEntry("RETURN_plane", null);
				}

				TablePlaneModel.List = new SelectList(TablePlaneModel.Elements.ToSelectList(x => x.ValModel, x => x.ValCodplane,  x => x.ValCodplane == this.ValCodplane), "Value", "Text", this.ValCodplane);
				FillDependant_FlightTablePlaneModel();

				//Check if foreignkey comes from history
				TablePlaneModel.FilledByHistory = Navigation.CheckFilledByHistory("plane");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePlaneModel (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Plane</param>
		public ConcurrentDictionary<string, object> GetDependant_FlightTablePlaneModel(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAplane.FldCodplane, CSGenioAplane.FldModel, CSGenioAplane.FldAirsc, CSGenioAairln.FldCodairln, CSGenioAairln.FldName];

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
		public void FillDependant_FlightTablePlaneModel(bool lazyLoad = false)
		{
			var row = GetDependant_FlightTablePlaneModel(this.ValCodplane);
			try
			{
				this.funcPlaneValAirsc = () => (string)row["plane.airsc"];
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

		private readonly string[] _fieldsToSerialize_FLIGHT__PLANEMODEL___ = ["Plane", "Plane.ValCodplane", "Plane.ValZzstate", "Plane.ValModel"];

		/// <summary>
		/// TableRouteName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Flight__routename____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool flight__routename____DoLoad = true;
			CriteriaSet flight__routename____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("route", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					flight__routename____Conds.Equal(CSGenioAroute.FldCodroute, hValue);
					this.ValCodroute = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

				// Limit by field
				flight__routename____Conds.Equal(
				CSGenio.business.CSGenioAairsc.FldName,
				this.ValNamesc);

			TableRouteName = new TableDBEdit<Models.Route>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_route") != null)
				{
					this.ValCodroute = Navigation.GetStrValue("RETURN_route");
					Navigation.CurrentLevel.SetEntry("RETURN_route", null);
				}
				FillDependant_FlightTableRouteName(lazyLoad);
				//Check if foreignkey comes from history
				TableRouteName.FilledByHistory = Navigation.CheckFilledByHistory("route");
				return;
			}

			if (flight__routename____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRouteName, "sTableRouteName", "dTableRouteName", qs, "route");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAroute.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRouteName_tableFilters"]))
					TableRouteName.TableFilters = bool.Parse(qs["TableRouteName_tableFilters"]);
				else
					TableRouteName.TableFilters = false;

				query = qs["qTableRouteName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAroute.FldName, query + "%");
				}
				flight__routename____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRouteName"] != null ? qs["pTableRouteName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAroute.FldCodroute, CSGenioAroute.FldName, CSGenioAairsc.FldName, CSGenioAroute.FldZzstate };

// USE /[MANUAL PJF OVERRQ FLIGHT_ROUTENAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("route", FormMode.New) || Navigation.checkFormMode("route", FormMode.Duplicate))
					flight__routename____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAroute.FldZzstate, 0)
						.Equal(CSGenioAroute.FldCodroute, Navigation.GetStrValue("route")));
				else
					flight__routename____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAroute.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("route", "name");
				ListingMVC<CSGenioAroute> listing = Models.ModelBase.Where<CSGenioAroute>(m_userContext, false, flight__routename____Conds, fields, offset, numberItems, sorts, "LED_FLIGHT__ROUTENAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRouteName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRouteName.Query = query;
				TableRouteName.Elements = listing.RowsForViewModel<GenioMVC.Models.Route>((r) => new GenioMVC.Models.Route(m_userContext, r, true, _fieldsToSerialize_FLIGHT__ROUTENAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_route") != null)
				{
					this.ValCodroute = Navigation.GetStrValue("RETURN_route");
					Navigation.CurrentLevel.SetEntry("RETURN_route", null);
				}

				TableRouteName.List = new SelectList(TableRouteName.Elements.ToSelectList(x => x.ValName, x => x.ValCodroute,  x => x.ValCodroute == this.ValCodroute), "Value", "Text", this.ValCodroute);
				FillDependant_FlightTableRouteName();

				//Check if foreignkey comes from history
				TableRouteName.FilledByHistory = Navigation.CheckFilledByHistory("route");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRouteName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Route</param>
		public ConcurrentDictionary<string, object> GetDependant_FlightTableRouteName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAroute.FldCodroute, CSGenioAroute.FldName];

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

			CSGenioAroute tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAroute.FldCodroute, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRouteName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_FlightTableRouteName(bool lazyLoad = false)
		{
			var row = GetDependant_FlightTableRouteName(this.ValCodroute);
			try
			{

				// Fill List fields
				this.ValCodroute = ViewModelConversion.ToString(row["route.codroute"]);
				TableRouteName.Value = (string)row["route.name"];
				if (GlobalFunctions.emptyG(this.ValCodroute) == 1)
				{
					this.ValCodroute = "";
					TableRouteName.Value = "";
					Navigation.ClearValue("route");
				}
				else if (lazyLoad)
				{
					TableRouteName.SetPagination(1, 0, false, false, 1);
					TableRouteName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodroute),
							Text = Convert.ToString(TableRouteName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodroute);
				}

				TableRouteName.Selected = this.ValCodroute;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRouteName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FLIGHT__ROUTENAME____ = ["Route", "Route.ValCodroute", "Route.ValZzstate", "Route.ValName", "Airsc", "Airsc.ValName"];

		/// <summary>
		/// TableCrewCrewname -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Flight__crew_crewname(NameValueCollection qs, bool lazyLoad = false)
		{
			bool flight__crew_crewnameDoLoad = true;
			CriteriaSet flight__crew_crewnameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("crew", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					flight__crew_crewnameConds.Equal(CSGenioAcrew.FldCodcrew, hValue);
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
				FillDependant_FlightTableCrewCrewname(lazyLoad);
				//Check if foreignkey comes from history
				TableCrewCrewname.FilledByHistory = Navigation.CheckFilledByHistory("crew");
				return;
			}

			if (flight__crew_crewnameDoLoad)
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
				flight__crew_crewnameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCrewCrewname"] != null ? qs["pTableCrewCrewname"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcrew.FldCodcrew, CSGenioAcrew.FldCrewname, CSGenioAcrew.FldZzstate };

// USE /[MANUAL PJF OVERRQ FLIGHT_CREWCREWNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("crew", FormMode.New) || Navigation.checkFormMode("crew", FormMode.Duplicate))
					flight__crew_crewnameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcrew.FldZzstate, 0)
						.Equal(CSGenioAcrew.FldCodcrew, Navigation.GetStrValue("crew")));
				else
					flight__crew_crewnameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcrew.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("crew", "crewname");
				ListingMVC<CSGenioAcrew> listing = Models.ModelBase.Where<CSGenioAcrew>(m_userContext, false, flight__crew_crewnameConds, fields, offset, numberItems, sorts, "LED_FLIGHT__CREW_CREWNAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCrewCrewname.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCrewCrewname.Query = query;
				TableCrewCrewname.Elements = listing.RowsForViewModel<GenioMVC.Models.Crew>((r) => new GenioMVC.Models.Crew(m_userContext, r, true, _fieldsToSerialize_FLIGHT__CREW_CREWNAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_crew") != null)
				{
					this.ValCodcrew = Navigation.GetStrValue("RETURN_crew");
					Navigation.CurrentLevel.SetEntry("RETURN_crew", null);
				}

				TableCrewCrewname.List = new SelectList(TableCrewCrewname.Elements.ToSelectList(x => x.ValCrewname, x => x.ValCodcrew,  x => x.ValCodcrew == this.ValCodcrew), "Value", "Text", this.ValCodcrew);
				FillDependant_FlightTableCrewCrewname();

				//Check if foreignkey comes from history
				TableCrewCrewname.FilledByHistory = Navigation.CheckFilledByHistory("crew");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCrewCrewname (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Crew</param>
		public ConcurrentDictionary<string, object> GetDependant_FlightTableCrewCrewname(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcrew.FldCodcrew, CSGenioAcrew.FldCrewname];

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
		public void FillDependant_FlightTableCrewCrewname(bool lazyLoad = false)
		{
			var row = GetDependant_FlightTableCrewCrewname(this.ValCodcrew);
			try
			{

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

		private readonly string[] _fieldsToSerialize_FLIGHT__CREW_CREWNAME = ["Crew", "Crew.ValCodcrew", "Crew.ValZzstate", "Crew.ValCrewname"];

		/// <summary>
		/// TablePilotName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Flight__pilotname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool flight__pilotname____DoLoad = true;
			CriteriaSet flight__pilotname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pilot", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					flight__pilotname____Conds.Equal(CSGenioApilot.FldCodpilot, hValue);
					this.ValCodpilot = DBConversion.ToString(hValue);
				}
			}

			TablePilotName = new TableDBEdit<Models.Pilot>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pilot") != null)
				{
					this.ValCodpilot = Navigation.GetStrValue("RETURN_pilot");
					Navigation.CurrentLevel.SetEntry("RETURN_pilot", null);
				}
				FillDependant_FlightTablePilotName(lazyLoad);
				//Check if foreignkey comes from history
				TablePilotName.FilledByHistory = Navigation.CheckFilledByHistory("pilot");
				return;
			}

			if (flight__pilotname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePilotName, "sTablePilotName", "dTablePilotName", qs, "pilot");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApilot.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePilotName_tableFilters"]))
					TablePilotName.TableFilters = bool.Parse(qs["TablePilotName_tableFilters"]);
				else
					TablePilotName.TableFilters = false;

				query = qs["qTablePilotName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApilot.FldName, query + "%");
				}
				flight__pilotname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePilotName"] != null ? qs["pTablePilotName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApilot.FldCodpilot, CSGenioApilot.FldName, CSGenioApilot.FldZzstate };

// USE /[MANUAL PJF OVERRQ FLIGHT_PILOTNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pilot", FormMode.New) || Navigation.checkFormMode("pilot", FormMode.Duplicate))
					flight__pilotname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApilot.FldZzstate, 0)
						.Equal(CSGenioApilot.FldCodpilot, Navigation.GetStrValue("pilot")));
				else
					flight__pilotname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApilot.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pilot", "name");
				ListingMVC<CSGenioApilot> listing = Models.ModelBase.Where<CSGenioApilot>(m_userContext, false, flight__pilotname____Conds, fields, offset, numberItems, sorts, "LED_FLIGHT__PILOTNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePilotName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePilotName.Query = query;
				TablePilotName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pilot>((r) => new GenioMVC.Models.Pilot(m_userContext, r, true, _fieldsToSerialize_FLIGHT__PILOTNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pilot") != null)
				{
					this.ValCodpilot = Navigation.GetStrValue("RETURN_pilot");
					Navigation.CurrentLevel.SetEntry("RETURN_pilot", null);
				}

				TablePilotName.List = new SelectList(TablePilotName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpilot,  x => x.ValCodpilot == this.ValCodpilot), "Value", "Text", this.ValCodpilot);
				FillDependant_FlightTablePilotName();

				//Check if foreignkey comes from history
				TablePilotName.FilledByHistory = Navigation.CheckFilledByHistory("pilot");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePilotName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pilot</param>
		public ConcurrentDictionary<string, object> GetDependant_FlightTablePilotName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApilot.FldCodpilot, CSGenioApilot.FldName];

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

			CSGenioApilot tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApilot.FldCodpilot, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePilotName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_FlightTablePilotName(bool lazyLoad = false)
		{
			var row = GetDependant_FlightTablePilotName(this.ValCodpilot);
			try
			{

				// Fill List fields
				this.ValCodpilot = ViewModelConversion.ToString(row["pilot.codpilot"]);
				TablePilotName.Value = (string)row["pilot.name"];
				if (GlobalFunctions.emptyG(this.ValCodpilot) == 1)
				{
					this.ValCodpilot = "";
					TablePilotName.Value = "";
					Navigation.ClearValue("pilot");
				}
				else if (lazyLoad)
				{
					TablePilotName.SetPagination(1, 0, false, false, 1);
					TablePilotName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpilot),
							Text = Convert.ToString(TablePilotName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpilot);
				}

				TablePilotName.Selected = this.ValCodpilot;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePilotName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FLIGHT__PILOTNAME____ = ["Pilot", "Pilot.ValCodpilot", "Pilot.ValZzstate", "Pilot.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"fligh.codairln" => ViewModelConversion.ToString(modelValue),
				"fligh.codsourc" => ViewModelConversion.ToString(modelValue),
				"fligh.codcrew" => ViewModelConversion.ToString(modelValue),
				"fligh.codpilot" => ViewModelConversion.ToString(modelValue),
				"fligh.codplane" => ViewModelConversion.ToString(modelValue),
				"fligh.codroute" => ViewModelConversion.ToString(modelValue),
				"fligh.flighnum" => ViewModelConversion.ToString(modelValue),
				"fligh.depart" => ViewModelConversion.ToDateTime(modelValue),
				"fligh.arrival" => ViewModelConversion.ToDateTime(modelValue),
				"fligh.duration" => ViewModelConversion.ToNumeric(modelValue),
				"fligh.namesc" => ViewModelConversion.ToString(modelValue),
				"plane.airsc" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"fligh.codfligh" => ViewModelConversion.ToString(modelValue),
				"plane.codplane" => ViewModelConversion.ToString(modelValue),
				"plane.model" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				"route.codroute" => ViewModelConversion.ToString(modelValue),
				"route.name" => ViewModelConversion.ToString(modelValue),
				"crew.codcrew" => ViewModelConversion.ToString(modelValue),
				"crew.crewname" => ViewModelConversion.ToString(modelValue),
				"pilot.codpilot" => ViewModelConversion.ToString(modelValue),
				"pilot.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM FLIGHT]/

		#endregion
	}
}
