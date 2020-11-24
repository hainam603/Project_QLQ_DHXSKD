
import authrepository from '../impl/auth';
import userrepository from '../impl/user';
import notificationrepository from '../impl/notification';


const responsitories = {
    auth: authrepository,
    user: userrepository,
    notification: notificationrepository
  };
  export default {
    get: name => responsitories[name]
  };