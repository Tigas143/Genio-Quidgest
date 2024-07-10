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

	import MenuViewModel from './QMenuPJF_31ViewModel.js'

	const requiredTextResources = ['QMenuPJF_31', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_INCLUDEJS PJF_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPjf31',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPJF_31', false),

				interfaceMetadata: {
					id: 'QMenuPJF_31', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '31',
					isMenuList: true,
					designation: computed(() => this.Resources.AIRCRAFTS00038),
					acronym: 'PJF_31',
					name: 'PLANE',
					route: 'menu-PJF_31',
					order: '31',
					controller: 'PLANE',
					action: 'PJF_Menu_31',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableSpecialRenderingControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PJF_Menu_31',
						controller: 'PLANE',
						action: 'PJF_Menu_31',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValPhoto',
								area: 'PLANE',
								field: 'PHOTO',
								label: computed(() => this.Resources.PHOTO51874),
								scrollData: 3,
								sortable: false,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValId',
								area: 'PLANE',
								field: 'ID',
								label: computed(() => this.Resources.MODEL27263),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValModel',
								area: 'PLANE',
								field: 'MODEL',
								label: computed(() => this.Resources.ID48520),
								dataLength: 30,
								scrollData: 10,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Aircr.ValName',
								area: 'AIRCR',
								field: 'NAME',
								label: computed(() => this.Resources.CURRENT_AIRPORT44954),
								dataLength: 50,
								scrollData: 20,
								pkColumn: 'ValCodairpt',
							}),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValEngines',
								area: 'PLANE',
								field: 'ENGINES',
								label: computed(() => this.Resources.NUMBER_OF_ENGINES61894),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValYear',
								area: 'PLANE',
								field: 'YEAR',
								label: computed(() => this.Resources.YEAR_OF_MANUFACTURE06704),
								scrollData: 8,
								dateTimeType: 'date',
							}),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValAge',
								area: 'PLANE',
								field: 'AGE',
								label: computed(() => this.Resources.AGE28663),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValManufact',
								area: 'PLANE',
								field: 'MANUFACT',
								label: computed(() => this.Resources.MANUFACTURER50759),
								dataLength: 30,
								scrollData: 10,
							}),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValCapacity',
								area: 'PLANE',
								field: 'CAPACITY',
								label: computed(() => this.Resources.CAPACITY63181),
								scrollData: 9,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.ArrayColumn({
								order: 10,
								name: 'ValStatus',
								area: 'PLANE',
								field: 'STATUS',
								label: computed(() => this.Resources.STATUS62033),
								dataLength: 9,
								scrollData: 9,
								array: qProjArrays.QArrayStatus.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayStatus.type,
								arrayDisplayMode: 'D',
							}),
						],
						config: {
							name: 'PJF_Menu_31',
							serverMode: true,
							pkColumn: 'ValCodplane',
							tableAlias: 'PLANE',
							tableNamePlural: computed(() => this.Resources.AIRCRAFTS00038),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.AIRCRAFTS00038),
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
										formName: 'PLANES',
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
										formName: 'PLANES',
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
										formName: 'PLANES',
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
										formName: 'PLANES',
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
										formName: 'PLANES',
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
								id: 'RCA_PJF_311',
								name: 'form-PLANES',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodplane
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'PLANES',
								}
							},
							formsDefinition: {
								'PLANES': {
									fnKeySelector: (row) => row.Fields.ValCodplane,
									isPopup: false
								},
							},
							allowFileExport: true,
							allowFileImport: true,
							// The list support form: PLANES
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-AIRLN', 'changed-PLANE', 'changed-AIRCR'],
						uuid: '78fc2326-0f4c-4b5f-b93a-cd3a087f5440',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'CARDS',
								type: 'cards',
								subtype: 'card-img-top',
								label: computed(() => this.Resources.CARTOES27587),
								order: 1,
								mappingVariables: readonly({
									title: {
										allowsMultiple: false,
										sources: [
											'PLANE.ID',
										]
									},
									text: {
										allowsMultiple: true,
										sources: [
											'PLANE.MODEL',
											'PLANE.MANUFACT',
											'PLANE.STATUS',
											'AIRCR.NAME',
										]
									},
									image: {
										allowsMultiple: false,
										sources: [
											'PLANE.PHOTO',
										]
									},
								}),
								styleVariables: {
									actionsAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									actionsStyle: {
										rawValue: 'dropdown',
										isMapped: false
									},
									backgroundColor: {
										rawValue: 'auto',
										isMapped: false
									},
									contentAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									customFollowupDefaultTarget: {
										rawValue: 'blank',
										isMapped: false
									},
									customInsertCard: {
										rawValue: true,
										isMapped: false
									},
									customInsertCardStyle: {
										rawValue: 'secondary',
										isMapped: false
									},
									displayMode: {
										rawValue: 'grid',
										isMapped: false
									},
									containerAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									hoverScaleAmount: {
										rawValue: '1.00',
										isMapped: false
									},
									imageShape: {
										rawValue: 'rectangular',
										isMapped: false
									},
									showColumnTitles: {
										rawValue: false,
										isMapped: false
									},
									showEmptyColumnTitles: {
										rawValue: true,
										isMapped: false
									},
									size: {
										rawValue: 'regular',
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
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
// USE /[MANUAL PJF FORM_CODEJS PJF_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FUNCTIONS_JS PJF_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF LISTING_CODEJS PJF_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
