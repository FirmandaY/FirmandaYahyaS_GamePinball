using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperControlle : MonoBehaviour
{

    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider ball;
    // untuk mengatur kecepatan bola setelah memantul
    public float multiplier;
    // tambahkan audio manager untuk mengakses fungsi pada audio managernya
    public AudioManager audioManager;

    public VFXManager vfxManager;

    private void OnCollisionEnter(Collision collision)
    {
        // memastikan yang menabrak adalah bola
        if (collision.collider == ball)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody ballRig = ball.GetComponent<Rigidbody>();
            ballRig.velocity *= multiplier;
        }

        // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
        audioManager.PlaySFX(collision.transform.position);

        vfxManager.PlayVFX(collision.transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
