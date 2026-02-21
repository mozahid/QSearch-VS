namespace QSearch
{
    public class Progress
    {
        private ActivityIndicator _prog;
        public Progress(ActivityIndicator ind)
        {
            _prog = ind;
        }
        public void ShowProgress()
        {
            _prog.IsVisible = true;
            _prog.IsRunning = true;
        }
        public void HideProgress()
        {
            _prog.IsVisible = false;
            _prog.IsRunning = false;
        }
    }
}