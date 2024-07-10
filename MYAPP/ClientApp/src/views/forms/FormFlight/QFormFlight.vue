<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-button-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-button
									v-if="showFormHeaderButton(btn)"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									:active="btn.isSelected"
									@click="btn.action">
									<q-icon
										v-if="btn.icon"
										v-bind="btn.icon" />
								</q-button>
							</template>
						</q-button-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="layoutConfig.FormAnchorsPosition === 'form-header' && groupFields.length > 0"
				:is-visible="anchorContainerVisibility"
				:anchors="groupFields"
				:controls="controls"
				:header-height="visibleHeaderHeight"
				@focus-control="(...args) => focusControl(...args)" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:error-data="validationErrors"
			@error-clicked="focusField" />

		<div class="heading-button-group-clear"></div>

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<div class="heading-button-group-clear"></div>

		<div
			class="form-flow"
			data-key="FLIGHT"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.FLIGHT__PSEUDNEWGRP04.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLIGHT__PSEUDNEWGRP04.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLIGHT__PSEUDNEWGRP04"
							v-bind="controls.FLIGHT__PSEUDNEWGRP04"
							:is-visible="controls.FLIGHT__PSEUDNEWGRP04.isVisible">
							<!-- Start FLIGHT__PSEUDNEWGRP04 -->
							<q-row-container v-show="controls.FLIGHT__FLIGHFLIGHNUM.isVisible || controls.FLIGHT__PLANEMODEL___.isVisible">
								<q-control-wrapper
									v-show="controls.FLIGHT__FLIGHFLIGHNUM.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__FLIGHFLIGHNUM"
										v-on="controls.FLIGHT__FLIGHFLIGHNUM.handlers"
										:loading="controls.FLIGHT__FLIGHFLIGHNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLIGHT__FLIGHFLIGHNUM.props"
											:model-value="model.ValFlighnum.value"
											@blur="onBlur(controls.FLIGHT__FLIGHFLIGHNUM, model.ValFlighnum.value)"
											@change="model.ValFlighnum.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLIGHT__PLANEMODEL___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__PLANEMODEL___"
										v-on="controls.FLIGHT__PLANEMODEL___.handlers"
										:loading="controls.FLIGHT__PLANEMODEL___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FLIGHT__PLANEMODEL___.isVisible"
											v-bind="controls.FLIGHT__PLANEMODEL___.props"
											v-on="controls.FLIGHT__PLANEMODEL___.handlers" />
										<q-see-more-flight-planemodel
											v-if="controls.FLIGHT__PLANEMODEL___.seeMoreIsVisible"
											v-bind="controls.FLIGHT__PLANEMODEL___.seeMoreParams"
											v-on="controls.FLIGHT__PLANEMODEL___.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLIGHT__PSEUDNEWGRP04 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FLIGHT__PSEUDNEWGRP02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLIGHT__PSEUDNEWGRP02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLIGHT__PSEUDNEWGRP02"
							v-bind="controls.FLIGHT__PSEUDNEWGRP02"
							:is-visible="controls.FLIGHT__PSEUDNEWGRP02.isVisible">
							<!-- Start FLIGHT__PSEUDNEWGRP02 -->
							<q-row-container v-show="controls.FLIGHT__ROUTENAME____.isVisible || controls.FLIGHT__FLIGHDEPART__.isVisible || controls.FLIGHT__FLIGHARRIVAL_.isVisible">
								<q-control-wrapper
									v-show="controls.FLIGHT__ROUTENAME____.isVisible || controls.FLIGHT__FLIGHDEPART__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__ROUTENAME____"
										v-on="controls.FLIGHT__ROUTENAME____.handlers"
										:loading="controls.FLIGHT__ROUTENAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FLIGHT__ROUTENAME____.isVisible"
											v-bind="controls.FLIGHT__ROUTENAME____.props"
											v-on="controls.FLIGHT__ROUTENAME____.handlers" />
										<q-see-more-flight-routename
											v-if="controls.FLIGHT__ROUTENAME____.seeMoreIsVisible"
											v-bind="controls.FLIGHT__ROUTENAME____.seeMoreParams"
											v-on="controls.FLIGHT__ROUTENAME____.handlers" />
									</base-input-structure>
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__FLIGHDEPART__"
										v-on="controls.FLIGHT__FLIGHDEPART__.handlers"
										:loading="controls.FLIGHT__FLIGHDEPART__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLIGHT__FLIGHDEPART__.isVisible"
											v-bind="controls.FLIGHT__FLIGHDEPART__.props"
											:model-value="model.ValDepart.value"
											@reset-icon-click="model.ValDepart.fnUpdateValue(model.ValDepart.originalValue ?? new Date())"
											@update:model-value="model.ValDepart.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLIGHT__FLIGHARRIVAL_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__FLIGHARRIVAL_"
										v-on="controls.FLIGHT__FLIGHARRIVAL_.handlers"
										:loading="controls.FLIGHT__FLIGHARRIVAL_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLIGHT__FLIGHARRIVAL_.isVisible"
											v-bind="controls.FLIGHT__FLIGHARRIVAL_.props"
											:model-value="model.ValArrival.value"
											@reset-icon-click="model.ValArrival.fnUpdateValue(model.ValArrival.originalValue ?? new Date())"
											@update:model-value="model.ValArrival.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLIGHT__FLIGHDURATION.isVisible">
								<q-control-wrapper
									v-show="controls.FLIGHT__FLIGHDURATION.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__FLIGHDURATION"
										v-on="controls.FLIGHT__FLIGHDURATION.handlers"
										:loading="controls.FLIGHT__FLIGHDURATION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLIGHT__FLIGHDURATION.isVisible"
											v-bind="controls.FLIGHT__FLIGHDURATION.props"
											@update:model-value="model.ValDuration.fnUpdateValue"
											@change="model.ValDuration.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLIGHT__PSEUDNEWGRP02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FLIGHT__PSEUDNEWGRP01.isVisible || controls.FLIGHT__AIRLNNAME____.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLIGHT__PSEUDNEWGRP01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLIGHT__PSEUDNEWGRP01"
							v-bind="controls.FLIGHT__PSEUDNEWGRP01"
							:is-visible="controls.FLIGHT__PSEUDNEWGRP01.isVisible">
							<!-- Start FLIGHT__PSEUDNEWGRP01 -->
							<q-row-container v-show="controls.FLIGHT__CREW_CREWNAME.isVisible || controls.FLIGHT__PILOTNAME____.isVisible">
								<q-control-wrapper
									v-show="controls.FLIGHT__CREW_CREWNAME.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__CREW_CREWNAME"
										v-on="controls.FLIGHT__CREW_CREWNAME.handlers"
										:loading="controls.FLIGHT__CREW_CREWNAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FLIGHT__CREW_CREWNAME.isVisible"
											v-bind="controls.FLIGHT__CREW_CREWNAME.props"
											v-on="controls.FLIGHT__CREW_CREWNAME.handlers" />
										<q-see-more-flight-crew-crewname
											v-if="controls.FLIGHT__CREW_CREWNAME.seeMoreIsVisible"
											v-bind="controls.FLIGHT__CREW_CREWNAME.seeMoreParams"
											v-on="controls.FLIGHT__CREW_CREWNAME.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLIGHT__PILOTNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLIGHT__PILOTNAME____"
										v-on="controls.FLIGHT__PILOTNAME____.handlers"
										:loading="controls.FLIGHT__PILOTNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FLIGHT__PILOTNAME____.isVisible"
											v-bind="controls.FLIGHT__PILOTNAME____.props"
											v-on="controls.FLIGHT__PILOTNAME____.handlers" />
										<q-see-more-flight-pilotname
											v-if="controls.FLIGHT__PILOTNAME____.seeMoreIsVisible"
											v-bind="controls.FLIGHT__PILOTNAME____.seeMoreParams"
											v-on="controls.FLIGHT__PILOTNAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLIGHT__PSEUDNEWGRP01 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLIGHT__AIRLNNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FLIGHT__AIRLNNAME____"
							v-on="controls.FLIGHT__AIRLNNAME____.handlers"
							:loading="controls.FLIGHT__AIRLNNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FLIGHT__AIRLNNAME____.props"
								:model-value="model.AirlnValName.value" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
			</template>
		</div>
	</teleport>

	<hr v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row-container v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
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
	import { computed, readonly, defineAsyncComponent } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@/api/network'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable no-unused-vars */

	import FormViewModel from './QFormFlightViewModel.js'

	const requiredTextResources = ['QFormFlight', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_INCLUDEJS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFlight',

		components: {
			QSeeMoreFlightPlanemodel: defineAsyncComponent(() => import('@/views/forms/FormFlight/dbedits/FlightPlanemodelSeeMore.vue')),
			QSeeMoreFlightRoutename: defineAsyncComponent(() => import('@/views/forms/FormFlight/dbedits/FlightRoutenameSeeMore.vue')),
			QSeeMoreFlightCrewCrewname: defineAsyncComponent(() => import('@/views/forms/FormFlight/dbedits/FlightCrewCrewnameSeeMore.vue')),
			QSeeMoreFlightPilotname: defineAsyncComponent(() => import('@/views/forms/FormFlight/dbedits/FlightPilotnameSeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => {
					return {
						name: 'FLIGHT',
						location: 'form-FLIGHT',
						params: {
							isNested: true
						}
					}
				}
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFlight', false),

				interfaceMetadata: {
					id: 'QFormFlight', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FLIGHT',
					route: 'form-FLIGHT',
					area: 'FLIGH',
					primaryKey: 'ValCodfligh',
					designation: computed(() => this.Resources.FLIGHT55228),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						style: 'primary',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						style: 'primary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						style: 'primary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						style: 'secondary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						style: 'primary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						style: 'primary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					FLIGHT__PSEUDNEWGRP04: new fieldControlClass.GroupControl({
						id: 'FLIGHT__PSEUDNEWGRP04',
						name: 'NEWGRP04',
						size: 'block',
						label: computed(() => this.Resources.FLIGHT_INFO45074),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FLIGHT__FLIGHFLIGHNUM: new fieldControlClass.StringControl({
						modelField: 'ValFlighnum',
						valueChangeEvent: 'fieldChange:fligh.flighnum',
						id: 'FLIGHT__FLIGHFLIGHNUM',
						name: 'FLIGHNUM',
						size: 'xlarge',
						label: computed(() => this.Resources.FLIGHT_NUMBER_IDENTI52250),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP04',
						maxLength: 15,
						labelId: 'label_FLIGHT__FLIGHFLIGHNUM',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FLIGHT__PLANEMODEL___: new fieldControlClass.LookupControl({
						modelField: 'TablePlaneModel',
						valueChangeEvent: 'fieldChange:plane.model',
						id: 'FLIGHT__PLANEMODEL___',
						name: 'MODEL',
						size: 'xxlarge',
						label: computed(() => this.Resources.AIRCRAFT03780),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP04',
						mustBeFilled: true,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodplane',
							dependencyEvent: 'fieldChange:fligh.codplane'
						},
						dependentFields: () => ({
							set 'plane.codplane'(value) { vm.model.ValCodplane.updateValue(value) },
							set 'plane.model'(value) { vm.model.TablePlaneModel.updateValue(value) },
							set 'plane.airsc'(value) { vm.model.PlaneValAirsc.updateValue(value) },
							set 'fligh.codairln'(value) { vm.model.ValCodairln.updateValue(value) },
							set 'airln.codairln'(value) { vm.model.ValCodairln.updateValue(value) },
							set 'airln.name'(value) { vm.model.AirlnValName.updateValue(value) },
						}),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					FLIGHT__PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'FLIGHT__PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.TRAVEL_INFO58474),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FLIGHT__ROUTENAME____: new fieldControlClass.LookupControl({
						modelField: 'TableRouteName',
						valueChangeEvent: 'fieldChange:route.name',
						id: 'FLIGHT__ROUTENAME____',
						name: 'NAME',
						size: 'medium',
						label: computed(() => this.Resources.ROUTE59240),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP02',
						mustBeFilled: false,
						controlLimits: [
							{
								identifier: 'fligh.namesc',
								dependencyEvents: ['fieldChange:fligh.namesc'],
								dependencyField: 'FLIGH.NAMESC',
								fnValueSelector: (model) => model.ValNamesc.value,
							},
						],
						lookupKeyModelField: {
							name: 'ValCodroute',
							dependencyEvent: 'fieldChange:fligh.codroute'
						},
						dependentFields: () => ({
							set 'route.codroute'(value) { vm.model.ValCodroute.updateValue(value) },
							set 'route.name'(value) { vm.model.TableRouteName.updateValue(value) },
						}),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					FLIGHT__FLIGHDEPART__: new fieldControlClass.DateControl({
						modelField: 'ValDepart',
						valueChangeEvent: 'fieldChange:fligh.depart',
						id: 'FLIGHT__FLIGHDEPART__',
						name: 'DEPART',
						size: 'medium',
						label: computed(() => this.Resources.DEPARTURE11999),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP02',
						format: 'dateTime',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FLIGHT__FLIGHARRIVAL_: new fieldControlClass.DateControl({
						modelField: 'ValArrival',
						valueChangeEvent: 'fieldChange:fligh.arrival',
						id: 'FLIGHT__FLIGHARRIVAL_',
						name: 'ARRIVAL',
						size: 'medium',
						label: computed(() => this.Resources.ARRIVAL52302),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP02',
						format: 'dateTime',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FLIGHT__FLIGHDURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:fligh.duration',
						id: 'FLIGHT__FLIGHDURATION',
						name: 'DURATION',
						size: 'medium',
						label: computed(() => this.Resources.DURACAO_EM_HORAS28972),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP02',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 0,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FLIGHT__PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'FLIGHT__PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.STAFF42088),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FLIGHT__CREW_CREWNAME: new fieldControlClass.LookupControl({
						modelField: 'TableCrewCrewname',
						valueChangeEvent: 'fieldChange:crew.crewname',
						id: 'FLIGHT__CREW_CREWNAME',
						name: 'CREWNAME',
						size: 'large',
						label: computed(() => this.Resources.CABIN_CREW13410),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodcrew',
							dependencyEvent: 'fieldChange:fligh.codcrew'
						},
						dependentFields: () => ({
							set 'crew.codcrew'(value) { vm.model.ValCodcrew.updateValue(value) },
							set 'crew.crewname'(value) { vm.model.TableCrewCrewname.updateValue(value) },
						}),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					FLIGHT__PILOTNAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePilotName',
						valueChangeEvent: 'fieldChange:pilot.name',
						id: 'FLIGHT__PILOTNAME____',
						name: 'NAME',
						size: 'medium',
						label: computed(() => this.Resources.PILOT61493),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLIGHT__PSEUDNEWGRP01',
						mustBeFilled: true,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodpilot',
							dependencyEvent: 'fieldChange:fligh.codpilot'
						},
						dependentFields: () => ({
							set 'pilot.codpilot'(value) { vm.model.ValCodpilot.updateValue(value) },
							set 'pilot.name'(value) { vm.model.TablePilotName.updateValue(value) },
						}),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					FLIGHT__AIRLNNAME____: new fieldControlClass.StringControl({
						modelField: 'AirlnValName',
						valueChangeEvent: 'fieldChange:airln.name',
						dependentModelField: 'ValCodairln',
						dependentChangeEvent: 'fieldChange:fligh.codairln',
						id: 'FLIGHT__AIRLNNAME____',
						name: 'NAME',
						size: 'small',
						label: computed(() => this.Resources.AIRLINE57868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 9,
						labelId: 'label_FLIGHT__AIRLNNAME____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'FLIGHT__PSEUDNEWGRP04',
					'FLIGHT__PSEUDNEWGRP02',
					'FLIGHT__PSEUDNEWGRP01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Airln: {
						get ValName() { return vm.model.AirlnValName.value },
						set ValName(value) { vm.model.AirlnValName.updateValue(value) },
					},
					Crew: {
						get ValCrewname() { return vm.model.TableCrewCrewname.value },
						set ValCrewname(value) { vm.model.TableCrewCrewname.updateValue(value) },
					},
					Fligh: {
						get ValArrival() { return vm.model.ValArrival.value },
						set ValArrival(value) { vm.model.ValArrival.updateValue(value) },
						get ValCodairln() { return vm.model.ValCodairln.value },
						set ValCodairln(value) { vm.model.ValCodairln.updateValue(value) },
						get ValCodcrew() { return vm.model.ValCodcrew.value },
						set ValCodcrew(value) { vm.model.ValCodcrew.updateValue(value) },
						get ValCodpilot() { return vm.model.ValCodpilot.value },
						set ValCodpilot(value) { vm.model.ValCodpilot.updateValue(value) },
						get ValCodplane() { return vm.model.ValCodplane.value },
						set ValCodplane(value) { vm.model.ValCodplane.updateValue(value) },
						get ValCodroute() { return vm.model.ValCodroute.value },
						set ValCodroute(value) { vm.model.ValCodroute.updateValue(value) },
						get ValCodsourc() { return vm.model.ValCodsourc.value },
						set ValCodsourc(value) { vm.model.ValCodsourc.updateValue(value) },
						get ValDepart() { return vm.model.ValDepart.value },
						set ValDepart(value) { vm.model.ValDepart.updateValue(value) },
						get ValDuration() { return vm.model.ValDuration.value },
						set ValDuration(value) { vm.model.ValDuration.updateValue(value) },
						get ValFlighnum() { return vm.model.ValFlighnum.value },
						set ValFlighnum(value) { vm.model.ValFlighnum.updateValue(value) },
						get ValNamesc() { return vm.model.ValNamesc.value },
						set ValNamesc(value) { vm.model.ValNamesc.updateValue(value) },
					},
					Pilot: {
						get ValName() { return vm.model.TablePilotName.value },
						set ValName(value) { vm.model.TablePilotName.updateValue(value) },
					},
					Plane: {
						get ValAirsc() { return vm.model.PlaneValAirsc.value },
						set ValAirsc(value) { vm.model.PlaneValAirsc.updateValue(value) },
						get ValModel() { return vm.model.TablePlaneModel.value },
						set ValModel(value) { vm.model.TablePlaneModel.updateValue(value) },
					},
					Route: {
						get ValName() { return vm.model.TableRouteName.value },
						set ValName(value) { vm.model.TableRouteName.updateValue(value) },
					},
					keys: {
						/** The primary key of the FLIGH table */
						get fligh() { return vm.model.ValCodfligh },
						/** The foreign key to the PLANE table */
						get plane() { return vm.model.ValCodplane },
						/** The foreign key to the ROUTE table */
						get route() { return vm.model.ValCodroute },
						/** The foreign key to the AIRSC table */
						get airsc() { return vm.model.ValCodsourc },
						/** The foreign key to the CREW table */
						get crew() { return vm.model.ValCodcrew },
						/** The foreign key to the PILOT table */
						get pilot() { return vm.model.ValCodpilot },
						/** The foreign key to the AIRLN table */
						get airln() { return vm.model.ValCodairln },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_CODEJS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				let loadForm = true

				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF BEFORE_LOAD_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return loadForm
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_LOADED_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				applyForm = await this.model.setDocumentChanges()

				if (applyForm)
				{
					const results = await this.model.saveDocuments()
					applyForm = results.every((e) => e === true)
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF BEFORE_APPLY_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF AFTER_APPLY_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				saveForm = await this.model.setDocumentChanges()

				if (saveForm)
				{
					const results = await this.model.saveDocuments()
					saveForm = results.every((e) => e === true)
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF BEFORE_SAVE_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF AFTER_SAVE_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return redirectPage
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				let deleteForm = true // Set to 'false' to cancel form delete.

				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF BEFORE_DEL_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return deleteForm
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				let redirectPage = true // Set to 'false' to cancel page redirect.

				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF AFTER_DEL_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return redirectPage
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				let leaveForm = true // Set to 'false' to cancel page redirect.

				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF BEFORE_EXIT_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return leaveForm
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF AFTER_EXIT_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF DLGUPDT FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field's is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue) 
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF CTRLBLR FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue);
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF CTRLUPD FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FUNCTIONS_JS FLIGHT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
