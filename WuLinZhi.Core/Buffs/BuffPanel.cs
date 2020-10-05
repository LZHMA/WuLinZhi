using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Buffs
{
    public class BuffPanel:List<IBuff>
    {
        public CharacterInFight Owner { get; set; }
        public void AppendBuff(IBuff buffToAppend,int layer)
        {
            if(this.Exists(buff=>buff.Name.Equals(buffToAppend.Name)))
            {
                var existBuff=this.Single<IBuff>(buff => buff.Name.Equals(buffToAppend.Name));
                existBuff.ChangeState(Owner, layer);
            }
            else
            {
                this.Add(buffToAppend);
                buffToAppend.ChangeState(Owner, layer);
            }
        }
    }
}
