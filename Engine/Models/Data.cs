using System;
using System.Collections.Generic;
using System.Text;
using Engine.Actions;
using Engine.Dialogues;

namespace Engine
{
    public class Data
    {
        private List<Location> _locations = new List<Location>();
        private List<Action1> _actions_1 = new List<Action1>();
        private List<Action2> _actions_2 = new List<Action2>();
        private List<Action3> _actions_3 = new List<Action3>();
        private List<Action4> _actions_4 = new List<Action4>();
        private List<Action5> _actions_5 = new List<Action5>();
        private List<Action6> _actions_6 = new List<Action6>();
        private List<Action7> _actions_7 = new List<Action7>();
        private List<Encounter> _encounters = new List<Encounter>();
        private List<Dialogue_1> _dialogues_1 = new List<Dialogue_1>();
        private List<Dialogue_2> _dialogues_2 = new List<Dialogue_2>();
        private List<Dialogue_3> _dialogues_3 = new List<Dialogue_3>();
        private List<Dialogue_4> _dialogues_4 = new List<Dialogue_4>();
        
        
        internal void AddLocation(int id, string name, string description)
        {
            Location loc = new Location();

            loc.ID = id;
            loc.Name = name;
            loc.Description = description;

            _locations.Add(loc);
        }
        internal void AddEncounter(int id, string imageName)
        {
            Encounter enc = new Encounter();
            enc.ID = id;
            enc.ImageName = imageName;
            _encounters.Add(enc);
        }

        public Location LocationByID (int id)
        {
            foreach (Location loc in _locations)
            {
                if (loc.ID == id)
                {
                    return loc;
                }
            }
            return null;
        }
        public Encounter EncounterByID (int id)
        {
            foreach (Encounter enc in _encounters)
            {
                if (enc.ID == id)
                {
                    return enc;
                }
            }
            return null;
        }
        internal void AddAction_1 (double id, string content)
        {
            Action1 action1 = new Action1();
            action1.ID = id;
            action1.Content = content;
            _actions_1.Add(action1);
        }
        internal void AddAction_2(double id, string content)
        {
            Action2 action2 = new Action2();
            action2.ID = id;
            action2.Content = content;
            _actions_2.Add(action2);
        }
        internal void AddAction_3(double id, string content)
        {
            Action3 action3 = new Action3();
            action3.ID = id;
            action3.Content = content;
            _actions_3.Add(action3);
        }
        internal void AddAction_4(double id, string content)
        {
            Action4 action4 = new Action4();
            action4.ID = id;
            action4.Content = content;
            _actions_4.Add(action4);
        }
        internal void AddAction_5(double id, string content)
        {
            Action5 action5 = new Action5();
            action5.ID = id;
            action5.Content = content;
            _actions_5.Add(action5);
        }
        internal void AddAction_6(double id, string content)
        {
            Action6 action6 = new Action6();
            action6.ID = id;
            action6.Content = content;
            _actions_6.Add(action6);
        }
        internal void AddAction_7(double id, string content)
        {
            Action7 action7 = new Action7();
            action7.ID = id;
            action7.Content = content;
            _actions_7.Add(action7);
        }
        internal void AddDialogue_1(double id, string content)
        {
            Dialogue_1 dialogue_1 = new Dialogue_1();
            dialogue_1.ID = id;
            dialogue_1.Content = content;
            _dialogues_1.Add(dialogue_1);
        }
        internal void AddDialogue_2(double id, string content)
        {
            Dialogue_2 dialogue_2 = new Dialogue_2();
            dialogue_2.ID = id;
            dialogue_2.Content = content;
            _dialogues_2.Add(dialogue_2);
        }
        internal void AddDialogue_3(double id, string content)
        {
            Dialogue_3 dialogue_3 = new Dialogue_3();
            dialogue_3.ID = id;
            dialogue_3.Content = content;
            _dialogues_3.Add(dialogue_3);
        }
        internal void AddDialogue_4(double id, string content)
        {
            Dialogue_4 dialogue_4 = new Dialogue_4();
            dialogue_4.ID = id;
            dialogue_4.Content = content;
            _dialogues_4.Add(dialogue_4);
        }
        public Action1 Action_1_byID(double id)
        {
            foreach (Action1 action in _actions_1)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Action2 Action_2_byID(double id)
        {
            foreach (Action2 action in _actions_2)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Action3 Action_3_byID(double id)
        {
            foreach (Action3 action in _actions_3)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Action4 Action_4_byID(double id)
        {
            foreach (Action4 action in _actions_4)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Action5 Action_5_byID(double id)
        {
            foreach (Action5 action in _actions_5)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Action6 Action_6_byID(double id)
        {
            foreach (Action6 action in _actions_6)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Action7 Action_7_byID(double id)
        {
            foreach (Action7 action in _actions_7)
            {
                if (action.ID == id)
                {
                    return action;
                }
            }
            return null;
        }
        public Dialogue_1 Dialogue_1_byID(double id)
        {
            foreach (Dialogue_1 dialogue in _dialogues_1)
            {
                if (dialogue.ID == id)
                {
                    return dialogue;
                }
            }
            return null;
        }
        public Dialogue_2 Dialogue_2_byID(double id)
        {
            foreach (Dialogue_2 dialogue in _dialogues_2)
            {
                if (dialogue.ID == id)
                {
                    return dialogue;
                }
            }
            return null;
        }
        public Dialogue_3 Dialogue_3_byID(double id)
        {
            foreach (Dialogue_3 dialogue in _dialogues_3)
            {
                if (dialogue.ID == id)
                {
                    return dialogue;
                }
            }
            return null;
        }
        public Dialogue_4 Dialogue_4_byID(double id)
        {
            foreach (Dialogue_4 dialogue in _dialogues_4)
            {
                if (dialogue.ID == id)
                {
                    return dialogue;
                }
            }
            return null;
        }


    }
}
