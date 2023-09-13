using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider ball;

    // menyimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;

    // menyimpan state switch apakah nyala atau mati
    private bool isOn;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;
    private SwitchState state;

    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    // Start is called before the first frame update
    void Start()
    {
        // ambil renderernya
        renderer = GetComponent<Renderer>();

        // set switch nya mati baik di state, maupun materialnya
        //isOn = false;
        //renderer.material = offMaterial;
        // set switch nya mati baik di state, maupun materialnya
        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        // memastikan yang menabrak adalah bola
        if (other == ball)
        {
            // kita matikan atau nyalakan switch sesuai dengan kebalikan state switch tersebut
            // mati --> nyala || nyala --> mati
            //Set(!isOn);

            // jalankan coroutine blink
            //StartCoroutine(Blink(2));
            Toggle();
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
