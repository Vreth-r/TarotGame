using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DeckSelectionManager : MonoBehaviour
{
    public Transform cardGrid; // Existing prefab children
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI startButtonText;

    private List<Card> allCards = new();
    private List<Card> selectedCards = new();

    public static List<Card> playerDeckSelection = new();

    private void Start()
    {
        LoadAllCards();
        DisplayCards();
        UpdateInfo();
    }

    private void LoadAllCards()
    {
        allCards.AddRange(Resources.LoadAll<Card>("ScriptableObjects"));
    }

    private void DisplayCards()
    {
        int childCount = cardGrid.childCount;

        for (int i = 0; i < allCards.Count && i < childCount; i++)
        {
            Transform child = cardGrid.GetChild(i);

            CardButton btn = child.GetComponent<CardButton>();
            Button uiButton = child.GetComponent<Button>();

            Card card = allCards[i];
            btn.Setup(card, null);
            CardTooltipTrigger trigger = child.GetComponent<CardTooltipTrigger>();
            trigger.card = card;

            uiButton.onClick.RemoveAllListeners();

            uiButton.onClick.AddListener(() => ToggleCard(card, uiButton));

            // Ensure unselected visual
            SetButtonSelected(uiButton, selectedCards.Contains(card));
        }
    }

    private void ToggleCard(Card card, Button uiButton)
    {
        if (selectedCards.Contains(card))
        {
            // Unselect
            selectedCards.Remove(card);
            SetButtonSelected(uiButton, false);
        }
        else
        {
            // Try selecting
            if (selectedCards.Count >= 10)
                return;

            selectedCards.Add(card);
            SetButtonSelected(uiButton, true);
        }

        UpdateInfo();
    }

    private void SetButtonSelected(Button btn, bool selected)
    {
        // vis feedback
        Image img = btn.GetComponent<Image>();
        if (img != null)
        {
            img.color = selected ?
                new Color(0.6f, 1f, 0.6f, 1f) :
                Color.white;
        }
    }

    private void UpdateInfo()
    {
        infoText.text = $"Selected {selectedCards.Count}/10 cards";
        startButtonText.text = selectedCards.Count == 10 ? "Start Game" : "Pick 10 Cards";
    }

    public void StartGame()
    {
        if (selectedCards.Count != 10)
        {
            infoText.text = "You must select 10 cards!";
            return;
        }

        playerDeckSelection = new List<Card>(selectedCards);
        SceneManager.LoadScene("GameScene");
    }
}
