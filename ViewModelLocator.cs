namespace WpfSample
{
    using ViewModels;

    public class ViewModelLocator
    {
        public ShellViewModel ShellViewModel =>
            new ShellViewModel(null)
            {
                DisplayName = "Design Mode!",
                Name = "your name"
            };
    }
}
