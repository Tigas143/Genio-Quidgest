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

namespace GenioMVC.ViewModels.Bookg
{
	public class Booking_ViewModel : FormViewModel<Models.Bookg>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => true; }

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
		/// Title: "Flight number identification" | Type: "CE"
		/// </summary>
		public string ValFlight { get; set; }
		/// <summary>
		/// Title: "Passenger" | Type: "CE"
		/// </summary>
		public string ValCodpasgr { get; set; }

		#endregion
		/// <summary>
		/// Title: "Booking number" | Type: "C"
		/// </summary>
		public string ValBnum { get; set; }
		/// <summary>
		/// Title: "Flight number identification" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Fligh> TableFlighFlighnum { get; set; }
		/// <summary>
		/// Title: "Price" | Type: "C"
		/// </summary>
		public string ValPrice { get; set; }
		/// <summary>
		/// Title: "Passenger" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Perso> TablePersoName { get; set; }
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

		public string ValCodbookg { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Booking_ViewModel() : base(null!) { }

		public Booking_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FBOOKING", nestedForm) { }

		public Booking_ViewModel(UserContext userContext, Models.Bookg row, bool nestedForm = false) : base(userContext, "FBOOKING", row, nestedForm) { }

		public Booking_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("bookg", id);
			Model = Models.Bookg.Find(id, userContext, "FBOOKING", fieldsToQuery: fieldsToLoad);
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
			Models.Bookg model = new Models.Bookg(userContext) { Identifier = "FBOOKING" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FBOOKING");
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
			Models.Bookg model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Bookg areaBookg = model;
			try
			{
				// (BOOKING form condition) StringToInt([BOOKG->PRICE]) > 0
				if (!isApply && !(CSGenio.business.GlobalFunctions.atoi(areaBookg.klass.ValPrice)>0))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FBOOKING access condition: {exc.Message}");
				throw;
			}
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Bookg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Bookg) to ViewModel (Booking) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodairln = ViewModelConversion.ToString(m.ValCodairln);
				ValFlight = ViewModelConversion.ToString(m.ValFlight);
				ValCodpasgr = ViewModelConversion.ToString(m.ValCodpasgr);
				ValBnum = ViewModelConversion.ToString(m.ValBnum);
				ValPrice = ViewModelConversion.ToString(m.ValPrice);
				funcAirlnValName = () => ViewModelConversion.ToString(m.Airln.ValName);
				ValCodbookg = ViewModelConversion.ToString(m.ValCodbookg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Bookg) to ViewModel (Booking) - Error during mapping");
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
		public override void MapToModel(Models.Bookg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Booking) to Model (Bookg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodairln = ViewModelConversion.ToString(ValCodairln);
				m.ValFlight = ViewModelConversion.ToString(ValFlight);
				m.ValCodpasgr = ViewModelConversion.ToString(ValCodpasgr);
				m.ValBnum = ViewModelConversion.ToString(ValBnum);
				m.ValPrice = ViewModelConversion.ToString(ValPrice);
				m.ValCodbookg = ViewModelConversion.ToString(ValCodbookg);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Booking) to Model (Bookg) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "bookg.codairln":
						this.ValCodairln = ViewModelConversion.ToString(_value);
						break;
					case "bookg.flight":
						this.ValFlight = ViewModelConversion.ToString(_value);
						break;
					case "bookg.codpasgr":
						this.ValCodpasgr = ViewModelConversion.ToString(_value);
						break;
					case "bookg.bnum":
						this.ValBnum = ViewModelConversion.ToString(_value);
						break;
					case "bookg.price":
						this.ValPrice = ViewModelConversion.ToString(_value);
						break;
					case "bookg.codbookg":
						this.ValCodbookg = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Booking) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Booking)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Bookg.Find(id ?? Navigation.GetStrValue("bookg"), m_userContext, "FBOOKING"); }
			finally { Model ??= new Models.Bookg(m_userContext) { Identifier = "FBOOKING" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Bookg.Find(Navigation.GetStrValue("bookg"), m_userContext, "FBOOKING");
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

			Model.Identifier = "FBOOKING";
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

		protected override void LoadDocumentsProperties(Models.Bookg row)
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
				Model = Models.Bookg.Find(Navigation.GetStrValue("bookg"), m_userContext, "FBOOKING");
				if (Model == null)
				{
					Model = new Models.Bookg(m_userContext) { Identifier = "FBOOKING" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("bookg");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Booking_flighflighnum(qs, lazyLoad);
			Load_Booking_personame____(qs, lazyLoad);
// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL BOOKING]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW BOOKING]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.Required("ValFlight", Resources.Resources.FLIGHT_NUMBER_IDENTI52250, ViewModelConversion.ToString(ValFlight), FieldType.CHAVE_ESTRANGEIRA.Formatting);
			validator.StringLength("ValBnum", Resources.Resources.BOOKING_NUMBER35241, ValBnum, 20);
			validator.StringLength("ValPrice", Resources.Resources.PRICE06900, ValPrice, 30);
			validator.StringLength("AirlnValName", Resources.Resources.AIRLINE57868, AirlnValName, 9);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE BOOKING]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY BOOKING]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE BOOKING]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY BOOKING]/
		public override void Destroy(string id)
		{
			Model = Models.Bookg.Find(id, m_userContext, "FBOOKING");
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
		/// TableFlighFlighnum -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Booking_flighflighnum(NameValueCollection qs, bool lazyLoad = false)
		{
			bool booking_flighflighnumDoLoad = true;
			CriteriaSet booking_flighflighnumConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("fligh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					booking_flighflighnumConds.Equal(CSGenioAfligh.FldCodfligh, hValue);
					this.ValFlight = DBConversion.ToString(hValue);
				}
			}

			TableFlighFlighnum = new TableDBEdit<Models.Fligh>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_fligh") != null)
				{
					this.ValFlight = Navigation.GetStrValue("RETURN_fligh");
					Navigation.CurrentLevel.SetEntry("RETURN_fligh", null);
				}
				FillDependant_BookingTableFlighFlighnum(lazyLoad);
				//Check if foreignkey comes from history
				TableFlighFlighnum.FilledByHistory = Navigation.CheckFilledByHistory("fligh");
				return;
			}

			if (booking_flighflighnumDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableFlighFlighnum, "sTableFlighFlighnum", "dTableFlighFlighnum", qs, "fligh");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfligh.FldFlighnum), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFlighFlighnum_tableFilters"]))
					TableFlighFlighnum.TableFilters = bool.Parse(qs["TableFlighFlighnum_tableFilters"]);
				else
					TableFlighFlighnum.TableFilters = false;

				query = qs["qTableFlighFlighnum"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAfligh.FldFlighnum, query + "%");
				}
				booking_flighflighnumConds.SubSet(search_filters);

				string tryParsePage = qs["pTableFlighFlighnum"] != null ? qs["pTableFlighFlighnum"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAfligh.FldCodfligh, CSGenioAfligh.FldFlighnum, CSGenioAfligh.FldZzstate };

