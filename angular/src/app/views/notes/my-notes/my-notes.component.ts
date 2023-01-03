import { Component, OnInit } from '@angular/core';
import { NoteListModel } from "../../../models/note-list.model";
import { NoteService } from "../../../service/note.service";
import { ErrorMessage } from "../../../models/error-message.model";

@Component({
  selector: 'app-my-notes',
  templateUrl: './my-notes.component.html',
  styleUrls: ['./my-notes.component.scss']
})
export class MyNotesComponent implements OnInit {

  notes: NoteListModel[] = [];
  errorMessages: ErrorMessage[] = [];
  success: boolean = true;

  constructor(private noteService: NoteService) {}

  ngOnInit(): void {
    this.noteService.getUserNotes().subscribe(r => {
      if (r.success) {
        this.notes = r.content;
      } else {
        this.errorMessages = r.errors;
      }
    });
  }

  delete(note: any): void {
    this.notes
  }
}
