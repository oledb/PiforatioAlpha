using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.Commands;
using Piforatio.Win.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Piforatio.Win.ViewModelCollection
{
    public class PTaskVMCollection : Notifier
    {
        public ObservableCollection<IPTask> PTasks { get; set; }

        public IProject BaseProject { get; protected set; }

        private PTaskModel _pTaskModel;

        public int SelectPTaskByValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IPTask SelectedPTask
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddPTask(IPTask pTask)
        {
            throw new NotImplementedException();
        }

        public void RemovePTaskSelected()
        {
            throw new NotImplementedException();
        }

        public void ChangePTaskSelected()
        {
            throw new NotImplementedException();
        }
    }
}
