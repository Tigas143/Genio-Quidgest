<template>
	<div
		:class="[...layoutClasses, ...customClasses]"
		:data-loading="loading">
		<slot name="layout-loading-effect"></slot>

		<template v-if="showContent">
<!-- eslint-disable indent, vue/html-indent, vue/script-indent -->
<!-- USE /[MANUAL PJF LAYOUT_HEADER]/ -->
<!-- eslint-disable-next-line -->
<!-- eslint-enable indent, vue/html-indent, vue/script-indent -->
			<navigational-bar :loading-menus="loadingMenus" />

			<slot name="layout-header"></slot>
		</template>

<!-- eslint-disable indent, vue/html-indent, vue/script-indent -->
<!-- USE /[MANUAL PJF LAYOUT_CONTENT]/ -->
<!-- eslint-disable-next-line -->
<!-- eslint-enable indent, vue/html-indent, vue/script-indent -->
		<slot name="layout-content"></slot>
	</div>
</template>

<script>
	import { defineAsyncComponent } from 'vue'

	import LayoutHandlers from '@/mixins/layoutHandlers.js'

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF LAYOUT_INCLUDEJS LAYOUT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QLayout',

		components: {
			NavigationalBar: defineAsyncComponent(() => import('./NavigationalBar.vue'))
		},

		mixins: [
			LayoutHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Custom classes to apply to the layout container.
			 */
			customClasses: {
				type: Array,
				default: () => []
			},

			/**
			 * Whether there's any asynchronous process running.
			 */
			loading: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the menu structure is loading.
			 */
			loadingMenus: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		computed: {
			/**
			 * True if the layout content should be visible, false otherwise.
			 */
			showContent()
			{
				return !this.isFullScreenPage && (this.userIsLoggedIn || this.isPublicRoute || this.layoutConfig.LoginStyle !== 'single_page')
			},

			/**
			 * Classes used in the layout container.
			 */
			layoutClasses()
			{
				const classes = ['layout-container']

				if (!this.showContent)
					classes.push('login-page')

				if (this.rightSidebarIsCollapsed)
					classes.push('right-sidebar-collapse')

				return classes
			}
		},

		methods: {
			/**
			 * Sets a custom text that appears in the header.
			 */
			async setCustomHeaderText()
			{
				let text

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF LAYOUT_HEADER_TEXT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.setHeaderText(text)
			},

			/**
			 * Checks if the header text is ready to be shown.
			 */
			showHeaderText(userIsLoggedIn)
			{
				if (this.isEmpty(this.headerText) && this.layoutConfig.MenuStyle === 'double_navbar' && userIsLoggedIn)
					this.setCustomHeaderText()
			}
		},

		watch: {
			// If the user logged off and logged back in the custom text would disappear, this prevents that.
			headerText: {
				handler()
				{
					this.showHeaderText(this.userIsLoggedIn)
				},
				immediate: true
			},

			userIsLoggedIn: {
				handler(val)
				{
					this.showHeaderText(val)
				},
				immediate: true
			}
		}
	}
</script>
