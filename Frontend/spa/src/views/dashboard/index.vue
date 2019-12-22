<template>
    <div class="dashboard">
        <h1>{{title}}</h1>
        <h2>profile{{profile}}</h2>
    </div>
</template>

<script>
import { mapGetters } from 'vuex'
import { getProfile } from '../../services/auth/auth'

export default {
    data() {
        return {
            title: 'Dashboard'
        }
    },
    computed: {
         ...mapGetters(["profile"])
    },
    created() {
        this.getProfile()
    },
    methods: {
        getProfile() {
            getProfile().then(resp=>{
                console.log(resp);
            })
        }
    }
}
</script>