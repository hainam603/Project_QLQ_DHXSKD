import repository from '../reponsitory/repository';
const resource = "/user";
export default {
    Lay_DS_Nguoidung() {
        return repository.get(`${resource}/Lay_DS_Nguoidung`);
    },
    //Quyền người dùng
    Lay_DS_Quyen_Nguoidung(ma_nd) {
        return repository.get(`${resource}/Lay_DS_Quyen_Nguoidung?ma_nd=`+ma_nd);
    },
    //Quyền menu
    Lay_DS_LoaiNV_Nguoidung(ma_nd) {
        return repository.get(`${resource}/Lay_DS_LoaiNV_Nguoidung?ma_nd=`+ma_nd);
    },
    Lay_DS_Menu_Nguoidung(ma_nd) {
        return repository.get(`${resource}/Lay_DS_Menu_Nguoidung?ma_nd=`+ma_nd);
    },
    //Quyền báo cáo
    Lay_DS_Baocao_Nguoidung(ma_nd, nhom_bc_id) {
        return repository.get(`${resource}/Lay_DS_Baocao_Nguoidung?ma_nd=`+ma_nd+`&nhom_bc_id=`+nhom_bc_id);
    },
    Lay_DS_Nhombaocao_Nguoidung(ma_nd) {
        return repository.get(`${resource}/Lay_DS_Nhombaocao_Nguoidung?ma_nd=`+ma_nd);
    },
   
}