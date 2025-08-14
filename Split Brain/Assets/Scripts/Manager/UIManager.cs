using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingleTon<UIManager>
{
    [Header("게임 시작 / 종료 UI")]
    public GameObject gameStart_UI;
    public GameObject gameOver_UI;

    [Header("스코어 관련 UI")]
    public Text score_Text;

    void Start()
    {
        ScoreManager.Instance.OnChangedScore += OnChangedScoreUI;
    }

    void OnChangedScoreUI(float score)
    {
        score_Text.text = $"Score : {score:F0}";
    }
}