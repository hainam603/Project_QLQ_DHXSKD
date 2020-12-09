<template>
  <div>
    
      <v-row>
        <v-col>
          <v-card class="mx-auto" color="" light>
            <v-card-title class="info--text">
              <v-icon large left color="info">
                mdi-menu-open </v-icon
              >Danh sách quyền xem menu của người dùng
              <v-spacer></v-spacer>
              
            </v-card-title>
          </v-card>

        </v-col>
      </v-row>
      <v-row>
        
        <v-col cols="5" >
        
          <template >
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách người dùng
                <v-spacer></v-spacer>
                <v-text-field
                  v-model="search"
                  append-icon="mdi-magnify"
                  label="Tìm kiếm người dùng"
                  single-line
                  hide-details
                  clearable
                ></v-text-field>
              </v-card-title>
              <v-data-table
                :headers="headers_user"
                :items="items_user"
                :search="search"
                :items-per-page="5"
              >
              <template v-slot:body="{ items }">
                <tbody>
                  <tr :class="key === selected_row ? 'custom-highlight-row' : ''" 
                  @click="Nguoidung_Click_Row(item,key)" 
                  v-for="(item, key) in items" 
                  :key="item.stt">
                    <td>{{ key+1 }}</td>
                    <td>{{ item.ma_ND }}</td>
                    <td>{{ item.ten_NV }}</td>
                    <td>{{ item.ten_dv }}</td>
                  </tr>
                </tbody>
              </template>
              </v-data-table>
            </v-card>
          </template>
              
        </v-col>

        <v-col cols="3.5">
           <template>
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách menu người dùng
              </v-card-title>
              <v-data-table
                :headers="headers_menu"
                :items="items_menu"
                :items-per-page="5"
              >
              
              </v-data-table>
            </v-card>
          </template>     
        </v-col>

        <v-col cols="3.5">
           <template>
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách loại nhân viên
              </v-card-title>
              <v-data-table
                :headers="headers_toe"
                :items="items_toe"
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
import kt from "../services/Kiemtra_Session";
import factory from "../services/factory/repositoryfactory";
const user = factory.get("user");
export default {
  data(){
    return{
      selected_row:null,
      ma_ND:'',
      search: "",
      headers_user: [],
      items_user:[],
      headers_menu: [
          { text: '', value: 'stt'},
          { text: 'Menu', value: 'ten_hienthi'}
        ],
      items_menu:[],
      headers_toe: [
          { text: '', value: 'stt'},
          { text: 'Loại nhân viên', value: 'ten_loainv'}
        ],
      items_toe:[],
      token:'',
    }
  },
  created(){
    var self=this;
    var tok=kt.getTokenByLocal();
    self.token=tok.token;
  },
  methods:{
   Nguoidung_Click_Row(e,k){
      var self=this;
      self.selected_row=k;
      if(self.ma_ND!=e.ma_ND){
        self.items_menu=[];
        self.items_toe=[];
        user.Lay_DS_Menu_Nguoidung(e.ma_ND,self.token).then(response=>{

          if(response.data.success)
          {
            response.data.data.forEach(function(value, key){
              self.items_menu.push({
                stt:key+1,
                ma_nd:value.ma_nd,
                ten_nd:value.ten_nd,
                menu_id:value.menu_id,
                ten_hienthi:value.ten_hienthi
              });
            });
          }
          self.ma_ND=e.ma_ND;
        }).catch(error=>{});
        user.Lay_DS_LoaiNV_Nguoidung(e.ma_ND,self.token).then(response=>{
          if(response.data.success)
          response.data.data.forEach((element,key) => {
            self.items_toe.push({
                stt:key+1,
                ma_nd:element.ma_nd,
                loainv_id:element.loainv_id,
                ten_loainv:element.ten_loainv,
              });
          });
        }).catch();
      }
   },
  
  },
  mounted () {
    // this.items_user=this.$store.getters.return_items_user;
    this.items_user= JSON.parse(localStorage.ds_nguoidung);
    this.headers_user=this.$store.getters.return_headers_user;
  },

}
</script>

<style>
@import '../css/style.css';
</style>