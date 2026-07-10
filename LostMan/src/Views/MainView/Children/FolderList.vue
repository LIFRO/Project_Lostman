<script lang="ts" setup>
    import type { ApiFolder } from '../../Model/ApiTypes';

    defineProps<{items: ApiFolder[]}>();
</script>

<template>
    <ul>
        <button v-for="item in items" key="item.id">
            <div>{{ item.name }}</div>
        </button>
    </ul>
</template>