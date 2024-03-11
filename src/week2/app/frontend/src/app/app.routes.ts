import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { TodoListComponent } from './pages/todo-list/todo-list.component';

export const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'todo-list',
    component: TodoListComponent,
  },
  {
    path: '**',
    redirectTo: 'dashboard',
  },
];
