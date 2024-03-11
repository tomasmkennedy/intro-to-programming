import { Component } from '@angular/core';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { DemoComponent } from './components/demo/demo.component';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <div class="container mx-auto">
      <app-page-header />
      <app-nav-bar />
      <main>
        <router-outlet />
      </main>
    </div>
  `,
  styles: [],
  imports: [PageHeaderComponent, RouterOutlet, NavBarComponent],
})
export class AppComponent {
  title = 'Demo Angular App';
}
