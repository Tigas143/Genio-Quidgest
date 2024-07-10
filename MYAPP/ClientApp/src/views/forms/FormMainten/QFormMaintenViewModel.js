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
			name: 'MAINTEN',
			area: 'MAINT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_MAINTEN'
			}
		})

		/** The primary key. */
		this.ValCodmaint = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmaint',
			originId: 'ValCodmaint',
			area: 'MAINT',
			field: 'CODMAINT',
			description: '',
		}).cloneFrom(values?.ValCodmaint))
		watch(() => this.ValCodmaint.value, (newValue, oldValue) => this.onUpdate('maint.codmaint', this.ValCodmaint, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'MAINT',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('maint.codairln', this.ValCodairln, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodplane = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodplane',
			originId: 'ValCodplane',
			area: 'MAINT',
			field: 'CODPLANE',
			relatedArea: 'PLANE',
			description: computed(() => this.Resources.AIRCRAFT03780),
		}).cloneFrom(values?.ValCodplane))
		watch(() => this.ValCodplane.value, (newValue, oldValue) => this.onUpdate('maint.codplane', this.ValCodplane, newValue, oldValue))

		/** The remaining form fields. */
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

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'MAINT',
			field: 'DATE',
			description: computed(() => this.Resources.MAINTANACE_VALID_UNT17315),
		}).cloneFrom(values?.ValDate))
		watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('maint.date', this.ValDate, newValue, oldValue))

		this.ValStatus = reactive(new modelFieldType.Number({
			id: 'ValStatus',
			originId: 'ValStatus',
			area: 'MAINT',
			field: 'STATUS',
			arrayOptions: qProjArrays.QArrayStatusm.setResources(vm.$getResource).elements,
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.ValStatus))
		watch(() => this.ValStatus.value, (newValue, oldValue) => this.onUpdate('maint.status', this.ValStatus, newValue, oldValue))

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
	 * Creates a clone of the current QFormMaintenViewModel instance.
	 * @returns {QFormMaintenViewModel} A new instance of QFormMaintenViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmaint'

	get QPrimaryKey() { return this.ValCodmaint.value }
	set QPrimaryKey(value) { this.ValCodmaint.updateValue(value) }
}
