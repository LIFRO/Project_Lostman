<script lang ="ts" setup>
    import { ref } from 'vue';
    import type { CreateApi, httpMethod } from '../../../Model/ApiTypes';

    let name = ref<string>('')
    let url = ref<string>('')
    let method = ref<httpMethod>("GET")
    const emit =  defineEmits<{
        updateApi: [data: CreateApi]
    }>()



    function send () {

        const api: CreateApi = {
            name: name.value,
            method: method.value,
            url: url.value,
            parentId: null
        }

        emit("updateApi", api)
    }
</script>

<template>
    <div>
        <input placeholder="Name" type="text" v-model="name">
        <input placeholder="Url" type="text" v-model="url">

        <select v-model="method">
            <option value="GET">GET</option>
            <option value="POST">POST</option>
            <option value="PUT">PUT</option>
            <option value="DELETE">DELETE</option>
        </select>

        <button type="button" @click="send()"> 
            Create note 
        </button>

        <slot></slot>
    </div>
</template>
