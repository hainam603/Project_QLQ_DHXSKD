import repository from '../reponsitory/repository';
const resource = "/user";
export default {
    Lay_DS_Nguoidung(token) {
        return repository.get(`${resource}/Lay_DS_Nguoidung`, { headers: {"Authorization" : `Bearer ${token}`} });
    },
    //Quyền người dùng
    Lay_DS_Quyen_Nguoidung(ma_nd,token) {
        return repository.get(`${resource}/Lay_DS_Quyen_Nguoidung?ma_nd=`+ma_nd,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    //Quyền menu
    Lay_DS_LoaiNV_Nguoidung(ma_nd,token) {
        return repository.get(`${resource}/Lay_DS_LoaiNV_Nguoidung?ma_nd=`+ma_nd,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Lay_DS_Menu_Nguoidung(ma_nd,token) {
        return repository.get(`${resource}/Lay_DS_Menu_Nguoidung?ma_nd=`+ma_nd,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    //Quyền báo cáo
    Lay_DS_Baocao_Nguoidung(ma_nd, nhom_bc_id,token) {
        return repository.get(`${resource}/Lay_DS_Baocao_Nguoidung?ma_nd=`+ma_nd+`&nhom_bc_id=`+nhom_bc_id,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Lay_DS_Nhombaocao_Nguoidung(ma_nd,token) {
        return repository.get(`${resource}/Lay_DS_Nhombaocao_Nguoidung?ma_nd=`+ma_nd,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
   
}