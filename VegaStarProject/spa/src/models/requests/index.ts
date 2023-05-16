import { message } from "antd";
import axios, { AxiosError } from "axios";

export const apiClient = axios.create({});

apiClient.interceptors.request.use((cfg) => {
   return Object.assign({}, cfg, {
      headers: Object.assign({}, cfg.headers, {
         Authorization: `Bearer ${localStorage.getItem("token")}`,
      }),
   });
});
