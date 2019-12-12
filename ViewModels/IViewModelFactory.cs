namespace WpfSample.ViewModels
{
    public interface IViewModelFactory
    {
        ShellViewModel GetShellViewModel();

        NavViewModel GetNavViewModel();

        FirstTabViewModel GetFirstTabViewModel();

        SecondTabViewModel GetSecondTabViewModel();
    }
}
