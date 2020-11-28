import repository from '../reponsitory/repository';
const resource = "/role";
export default {
    Lay_Quyen_Nguoidung(ma_nd,token) {
        return repository.get(`${resource}/Lay_Quyen_Nguoidung?ma_nd=`+ma_nd,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
   
}