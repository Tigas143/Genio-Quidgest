/*****************************************************************
 *                                                               *
 * This store holds data specific for the horizontal layout,     *
 * also defining functions to access and mutate it.              *
 *                                                               *
 *****************************************************************/

import { defineStore } from 'pinia'

//----------------------------------------------------------------
// State variables
//----------------------------------------------------------------

const state = () => {
	return {
		layoutType: 'horizontal',

		navbarHeight: 0,

		headerText: '',

		// Used to render the second level of menus in the double_navbar menu.
		childrenMenus: {}
	}
}

//----------------------------------------------------------------
// Actions
//----------------------------------------------------------------

const actions = {
	/**
	 * Sets the current height of the navbar.
	 * @param {number} height The current height of the navbar (in pixels)
	 */
	setNavbarHeight(height)
	{
		if (typeof height !== 'number')
			return

		this.navbarHeight = height
	},

	/**
	 * Sets the children of the given menu to render in the second level of the double_navbar menu.
	 * @param {object} menu The current menu to render it's children
	 */
	setChildrenMenus(menu)
	{
		if (typeof menu !== 'object')
			return

		this.childrenMenus = menu
	},

	/**
	 * Sets a custom text for the header
	 * @param {string} text The text to set
	 */
	setHeaderText(text)
	{
		this.headerText = text
	},

	/**
	 * Resets the layout info.
	 */
	resetStore()
	{
		Object.assign(this, state())
	}
}

//----------------------------------------------------------------
// Store export
//----------------------------------------------------------------

export const useLayoutDataStore = defineStore('layoutData', {
	state,
	actions
})
