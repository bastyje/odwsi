import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.scss']
})
export class CreateNoteComponent implements OnInit {

  title: string = 'enter title here'
  markdown: string = '*enter your note here*';

  constructor(private location: Location) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.location.back();
  }
}
