import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/AIRLN/:mode/:id?',
			name: 'form-AIRLN',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAirln/QFormAirln.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AIRLN',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/AIRPORTS/:mode/:id?',
			name: 'form-AIRPORTS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAirports/QFormAirports.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AIRPT',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/BOOKING/:mode/:id?',
			name: 'form-BOOKING',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormBooking/QFormBooking.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'BOOKG',
				humanKeyFields: ['ValBnum']
			}
		},
		{
			path: '/:culture/:system/:module/form/CITY/:mode/:id?',
			name: 'form-CITY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCity/QFormCity.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CITY',
				humanKeyFields: ['ValCity']
			}
		},
		{
			path: '/:culture/:system/:module/form/CREW/:mode/:id?',
			name: 'form-CREW',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCrew/QFormCrew.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CREW',
				humanKeyFields: ['ValCrewname']
			}
		},
		{
			path: '/:culture/:system/:module/form/FLIGHT/:mode/:id?',
			name: 'form-FLIGHT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFlight/QFormFlight.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLIGH',
				humanKeyFields: ['ValFlighnum']
			}
		},
		{
			path: '/:culture/:system/:module/form/MAINTEN/:mode/:id?',
			name: 'form-MAINTEN',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMainten/QFormMainten.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MAINT',
				humanKeyFields: ['ValDate']
			}
		},
		{
			path: '/:culture/:system/:module/form/MATEPROF/:mode/:id?',
			name: 'form-MATEPROF',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMateprof/QFormMateprof.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MATE',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PASSEGER/:mode/:id?',
			name: 'form-PASSEGER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPasseger/QFormPasseger.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PERSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PILOT/:mode/:id?',
			name: 'form-PILOT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPilot/QFormPilot.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PILOT',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PLANES/:mode/:id?',
			name: 'form-PLANES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPlanes/QFormPlanes.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PLANE',
				humanKeyFields: ['ValModel']
			}
		},
		{
			path: '/:culture/:system/:module/form/PSW/:mode/:id?',
			name: 'form-PSW',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPsw/QFormPsw.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'APSW',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/ROUTES/:mode/:id?',
			name: 'form-ROUTES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRoutes/QFormRoutes.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ROUTE',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/WFLIGHTS/:mode/:id?',
			name: 'form-WFLIGHTS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWflights/QFormWflights.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLIGH',
				humanKeyFields: ['ValFlighnum']
			}
		},
		{
			path: '/:culture/:system/:module/form/WPLANE/:mode/:id?',
			name: 'form-WPLANE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWplane/QFormWplane.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PLANE',
				humanKeyFields: ['ValModel']
			}
		},
	]
}
