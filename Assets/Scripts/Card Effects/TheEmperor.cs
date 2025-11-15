using UnityEngine;

[CreateAssetMenu(fileName = "The Emperor", menuName = "Tarot/Effects/Emperor")]
public class TheEmperor : Card
{
    public int id = 4;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}