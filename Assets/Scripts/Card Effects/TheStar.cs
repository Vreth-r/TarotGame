using UnityEngine;

[CreateAssetMenu(fileName = "The Star", menuName = "Tarot/Effects/Star")]
public class TheStar : Card
{
    public int healAmount = 3;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        self.ApplyDamage(healAmount);
    }
}