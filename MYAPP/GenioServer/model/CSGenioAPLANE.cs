

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Aircraft
	/// </summary>
	public class CSGenioAplane : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAplane(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.INT_KEY;
			// USE /[MANUAL PJF CONSTRUTOR PLANE]/
		}

		public CSGenioAplane(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codplane", FieldType.CHAVE_PRIMARIA);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("photo", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Photo";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PHOTO51874";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("model", FieldType.TEXTO);
			Qfield.FieldDescription = "Model";
			Qfield.FieldSize =  30;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MODEL27263";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("engines", FieldType.NUMERO);
			Qfield.FieldDescription = "Number of engines";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NUMBER_OF_ENGINES61894";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("manufact", FieldType.TEXTO);
			Qfield.FieldDescription = "Manufacturer";
			Qfield.FieldSize =  30;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MANUFACTERER13111";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("year", FieldType.DATA);
			Qfield.FieldDescription = "Year of manufacture";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "YEAR_OF_MANUFACTURE06704";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("capacity", FieldType.NUMERO);
			Qfield.FieldDescription = "Capacity";
			Qfield.FieldSize =  9;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CAPACITY63181";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("status", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Status";
			Qfield.FieldSize =  9;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STATUS62033";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCstatus";
            Qfield.ArrayClassName = "Status";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("aircr", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Current Airport";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CURRENT_AIRPORT32976";

			Qfield.Dupmsg = "";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("PJF", "pjffligh", "codplane", "codsourc"));
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("age", FieldType.NUMERO);
			Qfield.FieldDescription = "Age";
			Qfield.FieldSize =  4;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AGE28663";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"year"}, new int[] {0}, "plane", "codplane"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.Year(DateTime.Today)-GlobalFunctions.Year(((DateTime)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("airsc", FieldType.TEXTO);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_aircr", "name");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("maint", FieldType.NUMERO);
			Qfield.FieldDescription = "Status of maintenance";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STATUS_OF_MAINTENANC40849";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ismaint", FieldType.LOGICO);
			Qfield.FieldDescription = "is maint";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IS_MAINT27685";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"maint"}, new int[] {0}, "plane", "codplane"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((((decimal)args[0])>0)?(1):(0));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codairln", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("id", FieldType.TEXTO);
			Qfield.FieldDescription = "ID";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ID48520";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("zzstate", FieldType.INTEIRO);
			Qfield.FieldDescription = "Estado da ficha";
			Qfield.Alias = info.Alias;
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("fligh", new String[] {"codplane"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("maint", new String[] {"codplane"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("aircr", new Relation("PJF", "pjfplane", "plane", "codplane", "aircr", "PJF", "pjfairpt", "aircr", "codairpt", "codairpt"));
			info.ParentTables.Add("airln", new Relation("PJF", "pjfplane", "plane", "codplane", "codairln", "PJF", "pjfairln", "airln", "codairln", "codairln"));
			info.ParentTables.Add("_replicRel_aircr", new Relation("PJF", "pjfplane", "plane", "codplane", "aircr", "PJF", "pjfairpt", "airpt", "codairpt", "codairpt"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(4);
			info.Pathways.Add("aircr","aircr");
			info.Pathways.Add("airln","airln");
			info.Pathways.Add("city","aircr");
			info.Pathways.Add("airhb","airln");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.ReplicaFields = new string[] {
			 "airsc"
			};

			info.InternalOperationFields = new string[] {
			 "age","ismaint"
			};


			info.RelatedSumFields = new string[] {
			 "maint"
			};




			info.FieldsParametersReplicas = new string[] {
			 "aircr"
			};

			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAplane()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="PJF";
			info.TableName="pjfplane";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codplane";
			info.HumanKeyName="model,".TrimEnd(',');
			info.Alias="plane";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Aircraft";
			info.AreaPluralDesignation="Aircrafts";
			info.DescriptionCav="AIRCRAFT03780";

			info.KeyType = CodeType.INT_KEY;

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();
			EPHField[] camposEPH;
						camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("AIRLINE", "airln", "codairln", "=", false);
			info.Ephs.Add(new Par("PJF", "10"), camposEPH);
			camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("AIRLINE", "airln", "codairln", "=", false);
			info.Ephs.Add(new Par("PJF", "90"), camposEPH);

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodplane { get { return m_fldCodplane; } }
		private static FieldRef m_fldCodplane = new FieldRef("plane", "codplane");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodplane
		{
			get { return (string)returnValueField(FldCodplane); }
			set { insertNameValueField(FldCodplane, value); }
		}


		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhoto { get { return m_fldPhoto; } }
		private static FieldRef m_fldPhoto = new FieldRef("plane", "photo");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhoto
		{
			get { return (byte[])returnValueField(FldPhoto); }
			set { insertNameValueField(FldPhoto, value); }
		}


		/// <summary>Field : "Model" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldModel { get { return m_fldModel; } }
		private static FieldRef m_fldModel = new FieldRef("plane", "model");

		/// <summary>Field : "Model" Tipo: "C" Formula:  ""</summary>
		public string ValModel
		{
			get { return (string)returnValueField(FldModel); }
			set { insertNameValueField(FldModel, value); }
		}


		/// <summary>Field : "Number of engines" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldEngines { get { return m_fldEngines; } }
		private static FieldRef m_fldEngines = new FieldRef("plane", "engines");

		/// <summary>Field : "Number of engines" Tipo: "N" Formula:  ""</summary>
		public decimal ValEngines
		{
			get { return (decimal)returnValueField(FldEngines); }
			set { insertNameValueField(FldEngines, value); }
		}


		/// <summary>Field : "Manufacturer" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldManufact { get { return m_fldManufact; } }
		private static FieldRef m_fldManufact = new FieldRef("plane", "manufact");

		/// <summary>Field : "Manufacturer" Tipo: "C" Formula:  ""</summary>
		public string ValManufact
		{
			get { return (string)returnValueField(FldManufact); }
			set { insertNameValueField(FldManufact, value); }
		}


		/// <summary>Field : "Year of manufacture" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldYear { get { return m_fldYear; } }
		private static FieldRef m_fldYear = new FieldRef("plane", "year");

		/// <summary>Field : "Year of manufacture" Tipo: "D" Formula:  ""</summary>
		public DateTime ValYear
		{
			get { return (DateTime)returnValueField(FldYear); }
			set { insertNameValueField(FldYear, value); }
		}


		/// <summary>Field : "Capacity" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldCapacity { get { return m_fldCapacity; } }
		private static FieldRef m_fldCapacity = new FieldRef("plane", "capacity");

		/// <summary>Field : "Capacity" Tipo: "N" Formula:  ""</summary>
		public decimal ValCapacity
		{
			get { return (decimal)returnValueField(FldCapacity); }
			set { insertNameValueField(FldCapacity, value); }
		}


		/// <summary>Field : "Status" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldStatus { get { return m_fldStatus; } }
		private static FieldRef m_fldStatus = new FieldRef("plane", "status");

		/// <summary>Field : "Status" Tipo: "AC" Formula:  ""</summary>
		public string ValStatus
		{
			get { return (string)returnValueField(FldStatus); }
			set { insertNameValueField(FldStatus, value); }
		}


		/// <summary>Field : "Current Airport" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldAircr { get { return m_fldAircr; } }
		private static FieldRef m_fldAircr = new FieldRef("plane", "aircr");

		/// <summary>Field : "Current Airport" Tipo: "CE" Formula:  ""</summary>
		public string ValAircr
		{
			get { return (string)returnValueField(FldAircr); }
			set { insertNameValueField(FldAircr, value); }
		}


		/// <summary>Field : "Age" Tipo: "N" Formula: + "Year([Today]) - Year([PLANE->YEAR])"</summary>
		public static FieldRef FldAge { get { return m_fldAge; } }
		private static FieldRef m_fldAge = new FieldRef("plane", "age");

		/// <summary>Field : "Age" Tipo: "N" Formula: + "Year([Today]) - Year([PLANE->YEAR])"</summary>
		public decimal ValAge
		{
			get { return (decimal)returnValueField(FldAge); }
			set { insertNameValueField(FldAge, value); }
		}


		/// <summary>Field : "" Tipo: "C" Formula: ++ "[AIRCR->NAME]"</summary>
		public static FieldRef FldAirsc { get { return m_fldAirsc; } }
		private static FieldRef m_fldAirsc = new FieldRef("plane", "airsc");

		/// <summary>Field : "" Tipo: "C" Formula: ++ "[AIRCR->NAME]"</summary>
		public string ValAirsc
		{
			get { return (string)returnValueField(FldAirsc); }
			set { insertNameValueField(FldAirsc, value); }
		}


		/// <summary>Field : "Status of maintenance" Tipo: "N" Formula: SR "[MAINT->STATUS]"</summary>
		public static FieldRef FldMaint { get { return m_fldMaint; } }
		private static FieldRef m_fldMaint = new FieldRef("plane", "maint");

		/// <summary>Field : "Status of maintenance" Tipo: "N" Formula: SR "[MAINT->STATUS]"</summary>
		public decimal ValMaint
		{
			get { return (decimal)returnValueField(FldMaint); }
			set { insertNameValueField(FldMaint, value); }
		}


		/// <summary>Field : "is maint" Tipo: "L" Formula: + "iif([PLANE->MAINT] > 0, 1, 0)"</summary>
		public static FieldRef FldIsmaint { get { return m_fldIsmaint; } }
		private static FieldRef m_fldIsmaint = new FieldRef("plane", "ismaint");

		/// <summary>Field : "is maint" Tipo: "L" Formula: + "iif([PLANE->MAINT] > 0, 1, 0)"</summary>
		public int ValIsmaint
		{
			get { return (int)returnValueField(FldIsmaint); }
			set { insertNameValueField(FldIsmaint, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairln { get { return m_fldCodairln; } }
		private static FieldRef m_fldCodairln = new FieldRef("plane", "codairln");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairln
		{
			get { return (string)returnValueField(FldCodairln); }
			set { insertNameValueField(FldCodairln, value); }
		}


		/// <summary>Field : "ID" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldId { get { return m_fldId; } }
		private static FieldRef m_fldId = new FieldRef("plane", "id");

		/// <summary>Field : "ID" Tipo: "C" Formula:  ""</summary>
		public string ValId
		{
			get { return (string)returnValueField(FldId); }
			set { insertNameValueField(FldId, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("plane", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAplane search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAplane area = new CSGenioAplane(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}



        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        [Obsolete("Use List<CSGenioAplane> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAplane> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAplane>(where, user, fields);
        }


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAplane> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAplane>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAplane> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAplane>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL PJF TABAUX PLANE]/

 

                

	}
}
