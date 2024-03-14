import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-page-header',
  standalone: true,
  imports: [RouterLink],
  template: `
    <header>
      <h1 class="font-black text-3xl">Our Angular Application</h1>
      <p>Just Learning Here</p>
      <a routerLink="/prefs">⚙️</a>
    </header>
  `,
  styles: ``,
})
export class PageHeaderComponent {
  someThing = 'Tacos';

  anotherThing = 'cheese';
}
