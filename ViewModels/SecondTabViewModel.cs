namespace WpfSample
{
    using Stylet;
    using System;

    public class SecondTabViewModel : Screen, IDisposable
    {
        public SecondTabViewModel()
        {
            this.DisplayName = "Second";
        }

        public void Dispose()
        {
            // TODO
        }
    }
}
