<script lang="ts" setup>
import { ref } from 'vue';

    const name = ref<string>('');
    const emit = defineEmits<{
        newFolder: [data: string]
    }>()

    function send(){
        emit("newFolder", name.value)
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
