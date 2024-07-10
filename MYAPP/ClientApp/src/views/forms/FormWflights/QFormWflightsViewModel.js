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
			name: 'WFLIGHTS',
			area: 'FLIGH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_WFLIGHTS'
			}
		})

		/** The primary key. */
		this.ValCodfligh = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfligh',
			originId: 'ValCodfligh',
			area: 'FLIGH',
			field: 'CODFLIGH',
			description: '',
		}).cloneFrom(values?.ValCodfligh))
		watch(() => this.ValCodfligh.value, (newValue, oldValue) => this.onUpdate('fligh.codfligh', this.ValCodfligh, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodplane = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodplane',
			originId: 'ValCodplane',
			area: 'FLIGH',
			field: 'CODPLANE',
			relatedArea: 'PLANE',
			description: computed(() => this.Resources.AIRCRAFT03780),
			isFixed: true,
			isUnique: true,
		}).cloneFrom(values?.ValCodplane))
		watch(() => this.ValCodplane.value, (newValue, oldValue) => this.onUpdate('fligh.codplane', this.ValCodplane, newValue, oldValue))

		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'FLIGH',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('fligh.codairln', this.ValCodairln, newValue, oldValue))

		this.ValCodsourc = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodsourc',
			originId: 'ValCodsourc',
			area: 'FLIGH',
			field: 'CODSOURC',
			relatedArea: 'AIRSC',
			description: computed(() => this.Resources.SOURCE49690),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:fligh.codplane'],
				isServerRecalc: true,
				isServerFormula: false,
				isEmpty: qApi.emptyG,
			},
		}).cloneFrom(values?.ValCodsourc))
		watch(() => this.ValCodsourc.value, (newValue, oldValue) => this.onUpdate('fligh.codsourc', this.ValCodsourc, newValue, oldValue))

		this.ValCodcrew = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcrew',
			originId: 'ValCodcrew',
			area: 'FLIGH',
			field: 'CODCREW',
			relatedArea: 'CREW',
			description: computed(() => this.Resources.FLIGHTS_CABIN_CREW40365),
			isFixed: true,
		}).cloneFrom(values?.ValCodcrew))
		watch(() => this.ValCodcrew.value, (newValue, oldValue) => this.onUpdate('fligh.codcrew', this.ValCodcrew, newValue, oldValue))

		this.ValCodpilot = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpilot',
			originId: 'ValCodpilot',
			area: 'FLIGH',
			field: 'CODPILOT',
			relatedArea: 'PILOT',
			description: computed(() => this.Resources.FLIGHT_PILOT12997),
			isFixed: true,
		}).cloneFrom(values?.ValCodpilot))
		watch(() => this.ValCodpilot.value, (newValue, oldValue) => this.onUpdate('fligh.codpilot', this.ValCodpilot, newValue, oldValue))

		this.ValCodroute = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodroute',
			originId: 'ValCodroute',
			area: 'FLIGH',
			field: 'CODROUTE',
			relatedArea: 'ROUTE',
			description: computed(() => this.Resources.ROUTE59240),
			isFixed: true,
		}).cloneFrom(values?.ValCodroute))
		watch(() => this.ValCodroute.value, (newValue, oldValue) => this.onUpdate('fligh.codroute', this.ValCodroute, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValFlighnum = reactive(new modelFieldType.String({
			id: 'ValFlighnum',
			originId: 'ValFlighnum',
			area: 'FLIGH',
			field: 'FLIGHNUM',
			maxLength: 15,
			description: computed(() => this.Resources.FLIGHT_NUMBER_IDENTI52250),
			isFixed: true,
		}).cloneFrom(values?.ValFlighnum))
		watch(() => this.ValFlighnum.value, (newValue, oldValue) => this.onUpdate('fligh.flighnum', this.ValFlighnum, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormWflightsViewModel instance.
	 * @returns {QFormWflightsViewModel} A new instance of QFormWflightsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfligh'

	get QPrimaryKey() { return this.ValCodfligh.value }
	set QPrimaryKey(value) { this.ValCodfligh.updateValue(value) }
}
