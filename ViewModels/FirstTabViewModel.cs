namespace WpfSample.ViewModels
{
    using Stylet;
    using System;

    public class FirstTabViewModel : Screen, IDisposable
    {
        public FirstTabViewModel()
        {
            this.DisplayName = "First";
        }

        public void Dispose()
        {
            // TODO
        }
    }
}
