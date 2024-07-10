import { computed, reactive } from 'vue'

import CustomControl from './baseControl.js'
import CardsResources from './resources/cardsResources.js'
import { imageObjToSrc } from '@/mixins/genericFunctions.js'

/**
 * Cards control
 */
export default class CardsControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)

		this.texts = new CardsResources(controlContext.vueContext.$getResource)

		// Cards-specific handlers
		this.handlers = {
			'update:visible': (id) => this.onUpdateVisible(id)
		}
	}

	/**
	 * Get the properties for configuring the cards component.
	 * @param {object} viewMode - The current view mode of the cards.
	 * @returns {object} - An object containing cards properties.
	 */
	getProps(viewMode)
	{
		// TODO: only pass cards-specific props
		return {
			id: viewMode.containerId,
			subtype: viewMode.subtype,
			mappedValues: viewMode.mappedValues,
			styleVariables: viewMode.styleVariables,
			listConfig: this.controlContext.config,
			readonly: computed(() => viewMode.readonly),
			loading: !this.controlContext.loaded
		}
	}

	/**
	 * Sets any additional properties that might be needed for the cards
	 * @param {object} viewMode The current view mode
	 */
	setCustomProperties(viewMode)
	{
		viewMode.implementsOwnInsert = viewMode.styleVariables.customInsertCard?.value || false
	}

	/**
	 * Handles the model value update event.
	 * @param {string} rowKey - The key of the current slide.
	 */
	onUpdateVisible(rowKey)
	{
		const viewMode = this.controlContext.viewModes[this.controlOrder - 1],
			imageObj = viewMode.mappedValues.find(row => row.rowKey === rowKey).image

		this.fetchImage(rowKey, imageObj, (data) => 
		{
			/**
			 * While the response is arriving, the rows may change and the assignment 
			 * 	will be made on the image object that is no longer used.
			 */
			const row = viewMode.mappedValues.find(row => row.rowKey === rowKey)
			if (row)
				reactive(row).image.previewData = imageObjToSrc(data)
		})
	}
}
