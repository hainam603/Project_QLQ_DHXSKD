<template>
  <div>
    
      <v-row>
        <v-col>
          <v-card class="mx-auto" color="" light>
            <v-card-title class="info--text">
              <v-icon large left color="info">
                mdi-shield-key-outline
              </v-icon
              >Quản trị
              <v-spacer></v-spacer>
              
            </v-card-title>
          </v-card>

        </v-col>
      </v-row>
      <v-row>
        
        <v-col cols="4" >
        
          <template >
            <v-card style="min-height: 490px;">
              <v-card-title>
                Quyền
                <v-spacer></v-spacer>
                <v-text-field
                  v-model="search"
                  append-icon="mdi-magnify"
                  label="Tìm kiếm"
                  single-line
                  hide-details
                  clearable
                ></v-text-field>
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  @click="dialogAddRole=true"
                >
                  Thêm
                </v-btn>
              </v-card-title>
              <v-data-table
                :headers="headers_role"
                :items="items_role"
                :search="search"
                :items-per-page="5"
              >
              <template v-slot:body="{ items }">
                <tbody>
                  <tr :class="key === selected_row ? 'custom-highlight-row' : ''" 
                  @click="Role_Click_Row(item,key)" 
                  v-for="(item, key) in items" 
                  :key="item.stt">
                    <td>{{ key+1 }}</td>
                    <td>{{ item.quyen_id }}</td>
                    <td>{{ item.ten_quyen }}</td>
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
                Người dùng
                <v-spacer/>
                <v-btn
                  color="primary"
                  v-if="quyen_id"
                  @click="quyen_id ? dialogAddUser=true : ''"
                >
                  Thêm
                </v-btn>
                <v-spacer v-if="ma_nd"/>
                <v-btn
                  color="primary"
                  v-if="ma_nd"
                  @click="quyen_id ? dialogGoNguoidung=true : ''"
                >
                  Gỡ
                </v-btn>
              </v-card-title>
              <v-data-table
                :headers="headers_roleuser"
                :items="items_roleuser"
                :items-per-page="-1"
              >
               <template v-slot:body="{ items }">
                <tbody>
                  <tr :class="key === selected_rowroleuser ? 'custom-highlight-row' : ''" 
                  @click="RoleUser_Click_Row(item,key)" 
                  v-for="(item, key) in items" 
                  :key="item.stt">
                    <td>{{ key+1 }}</td>
                    <td>{{ item.ma_nd }}</td>
                    <td>{{ item.ten_nd }}</td>
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
                Chức năng 
                <v-spacer/>
                <v-btn
                  color="primary"
                  @click="dialog=true"
                  v-if="quyen_id"
                >
                  Lưu
                </v-btn>
              </v-card-title>
              <v-data-table
                :headers="headers_function"
                :items="items_function"
                :items-per-page="-1"
                v-model="selected_function"
                :single-select="singleSelect_function"
                item-key="chucnang_id"
                show-select
              >
              </v-data-table>
            </v-card>
          </template>     
        </v-col>
      </v-row>
      <v-row>
        <!-- Dialog cập nhật quyền -->
        <v-dialog
          v-model="dialog"
          persistent
          max-width="290"
        >
          <v-card>
            <v-card-title class="headline">
              Cập nhật quyền
            </v-card-title>
            <v-card-text>Thự hiện cập nhật?</v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="green darken-1"
                text
                @click="dialog = false"
              >
                Không
              </v-btn>
              <v-btn
                color="green darken-1"
                text
                @click="updateDecentralization()"
              >
                Đồng ý
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-row>
       <v-row>
        <!-- Dialog gỡ người dùng -->
        <v-dialog
          v-model="dialogGoNguoidung"
          persistent
          max-width="290"
        >
          <v-card>
            <v-card-title class="headline">
              Gỡ bỏ người dùng
            </v-card-title>
            <v-card-text>Thự hiện gỡ?</v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="green darken-1"
                text
                @click="dialogGoNguoidung = false"
              >
                Không
              </v-btn>
              <v-btn
                color="green darken-1"
                text
                @click="GoNguoidung()"
              >
                Đồng ý
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-row>
      <v-row>
        <!-- Popup hiện thông báo -->
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
      </v-row>

      <v-row justify="center">
        <!-- Dialog thêm mới quyền -->
        <v-dialog
          v-model="dialogAddRole"
          persistent
          max-width="400px"
        >
          <v-card>
            <v-card-title>
              <span class="headline">Thêm mới quyền</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row> 
                  <v-col cols="12">
                    <v-text-field
                      label="Tên quyền"
                      :rules="rules.name"
                      v-model="rolename"
                      required
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue darken-1"
                text
                @click="dialogAddRole = false"
              >
                Đóng
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="rolename ? ThemQuyen() : '' "
              >
                Thêm mới
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>

      </v-row>
      <v-row justify="center">
        <!-- Dialog thêm mới quyền -->
        <v-dialog
          v-model="dialogAddUser"
          persistent
          max-width="800px"
        >
          <template >
            <v-card style="min-height: 400px;">
              <v-card-title>
                Người dùng
                <v-spacer></v-spacer>
                <v-text-field
                  v-model="search_user"
                  append-icon="mdi-magnify"
                  label="Tìm kiếm"
                  single-line
                  hide-details
                  clearable
                ></v-text-field>
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  @click="selected_user.length ? Them_Nguoidung() : ThongbaoNDRong()"
                >
                  Thêm
                </v-btn>
               
                <v-spacer></v-spacer>
               
                <v-btn
                  color="primary"
                  @click="dialogAddUser=false"
                >
                  Đóng
                </v-btn>
              </v-card-title>
              <v-data-table
                :headers="headers_user"
                :items="items_user"
                :search="search_user"
                :items-per-page="5"
                v-model="selected_user"
                :single-select="singleSelect_user"
                item-key="ma_ND"
                show-select
               
              > 
              </v-data-table>
             
            </v-card>
             
          </template>
         
        </v-dialog>

      </v-row>
    

  </div>
