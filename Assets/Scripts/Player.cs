using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public string playerName;
    public int life = 10;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI nameText;

    public List<Card> deck = new();
    public List<Card> hand = new();

    public int ownerNumber = 0;

    // for effects
    public bool sturdy = false; // strength effect
    public bool protection = false; // hanged man effect
    public bool patience = false; // temperance effect

    private void Start()
    {
        if (nameText != null) nameText.text = playerName;
        UpdateLifeUI();
    }

    public void DrawCards(int count)
    {
        int drawAmount = Mathf.Min(count, deck.Count);
        for (int i = 0; i < drawAmount; i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }

    public void ProcEffectsRoundStart()
    {
        if(patience)
        {
            DrawCards(2);
        }
    }

    public void ApplyDamage(int amount)
    {
        if(protection) return;
        life = Mathf.Max(life - amount, 0);
        if(life == 0 && sturdy)
        {
            life = 1;
        }
        UpdateLifeUI();
    }

    public void Heal(int amount)
    {
        life += amount;
        UpdateLifeUI();
    }

    public void SetHealth(int amount)
    {
        life = amount;
        UpdateLifeUI();
    }

    public void ResetPlayer()
    {
        life = 10;
        hand.Clear();
        UpdateLifeUI();
    }

    private void UpdateLifeUI()
    {
        if (lifeText != null)
            lifeText.text = $"Life: {life}";
    }

    public void ResetRoundEnds()
    {
        sturdy = false;
        protection = false;
    }
}
