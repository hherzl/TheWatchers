import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatSlideToggle } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatSlideToggle],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('thewatchers-gui');
}
