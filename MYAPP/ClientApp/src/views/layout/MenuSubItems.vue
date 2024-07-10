<template>
	<li
		v-if="menu.Separates && !root"
		class="dropdown-divider" />

	<li
		:id="module + menu.Id"
		:class="menuClasses"
		@click="closeMenu">
		<template v-if="!isEmpty(menu.Children)">
			<make-link
				:menu="menu"
				:first-level="level === 0"
				@click="openMenu" />
			<q-button
				v-if="secondLevelMenu && level === 1"
				data-toggle="dropdown"
				b-style="secondary"
				borderless
				:class="['dropdown-toggle']"
				@click="toggleDropdownMenu" />

			<ul
				ref="dropdownMenu"
				:class="['dropdown-menu', { show: showSubMenu }]">
				<template
					v-for="child in menu.Children"
					:key="child.Id">
					<menu-sub-items
						v-if="child.Type === 'ITEM'"
						:menu="child"
						:level="level + 1"
						:root="false"
						:module="module" />
					<li v-else-if="child.Type === 'REPORT'">
						<make-link :menu="child" />
					</li>
					<component
						v-else-if="child.Type === 'LIST'"
						:is="getMenuList(child.Id)"
						:menu="child" />
				</template>
			</ul>
		</template>
		<template v-else>
			<make-link
				:menu="menu"
				:first-level="level === 0" />
		</template>
	</li>
</template>

<script>
	import { watchEffect, watch } from 'vue'

	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import menuAction from '@/mixins/menuAction.js'

	import MakeLink from './MakeLink.vue'

	export default {
		name: 'QMenuSubItems',

		emits: ['change-menu'],

		components: {
			MakeLink
		},

		mixins: [
			VueNavigation,
			LayoutHandlers,
			menuAction
		],

		props: {
			/**
			 * The menu object containing configuration and state data for the displayed menu link.
			 */
			menu: {
				type: Object,
				required: true
			},

			/**
			 * The module name to be used for dynamic component resolution and part of the ID for the menu item.
			 */
			module: {
				type: String,
				required: true
			},

			/**
			 * Indicates if this is the second-level menu. It affects behavior and styling.
			 */
			secondLevelMenu: {
				type: Boolean,
				default: false
			},

			/**
			 * The level of depth this menu item is at within the menu tree.
			 */
			level: {
				type: Number,
				default: 0
			},

			/**
			 * If true, indicates this is the root menu item.
			 */
			root: {
				type: Boolean,
				default: true
			}
		},

		expose: [],

		data()
		{
			return {
				showSubMenu: false
			}
		},

		mounted()
		{
			// On refresh persist the last opened menu, if there was none it defaults to the first menu.
			watchEffect(() => {
				if (!this.isEmpty(this.menuPath) && this.menuIsOpen(this.menu) && this.hasDoubleNavbar)
					this.$emit('change-menu', this.menu)
			})
		},

		computed: {
			/**
			 * Computes the CSS class list for the menu LI element based on the menu's properties and state.
			 */
			menuClasses()
			{
				const classes = []

				if (this.menuIsOpen(this.menu))
					classes.push('menu-selected')

				if (this.hasDoubleNavbar)
					classes.push('n-menu__item--double-navbar')

				if (this.menu.Children.length < 1)
					return classes

				if (this.root)
					classes.push('dropdown')
				else
					classes.push('dropdown-submenu')

				return classes
			}
		},

		methods: {
			/**
			 * Handles the navigation and behavior when a menu item with children is clicked.
			 * @param {Event} event - The click event.
			 */
			openMenu(event)
			{
				if (this.secondLevelMenu && this.level === 0)
					this.openSingleMenu(this.menu)
				else if (this.secondLevelMenu && this.level > 0)
					this.executeMenuAction(this.menu.Children[0])
				else
					this.toggleDropdownMenu()

				event.stopPropagation()
				event.preventDefault()
			},

			/**
			 * Toggles the visibility of the submenu.
			 */
			toggleDropdownMenu()
			{
				this.showSubMenu = !this.showSubMenu
			},

			/**
			 * Opens a single menu and optionally executes the default action if it exists.
			 * @param {Object} menu - The menu item to open.
			 */
			openSingleMenu(menu)
			{
				this.$emit('change-menu', menu)
				this.setMenuPath(menu.Order)

				const defaultAction = menu.DefaultAction
				if (defaultAction)
					this.navigateToDefaultAction(defaultAction)
			},

			/**
			 * Closes the currently open submenu.
			 */
			closeMenu()
			{
				this.showSubMenu = false
			},

			/**
			 * Closes submenu when clicking outside the element.
			 * @param {Event} event - Mouse up event outside of the dropdown menu to close it.
			 */
			closeSubMenu(event)
			{
				let el = this.$refs.dropdownMenu
				let target = event.target

				// If the target of the click isn't the container nor a descendant of the container close the menu
				if (el && !el.contains(target) && !el.previousElementSibling.contains(target))
					this.closeMenu()
			},

			/**
			 * Dynamically gets the component name for a given menu list.
			 * @param {string} id - The unique ID of the menu list.
			 * @returns {string} Returns the component name constructed dynamically.
			 */
			getMenuList(id)
			{
				return `QMenu${this.module}_${id}`
			}
		},

		watch: {
			showSubMenu(val)
			{
				if (val)
				{
					window.addEventListener('mouseup', this.closeSubMenu)
					const unwatch = watch(() => this.pageScroll, () => {
						this.closeMenu()
						unwatch()
					})
				}
				else
					window.removeEventListener('mouseup', this.closeSubMenu)
			}
		}
	}
</script>
