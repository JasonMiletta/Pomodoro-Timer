﻿using System;

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

            var TimerSection = ConstructTimerSection();

            var BottomButtonBar = ConstructBottomButtonBar();

            var TopButtonBar = ConstructTopButtonBar();

            Content = new StackLayout {
                Children = { TopButtonBar, TimerSection, BottomButtonBar },
                VerticalOptions = LayoutOptions.Center
            };
        }

        private StackLayout ConstructTimerSection()
        {
            var TimeLimitLabel = new Label
            {
                Text = string.Format("{0}:00",_timer.timeLimitMinutes.ToString()),
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center
            };
            TimeLimitLabel.SetBinding(Label.TextProperty, "timeLimitMinutes");

            var TimeLimitStepper = new Stepper
            {
                Value = _timer.timeLimitMinutes,
                Minimum = 0,
                Maximum = 60,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center
            };
            TimeLimitStepper.SetBinding(Stepper.ValueProperty, "timeLimitMinutes");

            var CurrentTimer = new Label
            {
                Text = _timer.time,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 60
            };
            CurrentTimer.SetBinding(Label.TextProperty, "time");

            var Task = new Entry
            {
                Text = _timer.task,
                Placeholder = "Enter a name for your task.",
                HorizontalTextAlignment = TextAlignment.Center
            };
            Task.SetBinding(Entry.TextProperty, "text");

            var ProgressBar = new ProgressBar
            {
                Progress = 0.0
            };
            ProgressBar.SetBinding(ProgressBar.ProgressProperty, "currentProgress");

            var TimerSection = new StackLayout
            {
                Children = { TimeLimitLabel, TimeLimitStepper, CurrentTimer, Task, ProgressBar }
            };

            return TimerSection;
        }

        private Grid ConstructTopButtonBar()
        {

            var PomodoroButton = new Button
            {
                Text = "Pomodoro"
            };
            PomodoroButton.Clicked += OnPomodoroClicked;

            var BreakButton = new Button
            {
                Text = "Break"
            };
            BreakButton.Clicked += OnBreakClicked;

            var TopButtonBar = new Grid();
            TopButtonBar.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            TopButtonBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            TopButtonBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            TopButtonBar.Children.Add(PomodoroButton, 0, 0);
            TopButtonBar.Children.Add(BreakButton, 1, 0);

            return TopButtonBar;
        }

        private Grid ConstructBottomButtonBar()
        {
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

            var BottomButtonBar = new Grid();
            BottomButtonBar.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            BottomButtonBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            BottomButtonBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            BottomButtonBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            BottomButtonBar.Children.Add(StartButton, 0, 0);
            BottomButtonBar.Children.Add(StopButton, 1, 0);
            BottomButtonBar.Children.Add(ResetButton, 2, 0);

            return BottomButtonBar;
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

        private void OnPomodoroClicked(object sender, EventArgs e)
        {
            _timer.setPomodoroTime();
        }

        private void OnBreakClicked(object sender, EventArgs e)
        {
            _timer.setBreakTime();
        }
    }
}
