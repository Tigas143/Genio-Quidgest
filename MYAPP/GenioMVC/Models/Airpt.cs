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
	public class Airpt : ModelBase
	{
		[JsonIgnore]
		public CSGenioAairpt klass { get { return baseklass as CSGenioAairpt; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Airpt.ValCodairpt")]
		public string ValCodairpt { get { return klass.ValCodairpt; } set { klass.ValCodairpt = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Airpt.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("City")]
		/// <summary>Field : "City" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Airpt.ValCodcity")]
		public string ValCodcity { get { return klass.ValCodcity; } set { klass.ValCodcity = value; } }
		private City _city;
		[DisplayName("City")]
		[ShouldSerialize("City")]
		public virtual City City {
			get {
				if (!this.isEmptyModel && (_city == null || (!string.IsNullOrEmpty(ValCodcity) && (_city.isEmptyModel || _city.klass.QPrimaryKey != ValCodcity))))
					_city = Models.City.Find(ValCodcity, m_userContext, Identifier, _fieldsToSerialize);
				if (_city == null)
					_city = new Models.City(m_userContext, true, _fieldsToSerialize);
				return _city;
			}
			set { _city = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Airpt.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Airpt(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAairpt(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Airpt(UserContext userContext, CSGenioAairpt val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAairpt csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "city":
						if (_city == null)
							_city = new City(m_userContext, true, _fieldsToSerialize);
						_city.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Airpt Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAairpt>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Airpt(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Airpt> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAairpt>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Airpt>((r) => new Airpt(userCtx, r));
		}

// USE /[MANUAL PJF MODEL AIRPT]/
	}
}
