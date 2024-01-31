using Kborod.AsyncProcesses;
using UnityEngine;
using Zenject;

namespace Kborod.Loader
{
    public class Bootstraper : MonoBehaviour
    {
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private async void Start()
        {
            await _container.Instantiate<InitServices>().Run();

            await _container.Instantiate<PreloaderProcess>().Run();

            await _container.Instantiate<LoginProcess>().Run();

            await _container.Instantiate<GameProcess>().Run();
        }
    }
}
