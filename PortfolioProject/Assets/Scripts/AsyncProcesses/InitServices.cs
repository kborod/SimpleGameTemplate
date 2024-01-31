using Cysharp.Threading.Tasks;
using Kborod.UI.UIScreenManager;
using Zenject;

namespace Kborod.AsyncProcesses
{
    public class InitServices : IAsyncProcess<bool>
    {
        private UIScreensLoader _screensLoader;

        [Inject]
        public void Construct(UIScreensLoader screensLoader)
        {
            _screensLoader = screensLoader;
        }

        public async UniTask<bool> Run()
        {
            await _screensLoader.Initialize();
            return true;
        }
    }
}
