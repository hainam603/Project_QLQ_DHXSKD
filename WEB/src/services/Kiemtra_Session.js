export default {
    getTokenByLocal() {
        var section_local = this.getCookie("token_session");
        if (section_local) {
          var tok = this.strToObj(this.getCookie("token_session"));
          // console.log(tok.token);
          return tok.token;
        }
        return "";
      
      },
    get_token_session() {
        var self=this;
        var section_local = self.getCookie("token_session");
        if (section_local) {
            var tok = self.strToObj(self.getCookie("token_session"));   
            if(tok.usid != "" && tok.token != "")
                return true;
            else
                return false;
        } else {
            return false;
        }
    },
    getCookie(cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        for (var i = 0; i < decodedCookie.length; i++) {
            var c = decodedCookie;
            while (c.charAt(0) === " ") {
            c = c.substring(1);
            }
            if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
            }
        }
        return "";
    },
    strToObj(str) {
    //convert string to object
        var obj = {};
        if (str && typeof str === "string") {
            var objStr = str.match(/\{(.)+\}/g);
            eval("obj =" + objStr);
        }
        return obj;
    },
}