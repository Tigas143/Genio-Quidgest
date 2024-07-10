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
			name: 'AIRLN',
			area: 'AIRLN',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_AIRLN'
			}
		})

		/** The primary key. */
		this.ValCodairln = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'AIRLN',
			field: 'CODAIRLN',
			description: '',
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('airln.codairln', this.ValCodairln, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcity = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'AIRLN',
			field: 'CODCITY',
			relatedArea: 'CITY',
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCodcity))
		watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('airln.codcity', this.ValCodcity, newValue, oldValue))

		this.ValCodairhb = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairhb',
			originId: 'ValCodairhb',
			area: 'AIRLN',
			field: 'CODAIRHB',
			relatedArea: 'AIRHB',
			description: computed(() => this.Resources.AIRLINE_HUB55930),
		}).cloneFrom(values?.ValCodairhb))
		watch(() => this.ValCodairhb.value, (newValue, oldValue) => this.onUpdate('airln.codairhb', this.ValCodairhb, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'AIRLN',
			field: 'NAME',
			maxLength: 9,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('airln.name', this.ValName, newValue, oldValue))

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

		this.TableAirhbName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAirhbName',
			originId: 'ValName',
			area: 'AIRHB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableAirhbName))
		watch(() => this.TableAirhbName.value, (newValue, oldValue) => this.onUpdate('airhb.name', this.TableAirhbName, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAirlnViewModel instance.
	 * @returns {QFormAirlnViewModel} A new instance of QFormAirlnViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodairln'

	get QPrimaryKey() { return this.ValCodairln.value }
	set QPrimaryKey(value) { this.ValCodairln.updateValue(value) }
}
