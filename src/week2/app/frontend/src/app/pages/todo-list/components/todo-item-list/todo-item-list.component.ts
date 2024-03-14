import { Component, Input, input } from '@angular/core';
import { TodoListItem } from '../../models';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-todo-item-list',
  standalone: true,
  imports: [NgClass],
  template: `
    @if(list().length === 0) {
    <!-- <app-alert-information message="You Have Nothing On Your Todo List! Party!" /> -->
    <div role="alert" class="alert alert-info">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="stroke-current shrink-0 w-6 h-6"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
        ></path>
      </svg>
      <span>You Have Nothing on your Todo List! Party!.</span>
    </div>
    }
    <ul>
      @for(item of list(); track item.id) {
      <li class="card bg-base-300 shadow-xl mb-4">
        <div class="card-body">
          <span [ngClass]="{ 'line-through': item.completed }">{{
            item.description
          }}</span>
          <div class="card-actions justify-end">
            @if(item.completed === false) {
            <button (click)="markComplete(item)" class="btn btn-sm btn-primary">
              X
            </button>
            } @else {
            <button
              (click)="markIncomplete(item)"
              class="btn btn-sm btn-accent"
            >
              +
            </button>
            }
          </div>
        </div>
      </li>
      }
    </ul>
  `,
  styles: `
 
  `,
})
export class TodoItemListComponent {
  // @Input({ required: true }) list: TodoListItem[] = [];
  list = input.required<TodoListItem[]>();
  markComplete(item: TodoListItem) {
    item.completed = true;
  }
  markIncomplete(item: TodoListItem) {
    item.completed = false;
  }
}
