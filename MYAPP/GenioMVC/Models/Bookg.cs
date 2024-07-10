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
	public class Bookg : ModelBase
	{
		[JsonIgnore]
		public CSGenioAbookg klass { get { return baseklass as CSGenioAbookg; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Bookg.ValCodbookg")]
		public string ValCodbookg { get { return klass.ValCodbookg; } set { klass.ValCodbookg = value; } }

		[DisplayName("Booking number")]
		/// <summary>Field : "Booking number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Bookg.ValBnum")]
		public string ValBnum { get { return klass.ValBnum; } set { klass.ValBnum = value; } }

		[DisplayName("Flight")]
		/// <summary>Field : "Flight" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Bookg.ValFlight")]
		public string ValFlight { get { return klass.ValFlight; } set { klass.ValFlight = value; } }
		private Fligh _fligh;
		[DisplayName("Fligh")]
		[ShouldSerialize("Fligh")]
		public virtual Fligh Fligh {
			get {
				if (!this.isEmptyModel && (_fligh == null || (!string.IsNullOrEmpty(ValFlight) && (_fligh.isEmptyModel || _fligh.klass.QPrimaryKey != ValFlight))))
					_fligh = Models.Fligh.Find(ValFlight, m_userContext, Identifier, _fieldsToSerialize);
				if (_fligh == null)
					_fligh = new Models.Fligh(m_userContext, true, _fieldsToSerialize);
				return _fligh;
			}
			set { _fligh = value; }
		}


		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Bookg.ValPrice")]
		public string ValPrice { get { return klass.ValPrice; } set { klass.ValPrice = value; } }

		[DisplayName("Passenger of the flight")]
		/// <summary>Field : "Passenger of the flight" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Bookg.ValCodpasgr")]
		public string ValCodpasgr { get { return klass.ValCodpasgr; } set { klass.ValCodpasgr = value; } }
		private Perso _perso;
		[DisplayName("Perso")]
		[ShouldSerialize("Perso")]
		public virtual Perso Perso {
			get {
				if (!this.isEmptyModel && (_perso == null || (!string.IsNullOrEmpty(ValCodpasgr) && (_perso.isEmptyModel || _perso.klass.QPrimaryKey != ValCodpasgr))))
					_perso = Models.Perso.Find(ValCodpasgr, m_userContext, Identifier, _fieldsToSerialize);
				if (_perso == null)
					_perso = new Models.Perso(m_userContext, true, _fieldsToSerialize);
				return _perso;
			}
			set { _perso = value; }
		}


		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Bookg.ValCodairln")]
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
		[ShouldSerialize("Bookg.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Bookg(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAbookg(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Bookg(UserContext userContext, CSGenioAbookg val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAbookg csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fligh":
						if (_fligh == null)
							_fligh = new Fligh(m_userContext, true, _fieldsToSerialize);
						_fligh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "perso":
						if (_perso == null)
							_perso = new Perso(m_userContext, true, _fieldsToSerialize);
						_perso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Bookg Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAbookg>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Bookg(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Bookg> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAbookg>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Bookg>((r) => new Bookg(userCtx, r));
		}

// USE /[MANUAL PJF MODEL BOOKG]/
	}
}
