<template>
  <div>
    <div class="nav-cnt">
      <b-navbar variant="primary">
        <div class="container">
          <b-navbar-nav>
            <b-nav-item @click="reload" :disabled="!isReady">Поиск твитов</b-nav-item>
          </b-navbar-nav>
        </div>
      </b-navbar>
    </div>
    <div class="container">
      <tweets-controls />
      <tweets-list />
    </div>
  </div>
</template>

<script>
import tweetsControls from "./components/tweets-controls.vue";
import tweetsList from "./components/tweets-list.vue";
import { 
  LOADING, 
  LOADED,
  TWEETS_LOAD
} from "./store/consts";

export default {
  components: {
    tweetsControls,
    tweetsList
  },
  methods: {
    load() {
      this.$store.dispatch(TWEETS_LOAD).finally(() => this.$store.commit(LOADED));
    },
    reload() {
      this.$store.commit(LOADING);
      this.load();
    }
  },
  computed: {
    isReady(){
      return this.$store.state.loading.isReady;
    }
  },
  created() {
    this.load();
  }
};
</script>

<style scoped>
.nav-cnt {
  margin-bottom: 40px;
}
</style>

