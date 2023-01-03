import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ErrorMessage } from "../../../models/error-message.model";
import { NoteService } from "../../../service/note.service";
import { NoteCreateModel } from "../../../models/note-create.model";
import { ScopeTypeEnum } from "../../../enums/scope-type.enum";
import { AES, enc } from 'crypto-js';
import { Router } from "@angular/router";

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.scss']
})
export class CreateNoteComponent implements OnInit {

  note: NoteCreateModel = <NoteCreateModel> {
    title: 'enter title here',
    text: '*enter your note here*',
    scopeType: ScopeTypeEnum.Private
  }

  encrypted: boolean = false;
  password: string = '';
  confirmedPassword: string = '';

  errorMessages: ErrorMessage[] = [];

  constructor(private noteService: NoteService, private location: Location) { }

  ngOnInit(): void {}

  save(): void {
    this.errorMessages = [];

    if (this.encrypted) {
      if (this.password.length === 0) {
        this.errorMessages.push({
          message: 'Password is required'
        });
      } else if (this.password !== this.confirmedPassword) {
        this.errorMessages.push({
          message: 'Passwords are not matching'
        });
      } else {
        this.note.text = AES.encrypt(this.note.text, this.password).toString();
      }
    }

    if (this.errorMessages.length === 0) {
      this.noteService.add(this.note).subscribe(r => {
        if (r.success) {
          this.location.back();
        } else {
          this.errorMessages = r.errors;
        }
      });
    }
  }

  cancel(): void {
    this.location.back();
  }

  toggle(mode: string): void {
    switch (mode) {
      case 'private':
        this.note.scopeType = ScopeTypeEnum.Private;
        break;
      case 'shared':
        this.note.scopeType = ScopeTypeEnum.Shared;
        break;
      case 'public':
        this.note.scopeType = ScopeTypeEnum.Public;
        break;
    }
  }

  private = (): boolean => this.note.scopeType === ScopeTypeEnum.Private;
  shared = (): boolean => this.note.scopeType === ScopeTypeEnum.Shared;
  public = (): boolean => this.note.scopeType === ScopeTypeEnum.Public;
}
