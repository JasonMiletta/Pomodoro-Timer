using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;

namespace Pomodoro_Timer
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Stopwatch _stopwatch;

        public float seconds;
        public float minutes;
        public float hours;

        public string time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        private string _time;

        public TimerViewModel()
        {
            initializeTimer();
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void startTimer()
        {
            _stopwatch.Start();
            time = "started";
        }

        public void stopTimer()
        {
            _stopwatch.Stop();
            time = "stopped";
        }

        public void resetTimer()
        {
            _stopwatch.Reset();
            time = "time";
        }

        private void initializeTimer()
        {
            _stopwatch = new Stopwatch();
        }
    }
}
