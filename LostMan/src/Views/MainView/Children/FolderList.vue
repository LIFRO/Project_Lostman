<script lang="ts" setup>
    import type { ApiFolder } from '../../../Model/ApiTypes';

    defineProps<{items: ApiFolder[]}>();

    const emit = defineEmits<{
        currentFolder: [number]
    }>()

    function send(id: number){
        emit("currentFolder", id)
    }
</script>

<template>
    <ul>
        <button v-on:click="send(item.id)" v-for="item in items" key="item.id">
            <div>{{ item.name }}</div>
        </button>
    </ul>
</template>