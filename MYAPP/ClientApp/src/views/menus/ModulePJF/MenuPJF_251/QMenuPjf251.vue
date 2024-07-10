<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-if="componentOnLoadProc.loaded"
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
				</q-table>

				<q-table-extra-extension
					:list-ctrl="controls.menu"
					v-on="controls.menu.handlers" />
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'
	/* eslint-enable no-unused-vars */

	import MenuViewModel from './QMenuPJF_251ViewModel.js'

	const requiredTextResources = ['QMenuPJF_251', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_INCLUDEJS PJF_MENU_251]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPjf251',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPJF_251', false),

				interfaceMetadata: {
					id: 'QMenuPJF_251', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '251',
					isMenuList: true,
					designation: computed(() => this.Resources.FLIGHT55228),
					acronym: 'PJF_251',
					name: 'FLIGH',
					route: 'menu-PJF_251',
					order: '251',
					controller: 'FLIGH',
					action: 'PJF_Menu_251',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PJF_Menu_251',
						controller: 'FLIGH',
						action: 'PJF_Menu_251',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValFlighnum',
								area: 'FLIGH',
								field: 'FLIGHNUM',
								label: computed(() => this.Resources.FLIGHT_NUMBER_IDENTI52250),
								dataLength: 15,
								scrollData: 15,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Plane.ValModel',
								area: 'PLANE',
								field: 'MODEL',
								label: computed(() => this.Resources.AIRCRAFT03780),
								dataLength: 30,
								scrollData: 10,
								pkColumn: 'ValCodplane',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Route.ValName',
								area: 'ROUTE',
								field: 'NAME',
								label: computed(() => this.Resources.ROUTE59240),
								dataLength: 10,
								scrollData: 10,
								pkColumn: 'ValCodroute',
							}),
							new listColumnTypes.DateColumn({
								order: 4,
								name: 'ValDepart',
								area: 'FLIGH',
								field: 'DEPART',
								label: computed(() => this.Resources.DEPARTURE11999),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 5,
								name: 'ValArrival',
								area: 'FLIGH',
								field: 'ARRIVAL',
								label: computed(() => this.Resources.ARRIVAL52302),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValDuration',
								area: 'FLIGH',
								field: 'DURATION',
								label: computed(() => this.Resources.DURACAO_EM_HORAS28972),
								scrollData: 9,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Crew.ValCrewname',
								area: 'CREW',
								field: 'CREWNAME',
								label: computed(() => this.Resources.CREW_NAME06457),
								dataLength: 20,
								scrollData: 20,
								pkColumn: 'ValCodcrew',
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'Pilot.ValName',
								area: 'PILOT',
								field: 'NAME',
								label: computed(() => this.Resources.PILOT61493),
								dataLength: 10,
								scrollData: 10,
								pkColumn: 'ValCodpilot',
							}),
						],
						config: {
							name: 'PJF_Menu_251',
							serverMode: true,
							pkColumn: 'ValCodfligh',
							tableAlias: 'FLIGH',
							tableNamePlural: computed(() => this.Resources.FLIGHT55228),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FLIGHT55228),
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FLIGHT',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FLIGHT',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FLIGHT',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FLIGHT',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FLIGHT',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA_PJF_2511',
								name: 'form-FLIGHT',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodfligh
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'FLIGHT',
								}
							},
							formsDefinition: {
								'FLIGHT': {
									fnKeySelector: (row) => row.Fields.ValCodfligh,
									isPopup: false
								},
							},
							allowFileExport: true,
							allowFileImport: true,
							// The list support form: FLIGHT
							crudConditions: {
							},
							defaultSearchColumnName: 'ValFlighnum',
							defaultSearchColumnNameOriginal: 'ValFlighnum',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-PLANE', 'changed-AIRLN', 'changed-AIRSC', 'changed-CREW', 'changed-FLIGH', 'changed-PILOT', 'changed-ROUTE'],
						uuid: '1d597cff-b15c-43c3-a60b-3f002ab91ede',
						allSelectedRows: 'false',
						headerLevel: 1,
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

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(to, next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_CODEJS PJF_MENU_251]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FUNCTIONS_JS PJF_251]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF LISTING_CODEJS PJF_MENU_251]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
