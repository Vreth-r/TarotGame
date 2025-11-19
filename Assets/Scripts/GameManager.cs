using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Player computer;
    public UIManager ui;

    private int currentRound = 1;
    private const int MAX_ROUNDS = 3;

    private bool cardNegate = false;

    private List<Card> allCards;

    private void Start()
    {
        allCards = new List<Card>(Resources.LoadAll<Card>("ScriptableObjects"));

        player.deck = new List<Card>(DeckSelectionManager.playerDeckSelection);
        computer.deck = GetRandomDeck();
        //ShuffleList(player.deck);

        player.ResetPlayer();
        computer.ResetPlayer();

        player.ownerNumber = 0;
        computer.ownerNumber = 1;

        StartCoroutine(GameLoop());
    }

    public void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int j = Random.Range(i, list.Count);
            (list[i], list[j]) = (list[j], list[i]);
        }
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

            if(player.patience)
            {
                player.Heal(4);
                player.patience = false;
            }
            
            if(computer.patience)
            {
                computer.Heal(4);
                computer.patience = false;
            }

            player.DrawCards(3); // data only no visuals
            computer.DrawCards(3);

            player.ProcEffectsRoundStart();
            computer.ProcEffectsRoundStart();

            int[] ownershipOrder = new int[] { 0, 0, 1, 1 };

            // Fisher–Yates shuffle (0 is player 1 is cpu)
            for (int i = 0; i < ownershipOrder.Length; i++)
            {
                int j = Random.Range(i, ownershipOrder.Length);
                (ownershipOrder[i], ownershipOrder[j]) = (ownershipOrder[j], ownershipOrder[i]);
            }

            ui.SetSlotOrderVisual(ownershipOrder);
            
            // Display player's hand
            ui.DisplayPlayerHand(player.hand);

            // Player picks 2
            yield return ui.PlayerSelectCards(player.hand);

            Card[] playerPicked = ui.GetSelectedCards();

            // CPU picks first 2
            List<Card> cpuHand = computer.hand;
            Card[] cpuPicked = cpuHand.OrderBy(x => Random.value).Take(2).ToArray();

            foreach (Card c in playerPicked)
            {
                player.hand.Remove(c);
            }

            foreach (Card c in cpuPicked)
            {
                computer.hand.Remove(c);
            }

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
            Debug.Log("Cards in slots");
            yield return new WaitForSeconds(1f);

            // Resolve in slot order
            for (int i = 0; i < 4; i++)
            {
                Card card = ordered[i];

                if(cardNegate)
                {
                    ui.ShowResult($"{card.cardName} was negated by Death!");
                }
                
                if (card != null && !cardNegate)
                {
                    if (ownershipOrder[i] == 0)
                    {
                        Debug.Log($"activating {card.cardName} for player");
                        ui.ShowResult(card.Activate(player, computer, ordered, ownershipOrder));
                    }
                    else
                    {
                        Debug.Log($"activating {card.cardName} for opp");
                        ui.ShowResult(card.Activate(computer, player, ordered, ownershipOrder));
                    }
                    ui.SlotPointerToggle(i, true);
                }

                if(GameVariables.nextCardNegate)
                {
                    cardNegate = true;
                    GameVariables.nextCardNegate = false;
                }
                else
                {
                    cardNegate = false;
                }

                ui.DisplayPlayerHand(player.hand);

                yield return new WaitForSeconds(2f);
                ui.SlotPointerToggle(i, false);
            }

            Debug.Log("Losing Fixed Life");
            // round end fixed damage
            player.ApplyDamage(2);
            computer.ApplyDamage(2);

            if(!GameVariables.addARound)
            {
                currentRound++;
                GameVariables.addARound = false;
            }

            yield return new WaitForSeconds(0.5f);
            ui.RemoveCardsFromSlots();

            // round effect cleanup
            player.ResetRoundEnds();
            computer.ResetRoundEnds();
            if(GameVariables.endGame)
            {
                GameVariables.endGame = false;
                break;
            }
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
