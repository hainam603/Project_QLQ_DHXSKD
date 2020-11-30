<template>
  <div>
    <template v-if="!$route.meta.allowAnonymous">
      <v-app>
        <v-navigation-drawer v-model="sideNav" temporary absolute bottom>
          <v-list shaped>
            <v-list-item>
              <v-list-item-icon>
                <v-icon>mdi-home</v-icon>
              </v-list-item-icon>
              <v-list-item-Title>Home</v-list-item-Title>
            </v-list-item>

            <v-list-group :value="true" prepend-icon="mdi-account-circle">
              <template v-slot:activator>
                <v-list-item-Title>Users</v-list-item-Title>
              </template>

              <v-list-group :value="true" no-action sub-group>
                <template v-slot:activator>
                  <v-list-item-content>
                    <v-list-item-Title>Admin</v-list-item-Title>
                  </v-list-item-content>
                </template>

                <v-list-item v-for="([Title, icon], i) in admins" :key="i" link>
                  <v-list-item-icon>
                    <v-icon v-text="icon"></v-icon>
                  </v-list-item-icon>
                  <v-list-item-Title v-text="Title"></v-list-item-Title>
                </v-list-item>
              </v-list-group>

              <v-list-group no-action sub-group>
                <template v-slot:activator>
                  <v-list-item-content>
                    <v-list-item-Title>Actions</v-list-item-Title>
                  </v-list-item-content>
                </template>

                <v-list-item v-for="([Title, icon], i) in cruds" :key="i" link>
                  <v-list-item-icon>
                    <v-icon v-text="icon"></v-icon>
                  </v-list-item-icon>
                  <v-list-item-Title v-text="Title"></v-list-item-Title>
                </v-list-item>
              </v-list-group>
            </v-list-group>
          </v-list>
        </v-navigation-drawer>
        <v-app-bar app color="primary" dark>
          <v-app-bar-nav-icon
            @click.stop="sideNav = !sideNav"
          ></v-app-bar-nav-icon>
          <v-toolbar-Title>
            <v-img
              alt="VNPT Logo"
              class="shrink mr-2"
              contain
              src="../public/VNPT_Logo.svg"
              transition="scale-transition"
              width="40"
            />
          </v-toolbar-Title>
          <v-autocomplete
            v-model="select"
            :loading="loading"
            :items="items"
            :search-input.sync="search"
            cache-items
            class="mx-4"
            flat
            hide-no-data
            hide-details
            label="Nhập nội dung cần tìm?"
            solo-inverted
          ></v-autocomplete>

          <v-spacer></v-spacer>

          <v-toolbar-items
            class="hidden-xs-only"
            v-for="(item,i) in menuItems"
            :key="i"
          >
            <v-btn text :to="item.link">
              <v-icon left dark>{{ item.icon }}</v-icon>
              <span class="mr-2">{{ item.Title }}</span>
            </v-btn>

            <v-divider vertical></v-divider>
          </v-toolbar-items>
          <v-toolbar-items class="hidden-xs-only"> </v-toolbar-items>
        </v-app-bar>

        <v-main>
          <router-view></router-view>
        </v-main>
        <v-card height="30px" class="">
          <v-footer fixed>
            <v-card flat width="100%" class="blue lighten-1 text-center">
              <v-card-text>
                <v-btn
                  v-for="(icon,i) in icons"
                  :key="i"
                  class="mx-4 white--text"
                  icon
                  :to="icon.link"
                >
                  <v-tooltip top color="warning">
                    <template v-slot:activator="{ on, attrs }">
                      <v-icon
                        v-bind="attrs"
                        v-on="on"
                        size="24px"
                        color=" lighten-3"
                      >
                        {{ icon.icon }}
                      </v-icon>
                    </template>
                    <span>{{ icon.Title}}</span>
                  </v-tooltip>
                </v-btn>
                <!-- <v-btn class="mx-4 white--text" icon>
                  <v-badge
                    bordered
                    dot
                    overlap
                    color="red lighten-2"
                    content="6"
                  >
                  <v-icon color="white" @click="Click_Thongbao_I8"> mdi-bell </v-icon>
                  </v-badge>
                </v-btn> -->
              </v-card-text>
            </v-card>
          </v-footer>
        </v-card>
      </v-app>
    </template>
    <!-- --Login -->
    <template v-else>
      <transition>
        <keep-alive>
          <v-app>
            <router-view></router-view>
          </v-app>
        </keep-alive>
      </transition>
    </template>
    <v-snackbar
        outlined
        color="#303F9F"
        top
        v-model="snackbar"
        :timeout="timeout"
      >
        {{ text }}
  
        <template v-slot:action="{ attrs }">
          <v-btn
            color="blue"
            text
            v-bind="attrs"
            @click="snackbar = false"
            :timeout="timeout"
          >
            Đóng
          </v-btn>
        </template>
      </v-snackbar>
  </div>
</template>

