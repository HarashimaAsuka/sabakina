using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScreamController : MonoBehaviour
{
    [Header("Judge Position")]
    [SerializeField] private float passengerZ = -4.0f;

    [Header("Audio")]
    [SerializeField] private AudioClip screamClip;

    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hasPlayed) return;

        // 自分自身（Passenger）の位置を見る
        if (transform.position.z <= passengerZ)
        {
            audioSource.PlayOneShot(screamClip);
            hasPlayed = true;
            Debug.Log("Scream 発火");
        }
    }
}
