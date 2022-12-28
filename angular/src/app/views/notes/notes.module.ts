import { NgModule, SecurityContext } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotesRoutingModule } from './notes-routing.module';
import { MyNotesComponent } from './my-notes/my-notes.component';
import { SharedNotesComponent } from './shared-notes/shared-notes.component';
import { CreateNoteComponent } from './create-note/create-note.component';
import { FormsModule } from "@angular/forms";
import { MarkdownModule } from "ngx-markdown";
import { PreviewNoteComponent } from './preview-note/preview-note.component';


@NgModule({
  declarations: [
    MyNotesComponent,
    SharedNotesComponent,
    CreateNoteComponent,
    PreviewNoteComponent
  ],
  imports: [
    CommonModule,
    NotesRoutingModule,
    FormsModule,
    MarkdownModule.forRoot({
      sanitize: SecurityContext.HTML
    }),
  ]
})
export class NotesModule { }
