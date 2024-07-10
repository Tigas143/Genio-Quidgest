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
			name: 'CREW',
			area: 'CREW',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CREW'
			}
		})

		/** The primary key. */
		this.ValCodcrew = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcrew',
			originId: 'ValCodcrew',
			area: 'CREW',
			field: 'CODCREW',
			description: '',
		}).cloneFrom(values?.ValCodcrew))
		watch(() => this.ValCodcrew.value, (newValue, oldValue) => this.onUpdate('crew.codcrew', this.ValCodcrew, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'CREW',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('crew.codairln', this.ValCodairln, newValue, oldValue))

		/** The remaining form fields. */
		this.ValCrewname = reactive(new modelFieldType.String({
			id: 'ValCrewname',
			originId: 'ValCrewname',
			area: 'CREW',
			field: 'CREWNAME',
			maxLength: 20,
			description: computed(() => this.Resources.CREW_NAME06457),
		}).cloneFrom(values?.ValCrewname))
		watch(() => this.ValCrewname.value, (newValue, oldValue) => this.onUpdate('crew.crewname', this.ValCrewname, newValue, oldValue))

		this.ValCount = reactive(new modelFieldType.Number({
			id: 'ValCount',
			originId: 'ValCount',
			area: 'CREW',
			field: 'COUNT',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMBER_OF_CREWMATES54610),
			isFixed: true,
		}).cloneFrom(values?.ValCount))
		watch(() => this.ValCount.value, (newValue, oldValue) => this.onUpdate('crew.count', this.ValCount, newValue, oldValue))

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
	}

	/**
	 * Creates a clone of the current QFormCrewViewModel instance.
	 * @returns {QFormCrewViewModel} A new instance of QFormCrewViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcrew'

	get QPrimaryKey() { return this.ValCodcrew.value }
	set QPrimaryKey(value) { this.ValCodcrew.updateValue(value) }
}
