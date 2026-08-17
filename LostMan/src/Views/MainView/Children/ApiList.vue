<script lang="ts" setup>
import type { Api } from '../../../Model/ApiTypes';
defineProps<{items: Api[]}>();
const emit = defineEmits<{
    'api-clicked': [api: Api]
}>();
</script>

<template>
    <ul>
        <button v-for="item in items" :key="item.id" @click="console.log('ApiList', item); emit('api-clicked', item)">
            <div>{{item.name}}</div>
        </button>
    </ul>
</template>
