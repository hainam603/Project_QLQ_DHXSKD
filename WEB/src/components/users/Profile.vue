<template>
  <div>
    
      <v-row>
        <v-col>
          <v-card class="mx-auto" color="" light>
            <v-card-title class="info--text">
              <v-icon large left color="info">
                mdi-account-box-multiple-outline </v-icon
              >Danh sách người dùng
              <v-spacer></v-spacer>
              
            </v-card-title>
          </v-card>

        </v-col>
      </v-row>
      <v-row>
        
        <v-col cols="5" >
        
          <template >
            <v-card :loading="loading_user" style="min-height: 490px;">
              <v-card-title>
                Danh sách người dùng
                <v-spacer></v-spacer>
                <v-text-field
                  v-model="search"
                  append-icon="mdi-magnify"
                  label="Tìm kiếm người dùng"
                  single-line
                  hide-details
                ></v-text-field>
              </v-card-title>
              <v-data-table
                :headers="headers_users"
                :items="items_user"
                :search="search"
                :items-per-page="5"
                @click:row="Nguoidung_Click"
              ></v-data-table>
            </v-card>
          </template>
              
        </v-col>

        <v-col cols="7">
           <template>
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách quyền người dùng
              </v-card-title>
              <v-data-table
                :headers="headers_role"
                :items="items_role"
                :items-per-page="5"
              >
              
              </v-data-table>
            </v-card>
          </template>     
        </v-col>
      </v-row> 
  </div>
  
</template>

<script>
import factory from "../../services/factory/repositoryfactory";
const user = factory.get("user");
export default {
  data(){
    return{
      nhanvien_ID:"",
      search: "",
      text: "",
      timeout: 2000,
      snackbar:false,
      loading_user:false,
      headers_users: [
          { text: '', value: 'stt'},
          { text: 'Nhân viên ID', value: 'nhanvien_ID'},
          { text: 'Tên NV', value: 'ten_NV' },
          { text: 'Đơn vị', value: 'ten_dv' },
        ],
      items_user:[],
      headers_role: [
          { text: '', value: 'stt'},
          { text: 'Mã ND', value: 'ma_nd'},
          { text: 'Tên ND', value: 'ten_nd'},
          { text: 'ID Quyền', value: 'quyen_id'},
          { text: 'Quyền', value: 'ten_quyen'},
          { text: 'ID Nhóm quyền', value: 'nhom_nd_id'}
        ],
      items_role:[],
      
    }
  },
  created(){
    
  },
  mounted () {
    this.items_user=this.$store.getters.return_items_user;
  },
  methods:{
      Nguoidung_Click(e){
        
      var self=this;
      if(self.nhanvien_ID!=e.nhanvien_ID){
        self.items_role=[];
        user.Lay_DS_Quyen_Nguoidung(e.nhanvien_ID).then(response=>{
          if(response.data.success)
          {
            response.data.data.forEach(function(value, key){
              self.items_role.push({
                stt:key+1,
                ma_nd:value.ma_nd,
                ten_nd:value.ten_nd,
                quyen_id:value.quyen_id,
                ten_quyen:value.ten_quyen,
                nhom_nd_id:value.nhom_nd_id
              });
            });
          }
          self.nhanvien_ID=e.nhanvien_ID;
        }).catch(error=>{});
      }
    }
  
  },
 
  

}
</script>

<style>
.v-text-field {
  padding-top: 0px;
  margin-top: 0px;
}
.v-data-table > .v-data-table__wrapper > table > thead > tr > th{
  font-size: 1rem;
  height: 35px;
}
</style>