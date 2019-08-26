import { Pagination } from './Pagination';

export class PaginationResponse<T> {
    success: boolean;
    code: number;
    response: PaginatedResponse<T>;
}

class PaginatedResponse<T> {
    count: number;
    totalCount: number;
    data: Array<T>;
    public get pagination() : Pagination {
        return {
            count: this.count,
            totalCount: this.totalCount,
            pageSize: this.count
        };
    }
}