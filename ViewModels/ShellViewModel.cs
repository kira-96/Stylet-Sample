namespace WpfSample.ViewModels
{
    using Stylet;
    using StyletIoC;
    using System.Windows;
    using System.Windows.Controls;

    public class ShellViewModel : Screen, IHandle<TabChangedEvent>
    {
        private readonly IEventAggregator _eventAggregator;

        [Inject]
        private IWindowManager _windowManager;

        [Inject(Key = "filelogger")]
        private ILogger _logger;

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetAndNotify(ref _name, value);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            DisplayName = "Hello Stylet!";
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        protected override void OnClose()
        {
            _eventAggregator.Unsubscribe(this);

            base.OnClose();
        }

        public void Handle(TabChangedEvent message)
        {
            // TODO
            if (message.ActiveItem == null)
                DisplayName = "Hello Stylet!";
            else
                DisplayName = message.ActiveItem.DisplayName;
        }

        public bool CanSayHello => !string.IsNullOrEmpty(Name);

        public void SayHello()
        {
            _logger.Info("Say Hello {0}", _name);
            _windowManager.ShowMessageBox($"Hello {_name}");
        }

        public void OpenNavWindow(Button s, RoutedEventArgs e)
        {
            _logger.Info("Open new Nav Window.");
            _windowManager.ShowWindow(SimpleIoC.Get<NavViewModel>());
        }
    }
}
