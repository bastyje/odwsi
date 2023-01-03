import { ScopeTypeEnum } from "../enums/scope-type.enum";

export interface NoteCreateModel {
  title: string;
  text: string;
  scopeType: ScopeTypeEnum
}
