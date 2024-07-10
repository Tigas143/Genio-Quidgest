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
			data-key="PLANES"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.PLANES__PSEUDNEWGRP02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PLANES__PSEUDNEWGRP02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PLANES__PSEUDNEWGRP02"
							v-bind="controls.PLANES__PSEUDNEWGRP02"
							:is-visible="controls.PLANES__PSEUDNEWGRP02.isVisible">
							<!-- Start PLANES__PSEUDNEWGRP02 -->
							<q-row-container v-show="controls.PLANES__PLANEPHOTO___.isVisible">
								<q-control-wrapper
									v-show="controls.PLANES__PLANEPHOTO___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.PLANES__PLANEPHOTO___"
										v-on="controls.PLANES__PLANEPHOTO___.handlers"
										:loading="controls.PLANES__PLANEPHOTO___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.PLANES__PLANEPHOTO___.isVisible"
											v-bind="controls.PLANES__PLANEPHOTO___.props"
											v-on="controls.PLANES__PLANEPHOTO___.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PLANES__PLANEID______.isVisible">
								<q-control-wrapper
									v-show="controls.PLANES__PLANEID______.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANEID______"
										v-on="controls.PLANES__PLANEID______.handlers"
										:loading="controls.PLANES__PLANEID______.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PLANES__PLANEID______.props"
											:model-value="model.ValId.value"
											@blur="onBlur(controls.PLANES__PLANEID______, model.ValId.value)"
											@change="model.ValId.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PLANES__PLANEMODEL___.isVisible || controls.PLANES__AIRLNNAME____.isVisible">
								<q-control-wrapper
									v-show="controls.PLANES__PLANEMODEL___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANEMODEL___"
										v-on="controls.PLANES__PLANEMODEL___.handlers"
										:loading="controls.PLANES__PLANEMODEL___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PLANES__PLANEMODEL___.props"
											:model-value="model.ValModel.value"
											@blur="onBlur(controls.PLANES__PLANEMODEL___, model.ValModel.value)"
											@change="model.ValModel.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PLANES__AIRLNNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__AIRLNNAME____"
										v-on="controls.PLANES__AIRLNNAME____.handlers"
										:loading="controls.PLANES__AIRLNNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PLANES__AIRLNNAME____.isVisible"
											v-bind="controls.PLANES__AIRLNNAME____.props"
											v-on="controls.PLANES__AIRLNNAME____.handlers" />
										<q-see-more-planes-airlnname
											v-if="controls.PLANES__AIRLNNAME____.seeMoreIsVisible"
											v-bind="controls.PLANES__AIRLNNAME____.seeMoreParams"
											v-on="controls.PLANES__AIRLNNAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PLANES__PSEUDNEWGRP02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PLANES__PSEUDNEWGRP01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PLANES__PSEUDNEWGRP01.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="PLANES__PSEUDNEWGRP01"
							v-bind="controls.PLANES__PSEUDNEWGRP01"
							v-on="controls.PLANES__PSEUDNEWGRP01.handlers">
							<!-- Start PLANES__PSEUDNEWGRP01 -->
							<q-row-container v-show="controls.PLANES__PLANEENGINES_.isVisible || controls.PLANES__PLANEMANUFACT.isVisible || controls.PLANES__PLANECAPACITY.isVisible || controls.PLANES__PLANEYEAR____.isVisible || controls.PLANES__PLANEAGE_____.isVisible">
								<q-control-wrapper
									v-show="controls.PLANES__PLANEENGINES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANEENGINES_"
										v-on="controls.PLANES__PLANEENGINES_.handlers"
										:loading="controls.PLANES__PLANEENGINES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PLANES__PLANEENGINES_.isVisible"
											v-bind="controls.PLANES__PLANEENGINES_.props"
											@update:model-value="model.ValEngines.fnUpdateValue"
											@change="model.ValEngines.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PLANES__PLANEMANUFACT.isVisible || controls.PLANES__PLANECAPACITY.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANEMANUFACT"
										v-on="controls.PLANES__PLANEMANUFACT.handlers"
										:loading="controls.PLANES__PLANEMANUFACT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PLANES__PLANEMANUFACT.props"
											:model-value="model.ValManufact.value"
											@blur="onBlur(controls.PLANES__PLANEMANUFACT, model.ValManufact.value)"
											@change="model.ValManufact.fnUpdateValueOnChange" />
									</base-input-structure>
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANECAPACITY"
										v-on="controls.PLANES__PLANECAPACITY.handlers"
										:loading="controls.PLANES__PLANECAPACITY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PLANES__PLANECAPACITY.isVisible"
											v-bind="controls.PLANES__PLANECAPACITY.props"
											@update:model-value="model.ValCapacity.fnUpdateValue"
											@change="model.ValCapacity.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PLANES__PLANEYEAR____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANEYEAR____"
										v-on="controls.PLANES__PLANEYEAR____.handlers"
										:loading="controls.PLANES__PLANEYEAR____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.PLANES__PLANEYEAR____.isVisible"
											v-bind="controls.PLANES__PLANEYEAR____.props"
											:model-value="model.ValYear.value"
											@reset-icon-click="model.ValYear.fnUpdateValue(model.ValYear.originalValue ?? new Date())"
											@update:model-value="model.ValYear.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PLANES__PLANEAGE_____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANEAGE_____"
										v-on="controls.PLANES__PLANEAGE_____.handlers"
										:loading="controls.PLANES__PLANEAGE_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PLANES__PLANEAGE_____.isVisible"
											v-bind="controls.PLANES__PLANEAGE_____.props"
											@update:model-value="model.ValAge.fnUpdateValue"
											@change="model.ValAge.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PLANES__PSEUDNEWGRP01 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PLANES__PSEUDNEWGRP03.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PLANES__PSEUDNEWGRP03.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="PLANES__PSEUDNEWGRP03"
							v-bind="controls.PLANES__PSEUDNEWGRP03"
							v-on="controls.PLANES__PSEUDNEWGRP03.handlers">
							<!-- Start PLANES__PSEUDNEWGRP03 -->
							<q-row-container v-show="controls.PLANES__AIRCRNAME____.isVisible || controls.PLANES__PLANESTATUS__.isVisible">
								<q-control-wrapper
									v-show="controls.PLANES__AIRCRNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__AIRCRNAME____"
										v-on="controls.PLANES__AIRCRNAME____.handlers"
										:loading="controls.PLANES__AIRCRNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PLANES__AIRCRNAME____.isVisible"
											v-bind="controls.PLANES__AIRCRNAME____.props"
											v-on="controls.PLANES__AIRCRNAME____.handlers" />
										<q-see-more-planes-aircrname
											v-if="controls.PLANES__AIRCRNAME____.seeMoreIsVisible"
											v-bind="controls.PLANES__AIRCRNAME____.seeMoreParams"
											v-on="controls.PLANES__AIRCRNAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PLANES__PLANESTATUS__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PLANES__PLANESTATUS__"
										v-on="controls.PLANES__PLANESTATUS__.handlers"
										:loading="controls.PLANES__PLANESTATUS__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.PLANES__PLANESTATUS__.isVisible"
											v-bind="controls.PLANES__PLANESTATUS__.props"
											:model-value="model.ValStatus.value"
											@update:model-value="model.ValStatus.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PLANES__PSEUDNEWGRP03 -->
						</q-group-collapsible>
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

	import FormViewModel from './QFormPlanesViewModel.js'

	const requiredTextResources = ['QFormPlanes', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FORM_INCLUDEJS PLANES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPlanes',

		components: {
			QSeeMorePlanesAirlnname: defineAsyncComponent(() => import('@/views/forms/FormPlanes/dbedits/PlanesAirlnnameSeeMore.vue')),
			QSeeMorePlanesAircrname: defineAsyncComponent(() => import('@/views/forms/FormPlanes/dbedits/PlanesAircrnameSeeMore.vue')),
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
						name: 'PLANES',
						location: 'form-PLANES',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPlanes', false),

				interfaceMetadata: {
					id: 'QFormPlanes', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PLANES',
					route: 'form-PLANES',
					area: 'PLANE',
					primaryKey: 'ValCodplane',
					designation: computed(() => this.Resources.AIRCRAFT03780),
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
					PLANES__PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'PLANES__PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION37731),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:plane.photo',
						id: 'PLANES__PLANEPHOTO___',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PLANES__PSEUDNEWGRP02',
						height: 50,
						width: 30,
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEID______: new fieldControlClass.StringControl({
						modelField: 'ValId',
						valueChangeEvent: 'fieldChange:plane.id',
						id: 'PLANES__PLANEID______',
						name: 'ID',
						size: 'large',
						label: computed(() => this.Resources.MODEL27263),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PLANES__PSEUDNEWGRP02',
						maxLength: 20,
						labelId: 'label_PLANES__PLANEID______',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEMODEL___: new fieldControlClass.StringControl({
						modelField: 'ValModel',
						valueChangeEvent: 'fieldChange:plane.model',
						id: 'PLANES__PLANEMODEL___',
						name: 'MODEL',
						size: 'small',
						label: computed(() => this.Resources.ID48520),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PLANES__PSEUDNEWGRP02',
						maxLength: 30,
						labelId: 'label_PLANES__PLANEMODEL___',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PLANES__AIRLNNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableAirlnName',
						valueChangeEvent: 'fieldChange:airln.name',
						id: 'PLANES__AIRLNNAME____',
						name: 'NAME',
						size: 'medium',
						label: computed(() => this.Resources.AIRLINE57868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PLANES__PSEUDNEWGRP02',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodairln',
							dependencyEvent: 'fieldChange:plane.codairln'
						},
						dependentFields: () => ({
							set 'airln.codairln'(value) { vm.model.ValCodairln.updateValue(value) },
							set 'airln.name'(value) { vm.model.TableAirlnName.updateValue(value) },
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
					PLANES__PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'PLANES__PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.TECHNICAL_SPECS63574),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-PLANES__PSEUDNEWGRP01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEENGINES_: new fieldControlClass.NumberControl({
						modelField: 'ValEngines',
						valueChangeEvent: 'fieldChange:plane.engines',
						id: 'PLANES__PLANEENGINES_',
						name: 'ENGINES',
						size: 'medium',
						label: computed(() => this.Resources.NUMBER_OF_ENGINES61894),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP01',
						container: 'PLANES__PSEUDNEWGRP01',
						maxIntegers: 10,
						maxDecimals: 0,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEMANUFACT: new fieldControlClass.StringControl({
						modelField: 'ValManufact',
						valueChangeEvent: 'fieldChange:plane.manufact',
						id: 'PLANES__PLANEMANUFACT',
						name: 'MANUFACT',
						size: 'medium',
						label: computed(() => this.Resources.MANUFACTURER50759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP01',
						container: 'PLANES__PSEUDNEWGRP01',
						maxLength: 30,
						labelId: 'label_PLANES__PLANEMANUFACT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PLANECAPACITY: new fieldControlClass.NumberControl({
						modelField: 'ValCapacity',
						valueChangeEvent: 'fieldChange:plane.capacity',
						id: 'PLANES__PLANECAPACITY',
						name: 'CAPACITY',
						size: 'small',
						label: computed(() => this.Resources.CAPACITY63181),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP01',
						container: 'PLANES__PSEUDNEWGRP01',
						maxIntegers: 9,
						maxDecimals: 0,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEYEAR____: new fieldControlClass.DateControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:plane.year',
						id: 'PLANES__PLANEYEAR____',
						name: 'YEAR',
						size: 'large',
						label: computed(() => this.Resources.DATE_OF_MANUFACTURE12439),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP01',
						container: 'PLANES__PSEUDNEWGRP01',
						format: 'date',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PLANEAGE_____: new fieldControlClass.NumberControl({
						modelField: 'ValAge',
						valueChangeEvent: 'fieldChange:plane.age',
						id: 'PLANES__PLANEAGE_____',
						name: 'AGE',
						size: 'mini',
						label: computed(() => this.Resources.AGE28663),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP01',
						container: 'PLANES__PSEUDNEWGRP01',
						isFormulaBlocked: true,
						maxIntegers: 4,
						maxDecimals: 0,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__PSEUDNEWGRP03: new fieldControlClass.GroupControl({
						id: 'PLANES__PSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.LOCATION_AND_STATUS50637),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-PLANES__PSEUDNEWGRP03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PLANES__AIRCRNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableAircrName',
						valueChangeEvent: 'fieldChange:aircr.name',
						id: 'PLANES__AIRCRNAME____',
						name: 'NAME',
						size: 'large',
						label: computed(() => this.Resources.CURRENT_AIRPORT44954),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP03',
						container: 'PLANES__PSEUDNEWGRP03',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValAircr',
							dependencyEvent: 'fieldChange:plane.aircr'
						},
						dependentFields: () => ({
							set 'aircr.codairpt'(value) { vm.model.ValAircr.updateValue(value) },
							set 'aircr.name'(value) { vm.model.TableAircrName.updateValue(value) },
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
					PLANES__PLANESTATUS__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValStatus',
						valueChangeEvent: 'fieldChange:plane.status',
						id: 'PLANES__PLANESTATUS__',
						name: 'STATUS',
						size: 'medium',
						label: computed(() => this.Resources.STATUS62033),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PLANES__PSEUDNEWGRP03',
						container: 'PLANES__PSEUDNEWGRP03',
						maxLength: 9,
						labelId: 'label_PLANES__PLANESTATUS__',
						arrayName: 'STATUS',
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
					'PLANES__PSEUDNEWGRP02',
					'PLANES__PSEUDNEWGRP01',
					'PLANES__PSEUDNEWGRP03',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Aircr: {
						get ValName() { return vm.model.TableAircrName.value },
						set ValName(value) { vm.model.TableAircrName.updateValue(value) },
					},
					Airln: {
						get ValName() { return vm.model.TableAirlnName.value },
						set ValName(value) { vm.model.TableAirlnName.updateValue(value) },
					},
					Plane: {
						get ValAge() { return vm.model.ValAge.value },
						set ValAge(value) { vm.model.ValAge.updateValue(value) },
						get ValAircr() { return vm.model.ValAircr.value },
						set ValAircr(value) { vm.model.ValAircr.updateValue(value) },
						get ValCapacity() { return vm.model.ValCapacity.value },
						set ValCapacity(value) { vm.model.ValCapacity.updateValue(value) },
						get ValCodairln() { return vm.model.ValCodairln.value },
						set ValCodairln(value) { vm.model.ValCodairln.updateValue(value) },
						get ValEngines() { return vm.model.ValEngines.value },
						set ValEngines(value) { vm.model.ValEngines.updateValue(value) },
						get ValId() { return vm.model.ValId.value },
						set ValId(value) { vm.model.ValId.updateValue(value) },
						get ValIsmaint() { return vm.model.ValIsmaint.value },
						set ValIsmaint(value) { vm.model.ValIsmaint.updateValue(value) },
						get ValMaint() { return vm.model.ValMaint.value },
						set ValMaint(value) { vm.model.ValMaint.updateValue(value) },
						get ValManufact() { return vm.model.ValManufact.value },
						set ValManufact(value) { vm.model.ValManufact.updateValue(value) },
						get ValModel() { return vm.model.ValModel.value },
						set ValModel(value) { vm.model.ValModel.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
						get ValStatus() { return vm.model.ValStatus.value },
						set ValStatus(value) { vm.model.ValStatus.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
					},
					keys: {
						/** The primary key of the PLANE table */
						get plane() { return vm.model.ValCodplane },
						/** The foreign key to the AIRCR table */
						get aircr() { return vm.model.ValAircr },
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
// USE /[MANUAL PJF FORM_CODEJS PLANES]/
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
// USE /[MANUAL PJF BEFORE_LOAD_JS PLANES]/
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
// USE /[MANUAL PJF FORM_LOADED_JS PLANES]/
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
// USE /[MANUAL PJF BEFORE_APPLY_JS PLANES]/
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
// USE /[MANUAL PJF AFTER_APPLY_JS PLANES]/
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
// USE /[MANUAL PJF BEFORE_SAVE_JS PLANES]/
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
// USE /[MANUAL PJF AFTER_SAVE_JS PLANES]/
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
// USE /[MANUAL PJF BEFORE_DEL_JS PLANES]/
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
// USE /[MANUAL PJF AFTER_DEL_JS PLANES]/
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
// USE /[MANUAL PJF BEFORE_EXIT_JS PLANES]/
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
// USE /[MANUAL PJF AFTER_EXIT_JS PLANES]/
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
// USE /[MANUAL PJF DLGUPDT PLANES]/
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
// USE /[MANUAL PJF CTRLBLR PLANES]/
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
// USE /[MANUAL PJF CTRLUPD PLANES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PJF FUNCTIONS_JS PLANES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.PLANES__PSEUDNEWGRP01.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'PLANES__PSEUDNEWGRP01',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.PLANES__PSEUDNEWGRP03.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'PLANES__PSEUDNEWGRP03',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
