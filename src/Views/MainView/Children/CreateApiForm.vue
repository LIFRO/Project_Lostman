<script lang ="ts" setup>
    import { ref } from 'vue';
    import type { CreateApi, httpMethod } from '../../../Model/ApiTypes';

    const props = defineProps<{
        handleCreateApi: Function
    }>();

    let name = ref('')
    let url = ref('')
    let method = ref<httpMethod>("GET")
    const emit =  defineEmits(["updateApi"])

    let api: CreateApi = {
        name: name.value,
        method: method.value,
        url: url.value,
        parentId: null
    }

    function send () {
        emit("updateApi", api)
    }

</script>

<template>
    <form>
        <input placeholder="Name" type="text" v-model="name">
        <input placeholder="Url" type="text" v-model="url">
        <select v-model="method">
            <option value="GET">GET</option>
            <option value="POST">POST</option>
            <option value="PUT">PUT</option>
            <option value="DELETE">DELETE</option>
        </select>
        <button v-on:click="() => {props.handleCreateApi(), send()}"> Create note </button>
    </form>
</template>