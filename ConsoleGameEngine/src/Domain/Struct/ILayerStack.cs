using System.Collections.Generic;

namespace ConsoleGameEngine.Domain.Struct
{
    public interface ILayerStack : IEnumerable<ILayer>
    {
        void Push(ILayer layer);
        void Pop(ILayer layer);

    }
}
