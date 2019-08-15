import { Injectable } from '@angular/core';
import { SwUpdate } from '@angular/service-worker';

@Injectable({
  providedIn: 'root'
})
export class PwaService {
  public promptEvent: any;

  constructor(private swUpdate: SwUpdate) {
    swUpdate.available.subscribe(event => {
      if (confirm('Want to update?')) {
        window.location.reload();
      }
    });

    window.addEventListener('beforeinstallprompt', event => {
      this.promptEvent = event;
    });
  }
}
