<script lang="ts" setup>
    import type { ApiFolder } from '../../../Model/ApiTypes';

    defineProps<{items: ApiFolder[]}>();

    const emit = defineEmits<{
        currentFolder: [ApiFolder]
    }>()

    function send(Folder: ApiFolder){
        emit("currentFolder", Folder)
    }
</script>

<template>
    <ul>
        <li>
            <button v-for="item in items" key="item.id" v-on:click="send(item)">
                <div>{{ item.name }}</div>
            </button>
        </li>
    </ul>
</template>