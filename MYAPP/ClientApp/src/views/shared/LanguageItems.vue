﻿<template>
	<div
		v-if="system.supportedLangs.length > 1"
		id="language-items">
		<ul class="n-language">
			<li>
				<q-icon
					icon="language"
					class="language-icon" />
			</li>

			<template
				v-for="lang in system.supportedLangs"
				:key="lang.language">
				<li
					class="n-language__item"
					:class="{ 'n-language__item-selected': lang.language === system.currentLang }">
					<q-router-link
						class="n-language__link"
						:is-disabled="lang.language === system.currentLang"
						:link="{
							name: currentRoute.name,
							params: { ...currentRoute.params, culture: lang.language }
						}">
						<template v-if="layoutConfig.LanguagePlacement === 'in_footer'">
							{{ lang.languageName }}
						</template>
						<template v-else>
							{{ lang.acronym }}
						</template>
					</q-router-link>
				</li>
			</template>
		</ul>
	</div>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import QRouterLink from '@/views/shared/QRouterLink.vue'

	export default {
		name: 'LanguageItems',

		components: {
			QRouterLink
		},

		mixins: [
			LayoutHandlers
		],

		expose: [],

		data()
		{
			return {
				supportedLangs: {}
			}
		},

		mounted()
		{
			this.supportedLangs = this.system.supportedLangs

			this.swapArrayPos(this.supportedLangs, 0, this.getCurLangIndex())
		},

		computed: {
			currentRoute()
			{
				return {
					name: this.$route.name || 'main',
					params: this.$route.params || {}
				}
			}
		},

		methods: {
			swapArrayPos(array, index1, index2)
			{
				const temp = array[index1]
				array[index1] = array[index2]
				array[index2] = temp
			},

			getCurLangIndex()
			{
				const curLang = this.supportedLangs.find((lang) => lang.language === this.system.currentLang)
				return this.supportedLangs.indexOf(curLang)
			}
		},

		watch: {
			'system.currentLang'()
			{
				const curLangIndex = this.getCurLangIndex()

				if (curLangIndex !== 0)
					this.swapArrayPos(this.supportedLangs, 0, curLangIndex)
			}
		}
	}
</script>
