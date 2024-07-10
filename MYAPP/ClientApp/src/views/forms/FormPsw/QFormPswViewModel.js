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
			name: 'PSW',
			area: 'APSW',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PSW'
			}
		})

		/** The primary key. */
		this.ValCodhpsw = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodhpsw',
			originId: 'ValCodhpsw',
			area: 'APSW',
			field: 'CODHPSW',
			description: '',
		}).cloneFrom(values?.ValCodhpsw))
		watch(() => this.ValCodhpsw.value, (newValue, oldValue) => this.onUpdate('apsw.codhpsw', this.ValCodhpsw, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodairln = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodairln',
			originId: 'ValCodairln',
			area: 'APSW',
			field: 'CODAIRLN',
			relatedArea: 'AIRLN',
			description: '',
		}).cloneFrom(values?.ValCodairln))
		watch(() => this.ValCodairln.value, (newValue, oldValue) => this.onUpdate('apsw.codairln', this.ValCodairln, newValue, oldValue))

		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'APSW',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: '',
		}).cloneFrom(values?.ValCodpsw))
		watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('apsw.codpsw', this.ValCodpsw, newValue, oldValue))

		/** The remaining form fields. */
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

		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePswNome))
		watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPswViewModel instance.
	 * @returns {QFormPswViewModel} A new instance of QFormPswViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodhpsw'

	get QPrimaryKey() { return this.ValCodhpsw.value }
	set QPrimaryKey(value) { this.ValCodhpsw.updateValue(value) }
}
