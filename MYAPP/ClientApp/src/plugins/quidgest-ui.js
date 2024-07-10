import { createFramework } from '@quidgest/ui'

const framework = createFramework({
	themes: {
		defaultTheme: 'Light',
		themes: [
			{
				name: 'Light',
				mode: 'light',
				colors: {
					primaryLight: '#c4d4e9',
					primaryDark: '#072753',
					secondary: '#717485',
					highlight: '#fd7e14',
					primary: '#10166F',
				}
			}
		]
	},
	defaults: {
		QIconSvg: {
			bundle: 'Content/svgbundle.svg'
		},
		QListItem: {
			icons: {
				check: {
					icon: 'ok'
				},
				description: {
					icon: 'help'
				}
			}
		},
		QSelect: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QCombobox: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		}
	}
})

export default framework
