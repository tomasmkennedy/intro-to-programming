import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { TodoEntity } from '../types';
import { TodoListItem } from '../models';

// A command is an order - "do this thing" - usually expects something specific to happen in response to that.
export const TodoCommands = createActionGroup({
  source: 'Todo Commands',
  events: {
    'Load Todos': emptyProps(),
  },
});

// An event is something that happened, that might mean multiple things need to happen, but the event is decoupled from that.
export const TodoEvents = createActionGroup({
  source: 'Todo Events',
  events: {
    'Todo Item Added': props<{ payload: string }>(),
    'Todo Item Marked Complete': props<{ payload: TodoListItem }>(),
    'Todo Item Marked Incomplete': props<{ payload: TodoListItem }>(),
  },
});

// Often the result of a command
export const TodoDocuments = createActionGroup({
  source: 'Todo Documents',
  events: {
    Todos: props<{ payload: TodoEntity[] }>(),
    Todo: props<{ payload: TodoEntity }>(),
  },
});
