using TDS.Entities;

namespace TDS.Components
{
    public interface IComponent : IHaveEntity, IDestroyable
    {
        void Init(IEntity entity);
        void OnRegistered();
    }
}