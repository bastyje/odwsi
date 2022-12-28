import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-preview-note',
  templateUrl: './preview-note.component.html',
  styleUrls: ['./preview-note.component.scss']
})
export class PreviewNoteComponent implements OnInit {

  markdown: string = '# markdown to preview'

  constructor() { }

  ngOnInit(): void {
  }

}
