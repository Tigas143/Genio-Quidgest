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
	public class Perso : ModelBase
	{
		[JsonIgnore]
		public CSGenioAperso klass { get { return baseklass as CSGenioAperso; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValCodperso")]
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("ID")]
		/// <summary>Field : "ID" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValId")]
		[Document("ValId", false, false, false, false)]
		public string ValId { get { return klass.ValId; } set { klass.ValId = value; } }
		public string ValIdfk { get { return klass.ValIdfk; } set { klass.ValIdfk = value; } }

		[DisplayName("Nationality")]
		/// <summary>Field : "Nationality" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValNatio")]
		public string ValNatio { get { return klass.ValNatio; } set { klass.ValNatio = value; } }

		[DisplayName("Mobile contact")]
		/// <summary>Field : "Mobile contact" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValPhone")]
		public string ValPhone { get { return klass.ValPhone; } set { klass.ValPhone = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Perso.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Perso(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAperso(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Perso(UserContext userContext, CSGenioAperso val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAperso csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Perso Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAperso>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Perso(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Perso> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAperso>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Perso>((r) => new Perso(userCtx, r));
		}

// USE /[MANUAL PJF MODEL PERSO]/
	}
}
