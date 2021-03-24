export default interface IApiService {
    get<T>(endpoint: string): Promise<T>;
}

export const IApiServiceType = Symbol.for("IApiService");
