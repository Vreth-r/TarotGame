using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Round / Result")]
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI resultText;

    [Header("Hand Display")]
    public Transform handPanel;
    public GameObject cardButtonPrefab;

    [Header("Slot Display (4 slots)")]
    public SlotUI[] slots;   // custom struct defined below

    [Header("Buttons")]
    public Button playButton;

    private List<CardButton> activeHandButtons = new();
    private List<Card> selectedCards = new();

    private bool waitingForSelection = false;

    // Used by GameManager
    private Card[] resolvedOrder = new Card[4];
    public Card[] GetResolvedOrder() => resolvedOrder;

    // Called by GameManager
    public void SetSlotOrderVisual(int[] order)
    {
        for (int i = 0; i < 4; i++)
        {
            slots[i].slotNumberText.text = (i + 1).ToString();
            slots[i].slotBackground.color = order[i] == 0 ? Color.blue : Color.red;
        }
    }

    // Draw 3 cards visually
    public void DisplayPlayerHand(List<Card> hand)
    {
        // cleanup old hand
        foreach (var b in activeHandButtons)
            Destroy(b.gameObject);
        activeHandButtons.Clear();

        selectedCards.Clear();
        resultText.text = "Pick 2 cards";

        foreach (var card in hand)
        {
            var obj = GameObject.Instantiate(cardButtonPrefab, handPanel);
            var btn = obj.GetComponent<CardButton>();
            btn.Setup(card, this);
            CardTooltipTrigger trigger = obj.GetComponent<CardTooltipTrigger>();
            trigger.card = card;

            activeHandButtons.Add(btn);
        }
    }

    public void SelectCard(Card card)
    {
        if (selectedCards.Contains(card))
            return;

        if (selectedCards.Count < 2)
            selectedCards.Add(card);

        if (selectedCards.Count == 2)
            playButton.interactable = true;
    }

    public void UnselectCard(Card card)
    {
        if (selectedCards.Contains(card))
            selectedCards.Remove(card);

        playButton.interactable = selectedCards.Count == 2;
    }

    public IEnumerator PlayerSelectCards(List<Card> hand)
    {
        resultText.text = "Select 2 cards to play";
        selectedCards.Clear();

        foreach (var card in hand)
        {
            var btnObj = Instantiate(cardButtonPrefab, handPanel);
            var btn = btnObj.GetComponent<CardButton>();
            btn.Setup(card, this);
            activeHandButtons.Add(btn);
        }

        // wait until the player has exactly 2 cards
        while (selectedCards.Count < 2)
            yield return null;
    }

    public bool ToggleCardSelection(Card card, CardButton button)
    {
        // If already selected → unselect it
        if (selectedCards.Contains(card))
        {
            selectedCards.Remove(card);
            button.SetSelected(false);
            return false;
        }

        // If already have 2 cards → cannot select more
        if (selectedCards.Count >= 2)
            return false;

        // Select it
        selectedCards.Add(card);
        button.SetSelected(true);
        return true;
    }

    public void ConfirmSelection()
    {
        waitingForSelection = false;
    }

    // Fill slots AFTER order has been decided by GameManager
    public void AssignCardsToSlots(Card[] orderedCards)
    {
        resolvedOrder = orderedCards;

        for (int i = 0; i < 4; i++)
        {
            if (orderedCards[i] == null)
            {
                slots[i].ClearSlot();
                continue;
            }

            slots[i].ShowCard(orderedCards[i], cardButtonPrefab);
        }
    }

    public void UpdateRoundUI(int round)
    {
        roundText.text = $"Round {round}/3";
    }

    public void ShowResult(string msg)
    {
        resultText.text = msg;
    }

    public Card[] GetSelectedCards()
    {
        return selectedCards.ToArray();
    }
}

[System.Serializable]
public class SlotUI
{
    public Image slotBackground;
    public TextMeshProUGUI slotNumberText;
    public Transform contentRoot; // place card prefab here

    public void ClearSlot()
    {
        foreach (Transform t in contentRoot)
            GameObject.Destroy(t.gameObject);
    }

    public void ShowCard(Card card, GameObject prefab)
    {
        ClearSlot();
        var c = GameObject.Instantiate(prefab, contentRoot);
        c.GetComponent<CardButton>().Setup(card, null);
    }
}
