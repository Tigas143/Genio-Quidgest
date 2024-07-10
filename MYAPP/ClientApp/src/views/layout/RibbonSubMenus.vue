<template>
	<div
		:id="menu.Id"
		class="ribbon-button ribbon-button-large">
		{{ Resources[menu.Title] }}

		<template v-if="menu.Preview && menu.Children.length > 0">
			<menu-action :menu="menu.Children[0]">
				<img
					class="ribbon-icon ribbon-normal"
					:src="menu.Image" />

				<img
					class="ribbon-icon ribbon-hot"
					:src="menu.Image" />

				<img
					class="ribbon-icon ribbon-disabled"
					:src="menu.Image" />

				<a data-toggle="dropdown">
					<span class="button-title">
						{{ Resources[menu.Title] }}
						<span
							class="caret"
							unselectable="on"></span>
					</span>

					<span class="button-help">&nbsp;</span>
				</a>
			</menu-action>
		</template>
		<template v-else>
			<a data-toggle="dropdown">
				<img
					class="ribbon-icon ribbon-normal"
					:src="menu.Image" />

				<img
					class="ribbon-icon ribbon-hot"
					:src="menu.Image" />

				<img
					class="ribbon-icon ribbon-disabled"
					:src="menu.Image" />

				<span class="button-title">
					{{ Resources[menu.Title] }}
					<span
						class="caret"
						unselectable="on"></span>
				</span>

				<span class="button-help">&nbsp;</span>
			</a>
		</template>

		<div class="dropdown-menu">
			<template
				v-for="subMenu in menu.Children"
				:key="subMenu.Id">
				<ribbon-sub-items
					v-if="subMenu.Type === 'ITEM'"
					:menu="subMenu"
					:module="module"
					:level="level + 1"
					:root="false" />
				<ribbon-make-link
					v-else-if="subMenu.Type === 'REPORT'"
					:menu="subMenu" />
			</template>
		</div>
	</div>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import MenuAction from '@/views/shared/MenuAction.vue'
	import RibbonMakeLink from './RibbonMakeLink.vue'
	import RibbonSubItems from './RibbonSubItems.vue'

	export default {
		name: 'QMenuRibbonSubMenus',

		components: {
			MenuAction,
			RibbonMakeLink,
			RibbonSubItems
		},

		mixins: [
			LayoutHandlers
		],

		expose: [],

		mounted()
		{
			if (!this.menu.Image)
				this.menu.Image = `${this.system.resourcesPath}no_img.png`
		}
	}
</script>
