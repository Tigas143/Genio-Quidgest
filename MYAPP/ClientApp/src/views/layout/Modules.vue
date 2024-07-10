<template>
	<div class="modules__container">
		<ul
			v-if="Object.keys(system.availableModules).length > 1"
			class="nav">
			<li class="dropdown">
				<a
					href="javascript:void(0)"
					class="brand"
					:data-key="system.currentModule"
					data-toggle="dropdown">
					<module-header />
				</a>

				<all-modules />
			</li>
		</ul>
	</div>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import ModuleHeader from './ModuleHeader.vue'
	import AllModules from './AllModules.vue'

	export default {
		name: 'QModules',

		components: {
			ModuleHeader,
			AllModules
		},

		mixins: [
			LayoutHandlers
		],

		expose: []
	}
</script>
