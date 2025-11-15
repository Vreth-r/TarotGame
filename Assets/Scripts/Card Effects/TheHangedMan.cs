using UnityEngine;

[CreateAssetMenu(fileName = "The Hanged Man", menuName = "Tarot/Effects/HangedMan")]
public class TheHangedMan : Card
{
    public int id = 12;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}