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
			name: 'PILOT',
			area: 'PILOT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PILOT'
			}
		})

		/** The primary key. */
		this.ValCodpilot = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpilot',
			originId: 'ValCodpilot',
			area: 'PILOT',
			field: 'CODPILOT',
			description: '',
		}).cloneFrom(values?.ValCodpilot))
		watch(() => this.ValCodpilot.value, (newValue, oldValue) => this.onUpdate('pilot.codpilot', this.ValCodpilot, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'PILOT',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('pilot.codairln', this.ValCodairln, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PILOT',
			field: 'NAME',
			maxLength: 10,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('pilot.name', this.ValName, newValue, oldValue))

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

		this.ValLicense = reactive(new modelFieldType.String({
			id: 'ValLicense',
			originId: 'ValLicense',
			area: 'PILOT',
			field: 'LICENSE',
			maxLength: 30,
			description: computed(() => this.Resources.LICENSE_NUMBER26109),
		}).cloneFrom(values?.ValLicense))
		watch(() => this.ValLicense.value, (newValue, oldValue) => this.onUpdate('pilot.license', this.ValLicense, newValue, oldValue))

		this.ValExperien = reactive(new modelFieldType.Number({
			id: 'ValExperien',
			originId: 'ValExperien',
			area: 'PILOT',
			field: 'EXPERIEN',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEARS_OF_EXPERIENCE63548),
		}).cloneFrom(values?.ValExperien))
		watch(() => this.ValExperien.value, (newValue, oldValue) => this.onUpdate('pilot.experien', this.ValExperien, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPilotViewModel instance.
	 * @returns {QFormPilotViewModel} A new instance of QFormPilotViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpilot'

	get QPrimaryKey() { return this.ValCodpilot.value }
	set QPrimaryKey(value) { this.ValCodpilot.updateValue(value) }
}
