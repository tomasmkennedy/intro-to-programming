import { createFeature, createReducer, on } from '@ngrx/store';
import { CountByValues, CounterActions } from './actions';

export interface CounterState {
  current: number;
  by: CountByValues;
}

export const initialState: CounterState = {
  current: 0,
  by: 1,
};

export const counterFeature = createFeature({
  name: 'counter',
  reducer: createReducer(
    initialState,
    on(CounterActions.incrementedTheCount, (state) => ({
      ...state,
      current: state.current + state.by,
    })),
    on(CounterActions.decrementedTheCount, (state) => ({
      ...state,
      current: state.current - state.by,
    })),
    on(CounterActions.countWasReset, (state) => ({
      ...state,
      current: initialState.current,
    })),
    on(CounterActions.countByChanged, (state, action) => ({
      ...state,
      by: action.payload,
    })),
    on(CounterActions.state, (_, a) => a.payload)
  ),
});
