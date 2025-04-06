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
    
    public override void EndDialogue()
    {
        canva.SetActive(false);
        currentIndex = 0;
        dialogueStarted = false;

        // Only count this NPC once
        if (!hasTalked)
        {
            hasTalked = true;
            NPCTracker.Instance.NPCInteracted();
        }
    }
}
