public class IntroNPC : DialogueManager
{
    protected override string[] GetDialogueLines()
    {
        return new string[]
        {
            "Player: Where am I?",
            "NPC: You have been in a coma for a long time.",
            "NPC: Our world has been taken over by Zombies.",
            "NPC: You are our only hope to save the human race.",
            "NPC: You must collect the 4 lost gems.",
            "Player: How will gems save the human race?",
            "NPC: Once you have collected the gems, you will unlock the key to face the zombie king.",
            "NPC: Once the zombie king is defeated, the rest of the zombies will fall.",
            "NPC: Good luck on your journey, Player!"
        };
    }
}