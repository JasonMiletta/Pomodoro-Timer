using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace Pomodoro_Timer
{
    public class PomodoroTimer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Timer timer;

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

        public PomodoroTimer()
        {
            _seconds = 0;
            _minutes = 0;
            _hours = 0;

            initializeTimer();
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
            timer.Enabled = true;
        }

        public void stopTimer()
        {
            timer.Enabled = false;
        }

        public void resetTimer()
        {
            Seconds = 0;
        }

        private void initializeTimer()
        {
            timer = new Timer(10);
            timer.AutoReset = true;
            timer.Elapsed += OnElapsedEvent;
        }

        private void OnElapsedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("{0}", e.SignalTime);
        }
    }
}
