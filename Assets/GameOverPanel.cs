using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(Vector3.zero, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
