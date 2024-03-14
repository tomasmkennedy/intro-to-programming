import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { CounterState } from '.';

export type CountByValues = 1 | 3 | 5;
export const CounterActions = createActionGroup({
  source: 'Counter Component Events',
  events: {
    'Incremented The Count': emptyProps(),
    'Decremented The Count': emptyProps(),
    'Count was Reset': emptyProps(),
    'Count By Changed': props<{ payload: CountByValues }>(),
    'Counter Entered': emptyProps(),
    State: props<{ payload: CounterState }>(),
  },
});
