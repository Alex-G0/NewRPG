using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Engine;
using Engine.Actions;
using Engine.Dialogues;
using Engine.Battle;
using Engine.EventArgs;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public event EventHandler<EncounterMessageEventArgs> OnEncounterMessageRaised;
        private Monster _currentMonster { get; set; }
        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                if(CurrentMonster != null)
                {
                    RaiseEncounterMessage($"{CurrentMonster.MonsterName} attacking you!");
                }
            }
        }
        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }
        public Glove CurrentGloves { get; set; }
        public Boot CurrentBoots { get; set; }
        private Encounter _currentEncounter { get; set; }
        public Encounter CurrentEncounter 
        {
            get { return _currentEncounter; }
            set
            {
                _currentEncounter = value;
                OnPropertyChanged(nameof(CurrentEncounter));
            }
        }
        private Location _currentLocation { get; set; }
        private Battle1 _currentBattle_1 { get; set; }
        private Action1 _currentAction_1 { get; set; }
        private Action2 _currentAction_2 { get; set; }
        private Action3 _currentAction_3 { get; set; }
        private Action4 _currentAction_4 { get; set; }
        private Action5 _currentAction_5 { get; set; }
        private Action6 _currentAction_6 { get; set; }
        private Action7 _currentAction_7 { get; set; }
        private Dialogue_1 _dialogue_1 { get; set; }
        private Dialogue_2 _dialogue_2 { get; set; }
        private Dialogue_3 _dialogue_3 { get; set; }
        private Dialogue_4 _dialogue_4 { get; set; }
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation 
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        public Battle1 CurrentBattle_1
        {
            get { return _currentBattle_1; }
            set
            {
                _currentBattle_1 = value;
                OnPropertyChanged(nameof(CurrentBattle_1));
            }
        }
        public Action1 CurrentAction_1
        {
            get { return _currentAction_1; }
            set
            {
                _currentAction_1 = value;
                OnPropertyChanged(nameof(CurrentAction_1));
            }
        }
        public Action2 CurrentAction_2
        {
            get { return _currentAction_2; }
            set
            {
                _currentAction_2 = value;
                OnPropertyChanged(nameof(CurrentAction_2));
            }
        }
        public Action3 CurrentAction_3
        {
            get { return _currentAction_3; }
            set
            {
                _currentAction_3 = value;
                OnPropertyChanged(nameof(CurrentAction_3));
            }
        }
        public Action4 CurrentAction_4
        {
            get { return _currentAction_4; }
            set
            {
                _currentAction_4 = value;
                OnPropertyChanged(nameof(CurrentAction_4));
            }
        }
        public Action5 CurrentAction_5
        {
            get { return _currentAction_5; }
            set
            {
                _currentAction_5 = value;
                OnPropertyChanged(nameof(CurrentAction_5));
            }
        }
        public Action6 CurrentAction_6
        {
            get { return _currentAction_6; }
            set
            {
                _currentAction_6 = value;
                OnPropertyChanged(nameof(CurrentAction_6));
            }
        }
        public Action7 CurrentAction_7
        {
            get { return _currentAction_7; }
            set
            {
                _currentAction_7 = value;
                OnPropertyChanged(nameof(CurrentAction_7));
            }
        }
        public Dialogue_1 CurrentDialogue_1
        {
            get { return _dialogue_1; }
            set
            {
                _dialogue_1 = value;
                OnPropertyChanged(nameof(CurrentDialogue_1));
            }
        }
        public Dialogue_2 CurrentDialogue_2
        {
            get { return _dialogue_2; }
            set
            {
                _dialogue_2 = value;
                OnPropertyChanged("CurrentDialogue_2");
            }
        }
        public Dialogue_3 CurrentDialogue_3
        {
            get { return _dialogue_3; }
            set
            {
                _dialogue_3 = value;
                OnPropertyChanged(nameof(CurrentDialogue_3));
            }
        }
        public Dialogue_4 CurrentDialogue_4
        {
            get { return _dialogue_4; }
            set
            {
                _dialogue_4 = value;
                OnPropertyChanged(nameof(CurrentDialogue_4));
            }
        }
        public Data CurrentData { get; set; }
        
        public GameSession()
        {
            CurrentData = DataFactory.PopulateData();
            CurrentLocation = CurrentData.LocationByID(0);
            CurrentEncounter = CurrentData.EncounterByID(2);          
        }
        public void RaiseEncounterMessage(string message)
        {
            OnEncounterMessageRaised?.Invoke(this, new EncounterMessageEventArgs(message));
        }
    }
}
