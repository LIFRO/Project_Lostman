<script lang="ts" setup>
    import "../../css/Main.css"
    import CreateApiForm from "./Children/CreateApiForm.vue";
    import ApiList from './Children/ApiList.vue';
    import  type { ApiFolder,  Api, CreateApi } from '../../Model/ApiTypes';
    import { SaveApi } from "../../Components/SaveItems.ts";
    import { ref } from 'vue';
    import { FetchItems, type FetchItemsResponse } from "../../Components/FetchItems.ts";

    let toggleCreateApibool = ref(false);
    const apis = ref<Api[]> ([]);
    const catalogs = ref<ApiFolder[]> ([])
    const createApiError = ref<string>("")

    function toggleCreateApi() {
        toggleCreateApibool.value = !toggleCreateApibool.value;
    }

    async function handleCreateApi(data:CreateApi){
        
        try{
            await SaveApi(data.name, data.method, data.url)

            const items:FetchItemsResponse = await FetchItems(null)

            if(!items) return;

            toggleCreateApi()
            apis.value = items.apis
            catalogs.value = items.catalogs
        }
        catch(error){
            console.log(error)
            createApiError.value = "Error couldnt save or fetch api's"
        }
    }

</script>

<template>
    <div>
        <div>
            <button class="Button">
                Create a folder
            </button>
            <button 
            v-on:click="toggleCreateApi()"
            class="Button"> 
                Create a api
            </button>
        </div>
        <div v-if="toggleCreateApibool">
            <CreateApiForm @update-api="handleCreateApi">
                <p>{{ createApiError }}</p>
            </CreateApiForm>
        </div>
        <div>
            ApiList
            <ApiList :items="apis"/>
        </div>
    </div>
</template>
