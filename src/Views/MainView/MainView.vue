<script lang="ts" setup>
import "../../css/Main.css"
import type { Api } from '../../Model/ApiTypes';
import ApiList from './Children/ApiList.vue';
import { ref } from 'vue';

const apis = ref<Api[]> ([]);

</script>

<template>
    <div>
        <div>
            <button class="Button">
                Create a folder
            </button>
            <button 
            v-on:click="CreateApi()"
            class="Button"> 
                Create a api
            </button>
        </div>
        <div>
            ApiList
            <ApiList :items="apis"/>
        </div>
    </div>
    <navbar>

    </navbar> 
</template>
