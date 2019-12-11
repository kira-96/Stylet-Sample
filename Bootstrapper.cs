namespace WpfSample
{
    using Stylet;
    using StyletIoC;
    using System.Windows.Threading;

    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            base.ConfigureIoC(builder);

            builder.Bind<ILogger>().To<Logger>().InSingletonScope().AsWeakBinding();
        }

        protected override void Configure()
        {
            base.Configure();

            SimpleIoC.GetInstance = this.Container.Get;
            SimpleIoC.GetAllInstances = this.Container.GetAll;
            SimpleIoC.BuildUp = this.Container.BuildUp;
        }

        protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
        {
            Container.Get<ILogger>("filelogger").Fatal(e.Exception);
        }
    }
}
