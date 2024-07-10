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
	public class Apsw : ModelBase
	{
		[JsonIgnore]
		public CSGenioAapsw klass { get { return baseklass as CSGenioAapsw; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Apsw.ValCodhpsw")]
		public string ValCodhpsw { get { return klass.ValCodhpsw; } set { klass.ValCodhpsw = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Apsw.ValCodairln")]
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


		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Apsw.ValCodpsw")]
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		private Psw _psw;
		[DisplayName("Psw")]
		[ShouldSerialize("Psw")]
		public virtual Psw Psw {
			get {
				if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw))))
					_psw = Models.Psw.Find(ValCodpsw, m_userContext, Identifier, _fieldsToSerialize);
				if (_psw == null)
					_psw = new Models.Psw(m_userContext, true, _fieldsToSerialize);
				return _psw;
			}
			set { _psw = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Apsw.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Apsw(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAapsw(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Apsw(UserContext userContext, CSGenioAapsw val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAapsw csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "airln":
						if (_airln == null)
							_airln = new Airln(m_userContext, true, _fieldsToSerialize);
						_airln.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "psw":
						if (_psw == null)
							_psw = new Psw(m_userContext, true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Apsw Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAapsw>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Apsw(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Apsw> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAapsw>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Apsw>((r) => new Apsw(userCtx, r));
		}

// USE /[MANUAL PJF MODEL APSW]/
	}
}
