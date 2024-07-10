<template>
	<q-dashboard
		v-if="componentOnLoadProc.loaded"
		v-bind="controls.dashboard"
		v-on="controls.dashboard.handlers" />
</template>

<script>
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import DashboardHandlers from '@/mixins/dashboardHandlers.js'
	import { DashboardControl } from '@/mixins/dashboardControl.js'

	const requiredTextResources = ['QMenuPJF_11', 'hardcoded', 'messages']

	export default {
		name: 'QMenuPjf11',

		mixins: [
			GenericMenuHandlers,
			DashboardHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the form is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPJF_11', false),

				interfaceMetadata: {
					id: 'QMenuPJF_11', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'PJF_11',
					name: 'New Menu',
					route: 'menu-PJF_11',
					order: '11'
				},

				controls: {
					dashboard: new DashboardControl({
						action: 'PJF_Menu_11',
						title: computed(() => this.Resources.DASHBOARD51597),
						groups: [
						],
					}, this)
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		created()
		{
			this.componentOnLoadProc.addImmediateBusy(loadResources(this, requiredTextResources))
			this.componentOnLoadProc.addImmediateBusy(this.fetchDashboardData(this.controls.dashboard))
			this.componentOnLoadProc.once(() => this.controls.dashboard.init(), this)
		}
	}
</script>
