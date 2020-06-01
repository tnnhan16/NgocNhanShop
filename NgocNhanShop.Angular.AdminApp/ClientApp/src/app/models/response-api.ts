import { PagingResponseApi } from "./paging-response-api"
import { IResponseError } from "./response-error";

export interface ResponseApi <T>{
    isSuccessed: boolean
    listError?: IResponseError[]
    message?: string
    resultObj:T
}