<script lang="ts" setup>
import { AddItemsUnderItemById } from '../../../Components/SaveItems';
import type { ApiFolder, ExplorerItemRequest} from '../../../Model/ApiTypes';
import { ref } from 'vue';

    const props = defineProps<{currentFolderChild: ApiFolder|undefined}>();

    const name = ref<string>('');
    const emit = defineEmits<{
        newFolder: [data: string]
    }>()

    async function send(){
        if (props.currentFolderChild === undefined){
            emit("newFolder", name.value);
        }
        else{
            const item: ExplorerItemRequest = {
                id: props.currentFolderChild.id,
                catalogs: [
                    {
                        name: name.value,
                        parentId: props.currentFolderChild.id
                    }
                ]
            };
            await AddItemsUnderItemById(item)
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
