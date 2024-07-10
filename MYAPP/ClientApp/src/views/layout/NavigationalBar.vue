<template>
	<div
		v-if="layoutConfig.HeaderEnable"
		:class="headerClasses"
		ref="topHeader">
		<div
			v-if="layoutConfig.LogoEnable"
			class="c-header__brand float-left">
			<q-router-link link="/">
				<img
					:src="`${system.resourcesPath}logotipo_header.png`"
					:alt="texts.initialPage" />
			</q-router-link>
		</div>

		<div
			class="custom-header-text"
			v-if="layoutConfig.MenuStyle === 'double_navbar' && !isEmpty(headerText)">
			<q-static-text
				supports-html
				:text="headerText" />
		</div>
		<div class="c-header__content">
			<q-select
				v-if="userIsLoggedIn && system.availableSystems.length > 1"
				id="system-years"
				:model-value="system.currentSystem"
				size="fit-content"
				:items="availableSystems"
				:groups="availableSystemsGroups"
				@update:model-value="selectSystem">
				<template #prepend>
					<q-icon icon="system-choice" />
				</template>
			</q-select>
			<q-tooltip
				anchor="#system-years"
				placement="bottom"
				:text="texts.systemYears" />

			<language-items v-if="layoutConfig.LanguagePlacement === 'in_header'" />

			<embedded-menu v-if="layoutConfig.LogonPlacement === 'in_header'" />
		</div>
	</div>

	<div
		v-if="layoutConfig.MenuStyle === 'ribbon'"
		class="navigation">
		<ribbon-menu />
	</div>
	<template v-else>
		<nav
			id="main-header-navbar"
			:class="[...navbarClasses, 'navbar', 'navbar-expand-md', 'navbar-dark']"
			ref="navbar">
			<div :class="[containerClasses, { 'n-menu__navbar--double-l1': hasDoubleNavbar }]">
				<q-router-link
					v-if="layoutConfig.BrandIconEnable"
					class="navbar-brand"
					link="/">
					<img
						:src="`${system.resourcesPath}Q_icon.png`"
						:alt="texts.initialPage"
						width="30"
						height="30" />
				</q-router-link>

				<button
					class="navbar-toggler"
					type="button"
					data-toggle="collapse"
					data-target="#collapsible-navbar"
					aria-expanded="false">
					<span class="navbar-toggler-icon"></span>
				</button>

				<bookmarks />

				<modules />

				<div class="ml-4 d-md-none">
					<embedded-menu />
				</div>

				<div
					id="collapsible-navbar"
					class="collapse navbar-collapse">
					<q-line-loader v-if="loadingMenus" />
					<q-menu
						v-else
						:second-level-menu="hasDoubleNavbar"
						@change-menu="changeMenu" />
				</div>

				<div :class="['ml-4', 'd-none', { 'd-md-block': layoutConfig.LogonPlacement === 'in_navmenu' }]">
					<embedded-menu />
				</div>
			</div>

			<div
				v-if="hasDoubleNavbar"
				class="n-menu__navbar--double-l2">
				<menu-sub-items
					v-for="child in childrenMenus.Children"
					:key="child.Id"
					:menu="child"
					:module="system.currentModule"
					:level="1"
					:second-level-menu="hasDoubleNavbar"
					root />
			</div>
		</nav>
	</template>
</template>

<script>
	import { watchEffect, computed, defineAsyncComponent } from 'vue'
	import { mapActions } from 'pinia'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import hardcodedTexts from '@/hardcodedTexts.js'
	import mainConfigUtils from '@/api/global/mainConfigUtils.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import Bookmarks from './Bookmarks.vue'
	import Modules from './Modules.vue'
	import QMenu from './Menu.vue'
	import MenuSubItems from './MenuSubItems.vue'

	import EmbeddedMenu from '@/views/shared/EmbeddedMenu.vue'
	import QRouterLink from '@/views/shared/QRouterLink.vue'

	export default {
		name: 'QNavigationBar',

		components: {
			LanguageItems: defineAsyncComponent(() => import('@/views/shared/LanguageItems.vue')),
			RibbonMenu: defineAsyncComponent(() => import('./RibbonMenu.vue')),
			EmbeddedMenu,
			QRouterLink,
			Bookmarks,
			Modules,
			QMenu,
			MenuSubItems
		},

		mixins: [LayoutHandlers],

		props: {
			/**
			 * Whether or not the menu structure is loading.
			 */
			loadingMenus: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				showLogin: false,

				texts: {
					initialPage: computed(() => this.Resources[hardcodedTexts.initialPage]),
					systemYears: computed(() => this.Resources[hardcodedTexts.systemYears])
				},

				navbar: '',

				header: ''
			}
		},

		mounted()
		{
			this.setListeners()

			this.navbar = this.$refs.navbar
			this.header = this.$refs.topHeader

			if (this.navbar)
			{
				const height = this.navbar.offsetHeight
				this.setNavbarValues(height)
			}

			const headerHeight = this.hasHeader ? this.header.offsetHeight + this.navbar.offsetHeight : this.navbar.offsetHeight
			this.setHeaderHeightValues(headerHeight)

			// Updates values when header & navbar gets resized
			this.$nextTick().then(() => {
				const resizeObserver = new ResizeObserver(() => {
					if (this.header && this.navbar)
					{
						const height = this.header.offsetHeight + this.navbar.offsetHeight
						this.setHeaderHeightValues(height)
						this.setNavbarValues(this.navbar.offsetHeight)
					}
				})
				resizeObserver.observe(this.navbar)
			})

			watchEffect(() => {
				if (this.isEmpty(this.menuPath) && this.hasDoubleNavbar && !this.isEmpty(this.menus) && !this.isEmpty(this.menus.MenuList))
				{
					const menu = this.menus.MenuList[0]
					this.setChildrenMenus(menu)
					this.setMenuPath(menu.Order)
				}
			})
		},

		beforeUnmount()
		{
			this.removeListeners()
		},

		computed: {
			headerClasses()
			{
				const classes = ['border-bottom', 'c-header']

				if (this.hasDoubleNavbar)
					classes.push('c-header--double-navbar')

				return classes
			},

			navbarClasses()
			{
				const classes = []

				if (this.hasDoubleNavbar)
					classes.push('n-menu__navbar--double')

				return classes
			},

			hasHeader()
			{
				return this.layoutConfig.HeaderEnable
			},

			availableSystems()
			{
				return (this.system.availableSystems || []).map((availableSystem) => ({
					key: availableSystem,
					value: availableSystem.toString(),
					disabled: this.system.currentSystem === availableSystem,
					group: availableSystem
				}))
			},

			availableSystemsGroups()
			{
				return (this.system.availableSystems || []).map((availableSystem) => ({
					id: availableSystem
				}))
			}
		},

		methods: {
			...mapActions(useSystemDataStore, [
				'setCurrentSystem'
			]),

			changeMenu(menu)
			{
				this.setChildrenMenus(menu)
			},

			/**
			 * Change the system (year) in the store and redirect to the home page.
			 * We should not preserve the current page because the user may not even have access to it on the other system.
			 * @param {String} selectedSystem Selected system
			 */
			selectSystem(selectedSystem)
			{
				this.setCurrentSystem(selectedSystem)
				// Before opening the home page, we must update the configuration to have the menu list for this system.
				mainConfigUtils.updateMainConfig(() => {
					this.$router.push({
						name: 'home',
						params: {
							culture: this.system.currentLang,
							system: selectedSystem,
							module: this.system.currentModule
						}
					})
				})
			}
		}
	}
</script>
