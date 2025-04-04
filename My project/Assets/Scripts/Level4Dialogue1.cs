using UnityEngine;

public class Level4Dialogue1 : DialogueManager
{
        protected override string[] GetDialogueLines()
        {
            return new string[]
            {
                "Player: What is happening?",
                "NPC:The Zombies have surrounded this hospital building",
                "NPC: You must go save the other professors in the building ",
                "NPC: Quick the first one is in the surgery room upstairs!"
            };
        }
    }
