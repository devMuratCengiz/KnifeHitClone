using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public bool itsOk;
    public Image Fader;
    public GameObject GameOverPanel;

    void Start()
    {
        Fader.gameObject.SetActive(true);
        Fader.DOFade(0f, .5f);
        itsOk = true;
    }

    public async void NextLevel()
    {
        Fader.DOFade(1f, .5f);
        await UniTask.Delay(1000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("aaaa");
    }
    public async void GameOver()
    {
        itsOk = false;
        await UniTask.Delay(500);
        GameOverPanel.gameObject.SetActive(true);
        GameOverPanel.transform.DOLocalMove(Vector3.zero, 1f);
    }
}
