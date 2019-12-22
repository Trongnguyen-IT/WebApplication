import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from '../views/dashboard'
import Login from '../views/login'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})
