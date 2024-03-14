import { Component } from '@angular/core';
import { TodoEntryComponent } from './components/todo-entry/todo-entry.component';
import { TodoItemListComponent } from './components/todo-item-list/todo-item-list.component';
import { TodoListItem } from './models';
import { Store } from '@ngrx/store';
import { todosFeature } from './state';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  template: `
    <section>
      <h2 class="text-2xl font-bold">Your Todo List</h2>
    </section>
    <div>
      <app-todo-entry (itemAdded)="addItem($event)" />
    </div>
    <div>
      <app-todo-item-list [list]="todoList()" />
    </div>
  `,
  styles: ``,
  imports: [TodoEntryComponent, TodoItemListComponent],
})
export class TodoListComponent {
  constructor(private store: Store) {}

  // todoList = this.store.selectSignal(todosFeature.)
  addItem(item: { description: string }) {
    // Todo: Dispatch An Action
  }

  todoList = this.store.selectSignal(todosFeature.selectTodoListItems);
}
