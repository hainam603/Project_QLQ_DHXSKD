
import authrepository from '../impl/auth';
import userrepository from '../impl/user';
import notificationrepository from '../impl/notification';
import rolerepository from '../impl/role';


const responsitories = {
    auth: authrepository,
    user: userrepository,
    notification: notificationrepository,
    role: rolerepository
  };
  export default {
    get: name => responsitories[name]
  };