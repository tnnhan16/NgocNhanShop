import { PagingResponseApi } from "./paging-response-api"
import { ResponseError } from "./response-error";

export interface ResponseApi <T>{
    isSuccessed: boolean
    listError?: ResponseError[]
    message?: string
    resultObj:PagingResponseApi<T>
}