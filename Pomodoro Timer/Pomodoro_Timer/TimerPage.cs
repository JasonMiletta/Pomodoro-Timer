using System;

using Xamarin.Forms;

namespace Pomodoro_Timer
{
    public class TimerPage : ContentPage
	{
        PomodoroTimer _timer;

		public TimerPage (PomodoroTimer timer)
		{
            this._timer = timer;
            this.BindingContext = timer;
            var seconds = "00";
            var minutes = "00";

            var CurrentTimer = new Label
            {
                Text = minutes + ":" + seconds,
                HorizontalTextAlignment =  TextAlignment.Center
            };
            CurrentTimer.SetBinding(Label.TextProperty, "Seconds");

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
				Children = {CurrentTimer, StartButton, StopButton, ResetButton}
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
