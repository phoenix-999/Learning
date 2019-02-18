using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace VoiceControl
{
    
    class Listener
    {
        SpeechRecognitionEngine _speechRecognitionEngine;
        DictationGrammar _dictationGrammar;

        public Listener()
        {
            _speechRecognitionEngine = new SpeechRecognitionEngine();
            _speechRecognitionEngine.SetInputToDefaultAudioDevice();
            _dictationGrammar = new DictationGrammar();
            _speechRecognitionEngine.LoadGrammar(_dictationGrammar);
            _speechRecognitionEngine.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple);

            InitializingHandlers();


        }

        private void InitializingHandlers()
        {
            _speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
        }

        

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Thread th = new Thread(() => {           
                    MainForm.MainFormSyncContext.Post((object state) => { (Application.OpenForms["MainForm"] as MainForm).tbSpokenCommandText.Text = string.Format("{0}", e.Result.Text); }, null);
            });
            th.IsBackground = true;
            th.Start();
        }
    }
}
