using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolyhydraGames.TextToSpeech.Core
{
    public interface ITextToSpeech
    {
         void Speak(string text);

         void Rate(double newvalue);

        void ChangeVoice(string voice);

        string[] VoiceNames();

         void Stop();

         Enum Pause();
    }
 
}
