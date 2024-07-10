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
			name: 'WPLANE',
			area: 'PLANE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_WPLANE'
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

		/** The hidden foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'PLANE',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('plane.codairln', this.ValCodairln, newValue, oldValue))

		this.ValAircr = reactive(new modelFieldType.ForeignKey({
			id: 'ValAircr',
			originId: 'ValAircr',
			area: 'PLANE',
			field: 'AIRCR',
			relatedArea: 'AIRCR',
			description: computed(() => this.Resources.CURRENT_AIRPORT44954),
			isFixed: true,
		}).cloneFrom(values?.ValAircr))
		watch(() => this.ValAircr.value, (newValue, oldValue) => this.onUpdate('plane.aircr', this.ValAircr, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValModel = reactive(new modelFieldType.String({
			id: 'ValModel',
			originId: 'ValModel',
			area: 'PLANE',
			field: 'MODEL',
			maxLength: 30,
			description: computed(() => this.Resources.MODEL27263),
			isFixed: true,
		}).cloneFrom(values?.ValModel))
		watch(() => this.ValModel.value, (newValue, oldValue) => this.onUpdate('plane.model', this.ValModel, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormWplaneViewModel instance.
	 * @returns {QFormWplaneViewModel} A new instance of QFormWplaneViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodplane'

	get QPrimaryKey() { return this.ValCodplane.value }
	set QPrimaryKey(value) { this.ValCodplane.updateValue(value) }
}
