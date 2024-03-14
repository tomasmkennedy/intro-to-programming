import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { CountByValues, CounterActions } from '../counter/state/actions';
import { counterFeature } from '../counter/state';

@Component({
  selector: 'app-prefs',
  standalone: true,
  imports: [],
  template: `
    <div class="join">
      <button
        [disabled]="by() === 1"
        (click)="setCountBy(1)"
        class="btn join-item"
      >
        Count by 1
      </button>
      <button
        [disabled]="by() === 3"
        (click)="setCountBy(3)"
        class="btn join-item"
      >
        Count by 3
      </button>
      <button
        [disabled]="by() === 5"
        (click)="setCountBy(5)"
        class="btn join-item"
      >
        Count by 5
      </button>
    </div>
  `,
  styles: ``,
})
export class PrefsComponent {
  constructor(private store: Store) {}
  by = this.store.selectSignal(counterFeature.selectBy);
  setCountBy(payload: CountByValues) {
    this.store.dispatch(CounterActions.countByChanged({ payload }));
  }
}
