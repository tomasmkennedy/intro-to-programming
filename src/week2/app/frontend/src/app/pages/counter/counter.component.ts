import { Component, computed } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';
import { CounterActions } from './state/actions';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  template: `
    <div>
      @if(isEven()) {
      <p>Even</p>
      } @else {
      <p>Odd</p>
      }
      <button (click)="decrement()" class="btn btn-primary">-</button>
      <span>{{ current() }}</span>
      <button (click)="increment()" class="btn btn-primary">+</button>
      <div>
        <button
          [disabled]="current() === 0"
          (click)="reset()"
          class="btn btn-warning"
        >
          Reset
        </button>
      </div>
      <p>
        If you increment now, the value will be {{ nextAdd() }} and if decrement
        it will be {{ nextDec() }}
      </p>
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
  // private store: Store;

  // constructor(store: Store) {
  //   this.store = store;
  // }
  constructor(private store: Store) {}
  current = this.store.selectSignal(counterFeature.selectCurrent);

  isEven = this.store.selectSignal(counterFeature.isEven);
  nextAdd = this.store.selectSignal(counterFeature.nextValueIfIncrement);
  nextDec = this.store.selectSignal(counterFeature.nextValueIfDecrement);
  increment() {
    this.store.dispatch(CounterActions.incrementedTheCount());
  }

  decrement() {
    this.store.dispatch(CounterActions.decrementedTheCount());
  }

  reset() {
    this.store.dispatch(CounterActions.countWasReset());
  }
}
