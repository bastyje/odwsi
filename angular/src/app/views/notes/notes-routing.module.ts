import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyNotesComponent } from "./my-notes/my-notes.component";
import { SharedNotesComponent } from "./shared-notes/shared-notes.component";
import { CreateNoteComponent } from "./create-note/create-note.component";
import { PreviewNoteComponent } from "./preview-note/preview-note.component";

const routes: Routes = [
  {
    path: 'my-notes',
    component: MyNotesComponent
  },
  {
    path: 'shared-notes',
    component: SharedNotesComponent
  },
  {
    path: 'public-notes',
    component: SharedNotesComponent
  },
  {
    path: 'create',
    component: CreateNoteComponent
  },
  {
    path: 'preview/:id',
    component: PreviewNoteComponent
  },
  {
    path: '',
    redirectTo: 'my-notes',
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotesRoutingModule { }
