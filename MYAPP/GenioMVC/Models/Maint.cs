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
	public class Maint : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmaint klass { get { return baseklass as CSGenioAmaint; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Maint.ValCodmaint")]
		public string ValCodmaint { get { return klass.ValCodmaint; } set { klass.ValCodmaint = value; } }

		[DisplayName("Status")]
		/// <summary>Field : "Status" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Maint.ValStatus")]
		[DataArray("Statusm", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValStatus { get { return klass.ValStatus; } set { klass.ValStatus = value; } }
		[JsonIgnore]
		public SelectList ArrayValstatus { get { return new SelectList(CSGenio.business.ArrayStatusm.GetDictionary(), "Key", "Value", ValStatus); } set { ValStatus = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Aircraft")]
		/// <summary>Field : "Aircraft" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Maint.ValCodplane")]
		public string ValCodplane { get { return klass.ValCodplane; } set { klass.ValCodplane = value; } }
		private Plane _plane;
		[DisplayName("Plane")]
		[ShouldSerialize("Plane")]
		public virtual Plane Plane {
			get {
				if (!this.isEmptyModel && (_plane == null || (!string.IsNullOrEmpty(ValCodplane) && (_plane.isEmptyModel || _plane.klass.QPrimaryKey != ValCodplane))))
					_plane = Models.Plane.Find(ValCodplane, m_userContext, Identifier, _fieldsToSerialize);
				if (_plane == null)
					_plane = new Models.Plane(m_userContext, true, _fieldsToSerialize);
				return _plane;
			}
			set { _plane = value; }
		}


		[DisplayName("Maintanace Valid Untill")]
		/// <summary>Field : "Maintanace Valid Untill" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Maint.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Maint.ValCodairln")]
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


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Maint.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Maint(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmaint(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Maint(UserContext userContext, CSGenioAmaint val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAmaint csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "plane":
						if (_plane == null)
							_plane = new Plane(m_userContext, true, _fieldsToSerialize);
						_plane.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Maint Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmaint>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Maint(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Maint> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmaint>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Maint>((r) => new Maint(userCtx, r));
		}

// USE /[MANUAL PJF MODEL MAINT]/
	}
}
