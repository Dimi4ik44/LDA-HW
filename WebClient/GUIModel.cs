using System;
using System.Collections.Generic;
using System.Text;

namespace WebClient
{
    abstract class GUIModel<T> : IGUIdable where T : class
    {
        public T Data { get; set; }
        public abstract void Render();
        public GUIModel(T data)
        {
            Data = data;
        }

    }
}
