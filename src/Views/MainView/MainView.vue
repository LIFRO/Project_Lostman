<script lang="ts" setup>
    import { FetchItems, type FetchItemsResponse } from "../../Components/FetchItems.ts";
    import  type { ApiFolder,  Api, CreateApi } from '../../Model/ApiTypes';
    import CreateApiForm from "./Children/CreateApiForm.vue";
    import CreateFolderForm from "./Children/CreateFolderForm.vue";
    import { SaveApi, SaveFolder } from "../../Components/SaveItems.ts";
    import ApiList from './Children/ApiList.vue';
    import "../../css/Main.css";
    import { ref } from 'vue';

    const folder = ref<ApiFolder[]> ([]);
    const createApiError = ref<string>("");
    const toggleForm = ref<string>('');
    const folders = ref<ApiFolder[]> ([]);
    const apis = ref<Api[]> ([]);
    const currentFolder = ref<ApiFolder>();

    function toggleCreateFolder(){
        toggleForm.value = 'folder';
    }

    function toggleCreateApi() {
        toggleForm.value = 'api';
    };

    async function handleCreateFolder(name: string){
        try{
            await SaveFolder(name)
        }catch(error)
        {
            console.log(error);
        }
    }

    async function handleCreateApi(data: CreateApi){
        
        try{
            await SaveApi(data.name, data.method, data.url);
            const items:FetchItemsResponse = await FetchItems(null);
            if(!items) return;

            toggleForm.value = '';
            apis.value = items.apis;
            folder.value = items.catalogs;
        }
        catch(error){
            console.log(error);
            createApiError.value = "Error couldnt save or fetch api's";
        };
    };

</script>

<template>
    <div>
        <div>
            <button 
            v-on:click="toggleCreateFolder()"
            class="Button">
                Create a folder
            </button>
            <button 
            v-on:click="toggleCreateApi()"
            class="Button"> 
                Create a api
            </button>
        </div>
        <div>
            <div v-if="toggleForm == 'folder'">
                <CreateFolderForm @new-folder="handleCreateFolder">
                    <p></p>
                </CreateFolderForm>
            </div>
            <div v-else-if="toggleForm == 'api'">
                <CreateApiForm @update-api="handleCreateApi">
                    <p>{{ createApiError }}</p> 
                </CreateApiForm>
            </div>
        </div>
        <div>
            ApiList
            <ApiList :items="apis"/>
        </div>
    </div>
</template>
