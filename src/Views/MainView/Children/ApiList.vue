<script lang="ts" setup>
import type { Api } from '../../../Model/ApiTypes';
defineProps<{items: Api[]}>();
</script>

<template>
    <ul>
        <li v-for="item in items" keyt="item.id">
            <div>{{item.name}}</div>
        </li>
    </ul>
</template>
