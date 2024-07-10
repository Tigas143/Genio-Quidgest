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
			name: 'AIRPORTS',
			area: 'AIRPT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_AIRPORTS'
			}
		})

		/** The primary key. */
		this.ValCodairpt = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodairpt',
			originId: 'ValCodairpt',
			area: 'AIRPT',
			field: 'CODAIRPT',
			description: '',
		}).cloneFrom(values?.ValCodairpt))
		watch(() => this.ValCodairpt.value, (newValue, oldValue) => this.onUpdate('airpt.codairpt', this.ValCodairpt, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcity = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'AIRPT',
			field: 'CODCITY',
			relatedArea: 'CITY',
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCodcity))
		watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('airpt.codcity', this.ValCodcity, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'AIRPT',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('airpt.name', this.ValName, newValue, oldValue))

		this.TableCityCity = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCityCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 30,
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.TableCityCity))
		watch(() => this.TableCityCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.TableCityCity, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAirportsViewModel instance.
	 * @returns {QFormAirportsViewModel} A new instance of QFormAirportsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodairpt'

	get QPrimaryKey() { return this.ValCodairpt.value }
	set QPrimaryKey(value) { this.ValCodairpt.updateValue(value) }
}
