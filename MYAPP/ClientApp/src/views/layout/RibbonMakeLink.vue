<template>
	<menu-action
		class="dropdown-item"
		:menu="menu"
		:data-toggle="dataToggle">
		<i v-if="menu.Image">
			<img
				:src="imgSrc"
				:alt="imgAlt" />
		</i>

		<u v-if="menu.Count > 0 && !menu.HideMenuSum">{{ menu.Count }}</u>

		<template v-if="menu.HelpTitle">
			{{ menu.HelpTitle }}
		</template>
	</menu-action>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import MenuAction from '@/views/shared/MenuAction.vue'

	export default {
		name: 'QMenuRibbonLink',

		components: {
			MenuAction
		},

		mixins: [
			LayoutHandlers
		],

		props: {
			/**
			 * The menu object containing details like image, count, help context, and other settings.
			 */
			menu: {
				type: Object,
				required: true
			},

			/**
			 * Determines if the menu link is part of the first level navigation.
			 */
			firstLevel: {
				type: Boolean,
				default: true
			}
		},

		expose: [],

		computed: {
			/**
			 * Determines behavior for data-toggle based on the menu level.
			 */
			dataToggle()
			{
				var dataToggle = ''
				if (this.firstLevel)
					dataToggle = 'dropdown'
				return dataToggle
			},

			/**
			 * Computes the source URL for the menu image.
			 */
			imgSrc()
			{
				return `${this.system.resourcesPath}${this.menu.Image}`
			},

			/**
			 * Computes the alt text for the menu image.
			 */
			imgAlt()
			{
				return `icon-${this.menu.Title}`
			}
		}
	}
</script>
