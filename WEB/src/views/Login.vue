<template>
  <v-container id="signinup-form" class="fill-height">
    <!-- <Notification
      :message="snackbarMessage"
      :snackbar="snackbar"
      :type="snackbarType"
    /> -->
    <v-row align="center" justify="center" no-gutters>
      <v-col cols="12" sm="8" md="8" class="">
        <v-card :loading="loading" class="evelation-12 card">
          <v-window v-model="step">
            <!--SignIn-->
            <v-window-item :value="1">
              <v-row class="">
                <v-col cols="12" md="8" class="pt-6 pb-6">
                  <v-card-text>
                    <v-form
                      v-model="valid"
                      class="signup-form-form"
                      @submit.prevent="Click_Login"
                    >
                      <h1
                        class="text-center display-1 mb-10"
                        :class="`${bgColor}--text`"
                      >
                        Login
                      </h1>

                      <v-text-field
                        id="username"
                        v-model="username"
                        label="Mã người dùng"
                        name="Username"
                        append-icon="mdi-account"
                        type="text"
                        outlined
                        :counter="10"
                        :rules="nameRules"
                        required
                      />
                      <v-text-field
                        id="password"
                        v-model="password"
                        label="Mật khẩu"
                        name="Password"
                        outlined
                        append-icon="mdi-lock"
                        type="password"
                        :rules="pwdRules"
                        required
                      />
                      <div class="text-center">
                        <a
                          class="mt-3 no-text-decoration font-italic"
                          :class="`${bgColor}--text`"
                        >
                          Chương trình sử dụng account ĐHSXKD để đăng nhập
                        </a>
                      </div>
                      <div class="text-center mt-6">
                        <v-btn
                          type="submit"
                          large
                          :color="bgColor"
                          dark
                          :disabled="!valid"
                          >Đăng nhập</v-btn
                        >
                      </div>
                    </v-form>
                  </v-card-text>
                </v-col>
                <v-col
                  cols="12"
                  md="4"
                  class="darken-2 vcenter"
                  :class="`${bgColor}`"
                >
                  <div>
                    <v-card-text :class="`${fgColor}--text`">
                      <h1 class="text-center headline mb-3">Cấp quyền?</h1>
                      <h5 class="text-center mb-3">
                        Vui lòng liên hệ Admin TTCNTT
                      </h5>
                    </v-card-text>
                    <div class="text-center mb-6">
                    </div>
                  </div>
                </v-col>
              </v-row>
            </v-window-item>
          </v-window>
        </v-card>
      </v-col>
    </v-row>
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
  </v-container>
  
</template>

