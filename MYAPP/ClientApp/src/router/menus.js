// eslint-disable-next-line no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/PJF/menu/PJF_231',
			name: 'menu-PJF_231',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_231/QMenuPjf231.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '231',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_251',
			name: 'menu-PJF_251',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_251/QMenuPjf251.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '251',
				baseArea: 'FLIGH',
				hasInitialPHE: false,
				humanKeyFields: ['ValFlighnum'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_81',
			name: 'menu-PJF_81',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_81/QMenuPjf81.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '81',
				baseArea: 'APSW',
				hasInitialPHE: false,
				humanKeyFields: [],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_621',
			name: 'menu-PJF_621',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_621/QMenuPjf621.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '621',
				baseArea: 'CREW',
				hasInitialPHE: false,
				humanKeyFields: ['ValCrewname'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_631',
			name: 'menu-PJF_631',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_631/QMenuPjf631.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '631',
				baseArea: 'MATE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_241',
			name: 'menu-PJF_241',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_241/QMenuPjf241.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '241',
				baseArea: 'ROUTE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_41',
			name: 'menu-PJF_41',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_41/QMenuPjf41.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '41',
				baseArea: 'MAINT',
				hasInitialPHE: false,
				humanKeyFields: ['ValDate'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_211',
			name: 'menu-PJF_211',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_211/QMenuPjf211.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '211',
				baseArea: 'AIRLN',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_71',
			name: 'menu-PJF_71',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_71/QMenuPjf71.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '71',
				baseArea: 'PERSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_31',
			name: 'menu-PJF_31',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_31/QMenuPjf31.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '31',
				baseArea: 'PLANE',
				hasInitialPHE: false,
				humanKeyFields: ['ValModel'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_221',
			name: 'menu-PJF_221',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_221/QMenuPjf221.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '221',
				baseArea: 'AIRPT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_51',
			name: 'menu-PJF_51',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_51/QMenuPjf51.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '51',
				baseArea: 'BOOKG',
				hasInitialPHE: false,
				humanKeyFields: ['ValBnum'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_611',
			name: 'menu-PJF_611',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_611/QMenuPjf611.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '611',
				baseArea: 'PILOT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PJF/menu/PJF_11',
			name: 'menu-PJF_11',
			component: () => import('@/views/menus/ModulePJF/MenuPJF_11/QMenuPjf11.vue'),
			meta: {
				routeType: 'menu',
				module: 'PJF',
				order: '11',
				baseArea: 'Dashboard',
				isDashboardPage: true,
				hasInitialPHE: false
			}
		},
	]
}
