<template>
  <v-container fluid grid-list-xl>
    <v-layout row wrap>
      <!-- Widgets-->

      <v-flex lg3 sm6 xs12
        ><v-hover v-slot="{ hover }" open-delay="200">
          <v-card :elevation="hover ? 16 : 2" :class="{ 'on-hover': hover }">
            <Widget
              icon="mdi-domain"
              title="1,287,687"
              :subTitle="'13% higher yesterday'"
              :supTitle="'Tỷ lệ'"
              color="#00b297"
          /></v-card>
        </v-hover>
      </v-flex>
      <v-flex lg3 sm6 xs12>
        <v-hover v-slot="{ hover }" open-delay="200"
          ><v-card :elevation="hover ? 16 : 2" :class="{ 'on-hover': hover }">
            <Widget
              icon="mdi-currency-usd"
              title="$141,291"
              :subTitle="'$117,212'"
              :supTitle="'widgetTodaysSale'"
              color="#dc3545"
          /></v-card>
        </v-hover>
      </v-flex>
      <v-flex lg3 sm6 xs12
        ><v-hover v-slot="{ hover }" open-delay="200">
          <v-card :elevation="hover ? 16 : 2" :class="{ 'on-hover': hover }">
            <Widget
              icon="mdi-monitor-cellphone-star"
              title="33.45%"
              :subTitle="'widgetAverageDuration'"
              :supTitle="'widgetUniqueVisits'"
              color="#0866C6"
          /></v-card>
        </v-hover>
      </v-flex>
      <v-flex lg3 sm6 xs12
        ><v-hover v-slot="{ hover }" open-delay="200"
          ><v-card :elevation="hover ? 16 : 2" :class="{ 'on-hover': hover }">
            <Widget
              icon="mdi-clock"
              title="13.00%"
              :subTitle="'widgetAverageTime 17.25%'"
              :supTitle="'widgetBounceRate'"
              color="#1D2939"
          /></v-card>
        </v-hover>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import Widget from "../components/Widget.vue";
export default {
  components: { Widget },
  data() {
    return {
      lorem: `Lorem ipsum dolor sit amet, mel at clita quando.`,
    };
  },
};
</script>
<style scoped>
.v-card {
  transition: opacity 0.1s ease-in-out;
}

.v-card:not(.on-hover) {
  opacity: 0.9;
}
.on-hover {
  transform: scale(1.1);
  z-index: 2;
}
.show-btns {
  color: rgba(255, 255, 255, 1) !important;
}
</style>
