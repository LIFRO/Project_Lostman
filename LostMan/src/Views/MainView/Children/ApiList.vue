<script lang="ts" setup>
import type { Api } from '../../../Model/ApiTypes';
defineProps<{items: Api[]}>();
</script>

<template>
    <ul>
        <button v-for="item in items" key="item.id">
            <div>{{item.name}}</div>
        </button>
    </ul>
</template>
