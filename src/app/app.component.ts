import { Component } from '@angular/core';
import { AlertSettings } from '@jaspero/ng-alerts';
import { PwaService } from './pwa.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  options: AlertSettings  = {
    overlay: true,
    duration: 0,
    showCloseButton: false,
    overlayClickToClose : true

  };

  constructor(public Pwa: PwaService) {}


}
