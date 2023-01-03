import { Injectable } from '@angular/core';
import { HttpService } from "./http.service";
import * as http from "http";
import { ServiceMessage, ServiceMessageWithContent } from "../models/service-message.model";
import { NoteListModel } from "../models/note-list.model";
import { Observable } from "rxjs";
import { NoteCreateModel } from "../models/note-create.model";
import { NoteDetailModel } from "../models/note-detail.model";

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private endpoint: string = 'note'

  constructor(private http: HttpService) { }

  public getUserNotes(): Observable<ServiceMessageWithContent<NoteListModel[]>> {
    return this.http.get<ServiceMessageWithContent<NoteListModel[]>>(`${this.endpoint}/my`);
  }

  public getSharedNotes(): Observable<ServiceMessageWithContent<NoteListModel[]>> {
    return this.http.get<ServiceMessageWithContent<NoteListModel[]>>(`${this.endpoint}/shared`);
  }

  public getPublicNotes(): Observable<ServiceMessageWithContent<NoteListModel[]>> {
    return this.http.get<ServiceMessageWithContent<NoteListModel[]>>(`${this.endpoint}`);
  }

  public add(note: NoteCreateModel): Observable<ServiceMessage> {
    return this.http.post<ServiceMessage>(`${this.endpoint}`, note);
  }

  public get(id: string): Observable<ServiceMessageWithContent<NoteDetailModel>> {
    return this.http.get<ServiceMessageWithContent<NoteDetailModel>>(`${this.endpoint}/${id}`);
  }
}
