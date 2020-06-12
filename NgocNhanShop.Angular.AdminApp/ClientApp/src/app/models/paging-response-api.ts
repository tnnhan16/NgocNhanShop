
export class PagingResponseApi<T> {
    items: T
    pageCount: number = 0
    pageIndex: number = 1
    pageSize: number = 10
    total: number = 0
    constructor(data:PagingResponseApi<T>){
        this.items = data.items
        this.pageCount = data.pageCount
        this.pageIndex = data.pageIndex
        this.pageSize = data.pageSize
        this.total = data.total
    }
}