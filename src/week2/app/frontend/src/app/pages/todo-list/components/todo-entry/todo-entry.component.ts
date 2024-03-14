import { Component, EventEmitter, Output, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Store } from '@ngrx/store';
import { TodoEvents } from '../../state/actions';

@Component({
  selector: 'app-todo-entry',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <form [formGroup]="form" (ngSubmit)="addItem()">
      <div>
        <label
          >Description
          <input
            type="text"
            formControlName="description"
            placeholder="Type here"
            class="input input-bordered w-full max-w-xs"
          />
        </label>
        @if(description.invalid && (description.touched || description.dirty)) {
        <div>
          @if(description.getError('required')) {
          <p>Please provide a description</p>
          } @if(description.getError('minlength')) {
          <p>Please enter at least three characters</p>
          } @if(description.getError('maxlength')) {
          <p>Please enter no more than 124 characters</p>
          }
        </div>
        }
        <button type="submit" class="btn btn-primary">
          Add Item To The List
        </button>
      </div>
    </form>
  `,
  styles: ``,
})
export class TodoEntryComponent {
  @Output() itemAdded = new EventEmitter<{ description: string }>();
  form = new FormGroup({
    description: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.maxLength(124),
        Validators.minLength(3),
      ],
    }),
  });

  private store = inject(Store);

  get description() {
    return this.form.controls.description;
  }

  addItem() {
    if (this.form.valid) {
      this.store.dispatch(
        TodoEvents.todoItemAdded({
          payload: this.form.controls.description.value,
        })
      );
    }
  }
}
