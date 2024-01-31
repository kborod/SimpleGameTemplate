using UnityEngine;
using Zenject;

namespace Kborod.UI.UIScreenManager.LoadOverlay
{
    public class LoadingOverlayHelper : MonoBehaviour
    {
        private LoadingOverlay _loadingOverlay;
        private UIScreensManager _screensManager;

        [Inject]
        public void Construct(LoadingOverlay loadingOverlay, UIScreensManager screensManager)
        {
            _loadingOverlay = loadingOverlay;
            _screensManager = screensManager;
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _screensManager.OnLoadingScreenStarted += ScreensManagerWorkStartedHandler;
            _screensManager.OnLoadingScreenFinished += ScreensManagerWorkFinishedHandler;
        }

        private void RemoveListeners()
        {
            _screensManager.OnLoadingScreenStarted -= ScreensManagerWorkStartedHandler;
            _screensManager.OnLoadingScreenFinished -= ScreensManagerWorkFinishedHandler;
        }

        private void ScreensManagerWorkStartedHandler()
        {
            _loadingOverlay.Show();
        }

        private void ScreensManagerWorkFinishedHandler()
        {
            _loadingOverlay.Hide();
        }
    }
}