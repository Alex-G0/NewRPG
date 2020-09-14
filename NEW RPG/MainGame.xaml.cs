using Engine;
using Engine.ViewModels;
using Engine.EventArgs;
using Engine.Actions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NEW_RPG
{
    public partial class MainGame : Window
    {
        public Player _player;
        public bool Dialogue = false;
        public bool Fight = false;
        private GameSession _gameSession;
        
        // Global variables for encounters 
        public bool Getkey = false;
        public bool FightRat = false;
        public bool GetPotion = false;
        public bool GetCrowbar = false;

        public MainGame(Player player)
        {
            InitializeComponent();

            _player = player;
            _gameSession = new GameSession();
            _gameSession.OnEncounterMessageRaised += EncounterMessageRaised;
            _gameSession.CurrentPlayer = _player;
            _player.Inventory.Add(ItemFactory.CreateItem(01));
            _player.Inventory.Add(ItemFactory.CreateItem(06));
            _player.Inventory.Add(ItemFactory.CreateItem(07));
            _player.Inventory.Add(ItemFactory.CreateItem(08));

            DataContext = _gameSession;

            UpdateActions();
            
        }
        // Update actions 
        public void UpdateActions()
        {
            int LocationID = _gameSession.CurrentLocation.ID;
            HideActions();
            
            switch (LocationID)
            {
                case (0):
                    SetAction_1(0.1, OldHut_LookAround);
                    break;
                case (1):
                    SetAction_1(1.1, OldHut_LeftDoor);
                    SetAction_2(1.2, OldHut_RightDoor);
                    SetAction_3(1.3, OldHut_Chest);
                    break;
                case (2):
                    SetAction_1(2.1, OldHut_Dialogue);
                    SetAction_2(2.2, OldHut_GoBack);
                    break;
                case (3):
                    if (GetPotion == false)
                        SetAction_1(3.1, OldHut_Boxes);
                    if (GetCrowbar == false)
                        SetAction_2(3.2, OldHut_Crowbar);
                    SetAction_3(3.3, OldHut_GoBack);
                    break;


            }         
        }
        // Update encounters
        public void UpdateEncounters()
        {
            double EncounterID = _gameSession.CurrentEncounter.ID;
            HideEncounters();
            EncounterMenu();

            switch (EncounterID)
            {
                case (1):
                    SetDialogue_1(1.1, OldHut_Talk_1);
                    SetDialogue_2(1.2, OldHut_Talk_2);
                    break;
                case (2):
                    break;
                   
                

                
            }
        }
        // OLD HUT LOCATION EVENTS //
        private void OldHut_LookAround(object sender, RoutedEventArgs e)
        {
            SetLocation(1);
            UpdateActions();
        }
        private void OldHut_LeftDoor(object sender, RoutedEventArgs e)
        {
            SetLocation(2);
            UpdateActions();
        }
        private void OldHut_RightDoor(object sender, RoutedEventArgs e)
        {
            SetLocation(3);
            UpdateActions();
            if(FightRat == false)
            {
                Fight = true;
                _gameSession.CurrentMonster = MonsterFactory.GetMonsterByID(00);
                SetEncounter(2);
                UpdateEncounters();
                HideActions();
                FightRat = true;
            }
        }
        private void OldHut_Chest(object sender, RoutedEventArgs e)
        {
            _gameSession.RaiseEncounterMessage("Chest is closed");
        }
        private void OldHut_Crowbar (object sender, RoutedEventArgs e)
        {
            _player.Inventory.Add(ItemFactory.CreateItem(04));
            GetCrowbar = true;
            UpdateActions();
        }
        private void OldHut_Dialogue(object sender, RoutedEventArgs e)
        {
            Dialogue = true;
            SetEncounter(1);
            UpdateEncounters();
        }
        private void OldHut_GoBack(object sender, RoutedEventArgs e)
        {       
                SetLocation(1);
                UpdateActions();
                Dialogue = false;
                UpdateEncounters();         
        }
        private void OldHut_Talk_1(object sender, RoutedEventArgs e)
        {
            _gameSession.RaiseEncounterMessage("Strange guy told you that he is prisoner here, like you. He hold the key from the chest");
            if(_gameSession.CurrentPlayer.Charisma >= 3 && Getkey == false)
                SetDialogue_3(1.3, OldHut_Charisma);
            if (_gameSession.CurrentPlayer.Strength >= 3 && Getkey == false)
                SetDialogue_4(1.4, OldHut_Strength);          
        }
        private void OldHut_Talk_2(object sender, RoutedEventArgs e)
        {
            _gameSession.RaiseEncounterMessage("Strange guy:'This is the bandits hideout. Here they bringing the slaves to sell them after'");
        }
        private void OldHut_Charisma(object sender, RoutedEventArgs e)
        {
            _gameSession.RaiseEncounterMessage("You can assure strange guy that you find good use for treasure in chest. He give you a key.");
            _player.Inventory.Add(ItemFactory.CreateItem(03));
            Getkey = true;
            UpdateEncounters();
        }
        private void OldHut_Strength(object sender, RoutedEventArgs e)
        {
            _gameSession.RaiseEncounterMessage("You treated strange guy to kill him. He scared and give you a key");
            _player.Inventory.Add(ItemFactory.CreateItem(03));
            Getkey = true;
            UpdateEncounters();
        }
        private void OldHut_Boxes(object sender, RoutedEventArgs e)
        {
            _gameSession.RaiseEncounterMessage("You found health potion");
            _player.Inventory.Add(ItemFactory.CreateItem(05));
            GetPotion = true;
            UpdateActions();
        }










        private void EncounterMessageRaised(object sender, EncounterMessageEventArgs e)
        {
            ActionsText.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            ActionsText.ScrollToEnd();
        }

        // Clean all event handler from button
        public static void RemoveAllEvents(UIElement element, RoutedEvent routedEvent)
        {
            var eventHandlersStoreProperty = typeof(UIElement).GetProperty(
                "EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
            object eventHandlersStore = eventHandlersStoreProperty.GetValue(element, null);
          
            if (eventHandlersStore == null)
                return;
            var getRoutedEventHandlers = eventHandlersStore.GetType().GetMethod(
                "GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var routedEventHandlers = (RoutedEventHandlerInfo[])getRoutedEventHandlers.Invoke(
                eventHandlersStore, new object[] { routedEvent });

            foreach (var routedEventHandler in routedEventHandlers)
                element.RemoveHandler(routedEvent, routedEventHandler.Handler);
        }          
        // Activate encounter menu
        public void EncounterMenu()
        {
            if(Dialogue == true)
            {
                labelIdle.Visibility = Visibility.Collapsed;
                borderImage.Visibility = Visibility.Visible;
                labelEncounter.Visibility = Visibility.Visible;
                labelEncounter.Content = "DIALOGUE";
                labelEncounter.Background = Brushes.Green;
                DialogueBar.Visibility = Visibility.Visible;
            }
            else if(Fight == true)
            {
                labelIdle.Visibility = Visibility.Collapsed;
                borderImage.Visibility = Visibility.Visible;
                labelEncounter.Visibility = Visibility.Visible;
                labelEncounter.Content = "FIGHT";
                labelEncounter.Background = Brushes.Red;
                DialogueBar.Visibility = Visibility.Visible;
                btnBattle_1.Visibility = Visibility.Visible;
            }
            else
            {
                labelIdle.Visibility = Visibility.Visible;
                borderImage.Visibility = Visibility.Collapsed;
                labelEncounter.Visibility = Visibility.Collapsed;
                labelEncounter.Visibility = Visibility.Collapsed;
                DialogueBar.Visibility = Visibility.Collapsed;
                btnBattle_1.Visibility = Visibility.Collapsed;
            }
        }
        // Method to hide all action buttons
        public void HideActions()
        {
            ActionBar.Children.OfType<Button>().ToList().ForEach(button => button.Visibility = Visibility.Collapsed);
        }
        // Method to hide all encounter buttons
        public void HideEncounters()
        {
            DialogueBar.Children.OfType<Button>().ToList().ForEach(button => button.Visibility = Visibility.Collapsed);
        }
        // Method to set buttons and actions
        public void SetAction_1(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_1 = _gameSession.CurrentData.Action_1_byID(id);
            btnAction_1.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_1, Button.ClickEvent);
            btnAction_1.Click += setEvent;
        }
        public void SetAction_2(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_2 = _gameSession.CurrentData.Action_2_byID(id);
            btnAction_2.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_2, Button.ClickEvent);
            btnAction_2.Click += setEvent;
        }
        public void SetAction_3(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_3 = _gameSession.CurrentData.Action_3_byID(id);
            btnAction_3.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_3, Button.ClickEvent);
            btnAction_3.Click += setEvent;
        }
        public void SetAction_4(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_4 = _gameSession.CurrentData.Action_4_byID(id);
            btnAction_4.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_4, Button.ClickEvent);
            btnAction_4.Click += setEvent;
        }
        public void SetAction_5(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_5 = _gameSession.CurrentData.Action_5_byID(id);
            btnAction_5.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_5, Button.ClickEvent);
            btnAction_5.Click += setEvent;
        }
        public void SetAction_6(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_6 = _gameSession.CurrentData.Action_6_byID(id);
            btnAction_6.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_6, Button.ClickEvent);
            btnAction_6.Click += setEvent;
        }
        public void SetAction_7(double id, RoutedEventHandler setEvent)
        {
            _gameSession.CurrentAction_7 = _gameSession.CurrentData.Action_7_byID(id);
            btnAction_7.Visibility = Visibility.Visible;
            RemoveAllEvents(btnAction_7, Button.ClickEvent);
            btnAction_7.Click += setEvent;
        }
        public void SetDialogue_1(double id, RoutedEventHandler setDialogue)
        {
            _gameSession.CurrentDialogue_1 = _gameSession.CurrentData.Dialogue_1_byID(id);
            btnDialogue_1.Visibility = Visibility.Visible;
            RemoveAllEvents(btnDialogue_1, Button.ClickEvent);
            btnDialogue_1.Click += setDialogue;
        }
        public void SetDialogue_2(double id, RoutedEventHandler setDialogue)
        {
            _gameSession.CurrentDialogue_2 = _gameSession.CurrentData.Dialogue_2_byID(id);
            btnDialogue_2.Visibility = Visibility.Visible;
            RemoveAllEvents(btnDialogue_2, Button.ClickEvent);
            btnDialogue_2.Click += setDialogue;
        }
        public void SetDialogue_3(double id, RoutedEventHandler setDialogue)
        {
            _gameSession.CurrentDialogue_3 = _gameSession.CurrentData.Dialogue_3_byID(id);
            btnDialogue_3.Visibility = Visibility.Visible;
            RemoveAllEvents(btnDialogue_3, Button.ClickEvent);
            btnDialogue_3.Click += setDialogue;
        }
        public void SetDialogue_4(double id, RoutedEventHandler setDialogue)
        {
            _gameSession.CurrentDialogue_4 = _gameSession.CurrentData.Dialogue_4_byID(id);
            btnDialogue_4.Visibility = Visibility.Visible;
            RemoveAllEvents(btnDialogue_4, Button.ClickEvent);
            btnDialogue_4.Click += setDialogue;
        }
        // Set current location
        public void SetLocation(int id)
        {
            _gameSession.CurrentLocation = _gameSession.CurrentData.LocationByID(id);
        }
        // Set current encounter
        public void SetEncounter(int id)
        {
            _gameSession.CurrentEncounter = _gameSession.CurrentData.EncounterByID(id);
        }
        // Set current description
        public void SetDescription(string text)
        {
            _gameSession.CurrentLocation.Description = text;
        }
        public void Attack(object sender, RoutedEventArgs e)
        {
            if (_gameSession.CurrentWeapon == null)
            {
                _gameSession.RaiseEncounterMessage("You unarmed. Select your weapon first");
                return;
            }
            int damageToEnemy = RandomNumberGenerator.NumberBetween(_gameSession.CurrentWeapon.MinDamage, _gameSession.CurrentWeapon.MaxDamage);
            if (damageToEnemy == 0)
                _gameSession.RaiseEncounterMessage("You missed the enemy");
            else
            {
                _gameSession.CurrentMonster.HitPoints -= damageToEnemy;
                _gameSession.RaiseEncounterMessage($"You hit the enemy for {damageToEnemy} points");
            }
            if (_gameSession.CurrentMonster.HitPoints <= 0)
            {
                _gameSession.RaiseEncounterMessage("Enemy is dead.");
                Fight = false;
                _gameSession.CurrentMonster = null;
                UpdateEncounters();
                UpdateActions();
            }
            else
            {
                int damageToPlayer = RandomNumberGenerator.NumberBetween(_gameSession.CurrentMonster.MinDamage, _gameSession.CurrentMonster.MaxDamage);
                if (damageToPlayer == 0)
                    _gameSession.RaiseEncounterMessage("Enemy missed");
                else
                {
                    _gameSession.CurrentPlayer.Health -= damageToPlayer;
                    _gameSession.RaiseEncounterMessage($"Enemy hit you for {damageToPlayer} points");
                }
            }
        }
    }
}

