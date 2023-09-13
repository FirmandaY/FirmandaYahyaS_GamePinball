using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxAudioSource;
    // Start is called before the first frame update
    // ini tidak di jalankan pada script ini, tapi nanti di jalankan pada script bumpernya
    public void PlayVFX(Vector3 spawnPosition)
    {
        // berbeda dengan bgm, disini kita buat script untuk 
        // memunculkan prefabnya pada posisi sesuai dengan parameternya
        GameObject.Instantiate(vfxAudioSource, spawnPosition, Quaternion.identity);

    }
}
