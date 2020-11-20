import repository from '../reponsitory/repository';
const resource = "/auth";
export default {
    auth(user) {
        return repository.post(`${resource}/login`,user);
    },
   
}