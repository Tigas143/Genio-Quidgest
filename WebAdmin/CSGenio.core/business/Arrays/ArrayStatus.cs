﻿using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array STATUS (Status)
	/// </summary>
	public class ArrayStatus : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayStatus _instance = new ArrayStatus();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayStatus Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Active
		/// </summary>
		public const string E_A_1 = "A";
		/// <summary>
		/// Inactive
		/// </summary>
		public const string E_I_2 = "I";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayStatus"/> class from being created.
		/// </summary>
		private ArrayStatus() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_A_1, new ArrayElement() { ResourceId = "ACTIVE03270", HelpId = "", Group = "" } },
				{ E_I_2, new ArrayElement() { ResourceId = "INACTIVE23138", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
