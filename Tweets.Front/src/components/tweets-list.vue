<template>
    <div>
        <div v-if="isReady">
            <div v-if="items.length === 0">
                Нет совпадений
            </div>
            <div v-else>
                <tweet-card v-for="item in items" :tweet="item" :key="item.id" />                
            </div>
        </div>
        <div v-else>
            Загрузка...
        </div>
    </div>
</template>

<script>
import tweetCard from "./tweet-card.vue";

export default {
    components: {
        tweetCard
    },
    computed: {
        isReady(){
            return this.$store.state.loading.isReady;
        },
        items(){
            return this.$store.state.tweets.items;
        }
    }
}
</script>
