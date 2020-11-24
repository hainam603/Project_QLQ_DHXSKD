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
                @change="selectFile"
                accept=".xlsx, .xls"
                prepend-icon="mdi-file-excel"
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
      progress: "",
      currentFile:"",
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
      
    }
  },
  methods:{
    handleClick(e){
      console.log(e.ma_vn);
      this.headers_menu[0].text = 'Menu chức năng của người dùng ' + e.ten_nv;

    },
    selectFile(file) {
      var self=this;
        if(file){
            if((file.type == 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet') 
                || (file.type == 'application/vnd.ms-excel')){
                self.import_data_from_excel();
            } else {
                self.$message({
                    type:'warning',
                    message:'File không đúng định dạng'
                })
            }
        } 
    },

    import_data_from_excel() {
          let self = this;
          let inputDOM = self.$refs.inputer;
          // Retrieving file data through DOM

          self.file = event.currentTarget.files[0];

          var rABS = false; //Read the file as a binary string
          var f = self.file;

          var reader = new FileReader();
          //if (!FileReader.prototype.readAsBinaryString) {
          FileReader.prototype.readAsBinaryString = function(f) {
              var binary = "";
              var rABS = false; //Read the file as a binary string
              var pt = self;
              var wb; //Read completed data
              var outdata;
              var reader = new FileReader();
              reader.onload = function(e) {
                  var bytes = new Uint8Array(reader.result);
                  var length = bytes.byteLength;
                  for (var i = 0; i < length; i++) {
                      binary += String.fromCharCode(bytes[i]);
                  }
                  //If not introduced in main.js, you need to introduce it here to parse excel
                  var XLSX = require("xlsx");
                  if (rABS) {
                      wb = XLSX.read(btoa(fixdata(binary)), {
                      //Manual conversion
                      type: "base64"
                      });
                  } else {
                      wb = XLSX.read(binary, {
                      type: "binary"
                      });
                  }
                  outdata = XLSX.utils.sheet_to_json(wb.Sheets[wb.SheetNames[0]]); 
                  if("MA_TB" in outdata[0])
                  {
                    var arr_ma_tb=[];
                    outdata.forEach(function(element,key){
                      arr_ma_tb.push(
                        element.MA_TB
                      )
                    });
                    console.log(arr_ma_tb);
                  }else
                  {
                    self.$message({
                    type:'warning',
                    message:"File vừa tải lên không có dữ liệu 'MA_TB'"
                })
                  }
              };
              reader.readAsArrayBuffer(f);
          };
          if (rABS) {
              reader.readAsArrayBuffer(f);
          } else {
              reader.readAsBinaryString(f);
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