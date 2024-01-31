using Cysharp.Threading.Tasks;
using Kborod.UI.Screens;
using Kborod.UI.UIScreenManager;

namespace Kborod.AsyncProcesses
{
    public class PreloaderProcess : IAsyncProcess<bool>
    {
        private UIScreensManager _screensManager;

        public PreloaderProcess(UIScreensManager screensManager)
        {
            _screensManager = screensManager;
        }

        public async UniTask<bool> Run()
        {
            var screen = await _screensManager.Open<PreloaderScreen>();
            await screen.Process();
            return true;
        }
    }
}
