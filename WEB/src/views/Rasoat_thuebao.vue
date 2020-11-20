<template>
  <div>
    
      <v-row>
        <v-col>
          <v-card class="mx-auto" color="" light>
            <v-card-title class="info--text">
              <v-icon large left color="info">
              mdi-book-search-outline </v-icon
              >Rà soát thuê bao không ghép được cước
              <v-spacer></v-spacer>
              
            </v-card-title>
          </v-card>

        </v-col>
      </v-row>
      <v-row>
        <v-col cols="1">
        </v-col>
        <v-col cols="10" >
        
          <template >
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách thuê bao không ghép được cước
               <v-file-input style="padding:0px 50px;"
                label="Tải lên danh sách thuê bao"
                truncate-length="15"
                ></v-file-input>
                <v-btn
                color="primary"
                elevation="2"
                medium
                >Xuất ra Excel</v-btn>
              </v-card-title>
              <v-data-table
                :headers="headers_tb"
                :items="items_tb"
                :search="search"
                :items-per-page="5"
                @click:row="handleClick"
              ></v-data-table>
            </v-card>
          </template>
              
        </v-col>
        <v-col cols="1">
        </v-col>

       
      </v-row>
    

  </div>
</template>

<script>
export default {
  data(){
    return{
      search: "",
      headers_tb: [
          { text: '', value: 'stt'},
          { text: 'ID thuê bao', value: 'thuebao_id' },
          { text: 'Tên thuê bao', value: 'ten_tb' },
          { text: 'Dịch vụ', value: 'dichvu' },
          { text: 'Ngày cập nhật', value: 'ngay_cn' },
          { text: 'Ngày thêm vào', value: 'ngay_ins' },
        ],
      items_tb:[
            {stt:"1",thuebao_id:"2707242",ten_tb:"NGUYEN DUY ANH",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"2",thuebao_id:"2872892",ten_tb:"NGUYEN VAN DUC",dichvu:"Fiber",ngay_cn:"",ngay_ins:"05-MAY-15"},
            {stt:"3",thuebao_id:"2712925",ten_tb:"NGUYEN THI TY",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"4",thuebao_id:"2712111",ten_tb:"NGUYEN THI KIM CHUNG",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"5",thuebao_id:"2896051",ten_tb:"PHAM THI HIEU NHI",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"6",thuebao_id:"2894590",ten_tb:"PHUNG THI CAM CAT",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"7",thuebao_id:"2897095",ten_tb:"DUONG VAN BINH",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"8",thuebao_id:"2712010",ten_tb:"TRAN THI HONG DIEP",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"9",thuebao_id:"2890227",ten_tb:"LY NGUYEN TICH",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"},
            {stt:"10",thuebao_id:"2891885",ten_tb:"NGUYEN BA HIEN",dichvu:"Fiber",ngay_cn:"05-MAY-15",ngay_ins:"05-MAY-15"}        
      ],
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
  }

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