// USE /[MANUAL PJF OVERRQ BOOKING_FLIGHFLIGHNUM]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("fligh", FormMode.New) || Navigation.checkFormMode("fligh", FormMode.Duplicate))
					booking_flighflighnumConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAfligh.FldZzstate, 0)
						.Equal(CSGenioAfligh.FldCodfligh, Navigation.GetStrValue("fligh")));
				else
					booking_flighflighnumConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfligh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("fligh", "flighnum");
				ListingMVC<CSGenioAfligh> listing = Models.ModelBase.Where<CSGenioAfligh>(m_userContext, false, booking_flighflighnumConds, fields, offset, numberItems, sorts, "LED_BOOKING_FLIGHFLIGHNUM", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFlighFlighnum.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFlighFlighnum.Query = query;
				TableFlighFlighnum.Elements = listing.RowsForViewModel<GenioMVC.Models.Fligh>((r) => new GenioMVC.Models.Fligh(m_userContext, r, true, _fieldsToSerialize_BOOKING_FLIGHFLIGHNUM));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_fligh") != null)
				{
					this.ValFlight = Navigation.GetStrValue("RETURN_fligh");
					Navigation.CurrentLevel.SetEntry("RETURN_fligh", null);
				}

				TableFlighFlighnum.List = new SelectList(TableFlighFlighnum.Elements.ToSelectList(x => x.ValFlighnum, x => x.ValCodfligh,  x => x.ValCodfligh == this.ValFlight), "Value", "Text", this.ValFlight);
				//Seleciona se só um
				if (TableFlighFlighnum.List != null && TableFlighFlighnum.List.Count() == 1)
				{
					this.ValFlight = TableFlighFlighnum.List.First().Value;
					Navigation.SetValue("fligh", this.ValFlight);
				}
				FillDependant_BookingTableFlighFlighnum();

				//Check if foreignkey comes from history
				TableFlighFlighnum.FilledByHistory = Navigation.CheckFilledByHistory("fligh");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFlighFlighnum (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Fligh</param>
		public ConcurrentDictionary<string, object> GetDependant_BookingTableFlighFlighnum(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAfligh.FldCodfligh, CSGenioAfligh.FldFlighnum, CSGenioAairln.FldCodairln, CSGenioAairln.FldName];

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

			CSGenioAfligh tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAfligh.FldCodfligh, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFlighFlighnum (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_BookingTableFlighFlighnum(bool lazyLoad = false)
		{
			var row = GetDependant_BookingTableFlighFlighnum(this.ValFlight);
			try
			{
				this.ValCodairln = (string)row["airln.codairln"];
				this.funcAirlnValName = () => (string)row["airln.name"];

				// Fill List fields
				this.ValFlight = ViewModelConversion.ToString(row["fligh.codfligh"]);
				TableFlighFlighnum.Value = (string)row["fligh.flighnum"];
				if (GlobalFunctions.emptyG(this.ValFlight) == 1)
				{
					this.ValFlight = "";
					TableFlighFlighnum.Value = "";
					Navigation.ClearValue("fligh");
				}
				else if (lazyLoad)
				{
					TableFlighFlighnum.SetPagination(1, 0, false, false, 1);
					TableFlighFlighnum.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValFlight),
							Text = Convert.ToString(TableFlighFlighnum.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValFlight);
				}

				TableFlighFlighnum.Selected = this.ValFlight;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFlighFlighnum): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_BOOKING_FLIGHFLIGHNUM = ["Fligh", "Fligh.ValCodfligh", "Fligh.ValZzstate", "Fligh.ValFlighnum"];

		/// <summary>
		/// TablePersoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Booking_personame____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool booking_personame____DoLoad = true;
			CriteriaSet booking_personame____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("perso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					booking_personame____Conds.Equal(CSGenioAperso.FldCodperso, hValue);
					this.ValCodpasgr = DBConversion.ToString(hValue);
				}
			}

			TablePersoName = new TableDBEdit<Models.Perso>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodpasgr = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}
				FillDependant_BookingTablePersoName(lazyLoad);
				//Check if foreignkey comes from history
				TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
				return;
			}

			if (booking_personame____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePersoName, "sTablePersoName", "dTablePersoName", qs, "perso");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAperso.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePersoName_tableFilters"]))
					TablePersoName.TableFilters = bool.Parse(qs["TablePersoName_tableFilters"]);
				else
					TablePersoName.TableFilters = false;

				query = qs["qTablePersoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAperso.FldName, query + "%");
				}
				booking_personame____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePersoName"] != null ? qs["pTablePersoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAperso.FldZzstate };

