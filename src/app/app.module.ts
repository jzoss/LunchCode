import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { LunchPadComponent } from './lunch-pad/lunch-pad.component';
import {MatInputModule, MatButtonModule, MatDialogModule, MatCheckboxModule, MatSlideToggleModule,
  MatGridListModule, MatIconModule} from '@angular/material';
import { SettingsComponent } from './settings/settings.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LocalStorageModule } from 'angular-2-local-storage';
import {JasperoAlertsModule, AlertSettings } from '@jaspero/ng2-alerts';

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
    JasperoAlertsModule
  ],
  providers: [],
  entryComponents: [SettingsComponent],
  bootstrap: [AppComponent]
})
export class AppModule {

 }
