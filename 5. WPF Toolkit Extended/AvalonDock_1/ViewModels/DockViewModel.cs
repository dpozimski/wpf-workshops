namespace ToDo.WPF.Core.ViewModels
{
    public class DockViewModel : BaseViewModel 
    {
        private bool _isClosed;

        public bool IsClosed
        {
            get => _isClosed;
            set => SetProperty(ref _isClosed, value);
        }
    }
}
