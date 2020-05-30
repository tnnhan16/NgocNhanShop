import { PagingResponseApi } from "./paging-response-api"

export interface ResponseApi <T>{
    isSuccessed: boolean
    listError?: string[]
    message?: string
    resultObj:PagingResponseApi<T>
}