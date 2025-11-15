using UnityEngine;

[CreateAssetMenu(fileName = "The Magician", menuName = "Tarot/Effects/Magician")]
public class TheMagician : Card
{
    public int id = 1;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        if (leftCard != null)
        {
            Debug.Log("Magician copies effect of the left card.");
            if (leftCard != null)
            {
                leftCard.Activate(self, opponent);
                return;
            }
            Debug.Log("No left card to copy effect from.");
        }
    }
}