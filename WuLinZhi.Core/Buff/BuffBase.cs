using System;


namespace WuLinZhi.Core.Buff
{
    public abstract class BuffBase
    {
        private int _layer = 0;
        public BuffBase()
        {
        }

        public bool Removable { get; set; }
        public int MaxLayer { get; set; }
        public int Layer
        {
            get => _layer;
            set
            {
                _layer = _layer < MaxLayer ? _layer : MaxLayer;
            }
        }

    }
}

