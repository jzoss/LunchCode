
using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using LunchCode.UWP;//enables registration outside of namespace

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace LunchCode.UWP
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation() { }

        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}
