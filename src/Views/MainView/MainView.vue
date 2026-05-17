<script lang="ts" setup>
import type { Api } from '../../Model/ApiTypes';
import ApiList from './Children/ApiList.vue';
import { ref } from 'vue';

const apis = ref<Api[]> ([]);
</script>

<template>
    <div>
        <div>
            <button>
            
            </button>
            <button> 

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
