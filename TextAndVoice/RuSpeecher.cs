using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;
using System.Globalization;
using System.Windows.Forms;

namespace TextAndVoice
{
    class RuSpeecher
    {
        SpeechRecognitionEngine _speechRecognitionEngine;
        Grammar _dictationGrammar;
        CultureInfo cultureInfo;
        public RuSpeecher()
        {
            cultureInfo = new CultureInfo("ru-RU");
            try
            {
                _speechRecognitionEngine = new Microsoft.Speech.Recognition.SpeechRecognitionEngine();
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("Не удалось запустить программу. Детали ниже:\n{0}", e.Message));
                Application.Exit();
            }
            _speechRecognitionEngine.SetInputToDefaultAudioDevice();
            //_dictationGrammar = new Grammar();
            _speechRecognitionEngine.LoadGrammar(_dictationGrammar);
            _speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            InitializingHandlers();
        }

        private void InitializingHandlers()
        {
            _speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
            _speechRecognitionEngine.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizing);
        }

        private void SpeechHypothesizing(object sender, SpeechHypothesizedEventArgs e)
        {
            MainForm.Current.realTimeResults.Text = e.Result.Text;
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MainForm.Current.finalAnswer.Text += string.Format(" {0}", e.Result.Text);
        }
    }
}
