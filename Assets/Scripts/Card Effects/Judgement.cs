using UnityEngine;

[CreateAssetMenu(fileName = "Judgement", menuName = "Tarot/Effects/Judgement")]
public class Judgement : Card
{
    public int id = 20;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}