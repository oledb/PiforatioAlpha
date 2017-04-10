using System;

namespace Piforatio.WPF
{
    public class TimerMessager
    {
        private readonly MessageSender _sender;
        private int _quantCount;
        public TimerMessager(MessageSender sender, TimerViewModel viewModel)
        {
            _sender = sender;
            viewModel.OnTimerStart += TimerStart;
            viewModel.OnTimerStop += TimerStop;
            viewModel.OnIntervalReached += TimerExecute;
        }

        public void TimerStart(object obj, EventArgs args)
        {
            _sender.Send("Timer is started");
            _quantCount = 0;
        }

        public void TimerExecute(object obj, EventArgs args)
        {
            _quantCount++;
        }

        public void TimerStop(object obj, EventArgs args)
        {
            _sender.Send(_quantCount == 0 ? "No quants was completed" : $"{_quantCount} quants was completed");
        }
    }
}
