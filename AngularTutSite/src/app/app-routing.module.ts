import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCurdSnackComponent } from './create-curd-snack/create-curd-snack.component';
import { EditCurdSnackComponent } from './edit-curd-snack/edit-curd-snack.component';

const routes: Routes = [
  {
    path: '', component: CreateCurdSnackComponent
  },
  {
     path: 'create-curd-snack', component: CreateCurdSnackComponent
  },
  {
    path: 'edit-curd-snack', component: EditCurdSnackComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
