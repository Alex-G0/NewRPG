using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    internal static class DataFactory
    {
        internal static Data PopulateData()
        {
            Data newData = new Data();

            // INTRODUCTION
            newData.AddLocation(0, "Somewhere", "You open your eyes and see only darkness around.Black stone floor, raw smell and absence of windown around suggest that this is some kind of basement." +
                "Getting up on your feet, you hear the crunch of joints and sharp pain in the head. The worst part of all of this: you dont remember anything, except your name. Time to look around");
            newData.AddAction_1(0.1, "Look around");

            // LOCATION : OLD HUT
            newData.AddLocation(1, "Old hut : basement", "This is the basement. You see the doors from the left and right side. Also there is the wooden chest in corner.");
            newData.AddAction_1(1.1, "Check left door");
            newData.AddAction_2(1.2, "Check right door");
            newData.AddAction_3(1.3, "Check the chest");

            newData.AddLocation(2, "Old hut : prison", "You open the door and enter another room. The strange guy sitting on the chair");
            newData.AddAction_1(2.1, "Talk with guy");
            newData.AddAction_2(2.2, "Go back");
            newData.AddEncounter(1, "/Engine;component/Images/NPC/StrangeGuy.png");
            newData.AddDialogue_1(1.1, "Who are you?");
            newData.AddDialogue_2(1.2, "What is that place?");
            newData.AddDialogue_3(1.3, "[Use charisma]");
            newData.AddDialogue_4(1.4, "[Use strength]");

            newData.AddLocation(3, "Old hut : Storage", "Seems like this is the old storage. There is some wooden boxes in the corner, covered by dust and crowbar lying on the floor");
            newData.AddAction_1(3.1, "Check the boxes");
            newData.AddAction_2(3.2, "Take the crowbar");
            newData.AddAction_3(3.3, "Go back");
            newData.AddEncounter(2, "/Engine;component/Images/NPC/rat.png");
            return newData;
        }
    }
}
