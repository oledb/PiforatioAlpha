using System;

namespace Piforatio.WPF
{
    public class TimerMessager
    {
        private MessageSender _sender;
        private TimerViewModel _viewModel;
        private int quantCount;
        public TimerMessager(MessageSender sender, TimerViewModel viewModel)
        {
            _sender = sender;
            _viewModel = viewModel;
            _viewModel.OnTimerStart += TimerStart;
            _viewModel.OnTimerEnd += TimerStop;
            _viewModel.OnTimerStop += TimerStop;
            _viewModel.OnIntervalReached += TimerExecute;
        }

        public void TimerStart(object obj, EventArgs args)
        {
            _sender.Send("Timer is started");
            quantCount = 0;
        }

        public void TimerExecute(object obj, EventArgs args)
        {
            quantCount++;
        }

        public void TimerStop(object obj, EventArgs args)
        {
            if (quantCount == 0)
                _sender.Send("No quants was completed");
            else
                _sender.Send($"{quantCount} quants was completed");
        }
    }
}
