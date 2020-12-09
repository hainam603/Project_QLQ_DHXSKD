import repository from '../reponsitory/repository';
const resource = "/role";
export default {
    
    Lay_DS_Quyen(token) {
        return repository.get(`${resource}/Lay_DS_Quyen`,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Lay_DS_Chucnang(token) {
        return repository.get(`${resource}/Lay_DS_Chucnang`,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
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
    //Quản trị
    Lay_DS_Chucnang_Theo_Quyen_ID(quyen_id,token) {
        return repository.get(`${resource}/Lay_DS_Chucnang_Theo_Quyen_ID?quyen_id=`+quyen_id,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Them_Quyen_Sudung_Chucnang(roleUpdate,token){
        return repository.put(`${resource}/Them_Quyen_Sudung_Chucnang`,roleUpdate,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Them_Quyen(quyen,token){
        return repository.put(`${resource}/Them_Quyen`,quyen,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Lay_DS_Nguoidung_Theo_Quyen(quyen_id,token){
        return repository.get(`${resource}/Lay_DS_Nguoidung_Theo_Quyen?quyen_id=`+quyen_id,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Them_Phanquyen_Nguoidung(phanquyen,token){
        return repository.put(`${resource}/Them_Phanquyen_Nguoidung`,phanquyen,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Xoa_Phanquyen_Nguoidung(phanquyen,token){
        return repository.put(`${resource}/Xoa_Phanquyen_Nguoidung`,phanquyen,{ headers: {"Authorization" : `Bearer ${token}`} });
    }


   
}