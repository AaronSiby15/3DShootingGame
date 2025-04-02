using UnityEngine;

public class CityNpc : DialogueManager
{
    protected override string[] GetDialogueLines()
    {
        return new string[]
        {
            "NPC: Thanks so much for coming.",
            "NPC: I tried to fight them off but I was outnumbered.",
            "NPC: I hid the gem from them in the next building over.",
            "NPC: Go get it... it's our only chance."
        };
    }
}
