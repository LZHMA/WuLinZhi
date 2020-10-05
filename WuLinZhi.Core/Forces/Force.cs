using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Effects;

namespace WuLinZhi.Core.Forces
{
    public class Force
    {
        #region property

        public string Name { get; set; }
        public int YinPhase { get; set; }
        public int RouPhase { get; set; }
        public int YangPhase { get; set; }
        public int GangPhase { get; set; }
        public int DuPahse { get; set; }

        public List<Effect> Effects { get; set; }
        #endregion
    }
}
