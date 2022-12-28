import { Component, OnInit } from '@angular/core';
import { NoteListModel } from "../../../models/note-list.model";

@Component({
  selector: 'app-shared-notes',
  templateUrl: './shared-notes.component.html',
  styleUrls: ['./shared-notes.component.scss']
})
export class SharedNotesComponent implements OnInit {

  notes: NoteListModel[] = [];

  constructor() {
    for (let i = 0; i < 10; i++) {
      this.notes.push({
        id: '123',
        date: new Date(),
        title: 'Note created to test notes list',
        author: 'Sebastian Górka'
      });
    }
  }

  ngOnInit(): void {
  }

}
