

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
	/// Booking
	/// </summary>
	public class CSGenioAbookg : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAbookg(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.INT_KEY;
			// USE /[MANUAL PJF CONSTRUTOR BOOKG]/
		}

		public CSGenioAbookg(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codbookg", FieldType.CHAVE_PRIMARIA);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("bnum", FieldType.TEXTO);
			Qfield.FieldDescription = "Booking number";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BOOKING_NUMBER35241";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1, "bnum");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("flight", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Flight";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FLIGHT55228";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("price", FieldType.TEXTO);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  30;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PRICE06900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpasgr", FieldType.CHAVE_ESTRANGEIRA);
			Qfield.FieldDescription = "Passenger of the flight";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PASSENGER_OF_THE_FLI48568";

			Qfield.Dupmsg = "";
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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("airln", new Relation("PJF", "pjfbookg", "bookg", "codbookg", "codairln", "PJF", "pjfairln", "airln", "codairln", "codairln"));
			info.ParentTables.Add("fligh", new Relation("PJF", "pjfbookg", "bookg", "codbookg", "flight", "PJF", "pjffligh", "fligh", "codfligh", "codfligh"));
			info.ParentTables.Add("perso", new Relation("PJF", "pjfbookg", "bookg", "codbookg", "codpasgr", "PJF", "pjfperso", "perso", "codperso", "codperso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(12);
			info.Pathways.Add("perso","perso");
			info.Pathways.Add("airln","airln");
			info.Pathways.Add("fligh","fligh");
			info.Pathways.Add("city","airln");
			info.Pathways.Add("airhb","airln");
			info.Pathways.Add("airsc","fligh");
			info.Pathways.Add("plane","fligh");
			info.Pathways.Add("crew","fligh");
			info.Pathways.Add("pilot","fligh");
			info.Pathways.Add("route","fligh");
			info.Pathways.Add("aircr","fligh");
			info.Pathways.Add("airds","fligh");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.SequentialDefaultValues = new string[] {
			 "bnum"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAbookg()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="PJF";
			info.TableName="pjfbookg";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codbookg";
			info.HumanKeyName="bnum,".TrimEnd(',');
			info.Alias="bookg";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Booking";
			info.AreaPluralDesignation="Booking";
			info.DescriptionCav="BOOKING10841";

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
		public static FieldRef FldCodbookg { get { return m_fldCodbookg; } }
		private static FieldRef m_fldCodbookg = new FieldRef("bookg", "codbookg");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodbookg
		{
			get { return (string)returnValueField(FldCodbookg); }
			set { insertNameValueField(FldCodbookg, value); }
		}


		/// <summary>Field : "Booking number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBnum { get { return m_fldBnum; } }
		private static FieldRef m_fldBnum = new FieldRef("bookg", "bnum");

		/// <summary>Field : "Booking number" Tipo: "C" Formula:  ""</summary>
		public string ValBnum
		{
			get { return (string)returnValueField(FldBnum); }
			set { insertNameValueField(FldBnum, value); }
		}


		/// <summary>Field : "Flight" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldFlight { get { return m_fldFlight; } }
		private static FieldRef m_fldFlight = new FieldRef("bookg", "flight");

		/// <summary>Field : "Flight" Tipo: "CE" Formula:  ""</summary>
		public string ValFlight
		{
			get { return (string)returnValueField(FldFlight); }
			set { insertNameValueField(FldFlight, value); }
		}


		/// <summary>Field : "Price" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("bookg", "price");

		/// <summary>Field : "Price" Tipo: "C" Formula:  ""</summary>
		public string ValPrice
		{
			get { return (string)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}


		/// <summary>Field : "Passenger of the flight" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpasgr { get { return m_fldCodpasgr; } }
		private static FieldRef m_fldCodpasgr = new FieldRef("bookg", "codpasgr");

		/// <summary>Field : "Passenger of the flight" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpasgr
		{
			get { return (string)returnValueField(FldCodpasgr); }
			set { insertNameValueField(FldCodpasgr, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairln { get { return m_fldCodairln; } }
		private static FieldRef m_fldCodairln = new FieldRef("bookg", "codairln");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairln
		{
			get { return (string)returnValueField(FldCodairln); }
			set { insertNameValueField(FldCodairln, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("bookg", "zzstate");



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
        public static CSGenioAbookg search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAbookg area = new CSGenioAbookg(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAbookg> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAbookg> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAbookg>(where, user, fields);
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
        public static List<CSGenioAbookg> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAbookg>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAbookg> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAbookg>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL PJF TABAUX BOOKG]/

 

       

	}
}
