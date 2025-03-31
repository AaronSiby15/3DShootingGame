using UnityEngine;

public class Level4Dialogue2 : DialogueManager
{
    protected override string[] GetDialogueLines()
    {
        return new string[]
        {
            "Player: Are you Okay!",
            "NPC: Thank you for saving me, The Zombies almost got me!!",
            "NPC: You must go save our lead professor downstairs",
            "NPC: Quick go downstairs into the classroom near the basement"
        };
    }
}
