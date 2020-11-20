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

        <v-col cols="8">
           <template>
            <v-card style="min-height: 490px;">
              <v-card-title>
                Danh sách quyền người dùng
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

        <!-- <v-col cols="4">
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
        </v-col> -->
      </v-row> 
    

  </div>
</template>

<script>
import { mapActions } from "vuex";
import { mapGetters } from "vuex";
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
          { text: 'ID quyền', value: 'id_quyen'},
          { text: 'Tên quyền', value: 'ten_quyen'},
          { text: 'Nhóm quyền', value: 'nhom_quyen'}
        ],
      items_menu:[
        {stt:"1",id_quyen:"893",ten_quyen:"Dự án tiếp thị đầu tư",nhom_quyen:"Phát triển hệ thống"},
        {stt:"2",id_quyen:"60",ten_quyen:"Tổ trường - Giải quyết khiếu nại",nhom_quyen:"Quản trị module PTTB"},
        {stt:"3",id_quyen:"2001",ten_quyen:"VNPT-Cab - Tổ trưởng",nhom_quyen:"Quản trị hệ thống"},
        {stt:"4",id_quyen:"963",ten_quyen:"Upload file hồ sơ điện tử (GDV, trạm)",nhom_quyen:"Phát triển hệ thống"},
        {stt:"5",id_quyen:"801",ten_quyen:"Tra cứu - Báo cáo",nhom_quyen:"Tra cứu - Báo cáo"},
        {stt:"6",id_quyen:"2001",ten_quyen:"VNPT-Cab - Tổ trưởng",nhom_quyen:"Phòng KTĐH TTVT"},
        {stt:"7",id_quyen:"2238",ten_quyen:"VNPT-Cab - Chăm sóc khách hàng (B2A)",nhom_quyen:"Quản trị hệ thống"},
        {stt:"8",id_quyen:"9100",ten_quyen:"VNPT-Cab - Thu thập thông tin thị trường (Rada)",nhom_quyen:"Lãnh đạo đơn vị"},
        {stt:"9",id_quyen:"893",ten_quyen:"Tổ trường - Giải quyết khiếu nại",nhom_quyen:"Quản lý Đại lý - Tổ trưởng"},
        {stt:"10",id_quyen:"9109",ten_quyen:"VNPT-Cab - Ví VNPTPay",nhom_quyen:"Quản trị hệ thống"},
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
    ...mapActions(["lay_ds_nguoidung"]),
    Lay_DS_NguoiDung(){
      try{
      this.lay_ds_nguoidung({});
      } catch(err) {
        console.log(err);
        }

    },




    handleClick(e){
      console.log(e.ma_vn);
      // this.headers_menu[0].text = 'Nhóm báo cáo của người dùng ' + e.ten_nv;

    }
  }
  ,
  created(){
    this.Lay_DS_NguoiDung();
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