// USE /[MANUAL PJF OVERRQ BOOKING_PERSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("perso", FormMode.New) || Navigation.checkFormMode("perso", FormMode.Duplicate))
					booking_personame____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAperso.FldZzstate, 0)
						.Equal(CSGenioAperso.FldCodperso, Navigation.GetStrValue("perso")));
				else
					booking_personame____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("perso", "name");
				ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(m_userContext, false, booking_personame____Conds, fields, offset, numberItems, sorts, "LED_BOOKING_PERSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePersoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePersoName.Query = query;
				TablePersoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Perso>((r) => new GenioMVC.Models.Perso(m_userContext, r, true, _fieldsToSerialize_BOOKING_PERSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodpasgr = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}

				TablePersoName.List = new SelectList(TablePersoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperso,  x => x.ValCodperso == this.ValCodpasgr), "Value", "Text", this.ValCodpasgr);
				FillDependant_BookingTablePersoName();

				//Check if foreignkey comes from history
				TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePersoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Perso</param>
		public ConcurrentDictionary<string, object> GetDependant_BookingTablePersoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAperso.FldCodperso, CSGenioAperso.FldName];

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

			CSGenioAperso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAperso.FldCodperso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePersoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_BookingTablePersoName(bool lazyLoad = false)
		{
			var row = GetDependant_BookingTablePersoName(this.ValCodpasgr);
			try
			{

				// Fill List fields
				this.ValCodpasgr = ViewModelConversion.ToString(row["perso.codperso"]);
				TablePersoName.Value = (string)row["perso.name"];
				if (GlobalFunctions.emptyG(this.ValCodpasgr) == 1)
				{
					this.ValCodpasgr = "";
					TablePersoName.Value = "";
					Navigation.ClearValue("perso");
				}
				else if (lazyLoad)
				{
					TablePersoName.SetPagination(1, 0, false, false, 1);
					TablePersoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpasgr),
							Text = Convert.ToString(TablePersoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpasgr);
				}

				TablePersoName.Selected = this.ValCodpasgr;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePersoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_BOOKING_PERSONAME____ = ["Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"bookg.codairln" => ViewModelConversion.ToString(modelValue),
				"bookg.flight" => ViewModelConversion.ToString(modelValue),
				"bookg.codpasgr" => ViewModelConversion.ToString(modelValue),
				"bookg.bnum" => ViewModelConversion.ToString(modelValue),
				"bookg.price" => ViewModelConversion.ToString(modelValue),
				"airln.name" => ViewModelConversion.ToString(modelValue),
				"bookg.codbookg" => ViewModelConversion.ToString(modelValue),
				"fligh.codfligh" => ViewModelConversion.ToString(modelValue),
				"fligh.flighnum" => ViewModelConversion.ToString(modelValue),
				"airln.codairln" => ViewModelConversion.ToString(modelValue),
				"perso.codperso" => ViewModelConversion.ToString(modelValue),
				"perso.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM BOOKING]/

		#endregion
	}
}
