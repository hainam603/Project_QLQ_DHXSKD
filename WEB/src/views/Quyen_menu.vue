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
                ></v-text-field>
              </v-card-title>
              <v-data-table
                :headers="headers_user"
                :items="items_user"
                :search="search"
                :items-per-page="5"
                @click:row="handleClick"
              ></v-data-table>
            </v-card>
          </template>
              
        </v-col>

        <v-col cols="3">
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

        <v-col cols="4">
           <template>
            <v-card style="min-height: 490px;">
              <v-card-title>
                Thông tin người dùng
                <v-container>
                <v-row style="font-size:14px">
                  <v-row>
                    <v-col cols="4">
                      Nhân viên:
                    </v-col>
                    <v-col cols="8">
                      HCM021012 - Lê Bùi Hải Nam
                    </v-col>
                  </v-row>
                  <v-row>
                    <v-col cols="4">
                      Nhóm người dùng:
                    </v-col>
                    <v-col cols="8">
                      Phát triển hệ thống
                    </v-col>
                  </v-row>
                </v-row>
                </v-container>
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
export default {
  data(){
    return{
      search: "",
      headers_user: [],
      items_user:[],
      headers_menu: [
          { text: 'Menu Chức năng', value: 'chuc_nang'}
        ],
      items_menu:[
        {chuc_nang:"Hệ thống"},
        {chuc_nang:"Quản trị"},
        {chuc_nang:"Dữ liệu"},
        {chuc_nang:"Lập hợp đồng"},
        {chuc_nang:"HĐ chưa phân công ĐV"},
        {chuc_nang:"Gạch nợ"},
        {chuc_nang:"Quản lý đại lý"},
        {chuc_nang:"Cabman"},
        {chuc_nang:"Thanh toán"},
        {chuc_nang:"Quản lý địa bàn"}
      ],
      headers_role: [
          { text: 'STT', value: 'stt'},
          { text: 'Loại nhân viên', value: 'loai_nv'}
        ],
      items_role:[
        {stt:"1",loai_nv:"Cộng tác viên"},
        {stt:"2",loai_nv:"Quản trị hệ thống"},
        {stt:"3",loai_nv:"Nhân viên tiếp thị"},
        {stt:"4",loai_nv:"CTV - Thu hồi thiết bị"},
      ]
    }
  },
  methods:{
    handleClick(e){
      console.log(e.ma_vn);
      this.headers_menu[0].text = 'Menu chức năng của người dùng ' + e.ten_nv;

    }
  },
  mounted () {
    this.items_user=this.$store.getters.return_items_user;
    this.headers_user=this.$store.getters.return_headers_user;
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