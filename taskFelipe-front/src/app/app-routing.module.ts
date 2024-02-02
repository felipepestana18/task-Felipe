import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { FormTaskComponent } from './pages/form-task/form-task.component';



const routes: Routes = [
  { path: '', component: DashboardComponent, pathMatch: 'full' },
  { path: 'create', component: FormTaskComponent },
  { path: 'create/:id', component: FormTaskComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
