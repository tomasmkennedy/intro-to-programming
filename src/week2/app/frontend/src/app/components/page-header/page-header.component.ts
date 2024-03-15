import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-page-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './page-header.component.html',
  styles: ``,
})
export class PageHeaderComponent {
  someThing = 'Tacos';

  anotherThing = 'cheese';
}
