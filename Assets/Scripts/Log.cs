using UnityEngine;
using DG.Tweening;

public class Log : MonoBehaviour
{
    private GameManager gameManager;
    private Slot slot;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public float spinForce;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slot = GameObject.Find("IceKnifes").GetComponent<Slot>();
    }

    void Update()
    {
        if (gameManager.itsOk)
        {
            transform.Rotate(Vector3.forward * spinForce);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            audioSource.Play();
            transform.DOMove(new Vector3(0, 2.1f, 0), .05f).SetLoops(2, LoopType.Yoyo);
            spriteRenderer.DOColor(new Color(255, 255, 255, 255), .05f).SetLoops(2, LoopType.Yoyo);
            slot.IceKnifesUpdate();
        }
    }

}
