using System;
using System.Threading;
using System.Windows;

namespace ATV.WPF.Core
{
    public class AsyncDelegateCommand : DelegateCommand
    {
        private bool _IsExecuting = false;

        public AsyncDelegateCommand(Action executeMethod) : base(executeMethod) { }

        public AsyncDelegateCommand(Action executeMethod, Func<bool> canExecuteMethod) : base(executeMethod, canExecuteMethod) { }

        public AsyncDelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled) : base(executeMethod, canExecuteMethod, isAutomaticRequeryDisabled) { }

        public override void Execute()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                _IsExecuting = true;
                base.Execute();
                _IsExecuting = false;
                Application.Current.Dispatcher.Invoke(() => RaiseCanExecuteChanged());
            });
        }

        public override bool CanExecute() => base.CanExecute() && !_IsExecuting;
    }
}

