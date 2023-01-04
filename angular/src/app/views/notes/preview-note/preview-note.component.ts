import { Component, OnInit } from '@angular/core';
import { NoteService } from "../../../service/note.service";
import { ActivatedRoute } from "@angular/router";
import { ErrorMessage } from "../../../models/error-message.model";
import { NoteDetailModel } from "../../../models/note-detail.model";
import { AES, enc } from "crypto-js";
import { ScopeTypeEnum } from "../../../enums/scope-type.enum";

@Component({
  selector: 'app-preview-note',
  templateUrl: './preview-note.component.html',
  styleUrls: ['./preview-note.component.scss']
})
export class PreviewNoteComponent implements OnInit {

  note: NoteDetailModel = <NoteDetailModel>{};
  markdown: string = '';
  errorMessages: ErrorMessage[] = [];
  password: string = '';

  constructor(private noteService: NoteService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.noteService.get(params['id']).subscribe(r => {
        if (r.success) {
          this.note = r.content;
          if (!r.content.encrypted) {
            this.markdown = r.content.text;
          }
        } else {
          this.errorMessages = r.errors;
        }
      })
    });
  }

  decrypt(): void {
    this.markdown = AES.decrypt(this.note.text, this.password).toString(enc.Utf8);
    this.note.encrypted = false;
  }
}
