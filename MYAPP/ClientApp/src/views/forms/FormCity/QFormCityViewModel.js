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
			name: 'CITY',
			area: 'CITY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CITY'
			}
		})

		/** The primary key. */
		this.ValCodcity = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'CITY',
			field: 'CODCITY',
			description: '',
		}).cloneFrom(values?.ValCodcity))
		watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('city.codcity', this.ValCodcity, newValue, oldValue))

		/** The remaining form fields. */
		this.ValCity = reactive(new modelFieldType.String({
			id: 'ValCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 30,
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCity))
		watch(() => this.ValCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.ValCity, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCityViewModel instance.
	 * @returns {QFormCityViewModel} A new instance of QFormCityViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcity'

	get QPrimaryKey() { return this.ValCodcity.value }
	set QPrimaryKey(value) { this.ValCodcity.updateValue(value) }
}
