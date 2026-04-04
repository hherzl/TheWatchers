import { AfterViewInit, Component} from '@angular/core';
import { JoeViewerComponent } from '../joe-viewer/joe-viewer.component';

@Component({
  selector: 'app-home',
  imports: [JoeViewerComponent],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements AfterViewInit {

  ngAfterViewInit(): void {
    
  }
}
