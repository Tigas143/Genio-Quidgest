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
	public class Route : ModelBase
	{
		[JsonIgnore]
		public CSGenioAroute klass { get { return baseklass as CSGenioAroute; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Route.ValCodroute")]
		public string ValCodroute { get { return klass.ValCodroute; } set { klass.ValCodroute = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Route.ValAirds")]
		public string ValAirds { get { return klass.ValAirds; } set { klass.ValAirds = value; } }
		private Airds _airds;
		[DisplayName("Airds")]
		[ShouldSerialize("Airds")]
		public virtual Airds Airds {
			get {
				if (!this.isEmptyModel && (_airds == null || (!string.IsNullOrEmpty(ValAirds) && (_airds.isEmptyModel || _airds.klass.QPrimaryKey != ValAirds))))
					_airds = Models.Airds.Find(ValAirds, m_userContext, Identifier, _fieldsToSerialize);
				if (_airds == null)
					_airds = new Models.Airds(m_userContext, true, _fieldsToSerialize);
				return _airds;
			}
			set { _airds = value; }
		}


		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Route.ValAirsc")]
		public string ValAirsc { get { return klass.ValAirsc; } set { klass.ValAirsc = value; } }
		private Airsc _airsc;
		[DisplayName("Airsc")]
		[ShouldSerialize("Airsc")]
		public virtual Airsc Airsc {
			get {
				if (!this.isEmptyModel && (_airsc == null || (!string.IsNullOrEmpty(ValAirsc) && (_airsc.isEmptyModel || _airsc.klass.QPrimaryKey != ValAirsc))))
					_airsc = Models.Airsc.Find(ValAirsc, m_userContext, Identifier, _fieldsToSerialize);
				if (_airsc == null)
					_airsc = new Models.Airsc(m_userContext, true, _fieldsToSerialize);
				return _airsc;
			}
			set { _airsc = value; }
		}


		[DisplayName("Estimated duration")]
		/// <summary>Field : "Estimated duration" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Route.ValDuration")]
		[DateAttribute("T")]
		public string ValDuration { get { return klass.ValDuration; } set { klass.ValDuration = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Route.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Route.ValCodairln")]
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
		[ShouldSerialize("Route.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Route(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAroute(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Route(UserContext userContext, CSGenioAroute val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAroute csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "airds":
						if (_airds == null)
							_airds = new Airds(m_userContext, true, _fieldsToSerialize);
						_airds.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airsc":
						if (_airsc == null)
							_airsc = new Airsc(m_userContext, true, _fieldsToSerialize);
						_airsc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Route Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAroute>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Route(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Route> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAroute>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Route>((r) => new Route(userCtx, r));
		}

// USE /[MANUAL PJF MODEL ROUTE]/
	}
}
