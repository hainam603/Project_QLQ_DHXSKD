import repository from '../reponsitory/repository';
const resource = "/user";
export default {
    Lay_DS_Nguoidung() {
        return repository.get(`${resource}/Lay_DS_Nguoidung`);
    },
    Lay_DS_Quyen_Nguoidung(nhanvien_id) {
        return repository.get(`${resource}/Lay_DS_Quyen_Nguoidung?nhanvien_id=`+nhanvien_id);
    },
   
}