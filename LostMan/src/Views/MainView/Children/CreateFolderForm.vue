<script lang="ts" setup>
import type { ApiFolder } from '../../../Model/ApiTypes';
import { ref } from 'vue';

    const currentFolderChild = defineProps<{currentFolderChild: ApiFolder|undefined}>();

    const name = ref<string>('');
    const emit = defineEmits<{
        newFolder: [data: string]
    }>()

    function send(){
        if (currentFolderChild === undefined){
            emit("newFolder", name.value)
        }
        else{
            currentFolderChild
        }
    } 
</script>

<template>
    <div>
        <input placeholder="Folder name" type="text" v-model="name">
        <button type="button" @click="send()">
            Create folder
        </button>

        <slot></slot>
    </div>
</template>
