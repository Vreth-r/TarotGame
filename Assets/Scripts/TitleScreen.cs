using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneFader.Instance.FadeToScene("DeckSelectScene");
    }
}
