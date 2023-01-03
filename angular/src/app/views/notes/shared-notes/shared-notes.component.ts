import { Component, OnInit } from '@angular/core';
import { NoteListModel } from "../../../models/note-list.model";
import { NoteService } from "../../../service/note.service";
import { ErrorMessage } from "../../../models/error-message.model";
import { Router } from "@angular/router";

@Component({
  selector: 'app-shared-notes',
  templateUrl: './shared-notes.component.html',
  styleUrls: ['./shared-notes.component.scss']
})
export class SharedNotesComponent implements OnInit {

  notes: NoteListModel[] = [];
  errorMessages: ErrorMessage[] = [];
  success: boolean = true;

  constructor(private noteService: NoteService, private router: Router) {}

  ngOnInit(): void {
    let observable;
    if (this.router.url === '/notes/public-notes') {
      observable = this.noteService.getPublicNotes();
    } else if (this.router.url === '/notes/shared-notes') {
      observable = this.noteService.getSharedNotes()
    }

    if (observable !== undefined) {
      observable.subscribe(r => {
        if (r.success) {
          this.notes = r.content;
        } else {
          this.errorMessages = r.errors;
        }
      });
    }
  }
}
