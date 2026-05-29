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
    
    function toggleCreateApi() {
        toggleCreateApibool.value = !toggleCreateApibool.value;
    }

    async function handleCreateApi(data:CreateApi){
        SaveApi(data.name, data.method, data.url)

        const items:FetchItemsResponse = await FetchItems(null)

        if(items == null){
            return
        }

        toggleCreateApi()
        apis.value = items.apis
        catalogs.value = items.catalogs
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
            <CreateApiForm :handleCreateApi="handleCreateApi">

            </CreateApiForm>
        </div>
        <div>
            ApiList
            <ApiList :items="apis"/>
        </div>
    </div>
    <navbar>

    </navbar> 
</template>
