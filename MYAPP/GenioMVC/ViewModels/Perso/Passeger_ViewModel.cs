using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Perso
{
	public class Passeger_ViewModel : FormViewModel<Models.Perso>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys

		#endregion
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "ID" | Type: "IB"
		/// </summary>
		[Document("ValId", false, false, false, false, DocumentViewTypeMode.Preview)]
		public string ValId { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValIdfk { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValIdPropertiesVM { get; set; }
		/// <summary>
		/// Title: "Nationality" | Type: "C"
		/// </summary>
		public string ValNatio { get; set; }
		/// <summary>
		/// Title: "Mobile contact" | Type: "C"
		/// </summary>
		public string ValPhone { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodperso { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Passeger_ViewModel() : base(null!) { }

		public Passeger_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPASSEGER", nestedForm) { }

		public Passeger_ViewModel(UserContext userContext, Models.Perso row, bool nestedForm = false) : base(userContext, "FPASSEGER", row, nestedForm) { }

		public Passeger_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("perso", id);
			Model = Models.Perso.Find(id, userContext, "FPASSEGER", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_10;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_90;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Perso model = new Models.Perso(userContext) { Identifier = "FPASSEGER" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPASSEGER");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Perso model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Perso) to ViewModel (Passeger) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValId = ViewModelConversion.ToString(m.ValId);
				ValIdfk = ViewModelConversion.ToString(m.ValIdfk);
				ValNatio = ViewModelConversion.ToString(m.ValNatio);
				ValPhone = ViewModelConversion.ToString(m.ValPhone);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Perso) to ViewModel (Passeger) - Error during mapping");
				throw;
			}
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <param name="m">The Model to be filled.</param>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Passeger) to Model (Perso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValId = ViewModelConversion.ToString(ValId);
				m.ValIdfk = ViewModelConversion.ToString(ValIdfk);
				m.ValNatio = ViewModelConversion.ToString(ValNatio);
				m.ValPhone = ViewModelConversion.ToString(ValPhone);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Passeger) to Model (Perso) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "perso.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "perso.id":
						this.ValId = ViewModelConversion.ToString(_value);
						break;
					case "perso.natio":
						this.ValNatio = ViewModelConversion.ToString(_value);
						break;
					case "perso.phone":
						this.ValPhone = ViewModelConversion.ToString(_value);
						break;
					case "perso.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "perso.codperso":
						this.ValCodperso = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Passeger) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Passeger)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Perso.Find(id ?? Navigation.GetStrValue("perso"), m_userContext, "FPASSEGER"); }
			finally { Model ??= new Models.Perso(m_userContext) { Identifier = "FPASSEGER" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Perso.Find(Navigation.GetStrValue("perso"), m_userContext, "FPASSEGER");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FPASSEGER";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Perso row)
		{
			try
			{
				ValIdPropertiesVM = row.GetInfoDoc("ValId");
			}
			catch (Exception)
			{
				ValIdPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
			}
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Perso.Find(Navigation.GetStrValue("perso"), m_userContext, "FPASSEGER");
				if (Model == null)
				{
					Model = new Models.Perso(m_userContext) { Identifier = "FPASSEGER" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("perso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL PJF VIEWMODEL_LOADPARTIAL PASSEGER]/
		}

// USE /[MANUAL PJF VIEWMODEL_NEW PASSEGER]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 25);
			validator.StringLength("ValNatio", Resources.Resources.NATIONALITY34787, ValNatio, 30);
			validator.StringLength("ValPhone", Resources.Resources.MOBILE_CONTACT62789, ValPhone, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL25170, ValEmail, 30);

			return validator.GetResult();
		}

// USE /[MANUAL PJF VIEWMODEL_SAVE PASSEGER]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PJF VIEWMODEL_APPLY PASSEGER]/

// USE /[MANUAL PJF VIEWMODEL_DUPLICATE PASSEGER]/

// USE /[MANUAL PJF VIEWMODEL_DESTROY PASSEGER]/
		public override void Destroy(string id)
		{
			Model = Models.Perso.Find(id, m_userContext, "FPASSEGER");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"perso.name" => ViewModelConversion.ToString(modelValue),
				"perso.id" => ViewModelConversion.ToString(modelValue),
				"perso.natio" => ViewModelConversion.ToString(modelValue),
				"perso.phone" => ViewModelConversion.ToString(modelValue),
				"perso.email" => ViewModelConversion.ToString(modelValue),
				"perso.codperso" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PJF VIEWMODEL_CUSTOM PASSEGER]/

		#endregion
	}
}
