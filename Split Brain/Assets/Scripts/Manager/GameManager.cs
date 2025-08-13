using System;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public enum GameState { Ready, Playing, GameOver } // 상태 패턴

    public GameState gameState = GameState.Ready;
    public GameObject obstacleSpawner;

    void Update()
    {
        // 화면에 손가락이 닿아 있는 경우
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0); // 첫 번째 터치 정보 가져오기

            // 터치가 시작된 순간(손가락이 닿는 순간)만 감지
            if (t.phase == TouchPhase.Began)
            {
                switch (gameState)
                {
                    case GameState.Ready:
                        GameStart();
                        break;
                    case GameState.GameOver:
                        Ready();
                        break;
                }
            }
        }
    }

    void GameStart()
    {
        if (gameState == GameState.Playing) return;

        Debug.Log("게임 시작");
        gameState = GameState.Playing;
        obstacleSpawner.SetActive(true);
        UIManager.Instance.gameStart_UI.SetActive(false);
    }

    void Ready()
    {
        Debug.Log("게임 준비");
        gameState = GameState.Ready;
        ObstacleSpawner.Instance.DespawnAll();
        UIManager.Instance.gameOver_UI.SetActive(false);
        UIManager.Instance.gameStart_UI.SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("게임 종료");
        gameState = GameState.GameOver;
        ObstacleSpawner.Instance.DespawnAll();
        obstacleSpawner.SetActive(false);
        UIManager.Instance.gameOver_UI.SetActive(true);
    }
}
