import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, merge, mergeMap, switchMap } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { ApplicationActions } from '../../../state/actions';
import { TodoCommands, TodoDocuments, TodoEvents } from './actions';
import { TodoEntity } from '../types';
@Injectable()
export class TodoEffects {
  // When the applications started, what does that mean for the todos feature?
  readonly baseUrl = environment.apiUrl;

  markCompleted$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodoEvents.todoItemMarkedComplete),
      mergeMap(({ payload }) =>
        this.httpClient.post(this.baseUrl + '/completed-todos', payload).pipe(
          map(() => ({ ...payload, completed: true })),
          map((payload) => TodoDocuments.todo({ payload }))
        )
      )
    )
  );

  markIncompleted$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodoEvents.todoItemMarkedIncomplete),
      mergeMap(({ payload }) =>
        this.httpClient.post(this.baseUrl + '/completed-todos', payload).pipe(
          map(() => ({ ...payload, completed: false })),
          map((payload) => TodoDocuments.todo({ payload }))
        )
      )
    )
  );

  addTodo$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodoEvents.todoItemAdded),
      mergeMap((a) =>
        this.httpClient
          .post<TodoEntity>(this.baseUrl + '/todos', { description: a.payload })
          .pipe(map((payload) => TodoDocuments.todo({ payload })))
      )
    )
  );

  onStartup$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ApplicationActions.applicationStarted),
      map(() => TodoCommands.loadTodos())
    )
  );

  // load the todos - when we get that command, go to the api, get the todos and return the list of todos to the reducer

  loadTodos$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodoCommands.loadTodos),
      switchMap(() =>
        this.httpClient
          .get<{ list: TodoEntity[] }>(this.baseUrl + '/todos') // Observable<{list: TodoEntity[]}>
          .pipe(
            map((results) => results.list),
            map((payload) => TodoDocuments.todos({ payload }))
          )
      )
    )
  );
  constructor(private actions$: Actions, private httpClient: HttpClient) {}
}
