import {LogLevel} from "../../models/LogLevel";

export default interface ILogService {
    log(level: LogLevel, ...data: any): void;
}

export const ILogServiceType = Symbol.for("ILogLevelType");
