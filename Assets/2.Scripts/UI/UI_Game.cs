using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text TimeText;
    public Button PauseButton;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject GameClearPanel;
    public Image[] HeartImage;

    public static UnityAction OnGameOverAction;
    public static UnityAction OnGameClearAction;

    bool _isPaused = false;

    void Start()
    {
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);

        ScoreText.text = $"Score: {GameManager.Instance.Score}";
        TimeText.text = $"{Timer.s_MinuteCount:D2}:{Timer.s_SecondCount:D2}";
        PauseButton.onClick.AddListener(OnPauseButtonClick);

        GameManager.Instance.OnScoreChanged += OnScoreTextChanged;
        Timer.s_TimerAction += OnTimeTextChanged;
        Player.Instance.OnPlayerHpChanged += OnPlayerHpChanged;
        OnGameOverAction += OnGameOver;
        OnGameClearAction += OnGameClear;
    }

    void OnPauseButtonClick()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = 1.0f;
            PausePanel.SetActive(false);
        }
        else
        {
            _isPaused = true;
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
        }
    }

    void OnScoreTextChanged()
    {
        ScoreText.text = $"Score: {GameManager.Instance.Score}";
    }

    void OnTimeTextChanged()
    {
        TimeText.text = $"{Timer.s_MinuteCount}:{Timer.s_SecondCount}";
    }

    void OnPlayerHpChanged()
    {
        int hp = Player.Instance.Hp;
        switch (hp)
        {
            case 0:
                HeartImage[hp].gameObject.SetActive(false);
                OnGameOver();
                break;

            case 1:
                HeartImage[hp].gameObject.SetActive(false);
                break;

            case 2:
                HeartImage[hp].gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    void OnGameOver()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }

    void OnGameClear()
    {
        Time.timeScale = 0f;
        GameClearPanel.SetActive(true);
    }
}
