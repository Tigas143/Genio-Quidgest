

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
	/// Flight
	/// </summary>
	public class CSGenioAfligh : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAfligh(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.INT_KEY;
			// USE /[MANUAL PJF CONSTRUTOR FLIGH]/
		}

		public CSGenioAfligh(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codfligh", FieldType.CHAVE_PRIMARIA);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codplane", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Aircraft";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AIRCRAFT03780";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codroute", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Route";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ROUTE59240";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("arrival", FieldType.DATAHORA);
			Qfield.FieldDescription = "Arrival";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ARRIVAL52302";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("depart", FieldType.DATAHORA);
			Qfield.FieldDescription = "Departure";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DEPARTURE11999";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("duration", FieldType.NUMERO);
			Qfield.FieldDescription = "Duracao";
			Qfield.FieldSize =  9;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DURACAO00266";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"depart","arrival"}, new int[] {0,1}, "fligh", "codfligh"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.DateDiffPart(((DateTime)args[0]),((DateTime)args[1]),"H");
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codsourc", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Source";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_codplane", "aircr");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcrew", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Flights Cabin Crew";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FLIGHTS_CABIN_CREW40365";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("namesc", FieldType.TEXTO);
			Qfield.FieldDescription = "Source";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOURCE49690";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"airsc"}, new int[] {0}, "plane", "codplane"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpilot", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Flight Pilot";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FLIGHT_PILOT12997";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("flighnum", FieldType.TEXTO);
			Qfield.FieldDescription = "Flight number identification";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FLIGHT_NUMBER_IDENTI52250";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("bookg", new String[] {"flight"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("airln", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codairln", "PJF", "pjfairln", "airln", "codairln", "codairln"));
			info.ParentTables.Add("airsc", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codsourc", "PJF", "pjfairpt", "airsc", "codairpt", "codairpt"));
			info.ParentTables.Add("crew", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codcrew", "PJF", "pjfcrew", "crew", "codcrew", "codcrew"));
			info.ParentTables.Add("pilot", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codpilot", "PJF", "pjfpilot", "pilot", "codpilot", "codpilot"));
			info.ParentTables.Add("plane", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codplane", "PJF", "pjfplane", "plane", "codplane", "codplane"));
			info.ParentTables.Add("route", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codroute", "PJF", "pjfroute", "route", "codroute", "codroute"));
			info.ParentTables.Add("_replicRel_codplane", new Relation("PJF", "pjffligh", "fligh", "codfligh", "codplane", "PJF", "pjfplane", "plane", "codplane", "codplane"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(10);
			info.Pathways.Add("airsc","airsc");
			info.Pathways.Add("airln","airln");
			info.Pathways.Add("plane","plane");
			info.Pathways.Add("crew","crew");
			info.Pathways.Add("pilot","pilot");
			info.Pathways.Add("route","route");
			info.Pathways.Add("city","airsc");
			info.Pathways.Add("airhb","airln");
			info.Pathways.Add("aircr","plane");
			info.Pathways.Add("airds","route");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.ReplicaFields = new string[] {
			 "codsourc"
			};

			info.InternalOperationFields = new string[] {
			 "duration","namesc"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAfligh()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="PJF";
			info.TableName="pjffligh";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codfligh";
			info.HumanKeyName="flighnum,".TrimEnd(',');
			info.Alias="fligh";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Flight";
			info.AreaPluralDesignation="Flight";
			info.DescriptionCav="FLIGHT55228";

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
		public static FieldRef FldCodfligh { get { return m_fldCodfligh; } }
		private static FieldRef m_fldCodfligh = new FieldRef("fligh", "codfligh");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfligh
		{
			get { return (string)returnValueField(FldCodfligh); }
			set { insertNameValueField(FldCodfligh, value); }
		}


		/// <summary>Field : "Aircraft" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodplane { get { return m_fldCodplane; } }
		private static FieldRef m_fldCodplane = new FieldRef("fligh", "codplane");

		/// <summary>Field : "Aircraft" Tipo: "CE" Formula:  ""</summary>
		public string ValCodplane
		{
			get { return (string)returnValueField(FldCodplane); }
			set { insertNameValueField(FldCodplane, value); }
		}


		/// <summary>Field : "Route" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodroute { get { return m_fldCodroute; } }
		private static FieldRef m_fldCodroute = new FieldRef("fligh", "codroute");

		/// <summary>Field : "Route" Tipo: "CE" Formula:  ""</summary>
		public string ValCodroute
		{
			get { return (string)returnValueField(FldCodroute); }
			set { insertNameValueField(FldCodroute, value); }
		}


		/// <summary>Field : "Arrival" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldArrival { get { return m_fldArrival; } }
		private static FieldRef m_fldArrival = new FieldRef("fligh", "arrival");

		/// <summary>Field : "Arrival" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValArrival
		{
			get { return (DateTime)returnValueField(FldArrival); }
			set { insertNameValueField(FldArrival, value); }
		}


		/// <summary>Field : "Departure" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDepart { get { return m_fldDepart; } }
		private static FieldRef m_fldDepart = new FieldRef("fligh", "depart");

		/// <summary>Field : "Departure" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDepart
		{
			get { return (DateTime)returnValueField(FldDepart); }
			set { insertNameValueField(FldDepart, value); }
		}


		/// <summary>Field : "Duracao" Tipo: "N" Formula: + "DateDiffPart([FLIGH->DEPART],[FLIGH->ARRIVAL],"H")"</summary>
		public static FieldRef FldDuration { get { return m_fldDuration; } }
		private static FieldRef m_fldDuration = new FieldRef("fligh", "duration");

		/// <summary>Field : "Duracao" Tipo: "N" Formula: + "DateDiffPart([FLIGH->DEPART],[FLIGH->ARRIVAL],"H")"</summary>
		public decimal ValDuration
		{
			get { return (decimal)returnValueField(FldDuration); }
			set { insertNameValueField(FldDuration, value); }
		}


		/// <summary>Field : "Source" Tipo: "CE" Formula: ++ "[PLANE->AIRCR]"</summary>
		public static FieldRef FldCodsourc { get { return m_fldCodsourc; } }
		private static FieldRef m_fldCodsourc = new FieldRef("fligh", "codsourc");

		/// <summary>Field : "Source" Tipo: "CE" Formula: ++ "[PLANE->AIRCR]"</summary>
		public string ValCodsourc
		{
			get { return (string)returnValueField(FldCodsourc); }
			set { insertNameValueField(FldCodsourc, value); }
		}


		/// <summary>Field : "Flights Cabin Crew" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcrew { get { return m_fldCodcrew; } }
		private static FieldRef m_fldCodcrew = new FieldRef("fligh", "codcrew");

		/// <summary>Field : "Flights Cabin Crew" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcrew
		{
			get { return (string)returnValueField(FldCodcrew); }
			set { insertNameValueField(FldCodcrew, value); }
		}


		/// <summary>Field : "Source" Tipo: "C" Formula: + "[PLANE->AIRSC]"</summary>
		public static FieldRef FldNamesc { get { return m_fldNamesc; } }
		private static FieldRef m_fldNamesc = new FieldRef("fligh", "namesc");

		/// <summary>Field : "Source" Tipo: "C" Formula: + "[PLANE->AIRSC]"</summary>
		public string ValNamesc
		{
			get { return (string)returnValueField(FldNamesc); }
			set { insertNameValueField(FldNamesc, value); }
		}


		/// <summary>Field : "Flight Pilot" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpilot { get { return m_fldCodpilot; } }
		private static FieldRef m_fldCodpilot = new FieldRef("fligh", "codpilot");

		/// <summary>Field : "Flight Pilot" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpilot
		{
			get { return (string)returnValueField(FldCodpilot); }
			set { insertNameValueField(FldCodpilot, value); }
		}


		/// <summary>Field : "Flight number identification" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldFlighnum { get { return m_fldFlighnum; } }
		private static FieldRef m_fldFlighnum = new FieldRef("fligh", "flighnum");

		/// <summary>Field : "Flight number identification" Tipo: "C" Formula:  ""</summary>
		public string ValFlighnum
		{
			get { return (string)returnValueField(FldFlighnum); }
			set { insertNameValueField(FldFlighnum, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairln { get { return m_fldCodairln; } }
		private static FieldRef m_fldCodairln = new FieldRef("fligh", "codairln");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairln
		{
			get { return (string)returnValueField(FldCodairln); }
			set { insertNameValueField(FldCodairln, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("fligh", "zzstate");



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
        public static CSGenioAfligh search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAfligh area = new CSGenioAfligh(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAfligh> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAfligh> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAfligh>(where, user, fields);
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
        public static List<CSGenioAfligh> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAfligh>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAfligh> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAfligh>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL PJF TABAUX FLIGH]/

 

             

	}
}
