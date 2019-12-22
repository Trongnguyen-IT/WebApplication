// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import Router from 'vue-router'
Vue.use(Router)
import router from './router'
import Element from 'element-ui'
import appStore from './store/app'
//import axios from 'axios'

Vue.use(Element)

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store: appStore,
  components: { App },
  template: '<App/>'
})
