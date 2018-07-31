using System;
using System.Speech.Recognition;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SpeechRecognition
{
    public class MainViewModel : ViewModelBase, IDisposable
    {
        private SpeechRecognitionEngine _recognizerEngine;

        public ICommand ActivateRecognitionCommand { get; private set; }

        private string _recognizedText;

        public string RecognizedText
        {
            get
            {
                return _recognizedText;
            }

            set
            {
                Set(ref _recognizedText, value);
            }
        }

        public MainViewModel()
        {
            ActivateRecognitionCommand = new RelayCommand(ActivateRecognition);

            InitializeRecognitionEngine();
        }

        private void InitializeRecognitionEngine()
        {
            _recognizerEngine = new SpeechRecognitionEngine();
            _recognizerEngine.SetInputToDefaultAudioDevice();
        }

        private void ActivateRecognition()
        {
            RecognizedText = string.Empty;
            _recognizerEngine.RecognizeAsync();
        }

        public void Dispose()
        {
            if (_recognizerEngine != null)
            {
                _recognizerEngine.Dispose();
            }
        }
    }
}