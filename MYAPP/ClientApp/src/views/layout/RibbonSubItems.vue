<template>
	<li
		v-if="menu.Separates && !root"
		class="dropdown-divider"></li>

	<li
		class="dropdown"
		:class="{ 'has-treeview': !isEmpty(menu.Children) }">
		<template v-if="!isEmpty(menu.Children)">
			<ribbon-make-link
				:menu="menu"
				:first-level="level === 0" />

			<ul class="dropdown-menu">
				<template
					v-for="child in menu.Children"
					:key="child.Id">
					<ribbon-sub-items
						v-if="child.Type === 'ITEM'"
						:menu="child"
						:level="level + 1"
						:root="false" />
					<li v-else-if="child.Type === 'REPORT'">
						<ribbon-make-link :menu="child" />
					</li>
				</template>
			</ul>
		</template>
		<template v-else>
			<ribbon-make-link :menu="menu" />
		</template>
	</li>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers'
	import RibbonMakeLink from './RibbonMakeLink.vue'

	export default {
		name: 'QMenuRibbonSubItems',

		components: {
			RibbonMakeLink
		},

		mixins: [
			LayoutHandlers
		],

		props: {
			/**
			 * The menu item object including details like child menu items, type, and whether it should be shown as separate.
			 */
			menu: {
				type: Object,
				required: true
			},

			/**
			 * The name of the module this menu is a part of. Used for identifying unique menus.
			 */
			module: {
				type: String,
				required: true
			},

			/**
			 * Indicates if this instance of the component represents the root level of the menu structure.
			 */
			root: {
				type: Boolean,
				default: true
			},

			/**
			 * The hierarchical level of the item within the menu structure.
			 */
			level: {
				type: Number,
				default: 0
			}
		},

		expose: []
	}
</script>
