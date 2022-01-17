import axios, { AxiosInstance } from "axios";

const apiClient: AxiosInstance = axios.create({
  // APIのURI
  baseURL: "https://localhost:5001",
  // リクエストヘッダ
  headers: {
    // 'Accept':'application/json',
    "Content-type": "application/json",
  },
});

export default apiClient;