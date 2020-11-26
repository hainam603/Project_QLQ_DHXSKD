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
                  clearable
                  hide-details
                ></v-text-field>
              </v-card-title>
              <v-data-table
                :headers="headers_user"
                dense
                :search="search"
                :items="items_user"
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
import a from "../../css/style.css"
const user = factory.get("user");
export default {
  data(){
    return{
      selected_row:'',
      ma_ND:"",
      search: "",
      text: "",
      timeout: 2000,
      snackbar:false,
      loading_user:false,
      // headers_user: [],
      // items_user:[],
      headers_role: [
          { text: '', value: 'stt'},
          { text: 'ID Quyền', value: 'quyen_id'},
          { text: 'Quyền', value: 'ten_quyen'},
          { text: 'ID Nhóm ND', value: 'nhom_nd_id'},
          { text: 'Nhóm ND', value: 'ten_nhom'}
        ],
      items_role:[],
      
    }
  },
  created(){

  },
  computed: {
    items_user(){
       return this.$store.getters.return_items_user;
      
      this.loading_user=false;
      },
    headers_user(){return this.$store.getters.return_headers_user;}
  },
  methods:{
    Nguoidung_Click_Row(e,k){

      var self=this;
      self.selected_row=k;
      if(self.ma_ND!=e.ma_ND){
        self.items_role=[];
        user.Lay_DS_Quyen_Nguoidung(e.ma_ND).then(response=>{
          if(response.data.success)
          {
            response.data.data.forEach(function(value, key){
              self.items_role.push({
                stt:key+1,
                ma_nd:value.ma_nd,
                ten_nd:value.ten_nd,
                quyen_id:value.quyen_id,
                ten_quyen:value.ten_quyen,
                nhom_nd_id:value.nhom_nd_id,
                ten_nhom:value.ten_nhom
              });
            });
          }

          self.ma_ND=e.ma_ND;
        }).catch(error=>{});
      }
   },
    
  
  },
 
  

}
</script>

<style>
@import '../../css/style.css';
</style>