import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormAirln', defineAsyncComponent(() => import('@/views/forms/FormAirln/QFormAirln.vue')))
		app.component('QFormAirports', defineAsyncComponent(() => import('@/views/forms/FormAirports/QFormAirports.vue')))
		app.component('QFormBooking', defineAsyncComponent(() => import('@/views/forms/FormBooking/QFormBooking.vue')))
		app.component('QFormCity', defineAsyncComponent(() => import('@/views/forms/FormCity/QFormCity.vue')))
		app.component('QFormCrew', defineAsyncComponent(() => import('@/views/forms/FormCrew/QFormCrew.vue')))
		app.component('QFormFlight', defineAsyncComponent(() => import('@/views/forms/FormFlight/QFormFlight.vue')))
		app.component('QFormMainten', defineAsyncComponent(() => import('@/views/forms/FormMainten/QFormMainten.vue')))
		app.component('QFormMateprof', defineAsyncComponent(() => import('@/views/forms/FormMateprof/QFormMateprof.vue')))
		app.component('QFormPasseger', defineAsyncComponent(() => import('@/views/forms/FormPasseger/QFormPasseger.vue')))
		app.component('QFormPilot', defineAsyncComponent(() => import('@/views/forms/FormPilot/QFormPilot.vue')))
		app.component('QFormPlanes', defineAsyncComponent(() => import('@/views/forms/FormPlanes/QFormPlanes.vue')))
		app.component('QFormPsw', defineAsyncComponent(() => import('@/views/forms/FormPsw/QFormPsw.vue')))
		app.component('QFormRoutes', defineAsyncComponent(() => import('@/views/forms/FormRoutes/QFormRoutes.vue')))
		app.component('QFormWflights', defineAsyncComponent(() => import('@/views/forms/FormWflights/QFormWflights.vue')))
		app.component('QFormWplane', defineAsyncComponent(() => import('@/views/forms/FormWplane/QFormWplane.vue')))
	}
}
