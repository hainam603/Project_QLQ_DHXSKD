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
                      @submit.prevent="login"
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
            Close
          </v-btn>
        </template>
      </v-snackbar>
  </v-container>
  
</template>

<script>

import factory from "../services/factory/repositoryfactory";
import kt_session from "../services/Kiemtra_Session";
const auth = factory.get("auth");
const kt=kt_session;
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
    loading:false,

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
      if(kt.getTokenByLocal())
        this.$router.push("/home");
    },
    login()
    {
      var self=this;
      self.loading=true;
      var user={ma_ND:self.username, Matkhau:self.password}
      auth.auth(user).then(response=>{
        if (response.data.success) {
          // debugger;
            self.token = response.data.data.access_token;
            var value = {
                usid: response.data.data.nguoidung.ma_ND,
                token: response.data.data.token.access_token
            };
            var today = new Date();
            var nexthour = new Date();
            nexthour.setDate(today.getDate() + 1);
            document.cookie = "token_session=" + JSON.stringify(value) + ";expires =" +nexthour +"";
            self.$router.push("/home");

        }
        else
        {
        //  self.$message.error('Sai thông tin đăng nhập');
          self.text=response.data.message;
          self.snackbar = true;
        }
        self.loading=false;
      })
      .catch(error => {
          //self.text="Đã có lỗi sảy ra, liên hệ admin để giải quyết";
          self.text=response.data.message;
          self.snackbar = true;
          self.loading=false;
      });
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
