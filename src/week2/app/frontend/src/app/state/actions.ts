import { createActionGroup, emptyProps } from '@ngrx/store';

export const ApplicationActions = createActionGroup({
  source: 'Application',
  events: {
    'Application Started': emptyProps(),
  },
});
