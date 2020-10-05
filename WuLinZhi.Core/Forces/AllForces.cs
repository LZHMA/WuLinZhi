using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using WuLinZhi.Core.Effects;

namespace WuLinZhi.Core.Forces
{
    public static class AllForces
    {
        private static List<Force> Singleton { get; } = new List<Force>
        {
            new Force
            {
                Name = "禅宗伏魔功",
                YinPhase = 0,
                RouPhase = 0,
                YangPhase = 16,
                GangPhase = 0,
                DuPahse = 0,
                Effects = new List<Effect>
                {
                    new AddSpecificHPCap(EffectOccasion.FightStart,100,300)
                }
            },
        };

        public static List<Force> GetAll()
        {
            return Singleton;
        }

        public static List<string> GetAllForceNames()
        {
            var nameList = new List<string>();
            Singleton.ForEach(force => nameList.Add(force.Name));
            return nameList;
        }

        public static Force GetForceByName(string name)
        {
            return Singleton.Single(force => force.Name.Equals(name));
        }
        public static List<Force> GetForcesByNames(List<string> names)
        {
            var forces = new List<Force>();
            foreach (var name in names)
            {
                var force = GetForceByName(name);
                forces.Add(force);
            }
            return forces;
        }
    }
}
