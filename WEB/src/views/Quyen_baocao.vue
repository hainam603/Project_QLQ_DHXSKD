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
        
        <v-col cols="4" >
        
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
                :headers="headers_users"
                :items="items_users"
                :search="search"
                :items-per-page="5"
                @click:row="handleClick"
              ></v-data-table>
            </v-card>
          </template>
              
        </v-col>

        <v-col cols="4">
           <template>
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách nhóm báo cáo người dùng
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
                Danh sách báo cáo
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
      headers_users: [
          { text: 'Tên nhân viên', value: 'ten_nv'},
          { text: 'Mã nhân viên', value: 'ma_vn' },
          { text: 'Đơn vị', value: 'ten_dv' },
        ],
      items_users:[
        {ten_nv:"Mai Đức Diễm Trang", ma_vn:"01761", ten_dv:"	ttvt"},
        {ten_nv:"Vũ Đình Thành", ma_vn:"20641", ten_dv:"	ttvt"},
        {ten_nv:"Vy Thị Huyền Chi", ma_vn:"02454", ten_dv:"	ttvt"},
        {ten_nv:"Võ Thị Ngọc Phương", ma_vn:"02509", ten_dv:"	ttvt"},
        {ten_nv:"Lê Thị Bích Thuận", ma_vn:"14246", ten_dv:"	ttvt"},
        {ten_nv:"Hoàng Thị Hoài Trang", ma_vn:"15201", ten_dv:"	ttvt"},
        {ten_nv:"Huỳnh Thu Hương", ma_vn:"totruong", ten_dv:"	ttvt"},
        {ten_nv:"Nguyễn Thị Bích Thủy", ma_vn:"00314", ten_dv:"	ttvt"},
        {ten_nv:"HUNG  VUONG CK THU NGAN 2", ma_vn:"hv2_ck", ten_dv:"	ttvt"},
        {ten_nv:"Vũ Thị Xuân Tú", ma_vn:"tuvtx", ten_dv:"ttvt"}
      ],
      headers_menu: [
          { text: '', value: 'stt'},
          { text: 'Nhóm báo cáo', value: 'chuc_nang'}
        ],
      items_menu:[
        {stt:"1",chuc_nang:"Báo cáo theo dõi dòng tiền thu cước, hoàn mạng, dịch vụ (HPG)"},
        {stt:"2",chuc_nang:"Báo cáo PTTB HCM phát triển"},
        {stt:"3",chuc_nang:"Kiểm kê công nợ"},
        {stt:"4",chuc_nang:"8 .Báo Cáo Kế Toán"},
        {stt:"5",chuc_nang:"TTCNTT Báo cáo quản lý vật tư"},
        {stt:"6",chuc_nang:"Kiểm kê công nợ"},
        {stt:"7",chuc_nang:"Báo cáo Outbound"},
        {stt:"8",chuc_nang:"2. Báo Cáo Bưu Cục_ Bưu Điện Trung Tâm và Bưu Điện Thành Phố"},
        {stt:"9",chuc_nang:"3. Báo Cáo Điểm Giao Dịch"},
        {stt:"10",chuc_nang:"Báo cáo thù lao thu cước - 2018"}
      ],
      headers_role: [
          { text: '', value: 'stt'},
          { text: 'Báo cáo', value: 'loai_nv'}
        ],
      items_role:[
        {stt:"1",loai_nv:"Báo cáo tổng hợp doanh thu"},
        {stt:"2",loai_nv:"Chi tiết Cước ĐNHM dịch vụ TSL"},
        {stt:"3",loai_nv:"Nguyên nhân thanh lý dịch vụ TSL "},
        {stt:"4",loai_nv:"01/PLNPTh - Bảng phân loại nợ phải thu"},
        {stt:"5",loai_nv:"01/XLPTh - Bảng tổng hợp các khoản phải thu khó đòi"},
        {stt:"6",loai_nv:"01/ĐCPTh - Danh sách đối tượng gửi thư xác nhận công nợ phải thu"},
        {stt:"7",loai_nv:"01TH - Báo cáo tổng hợp biến động nợ khách hàng (new)"},
        {stt:"8",loai_nv:"01_TTCUVT_Báo cáo tồn ONT mới (Tập Đoàn)"},
        {stt:"9",loai_nv:"02/ĐCPTh - Bảng phân công công việc gửi thư xác nhận"},
        {stt:"10",loai_nv:"026 C41-Khảo Sát Khách Hàng"},
        
      ]
    }
  },
  methods:{
    handleClick(e){
      console.log(e.ma_vn);
      // this.headers_menu[0].text = 'Nhóm báo cáo của người dùng ' + e.ten_nv;

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