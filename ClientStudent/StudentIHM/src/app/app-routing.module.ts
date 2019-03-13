import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { StudentsComponent } from './students/students.component';

const routes: Routes = [
   { path: '', redirectTo: 'home', pathMatch: 'full' },  
   { path: 'home', component: HomeComponent },  
   { path: 'students', component: StudentsComponent },   
{ path: '**', redirectTo: 'home' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
