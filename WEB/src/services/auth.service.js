import axios from "axios";

// const API_URL = "http://localhost:8080/api/auth/";
axios.defaults.baseURL = "https://localhost:5000/api/";

class AuthService {
  login(user) {
    return axios
      .post("nguoidung/login", {
        username: user.username,
        password: user.password,
      })
      .then((response) => {
        if (response.data.token) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }
        return response.data;
      });
  }



  logout() {
    localStorage.removeItem("user");
  }

  //   register(user) {
  //     return axios.post(API_URL + "signup", {
  //       username: user.username,
  //       email: user.email,
  //       password: user.password,
  //     });
  //   }
}

export default new AuthService();
