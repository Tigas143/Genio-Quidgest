<template>
	<q-button
		:id="popoverId"
		class="btn-popover"
		b-style="plain">
		<q-icon icon="help" />
	</q-button>

	<q-popover
		:anchor="anchorPopoverId"
		:title="label"
		:text="popoverText" />
</template>


<script>
	import HelpControl from '@/mixins/helpControls.js'

	export default {
		name: 'PopoverHelp',

		mixins: [HelpControl],

		expose: [],

		props: {
			/**
			* Unique identifier for the control.
			*/
			id: String,
			/**
			* The label text for the input field.
			*/
			label: String
		},
		
		computed: {
			popoverId() {
				return `popover_${this.id}`
			},
			anchorPopoverId() {
				return `#popover_${this.id}`
			}
		}
	}
</script>
