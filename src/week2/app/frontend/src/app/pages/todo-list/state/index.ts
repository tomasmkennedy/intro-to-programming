import { createFeature, createReducer, createSelector, on } from '@ngrx/store';
import { TodoEntity } from '../types';
import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { TodoListItem } from '../models';
import { TodoDocuments } from './actions';

export interface TodosState extends EntityState<TodoEntity> {
  isLoaded: boolean;
}

const adapter = createEntityAdapter<TodoEntity>();
const initialState: TodosState = adapter.getInitialState({
  isLoaded: false,
});

export const todosFeature = createFeature({
  name: 'todos',
  reducer: createReducer(
    initialState,
    on(TodoDocuments.todos, (s, a) => adapter.setAll(a.payload, s)), //
    on(TodoDocuments.todo, (s, a) => adapter.upsertOne(a.payload, s)),
    on(TodoDocuments.todos, (s) => ({ ...s, isLoaded: true }))
  ),
  extraSelectors: ({ selectTodosState }) => {
    const { selectAll } = adapter.getSelectors();
    const todosArray = createSelector(selectTodosState, (s) => selectAll(s));
    return {
      selectTodoListItems: createSelector(todosArray, (todos) =>
        todos.map(
          (t) =>
            ({
              id: t.id,
              completed: t.completed,
              description: t.description,
            } as TodoListItem)
        )
      ),
    };
  },
});
