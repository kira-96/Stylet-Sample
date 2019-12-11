namespace WpfSample
{
    using Stylet;

    public class TabChangedEvent
    {
        public IScreen ActiveItem { get; }

        public TabChangedEvent(IScreen activeItem)
        {
            ActiveItem = activeItem;
        }
    }
}
