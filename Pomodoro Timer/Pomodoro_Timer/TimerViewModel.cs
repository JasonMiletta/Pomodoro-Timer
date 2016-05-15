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

        private Stopwatch _stopwatch;
        private Timer timer;
        private string _time;
        private string _task;
        private double _currentProgress;
        private double _timeLimitMinutes;

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

        public string task
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        public double currentProgress
        {
            get
            {
                return _currentProgress;
            }
            set
            {
                _currentProgress = value;
                OnPropertyChanged();
            }
        }

        public double timeLimitMinutes
        {
            get
            {
                return _timeLimitMinutes;
            }
            set
            {
                _timeLimitMinutes = value;
                OnPropertyChanged();
            }
        }

        public TimerViewModel()
        {
            initializeTimer();
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void startTimer()
        {
            timer.Enabled = true;
            _stopwatch.Start();
        }

        public void stopTimer()
        {
            timer.Enabled = false;
            _stopwatch.Stop();
        }

        public void resetTimer()
        {
            timer.Enabled = false;
            _stopwatch.Reset();
            time = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.f");
            currentProgress = _stopwatch.ElapsedMilliseconds / (_timeLimitMinutes * 60 * 1000);
        }

        private void initializeTimer()
        {
            timer = new Timer(50);
            timer.Elapsed += new ElapsedEventHandler(onElapsedEvent);
            _stopwatch = new Stopwatch();

            _timeLimitMinutes = 1;
            time = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.f");
        }

        private void onElapsedEvent(object source, ElapsedEventArgs e)
        {
            time = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.f");
            currentProgress = _stopwatch.ElapsedMilliseconds / (_timeLimitMinutes * 60 * 1000);
            if(currentProgress >= 1)
            {
                stopTimer();
            }
        }
    }
}
