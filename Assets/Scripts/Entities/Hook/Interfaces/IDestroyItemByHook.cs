

using Unity.VisualScripting;

namespace Assets.Scripts.Entities
{
    public interface IDestroyItemByHook
    {
        bool IsDestroy { get; set; }
        bool DestroyItem();
    }
}
