<template>
    <b-card class="mb-5">
        <b>{{$displayDateTime(tweet.createdAt)}}</b>
        <p>{{tweet.text}}</p>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-lg-3" v-for="picture in tweet.pictures" :key="picture.id">
                <img :src="picture.url" class="t-img" />
            </div>
        </div>                   
    </b-card>
</template>

<script>
export default {
    props: {
        tweet: {
            type: Object,
            default: {}
        }
    }
}
</script>

<style scoped>
.t-img {
    width: 100%;
}
</style>