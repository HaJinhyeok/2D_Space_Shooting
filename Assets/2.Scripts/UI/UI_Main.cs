using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("1.Scenes/Game");
    }
}
