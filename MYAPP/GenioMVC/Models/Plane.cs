using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Plane : ModelBase
	{
		[JsonIgnore]
		public CSGenioAplane klass { get { return baseklass as CSGenioAplane; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValCodplane")]
		public string ValCodplane { get { return klass.ValCodplane; } set { klass.ValCodplane = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }

		[DisplayName("Model")]
		/// <summary>Field : "Model" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValModel")]
		public string ValModel { get { return klass.ValModel; } set { klass.ValModel = value; } }

		[DisplayName("Number of engines")]
		/// <summary>Field : "Number of engines" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValEngines")]
		[NumericAttribute(0)]
		public decimal? ValEngines { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValEngines, 0)); } set { klass.ValEngines = Convert.ToDecimal(value); } }

		[DisplayName("Manufacturer")]
		/// <summary>Field : "Manufacturer" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValManufact")]
		public string ValManufact { get { return klass.ValManufact; } set { klass.ValManufact = value; } }

		[DisplayName("Year of manufacture")]
		/// <summary>Field : "Year of manufacture" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValYear")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValYear { get { return klass.ValYear; } set { klass.ValYear = value ?? DateTime.MinValue; } }

		[DisplayName("Capacity")]
		/// <summary>Field : "Capacity" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValCapacity")]
		[NumericAttribute(0)]
		public decimal? ValCapacity { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValCapacity, 0)); } set { klass.ValCapacity = Convert.ToDecimal(value); } }

		[DisplayName("Status")]
		/// <summary>Field : "Status" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValStatus")]
		[DataArray("Status", GenioMVC.Helpers.ArrayType.Character)]
		public string ValStatus { get { return klass.ValStatus; } set { klass.ValStatus = value; } }
		[JsonIgnore]
		public SelectList ArrayValstatus { get { return new SelectList(CSGenio.business.ArrayStatus.GetDictionary(), "Key", "Value", ValStatus); } set { ValStatus = value.SelectedValue as string; } }

		[DisplayName("Current Airport")]
		/// <summary>Field : "Current Airport" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValAircr")]
		public string ValAircr { get { return klass.ValAircr; } set { klass.ValAircr = value; } }
		private Aircr _aircr;
		[DisplayName("Aircr")]
		[ShouldSerialize("Aircr")]
		public virtual Aircr Aircr {
			get {
				if (!this.isEmptyModel && (_aircr == null || (!string.IsNullOrEmpty(ValAircr) && (_aircr.isEmptyModel || _aircr.klass.QPrimaryKey != ValAircr))))
					_aircr = Models.Aircr.Find(ValAircr, m_userContext, Identifier, _fieldsToSerialize);
				if (_aircr == null)
					_aircr = new Models.Aircr(m_userContext, true, _fieldsToSerialize);
				return _aircr;
			}
			set { _aircr = value; }
		}


		[DisplayName("Age")]
		/// <summary>Field : "Age" Tipo: "N" Formula: + "Year([Today]) - Year([PLANE->YEAR])"</summary>
		[ShouldSerialize("Plane.ValAge")]
		[NumericAttribute(0)]
		public decimal? ValAge { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValAge, 0)); } set { klass.ValAge = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula: ++ "[AIRCR->NAME]"</summary>
		[ShouldSerialize("Plane.ValAirsc")]
		public string ValAirsc { get { return klass.ValAirsc; } set { klass.ValAirsc = value; } }

		[DisplayName("Status of maintenance")]
		/// <summary>Field : "Status of maintenance" Tipo: "N" Formula: SR "[MAINT->STATUS]"</summary>
		[ShouldSerialize("Plane.ValMaint")]
		[NumericAttribute(0)]
		public decimal? ValMaint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValMaint, 0)); } set { klass.ValMaint = Convert.ToDecimal(value); } }

		[DisplayName("is maint")]
		/// <summary>Field : "is maint" Tipo: "L" Formula: + "iif([PLANE->MAINT] > 0, 1, 0)"</summary>
		[ShouldSerialize("Plane.ValIsmaint")]
		public bool ValIsmaint { get { return Convert.ToBoolean(klass.ValIsmaint); } set { klass.ValIsmaint = Convert.ToInt32(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValCodairln")]
		public string ValCodairln { get { return klass.ValCodairln; } set { klass.ValCodairln = value; } }
		private Airln _airln;
		[DisplayName("Airln")]
		[ShouldSerialize("Airln")]
		public virtual Airln Airln {
			get {
				if (!this.isEmptyModel && (_airln == null || (!string.IsNullOrEmpty(ValCodairln) && (_airln.isEmptyModel || _airln.klass.QPrimaryKey != ValCodairln))))
					_airln = Models.Airln.Find(ValCodairln, m_userContext, Identifier, _fieldsToSerialize);
				if (_airln == null)
					_airln = new Models.Airln(m_userContext, true, _fieldsToSerialize);
				return _airln;
			}
			set { _airln = value; }
		}


		[DisplayName("ID")]
		/// <summary>Field : "ID" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Plane.ValId")]
		public string ValId { get { return klass.ValId; } set { klass.ValId = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Plane.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Plane(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAplane(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Plane(UserContext userContext, CSGenioAplane val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAplane csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "aircr":
						if (_aircr == null)
							_aircr = new Aircr(m_userContext, true, _fieldsToSerialize);
						_aircr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airln":
						if (_airln == null)
							_airln = new Airln(m_userContext, true, _fieldsToSerialize);
						_airln.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Plane Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAplane>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Plane(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Plane> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAplane>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Plane>((r) => new Plane(userCtx, r));
		}

// USE /[MANUAL PJF MODEL PLANE]/
	}
}
