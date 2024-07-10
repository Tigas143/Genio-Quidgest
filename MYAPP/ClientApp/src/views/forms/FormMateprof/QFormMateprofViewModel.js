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
			name: 'MATEPROF',
			area: 'MATE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_MATEPROF'
			}
		})

		/** The primary key. */
		this.ValCodmate = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmate',
			originId: 'ValCodmate',
			area: 'MATE',
			field: 'CODMATE',
			description: '',
		}).cloneFrom(values?.ValCodmate))
		watch(() => this.ValCodmate.value, (newValue, oldValue) => this.onUpdate('mate.codmate', this.ValCodmate, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'MATE',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('mate.codairln', this.ValCodairln, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcrew = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcrew',
			originId: 'ValCodcrew',
			area: 'MATE',
			field: 'CODCREW',
			relatedArea: 'CREW',
			description: computed(() => this.Resources.CABIN_CREW13410),
		}).cloneFrom(values?.ValCodcrew))
		watch(() => this.ValCodcrew.value, (newValue, oldValue) => this.onUpdate('mate.codcrew', this.ValCodcrew, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'MATE',
			field: 'NAME',
			maxLength: 20,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('mate.name', this.ValName, newValue, oldValue))

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
	 * Creates a clone of the current QFormMateprofViewModel instance.
	 * @returns {QFormMateprofViewModel} A new instance of QFormMateprofViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmate'

	get QPrimaryKey() { return this.ValCodmate.value }
	set QPrimaryKey(value) { this.ValCodmate.updateValue(value) }
}
