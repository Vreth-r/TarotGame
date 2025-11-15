using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Player computer;
    public UIManager ui;

    private int currentRound = 1;
    private const int MAX_ROUNDS = 3;

    private List<Card> allCards;

    private void Start()
    {
        allCards = new List<Card>(Resources.LoadAll<Card>("ScriptableObjects"));

        player.deck = new List<Card>(DeckSelectionManager.playerDeckSelection);
        computer.deck = GetRandomDeck();

        player.ResetPlayer();
        computer.ResetPlayer();

        StartCoroutine(GameLoop());
    }

    private List<Card> GetRandomDeck()
    {
        List<Card> deck = new();

        while (deck.Count < 10)
        {
            Card c = allCards[Random.Range(0, allCards.Count)];
            if (!deck.Contains(c))
                deck.Add(c);
        }
        return deck;
    }

    private IEnumerator GameLoop()
    {
        while (currentRound <= MAX_ROUNDS && player.life > 0 && computer.life > 0)
        {
            ui.UpdateRoundUI(currentRound);

            player.DrawCards(3);
            computer.DrawCards(3);

            // Display player's hand
            ui.DisplayPlayerHand(player.hand);

            // Pre-generate slot order (0 = player card, 1 = cpu card)
            int[] ownershipOrder = new int[4];
            ownershipOrder[0] = Random.Range(0, 2);
            ownershipOrder[1] = 1 - ownershipOrder[0];
            ownershipOrder[2] = Random.Range(0, 2);
            ownershipOrder[3] = 1 - ownershipOrder[2];

            ui.SetSlotOrderVisual(ownershipOrder);

            // Player picks 2
            yield return ui.PlayerSelectCards(player.hand);

            Card[] playerPicked = new Card[] { player.hand[0], player.hand[1] };
            playerPicked = ui.GetSelectedCards();

            // CPU picks first 2
            Card[] cpuPicked = new Card[2];
            cpuPicked[0] = computer.hand.Count > 0 ? computer.hand[0] : null;
            cpuPicked[1] = computer.hand.Count > 1 ? computer.hand[1] : null;

            // Build ordered array
            Card[] ordered = new Card[4];
            int pIndex = 0;
            int cIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                if (ownershipOrder[i] == 0)
                    ordered[i] = playerPicked[pIndex++];
                else
                    ordered[i] = cpuPicked[cIndex++];
            }

            ui.AssignCardsToSlots(ordered);
            yield return new WaitForSeconds(1f);

            // Resolve in slot order
            for (int i = 0; i < 4; i++)
            {
                Card card = ordered[i];
                if (card != null)
                {
                    if (ownershipOrder[i] == 0)
                        card.Activate(player, computer, i > 0 ? ordered[i - 1] : null);
                    else
                        card.Activate(computer, player, i > 0 ? ordered[i - 1] : null);
                }

                yield return new WaitForSeconds(1f);
            }

            // End-of-round fixed damage
            player.life -= 2;
            computer.life -= 2;

            currentRound++;
        }

        EndGame();
    }

    private void EndGame()
    {
        string msg;
        if (player.life == computer.life)
            msg = "Draw!";
        else if (player.life > computer.life)
            msg = "You Win!";
        else
            msg = "You Lose!";

        ui.ShowResult(msg);
        StartCoroutine(ReturnToSelect());
    }

    private IEnumerator ReturnToSelect()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DeckSelectScene");
    }
}
