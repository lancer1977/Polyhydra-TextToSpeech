using System;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using PolyhydraGames.TextToSpeech.Core;

namespace PolyhydraGames.TextToSpeech.Windows
{
    public class TextToSpeech : ITextToSpeech
    {
        public SpeechSynthesizer Synthesizer { get; }

        public TextToSpeech()
        {
            Synthesizer = new SpeechSynthesizer { Rate = 1, Volume = 100 };
        }

        public void Speak(string text)
        {
            Synthesizer.SpeakAsync(text);
        }

        public void Rate(double newvalue)
        {
            Synthesizer.Rate = (int)newvalue;
        }

        public void ChangeVoice(string voice)
        {
            Task.Run(() =>
            {
                Synthesizer.SelectVoice(voice);
            });

        }

        public string[] VoiceNames()
        {
            return (from items in Synthesizer.GetInstalledVoices()
                    select items.VoiceInfo.Name).ToArray();
        }

        public void Stop()
        {
            Synthesizer.SpeakAsyncCancelAll(); 

        }
        public Enum Pause()
        {
            switch (Synthesizer.State)
            {
                case SynthesizerState.Speaking:

                    Synthesizer.Pause();
                    break;
                case SynthesizerState.Paused:
                    Synthesizer.Resume();
                    break;
            }
            return Synthesizer.State;

        }
         
    }
}