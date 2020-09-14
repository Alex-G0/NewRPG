using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints { get; set; }
        private int _minDamage { get; set; }
        private int _maxDamage { get; set; }
        public string MonsterName { get; set; }
        public int MonsterID { get; set; }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged("HitPoints");
            }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value;
                OnPropertyChanged("MinDamage");
            }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set
            {
                _maxDamage = value;
                OnPropertyChanged("MaxDamage");
            }
        }
        public Monster(int id, string name, int hitPoints, int minDamage, int maxDamage)
        {
            MonsterID = id;
            MonsterName = name;
            HitPoints = hitPoints;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
