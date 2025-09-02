using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamController : MonoBehaviour
{
    public AudioSource screamSource;
    public AudioClip screamClip;
    public float passengerZ = -4.0f;
    public float threshold = 0.1f;

    [SerializeField] public GameObject passengerObj;

    // Start is called before the first frame update
    void Start()
    {
        screamSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(passengerObj.transform.position.z - passengerZ) <= threshold){
            PlayScream();
            Debug.Log("発火");
        }
    }

    void PlayScream(){
            screamSource.PlayOneShot(screamClip);
    }
}
