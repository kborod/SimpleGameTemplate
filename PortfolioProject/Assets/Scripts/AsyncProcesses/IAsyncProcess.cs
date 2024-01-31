using Cysharp.Threading.Tasks;

namespace Kborod.AsyncProcesses
{
    public interface IAsyncProcess<T>
    {
        public UniTask<T> Run();
    }
}
