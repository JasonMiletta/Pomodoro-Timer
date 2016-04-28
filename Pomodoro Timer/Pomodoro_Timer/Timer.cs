using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pomodoro_Timer
{
    public class Timer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        float _seconds;
        float _minutes;
        float _hours;

        public float Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                OnPropertyChanged();
            }
        }

        public float Minutes
        {
            get { return _minutes; }
        }

        public float Hours
        {
            get { return _hours; }
        }

        public Timer()
        {
            _seconds = 0;
            _minutes = 0;
            _hours = 0;

        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void startTimer()
        {
            Seconds = 12;
        }

        public void stopTimer()
        {

        }

        public void resetTimer()
        {
            Seconds = 0;
        }
    }
}
