import repository from '../reponsitory/repository';
const resource = "/notification";
export default {
    Lay_DS_Thaydoi_I8(dates) {
        return repository.post(`${resource}/Lay_DS_Thaydoi_I8`,dates);
    },
   
}