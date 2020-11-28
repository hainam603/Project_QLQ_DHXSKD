<template>
  <div>
    
      <v-row>
        <v-col>
          <v-card class="mx-auto" color="" light>
            <v-card-title class="info--text">
              <v-icon large left color="info">
                mdi-text-box-search-outline </v-icon
              >Danh sách quyền xem báo cáo của người dùng
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
                Danh sách nhóm báo cáo người dùng
              </v-card-title>
              <v-data-table
                :headers="headers_grp"
                :items="items_grp"
                :items-per-page="5"
              >
              <template v-slot:body="{ items }">
                <tbody>
                  <tr :class="key === selected_row_grp ? 'custom-highlight-row' : ''" 
                  @click="NhomBC_Click_Row(item,key)" 
                  v-for="(item, key) in items" 
                  :key="item.stt">
                    <td>{{ key+1 }}</td>
                    <td>{{ item.ten_nhom }}</td>
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
                Danh sách báo cáo
              </v-card-title>
              <v-data-table
                :headers="headers_rp"
                :items="items_rp"
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
      search: "",
      ma_ND:'',
      nhom_bc_id:'',
      selected_row_grp:null,
      selected_row:null,
      headers_user: [],
      items_user:[],
      headers_grp: [
          { text: '', value: 'stt'},
          { text: 'Nhóm báo cáo', value: 'chuc_nang'}
        ],
      items_grp:[],
      headers_rp: [
          { text: '', value: 'stt'},
          { text: 'Báo cáo', value: 'ten_bc'}
        ],
      items_rp:[],
      token:"",
    }
  },
  created(){
    this.token=kt.getTokenByLocal();

  },
  methods:{
    Nguoidung_Click_Row(e,k){
      var self=this;
      self.selected_row=k;
      if(self.ma_ND!=e.ma_nd){
        self.items_grp=[];
        user.Lay_DS_Nhombaocao_Nguoidung(e.ma_ND,self.token).then(response=>{
          if(response.data.success)
          {
           self.items_grp=response.data.data;
          }
          self.ma_ND=e.ma_ND;
        }).catch(error=>{});
      }
   },
   NhomBC_Click_Row(e,k){
      var self=this;
      self.selected_row_grp=k;
      if(self.nhom_bc_id!=e.nhom_bc_id){
        
        self.items_rp=[];
        user.Lay_DS_Baocao_Nguoidung(e.ma_nd, e.nhom_bc_id, self.token).then(response=>{
          if(response.data.success)
          {
 
            response.data.data.forEach((element,key) => {
              self.items_rp.push({
                stt:key+1,
                ma_nd:element.ma_nd,
                baocao_id:element.baocao_id,
                ten_bc:element.ten_bc,
                ten_nhom:element.ten_nhom
              });    
            }); 
          }
        self.nhom_bc_id=e.nhom_bc_id;
        }).catch(error=>{});
        
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