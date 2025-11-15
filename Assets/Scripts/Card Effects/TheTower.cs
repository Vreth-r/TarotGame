using UnityEngine;

[CreateAssetMenu(fileName = "The Tower", menuName = "Tarot/Effects/Tower")]
public class TheTower : Card
{
    public int id = 16;
    public int damageAmount = 5;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        self.ApplyDamage(damageAmount);
        opponent.ApplyDamage(damageAmount);
    }
}