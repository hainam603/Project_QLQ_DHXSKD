
import authrepository from '../impl/auth';


const responsitories = {
    auth: authrepository
  };
  export default {
    get: name => responsitories[name]
  };