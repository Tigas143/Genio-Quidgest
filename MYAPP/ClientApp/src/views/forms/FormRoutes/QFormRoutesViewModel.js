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
			name: 'ROUTES',
			area: 'ROUTE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ROUTES'
			}
		})

		/** The primary key. */
		this.ValCodroute = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodroute',
			originId: 'ValCodroute',
			area: 'ROUTE',
			field: 'CODROUTE',
			description: '',
		}).cloneFrom(values?.ValCodroute))
		watch(() => this.ValCodroute.value, (newValue, oldValue) => this.onUpdate('route.codroute', this.ValCodroute, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'ROUTE',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('route.codairln', this.ValCodairln, newValue, oldValue))

		this.ValAirsc = reactive(new modelFieldType.ForeignKey({
			id: 'ValAirsc',
			originId: 'ValAirsc',
			area: 'ROUTE',
			field: 'AIRSC',
			relatedArea: 'AIRSC',
			description: '',
		}).cloneFrom(values?.ValAirsc))
		watch(() => this.ValAirsc.value, (newValue, oldValue) => this.onUpdate('route.airsc', this.ValAirsc, newValue, oldValue))

		this.ValAirds = reactive(new modelFieldType.ForeignKey({
			id: 'ValAirds',
			originId: 'ValAirds',
			area: 'ROUTE',
			field: 'AIRDS',
			relatedArea: 'AIRDS',
			description: '',
		}).cloneFrom(values?.ValAirds))
		watch(() => this.ValAirds.value, (newValue, oldValue) => this.onUpdate('route.airds', this.ValAirds, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ROUTE',
			field: 'NAME',
			maxLength: 10,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('route.name', this.ValName, newValue, oldValue))

		this.TableAirlnName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAirlnName',
			originId: 'ValName',
			area: 'AIRLN',
			field: 'NAME',
			maxLength: 9,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableAirlnName))
		watch(() => this.TableAirlnName.value, (newValue, oldValue) => this.onUpdate('airln.name', this.TableAirlnName, newValue, oldValue))

		this.TableAirscName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAirscName',
			originId: 'ValName',
			area: 'AIRSC',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableAirscName))
		watch(() => this.TableAirscName.value, (newValue, oldValue) => this.onUpdate('airsc.name', this.TableAirscName, newValue, oldValue))

		this.TableAirdsName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAirdsName',
			originId: 'ValName',
			area: 'AIRDS',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableAirdsName))
		watch(() => this.TableAirdsName.value, (newValue, oldValue) => this.onUpdate('airds.name', this.TableAirdsName, newValue, oldValue))

		this.ValDuration = reactive(new modelFieldType.Time({
			id: 'ValDuration',
			originId: 'ValDuration',
			area: 'ROUTE',
			field: 'DURATION',
			description: computed(() => this.Resources.ESTIMATED_DURATION09591),
		}).cloneFrom(values?.ValDuration))
		watch(() => this.ValDuration.value, (newValue, oldValue) => this.onUpdate('route.duration', this.ValDuration, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRoutesViewModel instance.
	 * @returns {QFormRoutesViewModel} A new instance of QFormRoutesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodroute'

	get QPrimaryKey() { return this.ValCodroute.value }
	set QPrimaryKey(value) { this.ValCodroute.updateValue(value) }
}
