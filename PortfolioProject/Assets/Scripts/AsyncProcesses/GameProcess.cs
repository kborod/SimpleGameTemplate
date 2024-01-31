using Cysharp.Threading.Tasks;
using Kborod.Model;
using Kborod.UI.Screens;
using Kborod.UI.UIScreenManager;

namespace Kborod.AsyncProcesses
{
    public class GameProcess : IAsyncProcess<bool>
    {
        private UIScreensManager _screensManager;

        private UniTaskCompletionSource<bool> _utcs;

        public GameProcess(UIScreensManager screensManager)
        {
            _screensManager = screensManager;
        }

        public async UniTask<bool> Run()
        {
            _ = await _screensManager.Open<GameScreen>();

            _utcs = new UniTaskCompletionSource<bool>();
            return await _utcs.Task;
        }
    }
}
