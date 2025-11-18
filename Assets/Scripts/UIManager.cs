using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI resultText;

    [Header("Hand Display")]
    public Transform handPanel;
    public GameObject cardButtonPrefab;

    [Header("Slot Display (4 slots)")]
    public SlotUI[] slots;   // custom struct defined below

    [Header("Buttons")]
    public Button continueButton;

    private List<CardButton> activeHandButtons = new();
    public List<Card> selectedCards = new();

    private bool selectionDone = false;

    // Used by GameManager
    private Card[] resolvedOrder = new Card[4];
    public Card[] GetResolvedOrder() => resolvedOrder;

    // Called by GameManager
    public void SetSlotOrderVisual(int[] order)
    {
        for (int i = 0; i < 4; i++)
        {
            slots[i].slotNumberText.text = order[i] == 0 ? "P" : "O";
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

    public void UnselectCard(Card card)
    {
        if (selectedCards.Contains(card))
            selectedCards.Remove(card);

    }

    public IEnumerator PlayerSelectCards(List<Card> hand)
    {
        resultText.text = "Select 2 cards to play";
        selectedCards.Clear();
        selectionDone = false;

        continueButton.gameObject.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(() => selectionDone = true);

        // wait until the player has exactly 2 cards
        while (!selectionDone)
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
        {
            button.SetSelected(false);
            return false;
        }

        // Select it
        selectedCards.Add(card);
        button.SetSelected(true);
        continueButton.gameObject.SetActive(selectedCards.Count == 2);
        return true;
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

    public void RemoveCardsFromSlots()
    {
        for (int i = 0; i < 4; i++)
        {
            slots[i].ClearSlot();
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
    
    public void SlotPointerToggle(int index, bool status)
    {
        slots[index].PointerToggle(status);
    }
}

[System.Serializable]
public class SlotUI
{
    public Image slotBackground;
    public TextMeshProUGUI slotNumberText;
    public Transform contentRoot; // place card prefab here
    public Image pointer;

    public void ClearSlot()
    {
        foreach (Transform t in contentRoot)
        {
            if(t.gameObject.GetComponent<CardButton>() != null)
            {   
                GameObject.Destroy(t.gameObject);
            }
        }
    }

    public void ShowCard(Card card, GameObject prefab)
    {
        ClearSlot();
        var c = GameObject.Instantiate(prefab, contentRoot);
        c.GetComponent<CardButton>().Setup(card, null);
    }

    public void PointerToggle(bool status)
    {
        pointer.gameObject.SetActive(status);
    }
}
