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
			name: 'PLANES',
			area: 'PLANE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PLANES'
			}
		})

		/** The primary key. */
		this.ValCodplane = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodplane',
			originId: 'ValCodplane',
			area: 'PLANE',
			field: 'CODPLANE',
			description: '',
		}).cloneFrom(values?.ValCodplane))
		watch(() => this.ValCodplane.value, (newValue, oldValue) => this.onUpdate('plane.codplane', this.ValCodplane, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'PLANE',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('plane.codairln', this.ValCodairln, newValue, oldValue))

		this.ValAircr = reactive(new modelFieldType.ForeignKey({
			id: 'ValAircr',
			originId: 'ValAircr',
			area: 'PLANE',
			field: 'AIRCR',
			relatedArea: 'AIRCR',
			description: computed(() => this.Resources.CURRENT_AIRPORT44954),
		}).cloneFrom(values?.ValAircr))
		watch(() => this.ValAircr.value, (newValue, oldValue) => this.onUpdate('plane.aircr', this.ValAircr, newValue, oldValue))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PLANE',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('plane.photo', this.ValPhoto, newValue, oldValue))

		this.ValId = reactive(new modelFieldType.String({
			id: 'ValId',
			originId: 'ValId',
			area: 'PLANE',
			field: 'ID',
			maxLength: 20,
			description: computed(() => this.Resources.ID48520),
		}).cloneFrom(values?.ValId))
		watch(() => this.ValId.value, (newValue, oldValue) => this.onUpdate('plane.id', this.ValId, newValue, oldValue))

		this.ValModel = reactive(new modelFieldType.String({
			id: 'ValModel',
			originId: 'ValModel',
			area: 'PLANE',
			field: 'MODEL',
			maxLength: 30,
			description: computed(() => this.Resources.MODEL27263),
		}).cloneFrom(values?.ValModel))
		watch(() => this.ValModel.value, (newValue, oldValue) => this.onUpdate('plane.model', this.ValModel, newValue, oldValue))

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

		this.ValEngines = reactive(new modelFieldType.Number({
			id: 'ValEngines',
			originId: 'ValEngines',
			area: 'PLANE',
			field: 'ENGINES',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMBER_OF_ENGINES61894),
		}).cloneFrom(values?.ValEngines))
		watch(() => this.ValEngines.value, (newValue, oldValue) => this.onUpdate('plane.engines', this.ValEngines, newValue, oldValue))

		this.ValManufact = reactive(new modelFieldType.String({
			id: 'ValManufact',
			originId: 'ValManufact',
			area: 'PLANE',
			field: 'MANUFACT',
			maxLength: 30,
			description: computed(() => this.Resources.MANUFACTURER50759),
		}).cloneFrom(values?.ValManufact))
		watch(() => this.ValManufact.value, (newValue, oldValue) => this.onUpdate('plane.manufact', this.ValManufact, newValue, oldValue))

		this.ValCapacity = reactive(new modelFieldType.Number({
			id: 'ValCapacity',
			originId: 'ValCapacity',
			area: 'PLANE',
			field: 'CAPACITY',
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.CAPACITY63181),
		}).cloneFrom(values?.ValCapacity))
		watch(() => this.ValCapacity.value, (newValue, oldValue) => this.onUpdate('plane.capacity', this.ValCapacity, newValue, oldValue))

		this.ValYear = reactive(new modelFieldType.Date({
			id: 'ValYear',
			originId: 'ValYear',
			area: 'PLANE',
			field: 'YEAR',
			description: computed(() => this.Resources.YEAR_OF_MANUFACTURE06704),
		}).cloneFrom(values?.ValYear))
		watch(() => this.ValYear.value, (newValue, oldValue) => this.onUpdate('plane.year', this.ValYear, newValue, oldValue))

		this.ValAge = reactive(new modelFieldType.Number({
			id: 'ValAge',
			originId: 'ValAge',
			area: 'PLANE',
			field: 'AGE',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.AGE28663),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: Year([Today]) - Year([PLANE->YEAR])
					// eslint-disable-next-line eqeqeq
					return qApi.Year(qApi.Hoje())-qApi.Year(this.ValYear.value)
				},
				dependencyEvents: ['fieldChange:plane.year'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyN,
			},
		}).cloneFrom(values?.ValAge))
		watch(() => this.ValAge.value, (newValue, oldValue) => this.onUpdate('plane.age', this.ValAge, newValue, oldValue))

		this.TableAircrName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAircrName',
			originId: 'ValName',
			area: 'AIRCR',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableAircrName))
		watch(() => this.TableAircrName.value, (newValue, oldValue) => this.onUpdate('aircr.name', this.TableAircrName, newValue, oldValue))

		this.ValStatus = reactive(new modelFieldType.String({
			id: 'ValStatus',
			originId: 'ValStatus',
			area: 'PLANE',
			field: 'STATUS',
			arrayOptions: qProjArrays.QArrayStatus.setResources(vm.$getResource).elements,
			maxLength: 9,
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.ValStatus))
		watch(() => this.ValStatus.value, (newValue, oldValue) => this.onUpdate('plane.status', this.ValStatus, newValue, oldValue))

		this.ValMaint = reactive(new modelFieldType.Number({
			id: 'ValMaint',
			originId: 'ValMaint',
			area: 'PLANE',
			field: 'MAINT',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.STATUS_OF_MAINTENANC40849),
			isFixed: true,
		}).cloneFrom(values?.ValMaint))
		watch(() => this.ValMaint.value, (newValue, oldValue) => this.onUpdate('plane.maint', this.ValMaint, newValue, oldValue))

		this.ValIsmaint = reactive(new modelFieldType.Boolean({
			id: 'ValIsmaint',
			originId: 'ValIsmaint',
			area: 'PLANE',
			field: 'ISMAINT',
			description: computed(() => this.Resources.IS_MAINT27685),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif([PLANE->MAINT] > 0, 1, 0)
					// eslint-disable-next-line eqeqeq
					return qApi.iif(this.ValMaint.value>0,1,0)
				},
				dependencyEvents: ['fieldChange:plane.maint'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyL,
			},
		}).cloneFrom(values?.ValIsmaint))
		watch(() => this.ValIsmaint.value, (newValue, oldValue) => this.onUpdate('plane.ismaint', this.ValIsmaint, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPlanesViewModel instance.
	 * @returns {QFormPlanesViewModel} A new instance of QFormPlanesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodplane'

	get QPrimaryKey() { return this.ValCodplane.value }
	set QPrimaryKey(value) { this.ValCodplane.updateValue(value) }
}
