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
			name: 'BOOKING',
			area: 'BOOKG',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_BOOKING'
			}
		})

		/** The primary key. */
		this.ValCodbookg = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodbookg',
			originId: 'ValCodbookg',
			area: 'BOOKG',
			field: 'CODBOOKG',
			description: '',
		}).cloneFrom(values?.ValCodbookg))
		watch(() => this.ValCodbookg.value, (newValue, oldValue) => this.onUpdate('bookg.codbookg', this.ValCodbookg, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'BOOKG',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('bookg.codairln', this.ValCodairln, newValue, oldValue))

		/** The used foreign keys. */
		this.ValFlight = reactive(new modelFieldType.ForeignKey({
			id: 'ValFlight',
			originId: 'ValFlight',
			area: 'BOOKG',
			field: 'FLIGHT',
			relatedArea: 'FLIGH',
			description: computed(() => this.Resources.FLIGHT55228),
		}).cloneFrom(values?.ValFlight))
		watch(() => this.ValFlight.value, (newValue, oldValue) => this.onUpdate('bookg.flight', this.ValFlight, newValue, oldValue))

		this.ValCodpasgr = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpasgr',
			originId: 'ValCodpasgr',
			area: 'BOOKG',
			field: 'CODPASGR',
			relatedArea: 'PERSO',
			description: computed(() => this.Resources.PASSENGER_OF_THE_FLI48568),
		}).cloneFrom(values?.ValCodpasgr))
		watch(() => this.ValCodpasgr.value, (newValue, oldValue) => this.onUpdate('bookg.codpasgr', this.ValCodpasgr, newValue, oldValue))

		/** The remaining form fields. */
		this.ValBnum = reactive(new modelFieldType.String({
			id: 'ValBnum',
			originId: 'ValBnum',
			area: 'BOOKG',
			field: 'BNUM',
			maxLength: 20,
			description: computed(() => this.Resources.BOOKING_NUMBER35241),
		}).cloneFrom(values?.ValBnum))
		watch(() => this.ValBnum.value, (newValue, oldValue) => this.onUpdate('bookg.bnum', this.ValBnum, newValue, oldValue))

		this.TableFlighFlighnum = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFlighFlighnum',
			originId: 'ValFlighnum',
			area: 'FLIGH',
			field: 'FLIGHNUM',
			maxLength: 15,
			description: computed(() => this.Resources.FLIGHT_NUMBER_IDENTI52250),
		}).cloneFrom(values?.TableFlighFlighnum))
		watch(() => this.TableFlighFlighnum.value, (newValue, oldValue) => this.onUpdate('fligh.flighnum', this.TableFlighFlighnum, newValue, oldValue))

		this.ValPrice = reactive(new modelFieldType.String({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'BOOKG',
			field: 'PRICE',
			maxLength: 30,
			description: computed(() => this.Resources.PRICE06900),
		}).cloneFrom(values?.ValPrice))
		watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('bookg.price', this.ValPrice, newValue, oldValue))

		this.TablePersoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePersoName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 25,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePersoName))
		watch(() => this.TablePersoName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.TablePersoName, newValue, oldValue))

		this.AirlnValName = reactive(new modelFieldType.String({
			id: 'AirlnValName',
			originId: 'ValName',
			area: 'AIRLN',
			field: 'NAME',
			maxLength: 9,
			description: computed(() => this.Resources.NAME31974),
			isFixed: true,
		}).cloneFrom(values?.AirlnValName))
		watch(() => this.AirlnValName.value, (newValue, oldValue) => this.onUpdate('airln.name', this.AirlnValName, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormBookingViewModel instance.
	 * @returns {QFormBookingViewModel} A new instance of QFormBookingViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodbookg'

	get QPrimaryKey() { return this.ValCodbookg.value }
	set QPrimaryKey(value) { this.ValCodbookg.updateValue(value) }
}
