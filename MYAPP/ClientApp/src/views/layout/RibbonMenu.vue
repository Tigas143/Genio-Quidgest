<template>
	<template v-if="layoutConfig.LogonPlacement !== 'in_header'">
		<embedded-menu />
	</template>

	<div class="navbar float-left ribbon-modules">
		<modules />
	</div>

	<div class="navbar float-left">
		<a
			id="toggle-ribbon"
			href="javascript:void(0)"
			@click.stop.prevent="pin = !pin">
			<q-icon
				icon="pushpin"
				class="change-module-icon" />
		</a>
	</div>

	<div
		id="ribbon"
		class="ribbon">
		<span class="ribbon-window-title"></span>

		<template
			v-for="menu in menus.MenuList"
			:key="menu.Id">
			<div id="ribbon-tab-header-strip">
				<div
					id="ribbon-tab-header"
					class="ribbon-tab-header sel">
					<span class="ribbon-title">{{ Resources[menu.Title] }}</span>
				</div>

				<div class="clearfix"></div>
			</div>

			<template v-if="pin">
				<div
					v-if="menu.TreeLevel === 1"
					class="ribbon-tab"
					:id="menu.Title">
					<div
						class="ribbon-section-sep"
						unselectable="on"></div>

					<template
						v-for="gMenu in menu.Children"
						:key="gMenu.Id">
						<ribbon-section
							:menu="gMenu"
							:module="system.currentModule" />

						<div
							v-if="compareItems(getLastItem(menu.Children), gMenu)"
							class="clearfix"></div>
					</template>
				</div>
			</template>
		</template>
	</div>
</template>

<script>
	import { mapState } from 'pinia'
	import _last from 'lodash-es/last'
	import _isEqual from 'lodash-es/isEqual'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import EmbeddedMenu from '@/views/shared/EmbeddedMenu.vue'
	import RibbonSection from './RibbonSection.vue'
	import Modules from './Modules.vue'

	export default {
		name: 'QMenuRibbon',

		components: {
			EmbeddedMenu,
			Modules,
			RibbonSection
		},

		mixins: [
			LayoutHandlers
		],

		expose: [],

		data()
		{
			return {
				pin: true
			}
		},

		computed: {
			...mapState(useSystemDataStore, ['system'])
		},

		methods: {
			getLastItem: _last,

			compareItems: _isEqual
		}
	}
</script>
