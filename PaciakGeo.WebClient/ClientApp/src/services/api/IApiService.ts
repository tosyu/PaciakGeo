export default interface IApiService {
    get<T>(endpoint: string): Promise<T>;
    post<T, E>(endpoint: string, data: E): Promise<T>;
}

export const IApiServiceType = Symbol.for("IApiService");
