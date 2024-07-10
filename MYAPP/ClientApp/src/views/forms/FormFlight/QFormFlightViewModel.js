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
			name: 'FLIGHT',
			area: 'FLIGH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FLIGHT'
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

		/** The used foreign keys. */
		this.ValCodplane = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodplane',
			originId: 'ValCodplane',
			area: 'FLIGH',
			field: 'CODPLANE',
			relatedArea: 'PLANE',
			description: computed(() => this.Resources.AIRCRAFT03780),
			isUnique: true,
		}).cloneFrom(values?.ValCodplane))
		watch(() => this.ValCodplane.value, (newValue, oldValue) => this.onUpdate('fligh.codplane', this.ValCodplane, newValue, oldValue))

		this.ValCodroute = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodroute',
			originId: 'ValCodroute',
			area: 'FLIGH',
			field: 'CODROUTE',
			relatedArea: 'ROUTE',
			description: computed(() => this.Resources.ROUTE59240),
		}).cloneFrom(values?.ValCodroute))
		watch(() => this.ValCodroute.value, (newValue, oldValue) => this.onUpdate('fligh.codroute', this.ValCodroute, newValue, oldValue))

		this.ValCodcrew = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcrew',
			originId: 'ValCodcrew',
			area: 'FLIGH',
			field: 'CODCREW',
			relatedArea: 'CREW',
			description: computed(() => this.Resources.FLIGHTS_CABIN_CREW40365),
		}).cloneFrom(values?.ValCodcrew))
		watch(() => this.ValCodcrew.value, (newValue, oldValue) => this.onUpdate('fligh.codcrew', this.ValCodcrew, newValue, oldValue))

		this.ValCodpilot = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpilot',
			originId: 'ValCodpilot',
			area: 'FLIGH',
			field: 'CODPILOT',
			relatedArea: 'PILOT',
			description: computed(() => this.Resources.FLIGHT_PILOT12997),
		}).cloneFrom(values?.ValCodpilot))
		watch(() => this.ValCodpilot.value, (newValue, oldValue) => this.onUpdate('fligh.codpilot', this.ValCodpilot, newValue, oldValue))

		/** The remaining form fields. */
		this.ValFlighnum = reactive(new modelFieldType.String({
			id: 'ValFlighnum',
			originId: 'ValFlighnum',
			area: 'FLIGH',
			field: 'FLIGHNUM',
			maxLength: 15,
			description: computed(() => this.Resources.FLIGHT_NUMBER_IDENTI52250),
		}).cloneFrom(values?.ValFlighnum))
		watch(() => this.ValFlighnum.value, (newValue, oldValue) => this.onUpdate('fligh.flighnum', this.ValFlighnum, newValue, oldValue))

		this.TablePlaneModel = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePlaneModel',
			originId: 'ValModel',
			area: 'PLANE',
			field: 'MODEL',
			maxLength: 30,
			description: computed(() => this.Resources.MODEL27263),
		}).cloneFrom(values?.TablePlaneModel))
		watch(() => this.TablePlaneModel.value, (newValue, oldValue) => this.onUpdate('plane.model', this.TablePlaneModel, newValue, oldValue))

		this.TableRouteName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRouteName',
			originId: 'ValName',
			area: 'ROUTE',
			field: 'NAME',
			maxLength: 10,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableRouteName))
		watch(() => this.TableRouteName.value, (newValue, oldValue) => this.onUpdate('route.name', this.TableRouteName, newValue, oldValue))

		this.ValDepart = reactive(new modelFieldType.DateTime({
			id: 'ValDepart',
			originId: 'ValDepart',
			area: 'FLIGH',
			field: 'DEPART',
			description: computed(() => this.Resources.DEPARTURE11999),
		}).cloneFrom(values?.ValDepart))
		watch(() => this.ValDepart.value, (newValue, oldValue) => this.onUpdate('fligh.depart', this.ValDepart, newValue, oldValue))

		this.ValArrival = reactive(new modelFieldType.DateTime({
			id: 'ValArrival',
			originId: 'ValArrival',
			area: 'FLIGH',
			field: 'ARRIVAL',
			description: computed(() => this.Resources.ARRIVAL52302),
		}).cloneFrom(values?.ValArrival))
		watch(() => this.ValArrival.value, (newValue, oldValue) => this.onUpdate('fligh.arrival', this.ValArrival, newValue, oldValue))

		this.ValDuration = reactive(new modelFieldType.Number({
			id: 'ValDuration',
			originId: 'ValDuration',
			area: 'FLIGH',
			field: 'DURATION',
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.DURACAO00266),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: DateDiffPart([FLIGH->DEPART],[FLIGH->ARRIVAL],"H")
					// eslint-disable-next-line eqeqeq
					return qApi.DateDiffPart(this.ValDepart.value,this.ValArrival.value,"H")
				},
				dependencyEvents: ['fieldChange:fligh.depart', 'fieldChange:fligh.arrival'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyN,
			},
		}).cloneFrom(values?.ValDuration))
		watch(() => this.ValDuration.value, (newValue, oldValue) => this.onUpdate('fligh.duration', this.ValDuration, newValue, oldValue))

		this.ValNamesc = reactive(new modelFieldType.String({
			id: 'ValNamesc',
			originId: 'ValNamesc',
			area: 'FLIGH',
			field: 'NAMESC',
			maxLength: 20,
			description: computed(() => this.Resources.SOURCE49690),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [PLANE->AIRSC]
					// eslint-disable-next-line eqeqeq
					return this.PlaneValAirsc.value
				},
				dependencyEvents: ['fieldChange:plane.airsc'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyC,
			},
		}).cloneFrom(values?.ValNamesc))
		watch(() => this.ValNamesc.value, (newValue, oldValue) => this.onUpdate('fligh.namesc', this.ValNamesc, newValue, oldValue))

		this.TableCrewCrewname = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCrewCrewname',
			originId: 'ValCrewname',
			area: 'CREW',
			field: 'CREWNAME',
			maxLength: 20,
			description: computed(() => this.Resources.CREW_NAME06457),
		}).cloneFrom(values?.TableCrewCrewname))
		watch(() => this.TableCrewCrewname.value, (newValue, oldValue) => this.onUpdate('crew.crewname', this.TableCrewCrewname, newValue, oldValue))

		this.TablePilotName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePilotName',
			originId: 'ValName',
			area: 'PILOT',
			field: 'NAME',
			maxLength: 10,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePilotName))
		watch(() => this.TablePilotName.value, (newValue, oldValue) => this.onUpdate('pilot.name', this.TablePilotName, newValue, oldValue))

		this.PlaneValAirsc = reactive(new modelFieldType.String({
			id: 'PlaneValAirsc',
			originId: 'ValAirsc',
			area: 'PLANE',
			field: 'AIRSC',
			maxLength: 20,
			description: '',
			isFixed: true,
		}).cloneFrom(values?.PlaneValAirsc))
		watch(() => this.PlaneValAirsc.value, (newValue, oldValue) => this.onUpdate('plane.airsc', this.PlaneValAirsc, newValue, oldValue))

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
	 * Creates a clone of the current QFormFlightViewModel instance.
	 * @returns {QFormFlightViewModel} A new instance of QFormFlightViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfligh'

	get QPrimaryKey() { return this.ValCodfligh.value }
	set QPrimaryKey(value) { this.ValCodfligh.updateValue(value) }
}
