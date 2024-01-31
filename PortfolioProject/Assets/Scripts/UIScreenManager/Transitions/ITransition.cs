using Cysharp.Threading.Tasks;

namespace Kborod.UI.UIScreenManager.Transitions
{
    public interface ITransition
    {
        UniTask Show(ITransition prevOrNull = null);
        UniTask Hide(ITransition nextOrNull = null);
    }
}