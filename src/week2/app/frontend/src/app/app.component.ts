import { Component } from '@angular/core';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { Store } from '@ngrx/store';
import { ApplicationActions } from './state/actions';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <div class="container mx-auto">
      <app-page-header />
      <nav>
        <app-nav-bar />
      </nav>
      <main>
        <router-outlet />
      </main>
    </div>
  `,
  styles: [],
  imports: [PageHeaderComponent, RouterOutlet, NavBarComponent],
})
export class AppComponent {
  constructor(store: Store) {
    store.dispatch(ApplicationActions.applicationStarted());
  }
}
