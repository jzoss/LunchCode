using System;
using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using LunchCode.Droid;

[assembly: Dependency(typeof(TextToSpeech_Android))]

namespace LunchCode.Droid
{
    public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        public TextToSpeech_Android() { }

        public void Speak(string text)
        {
            var c = Forms.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(c, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Add, p);
                System.Diagnostics.Debug.WriteLine("spoke " + toSpeak);
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                System.Diagnostics.Debug.WriteLine("speaker init");
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Add, p);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("was quiet");
            }
        }
        #endregion
    }
}