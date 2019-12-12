namespace WpfSample.ViewModels
{
    using Stylet;
    using StyletIoC;

    public class NavViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private readonly IEventAggregator _eventAggregator;

        [Inject(Key = "filelogger")]
        private ILogger _logger;

        public NavViewModel(
            IEventAggregator eventAggregator,
            FirstTabViewModel tab1,
            SecondTabViewModel tab2)
        {
            this._eventAggregator = eventAggregator;
            this.Items.Add(tab1);
            this.Items.Add(tab2);
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();

            this.ActiveItem = Items.Count > 0 ? Items[0] : null;
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == "ActiveItem")
            {
                _logger.Debug("Nav ActiveItem Changed: {0}", ActiveItem?.DisplayName);
                _eventAggregator.Publish(new TabChangedEvent(ActiveItem));
            }
        }
    }
}
