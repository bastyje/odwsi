import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from "./views/shared/layout/layout.component";
import { LoginComponent } from "./views/login/login.component";
import { RegisterComponent } from "./views/register/register.component";
import { MyNotesComponent } from "./views/notes/my-notes/my-notes.component";
import { SharedNotesComponent } from "./views/notes/shared-notes/shared-notes.component";

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'notes',
        pathMatch: 'full'
      },
      {
        path: 'notes',
        loadChildren: () => import('./views/notes/notes.module').then(m => m.NotesModule),
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
