using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScream : MonoBehaviour
{
    [SerializeField] private AudioClip scream;

    private AudioSource audioSource;
    private Coroutine screamCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.instance.GetState() == GameState.PLAY)
        {
            if (screamCoroutine == null)
            {
                screamCoroutine = StartCoroutine(DelayScream());
            }
        }
        else
        {
            if (screamCoroutine != null)
            {
                StopCoroutine(screamCoroutine);
                screamCoroutine = null;
            }
        }
    }

    private IEnumerator DelayScream()
{
    while (GameManager.instance.GetState() == GameState.PLAY)
    {
        yield return new WaitForSeconds(5f); // ← 先に待つ（無音時間）
        audioSource.PlayOneShot(scream);    // ← そのあと鳴らす
    }
}

}
