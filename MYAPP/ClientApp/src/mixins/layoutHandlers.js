import { mapState, mapActions } from 'pinia'

import { useLayoutDataStore } from '@/stores/layoutData.js'

import GenericLayoutHandler from '@/mixins/genericLayoutHandlers.js'

/***************************************************************************
 * Mixin with handlers to be reused by the horizontal layout components.   *
 ***************************************************************************/
export default {
	mixins: [
		GenericLayoutHandler
	],

	computed: {
		...mapState(useLayoutDataStore, [
			'layoutType',
			'navbarHeight',
			'headerText',
			'childrenMenus'
		]),

		/**
		 * True if the MenuStyle layout Variable is set to "double_navbar", false otherwise.
		 */
		hasDoubleNavbar()
		{
			return this.layoutConfig.MenuStyle === 'double_navbar'
		},

		/**
		 * The visible vertical space (in pixels) occupied by this layout's header.
		 */
		visibleHeaderHeight()
		{
			const topDiff = this.headerHeight - this.pageScroll
			return topDiff > this.navbarHeight ? topDiff : this.navbarHeight
		}
	},

	methods: {
		...mapActions(useLayoutDataStore, [
			'setNavbarHeight',
			'setHeaderText',
			'setChildrenMenus'
		]),

		/**
		 * Sets the height for the "visible-header-height" CSS property.
		 * @param {number} height The current height (in pixels)
		 */
		setVisibleHeaderHeight(height)
		{
			document.documentElement.style.setProperty('--visible-header-height', height)
		},

		/**
		 * Sets the height for the "navbar-height" CSS property.
		 * @param {number} height The current height (in pixels)
		 */
		setNavbarHeightProp(height)
		{
			document.documentElement.style.setProperty('--navbar-height', height)
		},

		/**
		 * Sets the height for the "navbar-height" CSS property and the "headerHeight" property.
		 * @param {number} height The current height (in pixels)
		 */
		setHeaderHeightValues(height)
		{
			this.setHeaderHeight(height)
			this.setVisibleHeaderHeight(height)
		},

		/**
		 * Sets the height for the "navbar-height" CSS property and the "navbarHeight" property.
		 * @param {number} height The current height (in pixels)
		 */
		setNavbarValues(height)
		{
			this.setNavbarHeight(height)
			this.setNavbarHeightProp(height)
		},

		/**
		 * Sets the necessary listeners to control the state of the layout.
		 */
		setListeners()
		{
			window.addEventListener('scroll', this.updatePageScroll)
		},

		/**
		 * Removes all the listeners.
		 */
		removeListeners()
		{
			window.removeEventListener('scroll', this.updatePageScroll)
		}
	}
}
