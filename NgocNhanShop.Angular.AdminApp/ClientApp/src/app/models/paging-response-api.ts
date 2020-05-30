
export class PagingResponseApi<T> {
    items: T
    pageCount: number
    pageIndex: number
    pageSize: number
    total: number
}