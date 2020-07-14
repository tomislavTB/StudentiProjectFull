export class DetailResponse<T> {
    success: boolean;
    code: number;
    response: T;
}