<script>
import kt_session from "./services/Kiemtra_Session";
import factory from "./services/factory/repositoryfactory";
const user = factory.get("user");
const kt=kt_session;
export default {
  name: "App",

  components: {},

  data: () => ({
    //
    snackbar: false,
    text: "",
    timeout: 2000,
    loading: false,
    message: "",
    sideNav: false,
    icons: [
      // { icon: "mdi-home", Title: "Trang chủ", link: "/home" },
      // { icon: "mdi-calendar", Title: "Calendar", link:'' },
      // { icon: "mdi-view-dashboard", Title: "Dashboard", link: "/dashboard" },
      // { icon: "mdi-shield-key-outline", Title: "Quản trị", link: "/dashboard" },
    ],
    admins: [
      ["Management", "mdi-account-multiple-outline"],
      ["Settings", "mdi-cog-outline"],
    ],
    cruds: [
      ["Create", "mdi-plus-outline"],
      ["Read", "mdi-file-outline"],
      ["Update", "mdi-update"],
      ["Delete", "mdi-delete"],
    ],
    menuItems: [
      // { icon: "mdi-home", title: "Trang chủ", link: "/home" },
      // { icon: "mdi-menu", title: "Quyền Menu", link: "/role_menu" },
      // { icon: "mdi-account", title: "Quản lý người dùng", link: "/profile" },
      // { icon: "mdi-view-list", title: "Quyền báo cáo", link: "/role_baocao" },
      // { icon: "mdi-book-search-outline", title: "Rà soát thuê bao", link: "/rasoat_thuebao" },
      // { icon: "mdi-exit-to-app", title: "Thoát", link: "/logout" },
    ],
    items: [],
    search: null,
    select: null,
    states: [
      "Alabama",
      "Alaska",
      "American Samoa",
      "Arizona",
      "Arkansas",
      "California",
      "Colorado",
      "Connecticut",
      "Delaware",
      "District of Columbia",
      "Federated States of Micronesia",
      "Florida",
      "Georgia",
      "Guam",
      "Hawaii",
      "Idaho",
      "Illinois",
      "Indiana",
      "Iowa",
      "Kansas",
      "Kentucky",
      "Louisiana",
      "Maine",
      "Marshall Islands",
      "Maryland",
      "Massachusetts",
      "Michigan",
      "Minnesota",
      "Mississippi",
      "Missouri",
      "Montana",
      "Nebraska",
      "Nevada",
      "New Hampshire",
      "New Jersey",
      "New Mexico",
      "New York",
      "North Carolina",
      "North Dakota",
      "Northern Mariana Islands",
      "Ohio",
      "Oklahoma",
      "Oregon",
      "Palau",
      "Pennsylvania",
      "Puerto Rico",
      "Rhode Island",
      "South Carolina",
      "South Dakota",
      "Tennessee",
      "Texas",
      "Utah",
      "Vermont",
      "Virgin Island",
      "Virginia",
      "Washington",
      "West Virginia",
      "Wisconsin",
      "Wyoming",
    ],
  }),
  created(){
    var self=this;
    if(self.Kiemtra_Hotro_LocalStorage()){
      if(!kt.get_token_session() || !localStorage.ds_chucnang || !localStorage.ds_nguoidung){
        self.$router.push('/logout');
      }else{
        self.Khoitao_DS_Chucnang();
      }
    }else{
       self.$router.push('/logout');
       self.text="Trình duyệt hiện không hỗ trợ LocalStorage, vui lòng cập nhật lên phiên bản mới nhất để sử dụng ứng dụng";
       self.timeout=-1;
       self.snackbar=true;
    }
  },
  mounted(){
   
    
  },
  watch: {
    search(val) {
      val && val !== this.select && this.querySelections(val);
    },
    
  },
  computed:{
  
  },

  methods: {

    Khoitao_DS_Chucnang(){
      var self=this;
       var ds_chucnang=JSON.parse(localStorage.ds_chucnang);
        ds_chucnang.forEach((element,key) => {

          if(element.menu)
            self.menuItems.push({
              icon: element.icon, 
              Title: element.title, 
              link: element.link?element.link.trim():''
            });
          else
            self.icons.push({
              
              icon: element.icon,
              Title: element.title, 
              link: element.link?element.link.trim():''
            });
        });

    },
    Kiemtra_Hotro_LocalStorage(){
      if (typeof(Storage) !== 'undefined') 
        return true;
      else 
        return false;
    },
    // Click_Thongbao_I8(){
    //   console.log("thong bao i8")
    //   this.$router.push("/thongbao_i8");
    // },
    
    querySelections(v) {
      this.loading = true;
      // Simulated ajax query
      setTimeout(() => {
        this.items = this.states.filter((e) => {
          return (e || "").toLowerCase().indexOf((v || "").toLowerCase()) > -1;
        });
        this.loading = false;
      }, 500);
    },
  },
};
</script>
<style scoped>
.v-card__subTitle,
.v-card__text,
.v-card__Title {
  padding: 6px;
}
</style>
