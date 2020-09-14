using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.ViewModels;

namespace Engine
{
    public static class MonsterFactory
    {
        public static List<Monster> _monsters;
        static MonsterFactory()
        {
            _monsters = new List<Monster>();
            _monsters.Add(new Monster(00, "Rat", 6, 1, 3));
        }
        public static Monster GetMonsterByID (int id)
        {
            foreach (Monster m in _monsters)
            {
                if (m.MonsterID == id)
                {
                    return m;
                }
            }
            return null;
        }
            

    }
}
