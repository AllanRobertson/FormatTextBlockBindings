
using System;
using System.Collections.Generic;

namespace TextBlockFormating
{
    public class MainWindowViewModel : ViewModelBase
    {

        private List<string> _stringList = new List<string> { "The", "Quick", "Brown", "Fox", "Jumped", "Over", "The", "Lazy", "Dog" };

        int _index = 0;

        public MainWindowViewModel()
        {
            StepCommand = new RelayCommand(OnStepCommand);
        }


        private string _formattedText;

        public string FormattedText
        {
            get { return _formattedText; }
            set
            {
                if (value != _formattedText)
                {
                    _formattedText = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand StepCommand { get; private set; }

        private void OnStepCommand()
        {
            if (_index == _stringList.Count)
            {
                _index = 0;
            }
            FormattedText = string.Format("<Bold>The next string is</Bold> <Span FontStyle=\"Italic\">{0}</Span>", _stringList[_index++]);
        }

    }
}
