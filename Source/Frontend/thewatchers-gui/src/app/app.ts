import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { NavComponent } from '../nav/nav.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatSlideToggle, NavComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('The Watchers');
}
