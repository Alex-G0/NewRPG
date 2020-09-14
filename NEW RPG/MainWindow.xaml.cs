using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine;
using Engine.ViewModels;

namespace NEW_RPG
{
    // Make race class for XAML conbobox selection code
    public class Race
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }   
    public partial class MainWindow : Window
    {
        // Set basic attributes values and temporary attributes for race bonus check out
        public Player _player;
        int Str = 1;
        int Agi = 1;
        int Con = 1;
        int Int = 1;
        int Cha = 1;
        int attributeCounter = 6;
        int strBonus;
        int agiBonus;
        int conBonus;
        int chaBonus;     
        public MainWindow()
        {
            InitializeComponent();
            // Show basic attributes and remains points in textboxes
            textStr.Text = Str.ToString();
            textAgi.Text = Agi.ToString();
            textCon.Text = Con.ToString();
            textInt.Text = Int.ToString();
            textCha.Text = Cha.ToString();
            textPointRemains.Text = attributeCounter.ToString();
        }
        // Method to refresh attribute value and remains points value
        private void AttributeUpdate(TextBox textBox, int attribute, int counter)
        {
            textBox.Text = attribute.ToString();
            textPointRemains.Text = counter.ToString();
        }
        // Combobox race choice with race bonus
        private void comboRace_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int selectedRace = comboRace.SelectedIndex;

            if (selectedRace == 0)
            {
                chaBonus = 1;
                Cha = (Cha + chaBonus);
                textCha.Text = Cha.ToString();
            }
            else
            {
                Cha = Cha - chaBonus;
                textCha.Text = Cha.ToString();
                chaBonus = 0;
            }
            if (selectedRace == 1)
            {
                conBonus = 1;
                Con = (Con + conBonus);
                textCon.Text = Con.ToString();
            }
            else
            {
                Con = Con - conBonus;
                textCon.Text = Con.ToString();
                conBonus = 0;
            }
            if (selectedRace == 2)
            {
                agiBonus = 1;
                Agi = (Agi + agiBonus);
                textAgi.Text = Agi.ToString();
            }
            else
            {
                Agi = Agi - agiBonus;
                textAgi.Text = Agi.ToString();
                agiBonus = 0;
            }
            if (selectedRace == 3)
            {
                strBonus = 1;
                Str = (Str + strBonus);
                textStr.Text = Str.ToString();
            }
            else
            {
                Str = Str - strBonus;
                textStr.Text = Str.ToString();
                strBonus = 0;
            }
        }
        // Change attribute values buttons setup 
        private void strLess_Click(object sender, RoutedEventArgs e)
        {
            if (Str > 1 && comboRace.SelectedIndex != 3)
            {
                attributeCounter += 1;
                Str -= 1;
                AttributeUpdate(textStr, Str, attributeCounter);
            }
            if (Str > 2 && comboRace.SelectedIndex == 3)
            {
                attributeCounter += 1;
                Str -= 1;
                AttributeUpdate(textStr, Str, attributeCounter);
            }
        }
        private void strMore_Click(object sender, RoutedEventArgs e)
        {
            if (attributeCounter > 0)
            {
                attributeCounter -= 1;
                Str += 1;
                AttributeUpdate(textStr, Str, attributeCounter);
            }
        }
        private void agiLess_Click(object sender, RoutedEventArgs e)
        {
            if (Agi > 1 && comboRace.SelectedIndex != 2)
            {
                attributeCounter += 1;
                Agi -= 1;
                AttributeUpdate(textAgi, Agi, attributeCounter);
            }
            if (Agi > 2 && comboRace.SelectedIndex == 2)
            {
                attributeCounter += 1;
                Agi -= 1;
                AttributeUpdate(textAgi, Agi, attributeCounter);
            }
        }
        private void agiMore_Click(object sender, RoutedEventArgs e)
        {
            if (attributeCounter > 0)
            {
                attributeCounter -= 1;
                Agi += 1;
                AttributeUpdate(textAgi, Agi, attributeCounter);
            }
        }
        private void conLess_Click(object sender, RoutedEventArgs e)
        {
            if (Con > 1 && comboRace.SelectedIndex != 1)
            {
                attributeCounter += 1;
                Con -= 1;
                AttributeUpdate(textCon, Con, attributeCounter);
            }
            if (Con > 2 && comboRace.SelectedIndex == 1)
            {
                attributeCounter += 1;
                Con -= 1;
                AttributeUpdate(textCon, Con, attributeCounter);
            }
        }
        private void conMore_Click(object sender, RoutedEventArgs e)
        {
            if (attributeCounter > 0)
            {
                attributeCounter -= 1;
                Con += 1;
                AttributeUpdate(textCon, Con, attributeCounter);
            }
        }
        private void intLess_Click(object sender, RoutedEventArgs e)
        {
            if (Int > 1)
            {
                attributeCounter += 1;
                Int -= 1;
                AttributeUpdate(textInt, Int, attributeCounter);
            }
        }
        private void intMore_Click(object sender, RoutedEventArgs e)
        {
            if (attributeCounter > 0)
            {
                attributeCounter -= 1;
                Int += 1;
                AttributeUpdate(textInt, Int, attributeCounter);
            }
        }
        private void chaLess_Click(object sender, RoutedEventArgs e)
        {
            if (Cha > 1 && comboRace.SelectedIndex != 0)
            {
                attributeCounter += 1;
                Cha -= 1;
                AttributeUpdate(textCha, Cha, attributeCounter);
            }
            if (Cha > 2 && comboRace.SelectedIndex == 0)
            {
                attributeCounter += 1;
                Cha -= 1;
                AttributeUpdate(textCha, Cha, attributeCounter);
            }
        }
        private void chaMore_Click(object sender, RoutedEventArgs e)
        {
            if (attributeCounter > 0)
            {
                attributeCounter -= 1;
                Cha += 1;
                AttributeUpdate(textCha, Cha, attributeCounter);
            }
        }
        // Set up the button to show summary information in text block.
        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            textTest.Text = String.Empty;

            string name = textName.Text;
            string race = comboRace.Text;
            int strength = int.Parse(textStr.Text);
            int agility = int.Parse(textAgi.Text);
            int constitution = int.Parse(textCon.Text);
            int intelligence = int.Parse(textInt.Text);
            int charisma = int.Parse(textCha.Text);

            textTest.Text += "Name: " + name + Environment.NewLine;
            textTest.Text += "Race: " + race + Environment.NewLine;
            textTest.Text += "Strength: " + strength + Environment.NewLine;
            textTest.Text += "Agility: " + agility + Environment.NewLine;
            textTest.Text += "Constitution: " + constitution + Environment.NewLine;
            textTest.Text += "Intelligence: " + intelligence + Environment.NewLine;
            textTest.Text += "Charisma: " + charisma + Environment.NewLine;
        }
        private void textName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        // Set up Start Game button, switch to next window and make an instance of Player for the game
        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            string name = textName.Text;
            string race = comboRace.Text;
            int strength = int.Parse(textStr.Text);
            int agility = int.Parse(textAgi.Text);
            int constitution = int.Parse(textCon.Text);
            int intelligence = int.Parse(textInt.Text);
            int charisma = int.Parse(textCha.Text);
            int health = (constitution * 10);
            MainGame mainGame = new MainGame(new Player(name, race, strength, agility, constitution,intelligence, charisma, health,0));      
            mainGame.Show();
            this.Close();           
        }
    }
}
