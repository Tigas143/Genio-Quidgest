import _capitalize from 'lodash-es/capitalize'
import _isEmpty from 'lodash-es/isEmpty'

import eventBus from '@/api/global/eventBus.js'

/**
 * Generic custom control
 */
export default class CustomControl
{
	constructor(controlContext, controlOrder)
	{
		this.controlContext = controlContext
		this.controlOrder = controlOrder
		this.handlers = {}
		this.customProperties = {}
	}

	/**
	 * Checks whether or not the view mode should be blocked.
	 * @returns True if it's blocked, false otherwise.
	 */
	checkIsReadonly()
	{
		return false
	}

	/**
	 * Adds a new handler for the specified event.
	 * @param {string} id The id of the event
	 * @param {function} behavior The behavior of the handler
	 * @param {boolean} rewrite Whether or not the previous behavior should be rewritten (defaults to false).
	 */
	addHandler(id, behavior, rewrite = false)
	{
		if (typeof id !== 'string' || typeof behavior !== 'function')
			return

		const viewMode = this.controlContext.viewModes[this.controlOrder - 1]
		const prevHandler = viewMode.handlers[id]
		var behaviorFunc = behavior

		if (!rewrite && typeof prevHandler === 'function')
		{
			behaviorFunc = (...args) => {
				prevHandler(...args)
				behavior(...args)
			}
		}

		this.handlers[id] = behaviorFunc
		viewMode.handlers[id] = behaviorFunc
	}

	/**
	 * Sets a property in the control.
	 * @param {string} id The id of the property
	 * @param {any} value The value of the property
	 */
	setProperty(id, value)
	{
		if (typeof id !== 'string')
			return

		const viewMode = this.controlContext.viewModes[this.controlOrder - 1]
		viewMode[id] = value
	}

	/**
	 * Sets any additional properties that might be needed for the control.
	 * @param {object} viewMode The current view mode
	 */
	setGenericCustomProps(viewMode)
	{
		for (let i in this.customProperties)
			viewMode[i] = this.customProperties[i]
	}

	/**
	 * Fetches image data for a given row key and image object.
	 * @param {string} rowKey - The key of the row containing with the image.
	 * @param {Object} imageObj - The object containing information about the image.
	 * @param {function} callback - Callback to assign the value to the image property.
	 */
	fetchImage(rowKey, imageObj, callback)
	{
		if (!_isEmpty(imageObj.previewData))
			return

		const column = imageObj.source,
			baseArea = column.area,
			fieldName = column.field

		let id = rowKey
		// Having a dot means it's from a different area.
		if (column.name.includes('.'))
		{
			const row = this.controlContext.rows.find(row => row.rowKey === rowKey)
			id = row.Fields[column.pkColumn]
		}

		const params = {
			id,
			modelname: _capitalize(baseArea.toLowerCase()),
			fldname: fieldName,
			formIdentifier: null,
			nocache: Math.floor(Math.random() * 100000)
		}

		const imageData = {
			baseArea,
			params,
			callback
		}

		eventBus.emit('image-request', imageData)
	}
}
