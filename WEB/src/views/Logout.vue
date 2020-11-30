<template>
  <div></div>
</template>

<script>

export default {
  //   name: "Logout",
  created() {
    // this.$store.dispatch("clearTodos");
    // this.$store.dispatch("destroyToken").then((response) => {
    //   this.$router.push({ name: "Login" });
    
    // });
    this.logout();
  },
  methods:{
    logout(){
      
      var self=this;
      document.cookie = "token_session=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
      localStorage.setItem('ds_nguoidung','');
      localStorage.ds_chucnang='';
      self.islogin = false;
      self.selectComponent='loginComponent';
      this.$router.push({ name: "Login" });
    }
  }
};
</script>