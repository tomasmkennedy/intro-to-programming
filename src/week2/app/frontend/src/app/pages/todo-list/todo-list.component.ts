import { Component } from '@angular/core';
import { TodoEntryComponent } from './components/todo-entry/todo-entry.component';
import { TodoItemListComponent } from './components/todo-item-list/todo-item-list.component';
import { TodoListItem } from './models';
import { Store } from '@ngrx/store';
import { todosFeature } from './state';
import { TodoCommands } from './state/actions';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  template: `
    <section>
      <h2 class="text-2xl font-bold">Your Todo List</h2>
      <button (click)="reload()" class="btn btn-sm btn-primary">
        Reload The Data
      </button>
    </section>
    @if(loaded()) {
    <div>
      <app-todo-entry (itemAdded)="addItem($event)" />
    </div>
    <div>
      <app-todo-item-list [list]="todoList()" />
    </div>
    } @else {
    <span class="loading loading-ring loading-lg"></span>
    }
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

  reload() {
    this.store.dispatch(TodoCommands.loadTodos());
  }
  loaded = this.store.selectSignal(todosFeature.selectIsLoaded);
  todoList = this.store.selectSignal(todosFeature.selectTodoListItems);
}
