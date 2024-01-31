using Cysharp.Threading.Tasks;
using Kborod.UI.UIScreenManager;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Kborod.UI.Screens
{
    [UIScreen("UI/Screens/PreloaderScreen.prefab")]
    public class PreloaderScreen : UIScreenBase
    {
        [SerializeField] private Image _scaleImage;

        private const float PROCESS_DURATION = 1f;

        public async UniTask Process()
        {
            await ProcessCoroutine();
        }

        private IEnumerator ProcessCoroutine()
        {
            var progress = 0f;

            while (progress <= 1)
            {
                progress += Time.deltaTime / PROCESS_DURATION;
                _scaleImage.fillAmount = progress;
                yield return null;
            }
        }
    }
}
