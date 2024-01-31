using Cysharp.Threading.Tasks;
using Kborod.Model;
using Kborod.UI.Screens;
using Kborod.UI.UIScreenManager;

namespace Kborod.AsyncProcesses
{
    public class LoginProcess : IAsyncProcess<bool>
    {
        private UIScreensManager _screensManager;
        private AccountModel _accountModel;

        private UniTaskCompletionSource<bool> _utcs;

        public LoginProcess(UIScreensManager screensManager, AccountModel accountModel)
        {
            _screensManager = screensManager;
            _accountModel = accountModel;
        }

        public async UniTask<bool> Run()
        {
            _accountModel.LoggedIn += LoggedInHandler;
            _ = await _screensManager.Open<LoginScreen>();

            _utcs = new UniTaskCompletionSource<bool>();
            return await _utcs.Task;
        }

        private void LoggedInHandler()
        {
            _accountModel.LoggedIn -= LoggedInHandler;
            _utcs.TrySetResult(true);
        }
    }
}
