import { Component, OnInit } from '@angular/core';
import { NoteService } from "../../../service/note.service";
import { ActivatedRoute } from "@angular/router";
import { ErrorMessage } from "../../../models/error-message.model";

@Component({
  selector: 'app-preview-note',
  templateUrl: './preview-note.component.html',
  styleUrls: ['./preview-note.component.scss']
})
export class PreviewNoteComponent implements OnInit {

  markdown: string = '';
  errorMessages: ErrorMessage[] = []

  constructor(private noteService: NoteService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.noteService.get(params['id']).subscribe(r => {
        if (r.success) {
          this.markdown = r.content.text;
        } else {
          this.errorMessages = r.errors;
        }
      })
    });
  }
}
