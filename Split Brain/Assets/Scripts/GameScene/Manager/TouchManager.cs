using UnityEngine;

public class TouchManager : SingleTon<TouchManager>
{
    public LController leftController;
    public RController rightController;

    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Ready) return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            // 터치 시작, 이동, 유지 상태 모두 감지
            if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
            {
                if (t.position.x < Screen.width * 0.5f)
                {
                    leftController.OnTouch(t);
                }
                else
                {
                    rightController.OnTouch(t);
                }
            }

            // 터치 종료 전달
            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                if (t.position.x < Screen.width * 0.5f)
                {
                    leftController.OnTouchEnd(t);
                }
                else
                {
                    rightController.OnTouchEnd(t);
                }
            }
        }
    }
}
