import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { LunchPadComponent } from './lunch-pad/lunch-pad.component';
import {MatInputModule, MatButtonModule, MatDialogModule, MatCheckboxModule, MatSlideToggleModule,
  MatGridListModule, MatIconModule, MatTooltipModule} from '@angular/material';
import { SettingsComponent } from './settings/settings.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LocalStorageModule } from 'angular-2-local-storage';
import {JasperoAlertsModule, AlertSettings } from '@jaspero/ng-alerts';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    LunchPadComponent,
    SettingsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    LocalStorageModule.forRoot({
      prefix: 'lunch-pad',
      storageType: 'localStorage'
  }),
  MatInputModule,
  MatButtonModule,
  MatDialogModule,
    MatSlideToggleModule,
    MatDialogModule,
    MatInputModule,
    MatGridListModule,
    MatIconModule,
    MatTooltipModule,
    MatCheckboxModule,
    JasperoAlertsModule.forRoot(),
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [],
  entryComponents: [SettingsComponent],
  bootstrap: [AppComponent]
})
export class AppModule {

 }
