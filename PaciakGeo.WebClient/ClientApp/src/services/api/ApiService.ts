import {injectable} from "inversify";
import axios from 'axios';

import IApiService from "./IApiService";

@injectable()
export default class ApiService implements IApiService {
    async get<T>(endpoint: string): Promise<T> {
        const response = await axios.get<T>(endpoint);
        return response.data;
    }
}
