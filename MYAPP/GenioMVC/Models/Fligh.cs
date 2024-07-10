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
	public class Fligh : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfligh klass { get { return baseklass as CSGenioAfligh; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodfligh")]
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }

		[DisplayName("Aircraft")]
		/// <summary>Field : "Aircraft" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodplane")]
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


		[DisplayName("Route")]
		/// <summary>Field : "Route" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodroute")]
		public string ValCodroute { get { return klass.ValCodroute; } set { klass.ValCodroute = value; } }
		private Route _route;
		[DisplayName("Route")]
		[ShouldSerialize("Route")]
		public virtual Route Route {
			get {
				if (!this.isEmptyModel && (_route == null || (!string.IsNullOrEmpty(ValCodroute) && (_route.isEmptyModel || _route.klass.QPrimaryKey != ValCodroute))))
					_route = Models.Route.Find(ValCodroute, m_userContext, Identifier, _fieldsToSerialize);
				if (_route == null)
					_route = new Models.Route(m_userContext, true, _fieldsToSerialize);
				return _route;
			}
			set { _route = value; }
		}


		[DisplayName("Arrival")]
		/// <summary>Field : "Arrival" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValArrival")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValArrival { get { return klass.ValArrival; } set { klass.ValArrival = value ?? DateTime.MinValue; } }

		[DisplayName("Departure")]
		/// <summary>Field : "Departure" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValDepart")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDepart { get { return klass.ValDepart; } set { klass.ValDepart = value ?? DateTime.MinValue; } }

		[DisplayName("Duracao")]
		/// <summary>Field : "Duracao" Tipo: "N" Formula: + "DateDiffPart([FLIGH->DEPART],[FLIGH->ARRIVAL],"H")"</summary>
		[ShouldSerialize("Fligh.ValDuration")]
		[NumericAttribute(0)]
		public decimal? ValDuration { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDuration, 0)); } set { klass.ValDuration = Convert.ToDecimal(value); } }

		[DisplayName("Source")]
		/// <summary>Field : "Source" Tipo: "CE" Formula: ++ "[PLANE->AIRCR]"</summary>
		[ShouldSerialize("Fligh.ValCodsourc")]
		public string ValCodsourc { get { return klass.ValCodsourc; } set { klass.ValCodsourc = value; } }
		private Airsc _airsc;
		[DisplayName("Airsc")]
		[ShouldSerialize("Airsc")]
		public virtual Airsc Airsc {
			get {
				if (!this.isEmptyModel && (_airsc == null || (!string.IsNullOrEmpty(ValCodsourc) && (_airsc.isEmptyModel || _airsc.klass.QPrimaryKey != ValCodsourc))))
					_airsc = Models.Airsc.Find(ValCodsourc, m_userContext, Identifier, _fieldsToSerialize);
				if (_airsc == null)
					_airsc = new Models.Airsc(m_userContext, true, _fieldsToSerialize);
				return _airsc;
			}
			set { _airsc = value; }
		}


		[DisplayName("Flights Cabin Crew")]
		/// <summary>Field : "Flights Cabin Crew" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodcrew")]
		public string ValCodcrew { get { return klass.ValCodcrew; } set { klass.ValCodcrew = value; } }
		private Crew _crew;
		[DisplayName("Crew")]
		[ShouldSerialize("Crew")]
		public virtual Crew Crew {
			get {
				if (!this.isEmptyModel && (_crew == null || (!string.IsNullOrEmpty(ValCodcrew) && (_crew.isEmptyModel || _crew.klass.QPrimaryKey != ValCodcrew))))
					_crew = Models.Crew.Find(ValCodcrew, m_userContext, Identifier, _fieldsToSerialize);
				if (_crew == null)
					_crew = new Models.Crew(m_userContext, true, _fieldsToSerialize);
				return _crew;
			}
			set { _crew = value; }
		}


		[DisplayName("Source")]
		/// <summary>Field : "Source" Tipo: "C" Formula: + "[PLANE->AIRSC]"</summary>
		[ShouldSerialize("Fligh.ValNamesc")]
		public string ValNamesc { get { return klass.ValNamesc; } set { klass.ValNamesc = value; } }

		[DisplayName("Flight Pilot")]
		/// <summary>Field : "Flight Pilot" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodpilot")]
		public string ValCodpilot { get { return klass.ValCodpilot; } set { klass.ValCodpilot = value; } }
		private Pilot _pilot;
		[DisplayName("Pilot")]
		[ShouldSerialize("Pilot")]
		public virtual Pilot Pilot {
			get {
				if (!this.isEmptyModel && (_pilot == null || (!string.IsNullOrEmpty(ValCodpilot) && (_pilot.isEmptyModel || _pilot.klass.QPrimaryKey != ValCodpilot))))
					_pilot = Models.Pilot.Find(ValCodpilot, m_userContext, Identifier, _fieldsToSerialize);
				if (_pilot == null)
					_pilot = new Models.Pilot(m_userContext, true, _fieldsToSerialize);
				return _pilot;
			}
			set { _pilot = value; }
		}


		[DisplayName("Flight number identification")]
		/// <summary>Field : "Flight number identification" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValFlighnum")]
		public string ValFlighnum { get { return klass.ValFlighnum; } set { klass.ValFlighnum = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodairln")]
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
		[ShouldSerialize("Fligh.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Fligh(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfligh(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fligh(UserContext userContext, CSGenioAfligh val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAfligh csgenioa)
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
					case "route":
						if (_route == null)
							_route = new Route(m_userContext, true, _fieldsToSerialize);
						_route.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airsc":
						if (_airsc == null)
							_airsc = new Airsc(m_userContext, true, _fieldsToSerialize);
						_airsc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "crew":
						if (_crew == null)
							_crew = new Crew(m_userContext, true, _fieldsToSerialize);
						_crew.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pilot":
						if (_pilot == null)
							_pilot = new Pilot(m_userContext, true, _fieldsToSerialize);
						_pilot.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Fligh Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfligh>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Fligh(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Fligh> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfligh>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Fligh>((r) => new Fligh(userCtx, r));
		}

// USE /[MANUAL PJF MODEL FLIGH]/
	}
}
