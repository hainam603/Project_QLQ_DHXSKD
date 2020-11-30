import repository from '../reponsitory/repository';
const resource = "/role";
export default {
    Lay_Quyen_Nguoidung(ma_nd,token) {
        return repository.get(`${resource}/Lay_Quyen_Nguoidung?ma_nd=`+ma_nd,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    //Chức năng
    Lay_DS_Chucnang_Theo_DS_Chucnang_ID(dschucnang_id,token) {
        return repository.get(`${resource}/Lay_DS_Chucnang_Theo_DS_Chucnang_ID?dschucnang_id=`+dschucnang_id,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    //Quyền sử dụng chức năng
    Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(quyen_id,token) {
        return repository.get(`${resource}/Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID?quyen_id=`+quyen_id,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
   
}