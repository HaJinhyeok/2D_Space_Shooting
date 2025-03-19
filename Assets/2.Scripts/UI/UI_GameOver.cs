using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    public Button RetryButton;
    public Button QuitButton;
    public TMP_Text ScoreText;

    void Start()
    {
        ScoreText.text = $"Score: {GameManager.Instance.Score}";
        RetryButton.onClick.AddListener(OnRetryButtonClick);
        QuitButton.onClick.AddListener(OnQuitButtonClick);
    }

    void OnRetryButtonClick()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("1.Scenes/Main");
    }

    void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
