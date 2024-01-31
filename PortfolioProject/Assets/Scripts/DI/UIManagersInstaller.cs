using Kborod.UI.UIScreenManager;
using Kborod.UI.UIScreenManager.LoadOverlay;
using UnityEngine;
using Zenject;

namespace Kborod.Services.DI
{
    public class UIManagersInstaller : MonoInstaller
    {
        [SerializeField] private UIScreensLoader _screensLoaderPrefab;
        [SerializeField] private UIScreensManager _screensManagerPrefab;
        [SerializeField] private TransitionsConstructor _transitionsConstructor;
        [SerializeField] private LoadingOverlay _loadingOverlayPrefab;
        [SerializeField] private LoadingOverlayHelper _loadingOverlayHelperPrefab;

        public override void InstallBindings()
        {
            Container.Bind<UIScreensLoader>().FromComponentInNewPrefab(_screensLoaderPrefab).AsSingle().NonLazy();
            Container.Bind<UIScreensManager>().FromComponentInNewPrefab(_screensManagerPrefab).AsSingle().NonLazy();
            Container.Bind<TransitionsConstructor>().FromInstance(_transitionsConstructor).AsSingle().NonLazy();
            Container.Bind<LoadingOverlay>().FromComponentInNewPrefab(_loadingOverlayPrefab).AsSingle().NonLazy();
            Container.Bind<LoadingOverlayHelper>().FromComponentInNewPrefab(_loadingOverlayHelperPrefab).AsSingle().NonLazy();
        }
    }
}
