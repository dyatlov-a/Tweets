<template>
    <div>
        <div v-if="isReady">
            <div v-if="items.length === 0">
                Нет совпадений
            </div>
            <div v-else>
                <b-card v-for="item in items" :key="item.id" class="mb-5">
                    <b>{{$displayDateTime(item.createdAt)}}</b>
                    <p>{{item.text}}</p>
                </b-card>
            </div>
        </div>
        <div v-else>
            Загрузка...
        </div>
    </div>
</template>

<script>
export default {
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