</template>

<script>
import kt from "../services/Kiemtra_Session";
import factory from "../services/factory/repositoryfactory";
const role = factory.get("role");
export default {
  data(){
    return{
      //dialogGonguoidung
      dialogGoNguoidung:false,

      //dialogAddUser
      dialogAddUser:false,
      headers_user: [],
      items_user:[],
      search_user:'',
      selected_user:[],
      singleSelect_user:true,

      //dialogAddRole
      dialogAddRole:false,
      rules: {
          name: [val => (val || '').length > 0 || 'Nhập tên quyền'],
        },
      rolename:'',

      
      //Quyền
      search: "",
      headers_role: [],
      items_role:[],
      //Người dùng
      headers_roleuser: [],
      items_roleuser:[],

      //Chức năng
      dialog: false,
      selected_row:null,
      selected_rowroleuser:null,
      selected_function: [],
      headers_function: [],
      items_function:[],
      singleSelect_function: false,
      //main
      quyen_id:'',
      ma_nd:'',
      ma_nd_moi:'',
      token:'',
      ma_nd_login:'',
      
      //popup
      snackbar: false,
      text: "",
      timeout: 2000,
    }
  },
  watch:{
    search: function(){
      this.quyen_id='';
      this.selected_function=[];
    },

  },
  created(){
    var self=this;
    var tok=kt.getTokenByLocal();
    self.token=tok.token;
    self.ma_nd_login=tok.usid;
    self.Lay_DS_Quyen();
    self.Lay_DS_Chucnang();
    
  },

  methods:{
    Them_Nguoidung(){
      var self=this;
      var phanquyen={ma_nd:self.selected_user[0].ma_ND.trim(), ten_nd: self.selected_user[0].ten_NV, quyen_id: self.quyen_id};
      role.Them_Phanquyen_Nguoidung(phanquyen,self.token).then(response=>{
        if(response.data.success){
          self.text="Thêm người dùng thành công";
          self.snackbar=true;
          self.Lay_DS_Nguoidung_Theo_Quyen(self.quyen_id,self.token);
        }else{
          self.text="Người dùng đã được phân quyền";
          self.snackbar=true;
        }

      }).catch();
    },
    ThongbaoNDRong(){
      
      var self = this;
      self.text="Chưa chọn người dùng nào";
      self.snackbar=true;
    },

    ThemQuyen(){
      var self=this;
      self.dialogAddRole=false;
      var quyenModel = {ten_quyen:self.rolename.trim()};
      role.Them_Quyen(quyenModel, self.token).then(response=>{
        debugger;
        if(response.data.success)
        {

          self.Lay_DS_Quyen();
        }
      }).catch();
    },
    GoNguoidung(){
      var self=this;
      self.dialogGoNguoidung=false;
 
      if(self.ma_nd.trim()==self.ma_nd_login.trim()){
        self.text="Không thể gỡ người dùng đang đăng nhập";
        self.snackbar=true;
      }else{
        var phanquyen={ma_nd:self.ma_nd.trim(),quyen_id:self.quyen_id};
        role.Xoa_Phanquyen_Nguoidung(phanquyen,self.token).then(response=>{
          if(response.data.success){
            self.text="Gỡ người dùng thành công";
            self.snackbar=true;
            self.Lay_DS_Nguoidung_Theo_Quyen(self.quyen_id,self.token);
          }else{
            self.text=response.data.message;
            self.snackbar=true;
          }
        }).catch();

      }

    },
    checkItemSelectedUser(){

    },

    updateDecentralization(){
        var self=this;
        self.dialog=false;
        var param={"quyen_id":self.quyen_id,"ds_chucnang":(self.selected_function)}
        role.Them_Quyen_Sudung_Chucnang(param,self.token).then( response => {
          if(response.data.success){
            self.snackbar=true;
            self.text="Cập nhật thành công";
          }else{
            self.snackbar=true;
            self.text="Có lỗi xảy ra, vui lòng thử lại sau";
          }
        }).catch();
        
    },
    Lay_DS_Quyen()
    {
      var self=this;
      role.Lay_DS_Quyen(self.token).then(response =>{
        if(response.data.success)
        {
          self.headers_role = [
            { text: '', value: 'stt'},
            { text: 'ID', value: 'quyen_id'},
            { text: 'Quyền', value: 'ten_quyen'},
          ],
          self.items_role=response.data.data;
        }
      }).catch();

    },
    Lay_DS_Chucnang(){
      var self=this;
      role.Lay_DS_Chucnang(self.token).then(response =>{

          self.headers_function = [
            { text: 'ID', value: 'chucnang_id'},
            { text: 'Chức năng', value: 'title'},
            { text: 'Top menu', value: 'menu'},
          ],
          self.items_function=response.data;
          
      }).catch();
    },
    RoleUser_Click_Row(e,k){
      var self=this;
      self.selected_rowroleuser=k;
      self.ma_nd=e.ma_nd;
    },
    Role_Click_Row(e,k){
      var self=this;
      self.selected_row=k;
      self.ma_nd='';
      if(self.quyen_id!=e.quyen_id){
        self.selected_function=[];
        self.items_RoleUser=[];

        /////////////////////////////////////////////////////////////////////////
        role.Lay_DS_Chucnang_Theo_Quyen_ID(e.quyen_id,self.token).then(response=>{
          if(response.data.success)
          {
            if(response.data.data.length)
            {
              self.selected_function=response.data.data;
            }
          }
          self.quyen_id=e.quyen_id;
        }).catch(error=>{});
        /////////////////////////////////////////////////////////////////////////
        self.Lay_DS_Nguoidung_Theo_Quyen(e.quyen_id,self.token);
        
      }
   },
   Lay_DS_Nguoidung_Theo_Quyen(quyen_id,token){

     var self=this;

     role.Lay_DS_Nguoidung_Theo_Quyen(quyen_id,token).then(response=>{
          if(response.data.success){
            self.headers_roleuser=[
              { text: '', value: 'stt'},
              { text: 'Mã ND', value: 'ma_nd'},
              { text: 'Tên ND', value: 'ten_nd'},
            ],
            self.items_roleuser=response.data.data;

          }
        }).catch();
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