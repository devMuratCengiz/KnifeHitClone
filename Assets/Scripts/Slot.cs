using UnityEngine;

public class Slot : MonoBehaviour
{
    public int knifeCount;
    public GameObject[] iceKnifes;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        for (int i = 0; i < knifeCount; i++)
        {
            iceKnifes[i].gameObject.SetActive(true);
            iceKnifes[i].GetComponent<IceKnifes>().isFull = true;
        }
    }

    public void IceKnifesUpdate()
    {
        for (int i = iceKnifes.Length - 1; i >= 0; i--)
        {
            var item = iceKnifes[i];

            if (item.GetComponent<IceKnifes>().isFull)
            {
                item.GetComponent<SpriteRenderer>().color = Color.black;
                item.GetComponent<IceKnifes>().isFull = false;

                if (i == 0)
                {
                    Debug.Log("LevelComplete");
                    gameManager.NextLevel();
                }
                break;
            }
            else
            {
                continue;
            }
        }
    }
}
