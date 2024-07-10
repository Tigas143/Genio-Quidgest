<template>
	<div
		v-if="layoutConfig.BookmarkEnable && userIsLoggedIn"
		class="bookmarks__container">
		<ul class="nav">
			<li class="dropdown">
				<a
					class="bookmarks__header"
					href="#"
					data-toggle="dropdown"
					aria-expanded="false"
					:title="texts.favorites">
					<q-icon icon="bookmark" />
				</a>

				<bookmarks-content :classes="['dropdown-menu', 'bookmarks__content']" />
			</li>
		</ul>
	</div>
</template>

<script>
	import { computed } from 'vue'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import BookmarksContent from '@/views/shared/BookmarksContent.vue'

	export default {
		name: 'QBookmarks',

		components: {
			BookmarksContent
		},

		mixins: [
			LayoutHandlers
		],

		expose: [],

		data()
		{
			return {
				texts: {
					favorites: computed(() => this.Resources[hardcodedTexts.favorites])
				}
			}
		}
	}
</script>
