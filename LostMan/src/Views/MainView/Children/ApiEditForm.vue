<script lang="ts" setup>
    import type { Api, httpMethod, PatchApi } from '../../../Model/ApiTypes';
    import { asyncSaveEditedApi } from '../../../Components/EditedItems';
    import { ref } from 'vue';

    const props = defineProps<{SelectedApi: Api}>();

    const newName = ref<string>('');
    const newApiMethod = ref<httpMethod>('GET');
    const urlProtocol = ref<string>('');
    const newUrl = ref<string>('');
    let changeHappened: boolean = false;

    async function saveChanges(){
        let newApi: PatchApi = {
            id: props.SelectedApi.id,
        }
        
        if(newName.value != props.SelectedApi.name){
            newApi.name == newName.value;
            changeHappened = true;
        }

        if(newApiMethod.value != props.SelectedApi.method){
            newApi.method = newApiMethod.value;
            changeHappened = true;
        }

        if(urlProtocol.value + newUrl.value != props.SelectedApi.url){
            newApi.url = urlProtocol.value + newUrl.value;
            changeHappened = true;
        }

        if(changeHappened == false){
            newApi = props.SelectedApi;
            return;
        }

        asyncSaveEditedApi(newApi);
    }

</script>

<template>
    <div>
        <div>
            <input placeholder="Name">
            <select v-model="urlProtocol">
                <option value="http://"> http</option>
                <option value="https://">https</option>
            </select>
            <input placeholder="Url" v-model="newUrl">
            <select>
                <option value="GET">GET</option>
                <option value="POST">POST</option>
                <option value="PUT">PUT</option>
                <option value="DELETE">DELETE</option>
            </select>
        </div>
        <div>
            <button v-on:click="saveChanges">
                Save
            </button>
        </div>
        <div>
            <button>Run</button>
        </div>
    </div>
</template>