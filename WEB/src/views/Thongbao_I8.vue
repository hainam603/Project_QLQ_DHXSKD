<template>
  <div>
    
      <!-- <v-row>
        <v-col>
          <v-card class="mx-auto" color="" light>
            <v-card-title class="info--text">
              <v-icon large left color="info">
              mdi-bell </v-icon
              >Danh sách thay đổi I8
              <v-spacer></v-spacer>
              <v-combobox
                hide-selected
                v-model="model"
                :items="items_chucnang"
              ></v-combobox>
            </v-card-title>
          </v-card>

        </v-col>
      </v-row> -->
      <v-row>

        <v-col cols="12" >
        
          <template >
            <v-card style="min-height: 490px;">
              <v-card-title>
              <v-icon large left color="info">
              mdi-bell </v-icon
              >
      
                  <el-select v-model="option_value" placeholder="Chọn 1 chức năng">
                    <el-option
                      v-for="item in options"
                      :key="item.value"
                      :label="item.label"
                      :value="item.value"
                    >
                    </el-option>
                  </el-select>
                  <div style="padding:0 5px;"></div>
                  <el-date-picker
                    v-model="dates"
                    type="daterange"  
                    start-placeholder="Ngày bắt đầu"
                    end-placeholder="Ngày kết thúc"
                    format="dd/MM/yyyy"
                    value-format="dd/MM/yyyy">
                  </el-date-picker>
                  <div style="padding:0 5px;"></div>
                  <el-button type="primary" @click="Click_Xem()">Xem</el-button>
  
              </v-card-title>
            
              <v-data-table
                :headers="headers_i8"
                :items="items_i8"
                :search="search"
                :items-per-page="5"
              ></v-data-table>
            </v-card>
          </template>
              
        </v-col>


       
      </v-row>
      <!-- popup thông báo -->
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
            >
              Đóng
            </v-btn>
          </template>
        </v-snackbar>
    

  </div>
</template>

<script>
import factory from "../services/factory/repositoryfactory";
const notification = factory.get("notification");
export default {
  data(){
    return{
      ruleForm:{
        option_value:'',
        dates:'',
      },
      rules:{
          option_value: [
              { required: true, message: 'Please select Activity zone', trigger: 'change' }
            ],
          dates: [
            { type: 'date', message: 'Please select Activity zone', trigger: 'change' }
          ],
      },

      options: [
        {
          value: '0',
          label: 'Thay đổi I8'
        },
        {
          value: '1',
          label: 'Nhân viên nghỉ việc'
        },
        ],
      option_value:"",

      dates:'',

      search: "",
      progress: "",
      currentFile:"",
      headers_i8: [
          { text: '', value: 'stt'},
          { text: 'Mã NV', value: 'ma_nv' },
          { text: 'Tên NV', value: 'ten_nv' },
          { text: 'Loại NV I8', value: 'loai_nv_i8' },
          { text: 'Mã NV tác động', value: 'ma_nd_tac_dong' },
          { text: 'Tên NV tác động', value: 'ten_nd_tac_dong' },
          { text: 'Tác động', value: 'flags' },
          { text: 'Ngày tác động', value: 'ngay_td' },
        ],
      items_i8:[],

      text:'',
      snackbar:false,
      timeout:2000
     
      
    }
  },
  methods:{
    Click_Xem(){
      
      var self=this;
      self.items_i8=[];
      var dates={"tu_ngay":self.dates[0], "den_ngay":self.dates[1]}
      if(self.option_value=='0'){
        self.snackbar= true;
        self.text= "Đang lấy dữ liệu...";
        notification.Lay_DS_Thaydoi_I8(dates).then(response =>{
          if(response.data.success){
            response.data.data.forEach((element, key) => {
              self.items_i8.push({
                stt:key+1,
                ma_nv:element.ma_nv,
                ten_nv:element.ten_nv,
                loai_nv_i8:element.loai_nv_i8,
                ma_nd_tac_dong:element.ma_nd_tac_dong,
                ten_nd_tac_dong:element.ten_nd_tac_dong,
                flags:element.flags,
                ngay_td:element.ngay_td
              });
            });
            self.snackbar= true;
            self.text= "Hoàn thành lấy dữ liệu";
          }
          else{
            self.snackbar= true;
            self.text= response.data.message;
          }
        }).catch();
      }
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