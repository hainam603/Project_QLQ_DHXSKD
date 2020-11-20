
import authrepository from '../impl/auth';
import userrepository from '../impl/user'


const responsitories = {
    auth: authrepository,
    user: userrepository
  };
  export default {
    get: name => responsitories[name]
  };