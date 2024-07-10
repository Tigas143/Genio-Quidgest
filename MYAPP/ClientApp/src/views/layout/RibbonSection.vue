<template>
	<div :class="classes">
		<span class="section-title">{{ Resources[menu.Title] }}</span>

		<template
			v-for="btnMenu in menu.Children"
			:key="btnMenu.Id">
			<ribbon-sub-menus
				v-if="!isEmpty(btnMenu.Children)"
				root
				:module="module" />
			<ribbon-sub-menus
				v-else
				:menu="btnMenu"
				:module="module" />
		</template>

		<template v-if="isEmpty(menu.Children)">
			<ribbon-button
				:menu="menu"
				:module="module" />
		</template>
	</div>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import RibbonSubMenus from './RibbonSubMenus.vue'
	import RibbonButton from './RibbonButton.vue'

	export default {
		name: 'QMenuRibbonSection',

		components: {
			RibbonSubMenus,
			RibbonButton
		},

		mixins: [LayoutHandlers],

		props: {
			/**
			 * Contains menu information for a ribbon section, such as a title and child menu items.
			 */
			menu: {
				type: Object,
				required: true
			},

			/**
			 * The module key associated with this section of the ribbon menu.
			 */
			module: {
				type: String,
				required: true
			},

			/**
			 * Flag to indicate if the ribbon section is a root level menu.
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
				lastSection: true
			}
		},

		computed: {
			/**
			 * Computes the CSS classes to apply to the ribbon section, with the addition of 'ribbon-last-section' if it's the last section.
			 */
			classes()
			{
				const ribbonClass = ['ribbon-section']

				if (this.lastSection)
					ribbonClass.push('ribbon-last-section')

				return ribbonClass
			}
		}
	}
</script>
