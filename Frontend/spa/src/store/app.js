import Vue from 'vue'
import Vuex from 'vuex'
import getters from './getters'
import user from './modules/user'

Vue.use(Vuex)

const appStore =  new Vuex.Store({
    modules: {
        user
    },
    getters
})

export default appStore