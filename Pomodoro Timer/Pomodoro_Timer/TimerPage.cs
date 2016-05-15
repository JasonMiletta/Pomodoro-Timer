using System;

using Xamarin.Forms;

namespace Pomodoro_Timer
{
    public class TimerPage : ContentPage
	{
        TimerViewModel _timer;

        public TimerPage(TimerViewModel timer)
        {
            this._timer = timer;
            this.BindingContext = timer;

            var CurrentTimer = new Label
            {
                Text = timer.time,
                HorizontalTextAlignment = TextAlignment.Center
            };
            CurrentTimer.SetBinding(Label.TextProperty, "time");

            var Task = new Entry
            {
                Text = timer.task,
                Placeholder = "Enter a name for your task.",
                HorizontalTextAlignment = TextAlignment.Center
            };
            Task.SetBinding(Entry.TextProperty, "text");

            var ProgressBar = new ProgressBar
            {
                Progress = 0.0
            };
            ProgressBar.SetBinding(ProgressBar.ProgressProperty, "currentProgress");

            var StartButton = new Button
            {
                Text = "Start"
            };
            StartButton.Clicked += OnStartClicked;

            var StopButton = new Button
            {
                Text = "Stop"
            };
            StopButton.Clicked += OnStopClicked;

            var ResetButton = new Button
            {
                Text = "Reset"
            };
            ResetButton.Clicked += OnResetClicked;
            
			Content = new StackLayout {
				Children = {CurrentTimer, Task, ProgressBar, StartButton, StopButton, ResetButton}
			};
		}

        private void OnStartClicked(object sender, EventArgs e)
        {
            _timer.startTimer();   
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            _timer.stopTimer();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            _timer.resetTimer();
        }
    }
}