<script>
import factory from "../services/factory/repositoryfactory";
import kt_session from "../services/Kiemtra_Session";
const auth = factory.get("auth");
const role = factory.get("role");
const user = factory.get("user");
const kt = kt_session;
export default {
  name: "Login",

  components: {},
  props: {
    source: {
      type: String,
      default: "",
    },
    bgColor: {
      type: String,
      default: "indigo",
    },
    fgColor: {
      type: String,
      default: "white",
    },
  },

  data: () => ({
    // code của anh Linh
    step: 1,
    isLoggedin:true,
    username: "",
    password: "",
    loading: false,
    snackbarType: "success",
    snackbarMessage: "",
    snackbar: false,
    showError: false,
    valid: true,
    error: null,
    nameRules: [
      (v) => !!v || "Mã người dùng không được bỏ trống",
      (v) => (v && v.length >= 5) || "Mã người dùng ít nhất 5 kí tự",
    ],
    pwdRules: [(v) => !!v || "Mật khẩu không được bỏ trống"],


    // code của Nam
    token: "", //save token

    snackbar: false,
    text: "",
    timeout: 2000,
  }),
  created(){
    this.kiemtra_session();
  },
  methods: {
    kiemtra_session()
    {
      if(kt.get_token_session())
        this.$router.push("/home");
    },
    async Click_Login(){
      var self=this;
      self.loading=true;
      self.text="Đang kiểm tra dữ liệu đăng nhập";
      self.snackbar=true;
      var result1 = await this.login();  
      if(result1.code==1)
      {
      self.text="Đăng nhập thành công, đang kiểm tra quyền của người dùng";
      self.snackbar=true;
      var result2 = await this.lay_quyen_nguoidung(this.username, result1.value.token);
      
        if(result2.code==1){
          self.text="Kiểm tra quyền người dùng thành công, đang cài đặt ứng dụng";
          self.snackbar=true;
          var result3 = await this.lay_ds_nguoidung(result1.value.token);
          var result4 = await this.Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(result2.value, result1.value.token);
          var result5 = await this.Lay_DS_Chucnang_Theo_DS_Chucnang_ID(result4.value.dschucnang, result1.value.token);
          if(result3.code+result4.code+result5.code != 3){
            self.text="Đã có lỗi xảy ra khi cài đặt ứng dụng, liên hệ admin để xử lý";
            self.snackbar=true;
            self.timeout=-1;
            document.cookie = "token_session=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
            localStorage.setItem('ds_nguoidung','');
            localStorage.ds_chucnang='';
          }else{
            self.text="Cài đặt hoàn tất, đang vào ứng dụng";
            self.snackbar=true;
            window.location.href = "/";
          }

          
        }else{
          self.text="Người dùng không có quyền truy cập, liên hệ admin để xử lý";
          self.snackbar=true;
          document.cookie = "token_session=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
        }
      }else{
        self.text="Đăng nhập không thành công, kiểm tra lại thông tin người dùng, hoặc liên hệ admin để xử lý";
        self.snackbar=true;
      }
      self.loading=false;
    },
    login()
    {
      var self=this;
      var user={ma_ND:self.username, Matkhau:self.password};
      var result = auth.auth(user).then(response=>{
        if (response.data.success && response.data != null) {
            var value = {
                usid: response.data.data.nguoidung.ma_ND,
                token: response.data.data.token.access_token
            };
            var today = new Date();
            var nexthour = new Date();
            nexthour.setDate(today.getDate() + response.data.data.token.expires_in/86400);
            
            document.cookie = "token_session=" + JSON.stringify(value) + ";expires =" +nexthour +"";

            return {"code":1, "value":value};
            
        }
        else
          return {"code":0,"value":null};
      })
      .catch(error => {
          return {"code":0,"value":error};
      });  
      
      return result;
    },
    lay_quyen_nguoidung(ma_nd,token){
      var self=this;
      var result = role.Lay_Quyen_Nguoidung(ma_nd,token).then(response=>{
        if(response.data.success && response.data.data != null){
            return {"code":1, "value":response.data.data.quyen_id};
        }else
          return {"code":0,"value":null};
      }).catch(error=>{
        return {"code":0, "value": error};
      });
      return result;
    },
    lay_ds_nguoidung(token)
    {
      var self=this;
      var result = user.Lay_DS_Nguoidung(token).then( response =>{
        
        if(response.data.success){
          //self.$store.commit("get_items_user", response.data.data);
            localStorage.setItem("ds_nguoidung",JSON.stringify(response.data.data));
          return {"code":1, "value":response.data.data}
        }
      }).catch(error=>{
        return {"code":0, "value":error};
      });
      return result;
      
    },
    Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(quyen_id,token){
      var sefl=this;
      var result=role.Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(quyen_id,token).then(response=>{
        if(response.data.success){
            return {"code":1, "value":response.data.data}
        }
      }).catch();
      return result;
    },
    Lay_DS_Chucnang_Theo_DS_Chucnang_ID(dschucnang_id,token){
      var sefl=this;
      var result=role.Lay_DS_Chucnang_Theo_DS_Chucnang_ID(dschucnang_id,token).then(response=>{
        if(response.data.success){
            localStorage.setItem("ds_chucnang",JSON.stringify(response.data.data));
            return {"code":1, "value":response.data.data}
        }
      }).catch();
      return result;
    }
  },
  watch: {
    // ...mapGetters(["loggedIn"]),
  },
  computed: {},
};
</script>

<style scoped lang="scss">
.v-input__icon--double .v-input__icon {
  margin-left: -4.25rem !important;
}
a.no-text-decoration {
  text-decoration: none;
}
#signinup-form {
  max-width: 75rem;
}
.signup-form-form {
  max-width: 23rem;
  margin: 0 auto;
}
.card {
  overflow: hidden;
}
.vcenter {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
