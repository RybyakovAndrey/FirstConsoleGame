using System.Collections;
using System.Collections.Generic;

namespace ConsoleGameEngine.Domain.Struct
{
    public sealed class LayerStack : ILayerStack
    {
        private List<ILayer> m_stack;
        public LayerStack() 
        { 
            m_stack = new List<ILayer>();
        }

        public void Pop(ILayer layer)
        {
            if (layer is null)
                return;

            m_stack.Remove(layer);     
        }

        public void Push(ILayer layer)
        {
            if (layer is null)
                return;

            m_stack.Add(layer);
        }

        public void Clear()
        {
            m_stack.Clear();
        }

        public IEnumerator<ILayer> GetEnumerator()
        {
            for(int i = 0; i < m_stack.Count; i++)
                yield return m_stack[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
