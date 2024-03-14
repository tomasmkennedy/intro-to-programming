import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { map, tap } from 'rxjs';
import { CounterActions } from './actions';
import { Store } from '@ngrx/store';
import { counterFeature, initialState } from '.';
import { ApplicationActions } from '../../../state/actions';

@Injectable()
export class CounterEffects {
  //   logTheActions$ = createEffect(
  //     () => this.actions.pipe(tap((a) => console.log(a.type))),
  //     { dispatch: false }
  //   );

  //
  // Turn a counterEntered => state(initialState | what they stored)

  loadTheDataOnApplicationStart$ = createEffect(() =>
    this.actions.pipe(
      ofType(ApplicationActions.applicationStarted),
      map(() => CounterActions.counterEntered())
    )
  );

  loadUserCounterData$ = createEffect(
    () =>
      this.actions.pipe(
        ofType(CounterActions.counterEntered),
        map(() => localStorage.getItem('counter')), // string | null
        map((stuff) => (stuff === null ? initialState : JSON.parse(stuff))),
        map((payload) => CounterActions.state({ payload }))
      ),
    { dispatch: true }
  );

  saveUserCounterData$ = createEffect(
    () =>
      this.actions.pipe(
        ofType(
          CounterActions.countByChanged,
          CounterActions.countWasReset,
          CounterActions.decrementedTheCount,
          CounterActions.incrementedTheCount
        ),
        concatLatestFrom(() =>
          this.store.select(counterFeature.selectCounterState)
        ),
        tap(([_, state]) =>
          localStorage.setItem('counter', JSON.stringify(state))
        )
      ),
    { dispatch: false }
  );

  constructor(private actions: Actions, private store: Store) {}
}
