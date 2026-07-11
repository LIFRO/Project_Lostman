<script lang="ts" setup>
    import { FetchItems, FetchItemsById, type FetchItemsResponse } from "../../Components/FetchItems.ts";
    import  type { ApiFolder,  Api, CreateApi } from '../../Model/ApiTypes';
    import CreateApiForm from "./Children/CreateApiForm.vue";
    import CreateFolderForm from "./Children/CreateFolderForm.vue";
    import { SaveApi, SaveFolder } from "../../Components/SaveItems.ts";
    import ApiList from './Children/ApiList.vue';
    import FolderList from "./Children/FolderList.vue";
    import "../../css/Main.css";
    import { onMounted, ref } from 'vue';

    const createApiError = ref<string>("");
    const createFolderError = ref<string>("");
    const toggleForm = ref<string>('');
    const folders = ref<ApiFolder[]> ([]);
    const apis = ref<Api[]> ([]);
    const currentFolder = ref<ApiFolder>();
    const errorText = ref<string>("");

    async function loadItems(){
        try {
            const items:FetchItemsResponse = await FetchItems();

            folders.value = items.catalogs;
            apis.value = items.apis;
        }catch(error){
            console.log(error);
            errorText.value = "Couldnt load apis and folders on startup"
        }
    }

    onMounted(loadItems)

    async function folderChange(folder: ApiFolder){
        try{
        const foldersInsideOfCurrentFolder: FetchItemsResponse = await FetchItemsById(folder.id);

        currentFolder.value = folder;
        apis.value = foldersInsideOfCurrentFolder.apis;
        folders.value = foldersInsideOfCurrentFolder.catalogs;
        }
        catch(error){
            console.log(error)
        }
    }

    function toggleCreateFolder(){
        toggleForm.value = 'folder';
    }

    function toggleCreateApi() {
        toggleForm.value = 'api';
    };

    async function handleCreateFolder(name: string){
        try{
            await SaveFolder(name)
            const items:FetchItemsResponse = await FetchItems();
            if(!items) return;

            apis.value = items.apis;
            folders.value = items.catalogs; 
            toggleForm.value = '';
        }catch(error)
        {
            console.log(error);
            createFolderError.value = 'Error saving or updating folders';
        }
    }

    async function handleCreateApi(data: CreateApi){
        
        try{
            await SaveApi(data.name, data.method, data.url);
            const items:FetchItemsResponse = await FetchItems();
            if(!items) return;

            toggleForm.value = '';
            apis.value = items.apis;
            folders.value = items.catalogs;
        }
        catch(error){
            console.log(error);
            createApiError.value = "Error saving or updating apis";
        };
    };
</script>

<template>
    <p role="alert">
        {{ errorText }}
    </p>
    <div v-if="currentFolder != undefined">
        <button 
        v-on:click="currentFolder = undefined, loadItems()" 
        type="button"
        class="Button"
        >
            Back
        </button>
    </div>
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
                <CreateFolderForm :currentFolderChild="currentFolder" @new-folder="handleCreateFolder">
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
            Api list
            <ApiList :items="apis" />
        </div>
        <div>
            Folder list
            <FolderList :items="folders" @current-Folder="folderChange"/>
        </div>
        <div>
            {{ currentFolder }}
        </div>
    </div>
</template>
