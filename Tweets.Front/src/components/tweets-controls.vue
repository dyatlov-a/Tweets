<template>
    <div class="row">
        <div class="col-sm-12">
            <b-form @submit.prevent="update">
                <b-form-group :state="!errors.has('tag')" invalid-feedback="Это поле обязательно для заполнения" class="mb-5">
                    <b-input-group>
                        <b-form-input 
                            type="text"
                            v-model="tag" 
                            v-validate="'required'" 
                            name="tag" 
                            :class="{ 'is-invalid': errors.has('tag') }"
                            placeholder="Введите текст" 
                            :disabled="!isReady" />
                        <b-input-group-append>
                            <b-btn type="submit" variant="primary" :disabled="!isReady">Поиск</b-btn>
                        </b-input-group-append>
                    </b-input-group>
                </b-form-group>
            </b-form>
        </div>
    </div>
</template>

<script>
import { TWEETS_SET_TAG, TWEETS_UPDATE } from "../store/consts";

export default {
    computed: {
        isReady(){
            return this.$store.state.loading.isReady;
        },
        tag: {
            get() {
                return this.$store.state.tweets.tag;
            },
            set(newValue) {
                this.$store.commit(TWEETS_SET_TAG, newValue);
            }
        }
    },
    methods: {
        update() {
            this.$validator.validateAll().then(result => {
                if (result) {
                    this.$store.dispatch(TWEETS_UPDATE);
                }
            });
        }
    }
}
</script>