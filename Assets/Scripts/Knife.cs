using UnityEngine;
using DG.Tweening;

public class Knife : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    private Collider2D col;
    private AudioSource audioSource;

    [SerializeField] private float throwSpeed;

    public GameObject knifePrefab;
    public Vector3 spawnPos = new Vector3(0, -6, 0);


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        col = GetComponent<PolygonCollider2D>();
        col.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        transform.DOMove(new Vector3(0, -3, 0), .3f);
    }

    void Update()
    {
        Throw();
    }
    public void Throw()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.itsOk)
        {
            col.enabled = true;
            rb.AddForce(Vector3.up * throwSpeed);
            Instantiate(knifePrefab, spawnPos, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            transform.SetParent(collision.transform);
            rb.isKinematic = true;
            Destroy(this);
        }

        if (collision.gameObject.CompareTag("Knife"))
        {
            audioSource.Play();
            transform.DOMove(new Vector3(6, -6, 0), 1f);
            transform.DORotate(Vector3.forward * 200f, .5f);
            gameManager.GameOver();
            Destroy(this);
            Destroy(gameObject, 1f);
        }

    }

}
