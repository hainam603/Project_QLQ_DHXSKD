<template>
  <v-timeline align-top :dense="$vuetify.breakpoint.smAndDown">
    <v-timeline-item
      v-for="(item, i) in items"
      :key="i"
      :color="item.color"
      :icon="item.icon"
      fill-dot
    >
      <v-card :color="item.color" dark>
        <v-card-title class="title">
          {{ item.title }}
        </v-card-title>
        <v-card-text class="white text--primary">
          <p class="pt-6 pl-6">{{ item.text }}</p>
          <v-btn :color="item.color" class="mx-0" outlined>
            Chi tiết
          </v-btn>
        </v-card-text>
      </v-card>
    </v-timeline-item>
  </v-timeline>
</template>

<script>
import factory from "../services/factory/repositoryfactory";
const user = factory.get("user");
export default {
  
  data() {
    return {
      items_user:[],
      items: [
        {
          title: "QUẢN LÝ MENU",
          text:
            "Chương trình hỗ trợ cho phép xem người dùng đang được cấp những menu nào trên ĐHSXKD",
          color: "red lighten-2",
          icon: "mdi-menu",
        },
        {
          title: "QUẢN LÝ NGƯỜI DÙNG",
          text:
            "Hỗ trợ giám sát mọi tác động liên quan đến người dùng (Account có quyền truy cập gì, thuộc đơn vị nào, loại nhân viên đang được gán, như thời gian ra vào ĐHSXKD...)",
          color: "purple darken-1",
          icon: "mdi-account",
        },
        {
          title: "QUẢN LÝ BÁO CÁO",
          text:
            "Chương trình giúp quản trị giám sát việc cấp quyền hệ thống báo cáo trong ĐHSXKD, giúp theo dõi việc cấp quyền truy cập xem báo cáo... Xuất file thống kê các báo cáo được cấp cho những ai...",
          color: "green lighten-1",
          icon: "mdi-view-list",
        },
        {
          title: "SMS cảnh báo",
          text:
            "Ngoài ra, chương trình cũng giúp đưa ra cảnh báo gửi sms giám sát cho quản trị theo dõi việc tác động đến nhân viên liên quan đối tượng I8, tác động nhân viên nghỉ việc...",
          color: "indigo",
          icon: "mdi-cellphone-message",
        },
      ],
    };
  },
  computed: {
    loggedIn() {
      return this.$store.getters.loggedIn}
  },
  created() {
    if (this.loggedIn) {
      this.$router.push("/login");
    }
    else
      this.Lay_DS_Nguoidung();
  },
  methods:{
    Lay_DS_Nguoidung(){
      var self=this;
      user.Lay_DS_Nguoidung().then( response =>{
        if(response.data.success){
          response.data.data.forEach(function(element,key){
            self.items_user.push({
              stt:key+1,
              ma_ND:element.ma_ND,
              ma_NV:element.ma_NV,
              ten_NV:element.ten_NV,
              so_DT:element.so_DT,
              nhanvien_ID:element.nhanvien_ID,
              trangThai:element.trangThai,
              ghiChu:element.ghiChu,
              ten_dv:element.ten_dv,
              ten_dvql:element.ten_dvql
            });
          });
          self.$store.commit("get_items_user", self.items_user);
        }
      }).catch(error=>{console.log(error)});
    },
  }
}
</script>
<style scoped></style>
