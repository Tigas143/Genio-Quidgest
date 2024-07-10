<template>
	<ul
		v-if="!isEmpty(system.availableModules)"
		class="dropdown-menu">
		<template
			v-for="mod in system.availableModules"
			:key="mod.id">
			<li
				v-if="mod.id !== system.currentModule"
				class="i-change-module__item">
				<a
					class="dropdown-item"
					:data-key="mod.id"
					href="javascript:void(0)"
					@click.prevent="navigateToModule(mod.id)">
					<i
						v-if="mod.icon"
						:class="['dropdown__icon', mod.icon]"></i>
					{{ Resources[mod.title] }}
				</a>
			</li>
		</template>
	</ul>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import VueNavigation from '@/mixins/vueNavigation.js'

	export default {
		name: 'QMenuAllModules',

		mixins: [
			LayoutHandlers,
			VueNavigation
		],

		expose: []
	}
</script>
