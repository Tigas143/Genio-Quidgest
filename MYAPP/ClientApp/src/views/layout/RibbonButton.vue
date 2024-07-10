<template>
	<div
		:id="menu.Id"
		class="ribbon-button ribbon-button-large">
		<menu-action :menu="menu">
			<img
				class="ribbon-icon ribbon-normal"
				:src="menuImage" />

			<img
				class="ribbon-icon ribbon-hot"
				:src="menuImage" />

			<img
				class="ribbon-icon ribbon-disabled"
				:src="menuImage" />

			<span class="button-title">{{ Resources[menu.Title] }}</span>

			<span class="button-help">&nbsp;</span>
		</menu-action>
	</div>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import MenuAction from '@/views/shared/MenuAction.vue'

	export default {
		name: 'QMenuRibbonButton',

		components: {
			MenuAction
		},

		mixins: [
			LayoutHandlers
		],

		props: {
			/**
			 * The menu object containing all the necessary properties to render the ribbon button.
			 */
			menu: {
				type: Object,
				required: true
			},

			/**
			 * The specific module in which the menu is being used.
			 */
			module: {
				type: String,
				required: true
			}
		},

		expose: [],

		data()
		{
			return {
				menuImage: `${this.system.resourcesPath}no_img.png`
			}
		}
	}
</script>
