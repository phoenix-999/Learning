using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Globalization;
using System.Speech.Recognition;
using System.Threading;

namespace TextAndVoice
{
    class EnSpeecher
    {
        SpeechRecognitionEngine _speechRecognitionEngine;
        DictationGrammar  _dictationGrammar;
        public EnSpeecher()
        {
            _speechRecognitionEngine = new System.Speech.Recognition.SpeechRecognitionEngine(new CultureInfo("en-EN"));
            _speechRecognitionEngine.SetInputToDefaultAudioDevice();
            _dictationGrammar = new DictationGrammar();
            _speechRecognitionEngine.LoadGrammar(_dictationGrammar);
            _speechRecognitionEngine.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple);

            InitializingHandlers();
        }

        private void InitializingHandlers()
        {
            _speechRecognitionEngine.SpeechRecognized += new EventHandler<System.Speech.Recognition.SpeechRecognizedEventArgs>(SpeechRecognized);
            _speechRecognitionEngine.SpeechHypothesized += new EventHandler<System.Speech.Recognition.SpeechHypothesizedEventArgs>(SpeechHypothesizing);
        }

        private void SpeechHypothesizing(object sender, System.Speech.Recognition.SpeechHypothesizedEventArgs e)
        {
            MainForm.Current.realTimeResults.Text = e.Result.Text;
        }

        private void SpeechRecognized(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            MainForm.Current.finalAnswer.Text += string.Format(" {0}", e.Result.Text);
        }
    }
}
