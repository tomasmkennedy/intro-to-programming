import { createFeature, createReducer, createSelector } from '@ngrx/store';
import { TodoEntity } from '../types';
import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { TodoListItem } from '../models';

export interface TodosState extends EntityState<TodoEntity> {}

const adapter = createEntityAdapter<TodoEntity>();
// const initialState: TodosState = adapter.getInitialState();
const initialState: TodosState = adapter.getInitialState();
export const todosFeature = createFeature({
  name: 'todos',
  reducer: createReducer(initialState),
  extraSelectors: ({ selectTodosState }) => {
    const { selectAll } = adapter.getSelectors();
    const todosArray = createSelector(selectTodosState, (s) => selectAll(s));
    return {
      selectTodoListItems: createSelector(todosArray, (todos) =>
        todos.map(
          (t) =>
            ({
              id: t.id,
              completed: false,
              description: t.description,
            } as TodoListItem)
        )
      ),
    };
  },
});
