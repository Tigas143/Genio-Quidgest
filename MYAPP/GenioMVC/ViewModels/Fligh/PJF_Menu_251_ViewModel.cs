using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Fligh
{
	public class PJF_Menu_251_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Fligh> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "fligh"; }

		/// <inheritdoc/>
		public override string Uuid { get => "1d597cff-b15c-43c3-a60b-3f002ab91ede"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodfligh { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				return conds;
			}
		}

		/// <inheritdoc/>
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}


		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("fligh", user, "PJF");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML251");
			conditions.Equal(CSGenioAfligh.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAfligh.FldCodfligh, CSGenioAfligh.FldZzstate, CSGenioAfligh.FldFlighnum, CSGenioAfligh.FldCodplane, CSGenioAplane.FldCodplane, CSGenioAplane.FldModel, CSGenioAfligh.FldCodroute, CSGenioAroute.FldCodroute, CSGenioAroute.FldName, CSGenioAfligh.FldDepart, CSGenioAfligh.FldArrival, CSGenioAfligh.FldDuration, CSGenioAfligh.FldCodcrew, CSGenioAcrew.FldCodcrew, CSGenioAcrew.FldCrewname, CSGenioAfligh.FldCodpilot, CSGenioApilot.FldCodpilot, CSGenioApilot.FldName };

			ListingMVC<CSGenioAfligh> listing = new ListingMVC<CSGenioAfligh>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PJF_Menu_251_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PJF_Menu_251_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_10;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAfligh.FldFlighnum, FieldType.TEXTO, Resources.Resources.FLIGHT_NUMBER_IDENTI52250, 15, 0, true),
				new Exports.QColumn(CSGenioAplane.FldModel, FieldType.TEXTO, Resources.Resources.AIRCRAFT03780, 10, 0, true),
				new Exports.QColumn(CSGenioAroute.FldName, FieldType.TEXTO, Resources.Resources.ROUTE59240, 10, 0, true),
				new Exports.QColumn(CSGenioAfligh.FldDepart, FieldType.DATAHORA, Resources.Resources.DEPARTURE11999, 16, 0, true),
				new Exports.QColumn(CSGenioAfligh.FldArrival, FieldType.DATAHORA, Resources.Resources.ARRIVAL52302, 16, 0, true),
				new Exports.QColumn(CSGenioAfligh.FldDuration, FieldType.NUMERO, Resources.Resources.DURACAO_EM_HORAS28972, 9, 0, true),
				new Exports.QColumn(CSGenioAcrew.FldCrewname, FieldType.TEXTO, Resources.Resources.CREW_NAME06457, 20, 0, true),
				new Exports.QColumn(CSGenioApilot.FldName, FieldType.TEXTO, Resources.Resources.PILOT61493, 10, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAfligh> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAfligh> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfiguration);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAfligh.FldArrival, FieldType.DATAHORA, Resources.Resources.ARRIVAL52302, 16, 0, true),
				new Exports.QColumn(CSGenioAfligh.FldDepart, FieldType.DATAHORA, Resources.Resources.DEPARTURE11999, 16, 0, true),
				new Exports.QColumn(CSGenioAfligh.FldFlighnum, FieldType.TEXTO, Resources.Resources.FLIGHT_NUMBER_IDENTI52250, 15, 0, true),
				new Exports.QColumn(CSGenioAplane.FldModel, FieldType.TEXTO, Resources.Resources.AIRCRAFT03780, 10, 0, true),
				new Exports.QColumn(CSGenioAroute.FldName, FieldType.TEXTO, Resources.Resources.ROUTE59240, 10, 0, true),
				new Exports.QColumn(CSGenioAcrew.FldCrewname, FieldType.TEXTO, Resources.Resources.CREW_NAME06457, 20, 0, true),
				new Exports.QColumn(CSGenioApilot.FldName, FieldType.TEXTO, Resources.Resources.PILOT61493, 10, 0, true),
			};
		}

		/// <summary>
		/// Builds the list CriteriaSet with all the limits, filters and conditions
		/// </summary>
		/// <param name="requestValues">Parameters from the request</param>
		/// <param name="tableReload">[Quick fix] Indicates whether the data list should be loaded. If set to false within the method, it signals that the data list should not display rows due to unmet mandatory limits.</param>
		/// <param name="crs">Pass a CriteriaSet by reference to be modified</param>
		/// <param name="isToExport">If the  table is to be exported</param>
		public CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <summary>
		/// Builds the list CriteriaSet with all the limits, filters and conditions
		/// </summary>
		/// <param name="tableConfig">Table configuration object</param>
		/// <param name="requestValues">Parameters from the request</param>
		/// <param name="tableReload">[Quick fix] Indicates whether the data list should be loaded. If set to false within the method, it signals that the data list should not display rows due to unmet mandatory limits.</param>
		/// <param name="crs">Pass a CriteriaSet by reference to be modified</param>
		/// <param name="isToExport">If the  table is to be exported</param>
		public CriteriaSet BuildCriteriaSet(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();


			if (Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Fligh>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FLIGH.DEPART", new OrderedDictionary());
			allSortOrders["FLIGH.DEPART"].Add("FLIGH.DEPART", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Fligh.AddEPH<CSGenioAfligh>(ref u, crs, "ML251");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfligh.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FLIGH", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAfligh.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_fligh");
				Navigation.DestroyEntry("QMVC_POS_RECORD_fligh");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Fligh.AddEPH<CSGenioAfligh>(ref u, null, "ML251"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAfligh> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfligh> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAfligh> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfligh> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Fligh>();

			CriteriaSet pjf_menu_251Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(false, false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FLIGH.DEPART", new OrderedDictionary());
			allSortOrders["FLIGH.DEPART"].Add("FLIGH.DEPART", "A");




			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "fligh", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfligh.FldDepart), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAfligh.FldCodfligh, CSGenioAfligh.FldZzstate, CSGenioAfligh.FldFlighnum, CSGenioAfligh.FldCodplane, CSGenioAplane.FldCodplane, CSGenioAplane.FldModel, CSGenioAfligh.FldCodroute, CSGenioAroute.FldCodroute, CSGenioAroute.FldName, CSGenioAfligh.FldDepart, CSGenioAfligh.FldArrival, CSGenioAfligh.FldDuration, CSGenioAfligh.FldCodcrew, CSGenioAcrew.FldCodcrew, CSGenioAcrew.FldCrewname, CSGenioAfligh.FldCodpilot, CSGenioApilot.FldCodpilot, CSGenioApilot.FldName };


			//columns by users list (TemplateDBEditViewModel)
			//TODO: Get columns based on table configuration or merge this into the main column sort logic
			userColumns = UserUiSettings.Load(m_userContext.PersistentSupport, Uuid, m_userContext.User).userColumns;
			FieldRef firstVisibleColumn = null;

			if (sorts == null)
				if (userColumns != null)
				{
					CSGenioAlstcol col = userColumns.FirstOrDefault(x => x.ValVisivel == 1);

					if (col != null)
					{
						string table = col.ValTabela.ToLower();
						string field = col.ValCampo.ToLower(); //may contain Table.ValField
						if (field.Contains("."))
						{
							field = field.Substring(table.Length + 4); //remove table name and .Val from ValCampo data. i.e: "Pesso.ValNome", pesso lenght will remove "Pesso" and then +4 for the fixed ".Val"
						}
						else
						{
							field = field.Substring(3); //remove table Val from ValCampo data. i.e: "ValNome", Substring(3) will remove "Val"
						}

						firstVisibleColumn = new FieldRef(table, field);
					}
				}
				else
					firstVisibleColumn = new FieldRef("fligh", "flighnum");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAfligh model_limit_area = new CSGenioAfligh(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML251");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(pjf_menu_251Conds);
			pjf_menu_251Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PJF OVERRQ 251]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfligh>(m_userContext, false, pjf_menu_251Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML251", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PJF OVERRQLSTEXP 251]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL PJF OVERRQLIST 251]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_fligh");
				Navigation.DestroyEntry("QMVC_POS_RECORD_fligh");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAfligh.GetInformation(), QMVC_POS_RECORD, sorts, pjf_menu_251Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAfligh> listing = Models.ModelBase.Where<CSGenioAfligh>(m_userContext, false, pjf_menu_251Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML251", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapPJF_Menu_251(listing);

				Menu.Identifier = "ML251";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML251";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;
		}

		private List<Models.Fligh> MapPJF_Menu_251(ListingMVC<CSGenioAfligh> Qlisting)
		{
			var Elements = new List<Models.Fligh>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPJF_Menu_251(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAfligh row
		/// to a Models.Fligh object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Fligh MapPJF_Menu_251(CSGenioAfligh row)
		{
			var model = new Models.Fligh(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fligh":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "plane":
						model.Plane.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "route":
						model.Route.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "crew":
						model.Crew.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pilot":
						model.Pilot.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}


		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows.</param>
		private void SetDocumentFields(ListingMVC<CSGenioAfligh> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAfligh row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL PJF VIEWMODEL_CUSTOM PJF_MENU_251]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Fligh", "Fligh.ValCodfligh", "Fligh.ValZzstate", "Fligh.ValFlighnum", "Plane", "Plane.ValModel", "Route", "Route.ValName", "Fligh.ValDepart", "Fligh.ValArrival", "Fligh.ValDuration", "Crew", "Crew.ValCrewname", "Pilot", "Pilot.ValName", "Fligh.ValCodairln", "Fligh.ValCodsourc", "Fligh.ValCodcrew", "Fligh.ValCodpilot", "Fligh.ValCodplane", "Fligh.ValCodroute"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValFlighnum", CSGenioAfligh.FldFlighnum, typeof(string), defaultSearch : true),
			new TableSearchColumn("Plane_ValModel", CSGenioAplane.FldModel, typeof(string)),
			new TableSearchColumn("Route_ValName", CSGenioAroute.FldName, typeof(string)),
			new TableSearchColumn("ValDepart", CSGenioAfligh.FldDepart, typeof(DateTime?)),
			new TableSearchColumn("ValArrival", CSGenioAfligh.FldArrival, typeof(DateTime?)),
			new TableSearchColumn("ValDuration", CSGenioAfligh.FldDuration, typeof(decimal?)),
			new TableSearchColumn("Crew_ValCrewname", CSGenioAcrew.FldCrewname, typeof(string)),
			new TableSearchColumn("Pilot_ValName", CSGenioApilot.FldName, typeof(string))
		};
	}
}
