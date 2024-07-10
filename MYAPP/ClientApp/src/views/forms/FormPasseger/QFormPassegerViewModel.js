/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@/api/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends ViewModelBase
 */
export default class ViewModel extends ViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line no-unused-vars
		const vm = this.vueContext

		/** The view model metadata */
		_merge(this.modelInfo, {
			name: 'PASSEGER',
			area: 'PERSO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PASSEGER'
			}
		})

		/** The primary key. */
		this.ValCodperso = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodperso',
			originId: 'ValCodperso',
			area: 'PERSO',
			field: 'CODPERSO',
			description: '',
		}).cloneFrom(values?.ValCodperso))
		watch(() => this.ValCodperso.value, (newValue, oldValue) => this.onUpdate('perso.codperso', this.ValCodperso, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 25,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.ValName, newValue, oldValue))

		this.ValId = reactive(new modelFieldType.Document({
			id: 'ValId',
			originId: 'ValId',
			area: 'PERSO',
			field: 'ID',
			properties: computed(() => this.ValIdPropertiesVM),
			documentFK: computed(() => this.ValIdfk),
			description: computed(() => this.Resources.ID48520),
		}).cloneFrom(values?.ValId))
		watch(() => this.ValId.value, (newValue, oldValue) => this.onUpdate('perso.id', this.ValId, newValue, oldValue))

		this.ValIdPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValIdPropertiesVM',
			area: 'PERSO',
			field: 'IDDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValIdPropertiesVM))
		this.ValIdfk = reactive(new modelFieldType.Base({
			id: 'ValIdfk',
			area: 'PERSO',
			field: 'IDFK'
		}).cloneFrom(values?.ValIdfk))
		watch(() => this.ValIdfk.value, (newValue, oldValue) => this.onUpdate('perso.idfk', this.ValIdfk, newValue, oldValue))

		this.ValNatio = reactive(new modelFieldType.String({
			id: 'ValNatio',
			originId: 'ValNatio',
			area: 'PERSO',
			field: 'NATIO',
			maxLength: 30,
			description: computed(() => this.Resources.NATIONALITY34787),
		}).cloneFrom(values?.ValNatio))
		watch(() => this.ValNatio.value, (newValue, oldValue) => this.onUpdate('perso.natio', this.ValNatio, newValue, oldValue))

		this.ValPhone = reactive(new modelFieldType.String({
			id: 'ValPhone',
			originId: 'ValPhone',
			area: 'PERSO',
			field: 'PHONE',
			maxLength: 20,
			description: computed(() => this.Resources.MOBILE_CONTACT62789),
		}).cloneFrom(values?.ValPhone))
		watch(() => this.ValPhone.value, (newValue, oldValue) => this.onUpdate('perso.phone', this.ValPhone, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PERSO',
			field: 'EMAIL',
			maxLength: 30,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('perso.email', this.ValEmail, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPassegerViewModel instance.
	 * @returns {QFormPassegerViewModel} A new instance of QFormPassegerViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodperso'

	get QPrimaryKey() { return this.ValCodperso.value }
	set QPrimaryKey(value) { this.ValCodperso.updateValue(value) }
}
