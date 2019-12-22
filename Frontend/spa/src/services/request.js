import axios from "axios";
//import { Message } from "element-ui";
import appStore from '../store/app'
//import listrouter from "../config/list-route";

//export const baseURL = process.env.VUE_APP_BASE_API;
export const baseURL = 'https://localhost:44326/';
// create an axios instance
const service = axios.create({
  baseURL: baseURL, // api 的 base_url
  //  baseURL: 'http://backend.ticketspace.vn', // api 的 base_url
  timeout: 60 *1000 // request timeout,
});
//console.log('token',store.getters.token);

// request interceptor
service.interceptors.request.use(
  config => {
      console.log('config',config);
      
    // Do something before request is sent
    if (appStore.getters.token) {
      // 让每个请求携带token-- ['X-Token']为自定义key 请根据实际情况自行修改
      config.headers["Authorization"] = "Bearer " + 'test';
    }
    return config;
  },
  error => {
    // Do something with request error
    console.log(error); // for debug
    Promise.reject(error);
  }
);

// response interceptor
service.interceptors.response.use(
  response => {
    return response
  },

  error => {
    //console.log("err" + error); // for debug
    if (appStore.getters.token) {
      // Message({
      //   message: error.message,
      //   type: "error",
      //   duration: 5 * 1000
      // });
    //   if(error.response && error.response.status && error.response.status == 403) {
    //     store.dispatch(AUTH_ACTIONS.NOT_AUTH, listrouter.Dashboard)
    //   }
    }
    return Promise.reject(error);
  }
);

export default service;
