import { Component, OnInit, AfterViewInit } from '@angular/core';
import { RandomSaying } from '../RandomSayings';

import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatIcon} from '@angular/material';
import {SettingsComponent} from '../settings/settings.component';
import { LocalStorageService } from 'angular-2-local-storage';
import { AlertsService } from '@jaspero/ng2-alerts';

// export interface IWindow extends Window {
//   webkitSpeechRecognition: any;
// }

// const {webkitSpeechRecognition}: IWindow = <IWindow>window;
// const recognition = new webkitSpeechRecognition();

@Component({
  selector: 'app-lunch-pad',
  templateUrl: './lunch-pad.component.html',
  styleUrls: ['./lunch-pad.component.css'],
})
export class LunchPadComponent implements OnInit, AfterViewInit {


  synth = window.speechSynthesis;
  color = 'accent';
  speakWords = false;
  trainingMode = false;
  checked = false;
  disabled = false;
  _pin: string;
  _name: string;
  curentEnteredValue = '0';
  numberButtonsState: Array<boolean> = [true, true, true, true, true, true, true, true, true, true ];
  clearButtonEnabled = true;
  enterButtonEnabled = true;
  navigator = window.navigator;

  get pin(): string
  {
    return this._pin;
  }

  set pin(value: string)
  {
    if(value != null)
    {
      this._pin = value.toString();
      this.localStorageService.set('pin', this._pin);
    }
  }

  get name(): string
  {
    return this._name;
  }

  set name(value: string)
  {
    this._name = value;
    this.localStorageService.set('name', value);
  }

  constructor(
    public dialog: MatDialog,
    private _alert: AlertsService,
    private localStorageService: LocalStorageService) {
   // this.buttonsState = Array[true];
    // this.buttonsState
    this.name = this.localStorageService.get<string>('name');
    this.pin = this.localStorageService.get<string>('pin');

  }


  private setAllButtons(state: boolean)
  {
    for (let index = 0; index < this.numberButtonsState.length; index++) {
     this.numberButtonsState[index] = state;
    }
    this.clearButtonEnabled = state;
    this.enterButtonEnabled = state;
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(SettingsComponent, {
      width: '250px',
      data: { name: this.name, pin: this.pin }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(result)
      {
        this.pin = result.pin;
        this.name = result.name;
      }
    });
  }

  ngOnInit() {


  }

  ngAfterViewInit(): void {
    if (this.name == null || this.pin == null) {
      setTimeout(() => this.openDialog());
    }
  }

  clicked()
  {
    this.disabled = !this.disabled;
    this.setAllButtons(!this.disabled);
    // var utterThis = new SpeechSynthesisUtterance(RandomSaying.RandomFun());
    // this.synth.speak(utterThis);
  }

  numberPush(num: number) {
    this.vibrate(200);
    this.AddNumber(num.toString());
    console.log(num);
  }

  clearPush() {
    if (this.speakWords) {
      this.speak('Clear');
    }
    this.curentEnteredValue = '0';
    this.processTrainingMode();
  }

  enterPush()
  {
    if (this.speakWords)
    {
        this.speak("Enter");
    }
    if (this.isPinCorrect)
    {
      this.speak(`Great Job ${this.name}`);
      let saying = RandomSaying.RandomFun();
      this.speak(saying);
      this._alert.create('success', saying, {duration: 0, overlay: true });
      this.vibrate([200, 100, 200]);
      this.curentEnteredValue = '0';
      this.clearButtonEnabled = true;
      this.processTrainingMode();
    }
    else
    {
      this.speak('Oh Noes!');
      this._alert.create('error', 'You Are Doing Great, Try Again', {duration: 0, overlay: true });
    }
  }


  private AddNumber(number: string)
  {
    if (this.curentEnteredValue.length === 1 && this.curentEnteredValue[0] === '0')
    {
      this.curentEnteredValue = number;
    }
    else {
      this.curentEnteredValue = `${this.curentEnteredValue}${number}`;
    }
    if (this.speakWords) {
        this.speak(number);
    }
    this.processTrainingMode();
  }

  trainingModeToggle()
  {
    this.trainingMode = !this.trainingMode;

    if(this.trainingMode)
    {
      this.processTrainingMode();
    }
    else{
      this.setAllButtons(true);
    }
  }

  private processTrainingMode()
  {
      if(this.trainingMode)
      {
          if(this.isPinCorrect)
          {
              this.setAllButtons(false);
              this.enterButtonEnabled = true;
          }
          else
          {
              this.disableAllWrongButtons();
              this.enterButtonEnabled = false;
              this.clearButtonEnabled = true;
          }
      }
  }

  private disableAllWrongButtons()
  {
      let nextChar = this.nextNumber;
      if(nextChar != null)
      {
        // tslint:disable-next-line:prefer-const
        let nextNum = +nextChar;
          for(let i = 0; i < 10; i++)
          {
            let enabled = false;
            if(i === nextNum)
            {
              enabled = true;
            }
            this.numberButtonsState[i] = enabled;
          }
      }
  }

  private get nextNumber(): string
  {
      if (this.curentEnteredValue.length === 1 &&  this.curentEnteredValue[0] === '0') {
          return this.pin[0];
      }
      else {
          if (this.pin.length > this.curentEnteredValue.length) {
              return this.pin[this.curentEnteredValue.length];
          }
          return null;
      }
  }

  private get isPinCorrect(): boolean
  {
          return (this.curentEnteredValue.toLowerCase() === this.pin.toLowerCase());
  }


  vibrate(duration: any)
  {
    if ('vibrate' in this.navigator) {
      // vibration API supported
      this.navigator.vibrate(duration);
    }
  }

  speak(text: string)
  {
    let utterThis = new SpeechSynthesisUtterance(text);
    this.synth.speak(utterThis);
  }
}


