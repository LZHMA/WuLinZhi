using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Equipment;
using WuLinZhi.Core.Force;

namespace WuLinZhi.Core.Character
{
    class Character
    {
        #region field
        private int _hpBase;
        private int _hpEquipment;
        private int _hpForce;
        #endregion

        #region property
        public int HPBase { get; set; }
        public int HP
        {
            get => _hpBase+_hpEquipment+_hpForce;
        }

        public ICollection<EquipmentBase> Equipments { get; set; }
        public ICollection<ForceBase> Forces { get; set; }
        #endregion

        public void OnEquipmentChange(object sender, EventArgs e)
        {
        }

        public void OnForceChange(object sender,EventArgs e)
        {

        }
    }
}