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

namespace GenioMVC.ViewModels.Plane
{
	public class Wplane_ValListplan_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Plane> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "plane"; }

		/// <inheritdoc/>
		public override string Uuid { get => "Wplane_ValListplan"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodplane { get; set; }

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
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Wplane_ValListplan_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Wplane_ValListplan_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodplane = userContext.CurrentNavigation.CurrentLevel.GetEntry("plane")?.ToString();
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				!ajaxRequest ? new Exports.QColumn(CSGenioAplane.FldPhoto, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 0, true):null,
				new Exports.QColumn(CSGenioAairln.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 9, 0, true),
				new Exports.QColumn(CSGenioAplane.FldId, FieldType.TEXTO, Resources.Resources.MODEL27263, 20, 0, true),
				new Exports.QColumn(CSGenioAplane.FldManufact, FieldType.TEXTO, Resources.Resources.MANUFACTURER50759, 30, 0, true),
				new Exports.QColumn(CSGenioAplane.FldModel, FieldType.TEXTO, Resources.Resources.MODEL27263, 30, 0, true),
				new Exports.QColumn(CSGenioAplane.FldCapacity, FieldType.NUMERO, Resources.Resources.CAPACITY63181, 9, 0, true),
				new Exports.QColumn(CSGenioAplane.FldStatus, FieldType.ARRAY_COD_TEXTO, Resources.Resources.STATUS62033, 9, 0, true, "STATUS"),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAplane> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAplane> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GenioMVC.Models.Plane>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Plane.AddEPH<CSGenioAplane>(ref u, crs, "IBL_WPLANE__PSEUDLISTPLAN");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAplane.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PLANE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAplane.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_plane");
				Navigation.DestroyEntry("QMVC_POS_RECORD_plane");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Plane.AddEPH<CSGenioAplane>(ref u, null, "IBL_WPLANE__PSEUDLISTPLAN"));
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
			ListingMVC<CSGenioAplane> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAplane> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAplane> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAplane> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Plane>();

			CriteriaSet wplane__pseudlistplanConds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(false, false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "plane", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAplane.FldCodplane, CSGenioAplane.FldZzstate, CSGenioAplane.FldPhoto, CSGenioAplane.FldCodairln, CSGenioAairln.FldCodairln, CSGenioAairln.FldName, CSGenioAplane.FldId, CSGenioAplane.FldManufact, CSGenioAplane.FldModel, CSGenioAplane.FldCapacity, CSGenioAplane.FldStatus };


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
					firstVisibleColumn = new FieldRef("plane", "photo");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAplane model_limit_area = new CSGenioAplane(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_WPLANE__PSEUDLISTPLAN");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(wplane__pseudlistplanConds);
			wplane__pseudlistplanConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PJF OVERRQ WPLANE_PSEUDLISTPLAN]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAplane>(m_userContext, false, wplane__pseudlistplanConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WPLANE__PSEUDLISTPLAN", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PJF OVERRQLSTEXP WPLANE_PSEUDLISTPLAN]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL PJF OVERRQLIST WPLANE_PSEUDLISTPLAN]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_plane");
				Navigation.DestroyEntry("QMVC_POS_RECORD_plane");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAplane.GetInformation(), QMVC_POS_RECORD, sorts, wplane__pseudlistplanConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAplane> listing = Models.ModelBase.Where<CSGenioAplane>(m_userContext, false, wplane__pseudlistplanConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WPLANE__PSEUDLISTPLAN", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapWplane_ValListplan(listing);

				Menu.Identifier = "IBL_WPLANE__PSEUDLISTPLAN";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_WPLANE__PSEUDLISTPLAN";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;
		}

		private List<Models.Plane> MapWplane_ValListplan(ListingMVC<CSGenioAplane> Qlisting)
		{
			var Elements = new List<Models.Plane>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWplane_ValListplan(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAplane row
		/// to a Models.Plane object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Plane MapWplane_ValListplan(CSGenioAplane row)
		{
			var model = new Models.Plane(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "plane":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "airln":
						model.Airln.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAplane> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAplane row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL PJF VIEWMODEL_CUSTOM WPLANE_VALLISTPLAN]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Plane", "Plane.ValCodplane", "Plane.ValZzstate", "Plane.ValPhoto", "Airln", "Airln.ValName", "Plane.ValId", "Plane.ValManufact", "Plane.ValModel", "Plane.ValCapacity", "Plane.ValStatus", "Plane.ValAircr", "Plane.ValCodairln"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("Airln_ValName", CSGenioAairln.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValId", CSGenioAplane.FldId, typeof(string)),
			new TableSearchColumn("ValManufact", CSGenioAplane.FldManufact, typeof(string)),
			new TableSearchColumn("ValModel", CSGenioAplane.FldModel, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValCapacity", CSGenioAplane.FldCapacity, typeof(decimal?)),
			new TableSearchColumn("ValStatus", CSGenioAplane.FldStatus, typeof(string), array : "STATUS")
		};
	}
}
