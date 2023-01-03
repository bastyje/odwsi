import { ErrorMessage } from "./error-message.model";

export interface ServiceMessageWithContent<T> extends ServiceMessage {
  content: T;
}

export interface ServiceMessage {
  errors: ErrorMessage[];
  success: boolean;
}
