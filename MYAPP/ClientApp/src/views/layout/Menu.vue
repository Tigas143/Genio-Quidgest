﻿<template>
	<ul
		v-if="menuSearchCollapsed && !isEmpty(menus) && !isEmpty(menus.MenuList)"
		id="menu-navbar"
		:class="alignClasses">
		<menu-sub-items
			v-for="menu in menus.MenuList"
			:key="menu.Id"
			:menu="menu"
			:second-level-menu="secondLevelMenu"
			:module="system.currentModule"
			:level="0"
			root
			@change-menu="changeMenu" />
	</ul>

	<menu-search-box
		v-if="layoutConfig.MenuSearchEnable && hasMenus || secondLevelMenu"
		v-model:collapsed="menuSearchCollapsed" />
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import MenuSearchBox from './MenuSearchBox.vue'
	import MenuSubItems from './MenuSubItems.vue'

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF LAYOUT_INCLUDEJS MENU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenu',

		emits: ['change-menu'],

		components: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF LAYOUT_INJECT_COMPONENT MENU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			MenuSearchBox,
			MenuSubItems
		},

		mixins: [
			LayoutHandlers
		],

		props: {
			/**
			 * Indicates if the current menu being rendered should be treated as a second level menu.
			 */
			secondLevelMenu: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				menuSearchCollapsed: true
			}
		},

		computed: {
			/**
			 * Derives the class list to be applied to the menu UL element based on the menu alignment configuration.
			 */
			alignClasses()
			{
				const classes = ['navbar-nav', 'nav']

				if (this.layoutConfig.MenuAlign === 'right')
					classes.push('ml-auto')
				else
				{
					classes.push('mr-auto')
					classes.push('w-100')
				}

				return classes
			}
		},

		methods: {
			/**
			 * Emits the 'change-menu' event with the selected menu item.
			 * @param {Object} menu - The menu item object that has been selected.
			 */
			changeMenu(menu)
			{
				this.$emit('change-menu', menu)
			}
		}
	}
</script>
