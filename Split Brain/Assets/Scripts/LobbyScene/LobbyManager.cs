using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
}
