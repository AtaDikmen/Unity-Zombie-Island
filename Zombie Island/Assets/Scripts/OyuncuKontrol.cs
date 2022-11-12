using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrol : MonoBehaviour
{
    public Image canImage;
    public float canDegeri = 100f;
    public AudioClip olmeSesi, canAlmaSesi, yaralanmaSesi,silahAlmaSesi;
    private AudioSource SesKaynak;
    public OyunKontrol oKontrol;
    public GameObject m1918Image, thompsonImage;

    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (canDegeri <= 0)
        {
            oKontrol.OyunBitti();
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi") || c.collider.gameObject.tag.Equals("zombiQuick"))
        {
            canDegeri -= 10f;
            float x = canDegeri / 100f;
            canImage.fillAmount = x;
            canImage.color = Color.Lerp(Color.red, Color.green, x);
            SesKaynak.PlayOneShot(yaralanmaSesi,1f);
        }

        if (c.collider.gameObject.tag.Equals("zombiBoss"))
        {
            canDegeri -= 30f;
            float x = canDegeri / 100f;
            canImage.fillAmount = x;
            canImage.color = Color.Lerp(Color.red, Color.green, x);
            SesKaynak.PlayOneShot(yaralanmaSesi, 1f);
        }

        if (c.collider.gameObject.tag.Equals("crab"))
        {
            canDegeri -= 5f;
            float x = canDegeri / 100f;
            canImage.fillAmount = x;
            canImage.color = Color.Lerp(Color.red, Color.green, x);
            SesKaynak.PlayOneShot(yaralanmaSesi, 1f);
        }

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("kalp"))
        {
            if (canDegeri < 100f)
            {
                canDegeri += 10f;
                float x = canDegeri / 100f;
                canImage.fillAmount = x;
                canImage.color = Color.Lerp(Color.red, Color.green, x);
                Destroy(c.gameObject);
                SesKaynak.PlayOneShot(canAlmaSesi, 1f);
            }
        }

        if (c.gameObject.tag.Equals("okyanus"))
        {
            canDegeri = 0f;
            float x = canDegeri / 100f;
            canImage.fillAmount = x;
            canImage.color = Color.Lerp(Color.red, Color.green, x);
        }

        if (c.gameObject.tag.Equals("m1918obj"))
        {
            m1918Image.SetActive(true);
            oKontrol.m1918Bool = true;
            SesKaynak.PlayOneShot(silahAlmaSesi,1f);
            Destroy(c.gameObject);
            oKontrol.BilgiImage.SetActive(false);
        }

        if (c.gameObject.tag.Equals("thompsonobj"))
        {
            thompsonImage.SetActive(true);
            oKontrol.thompsonBool = true;
            SesKaynak.PlayOneShot(silahAlmaSesi, 1f);
            Destroy(c.gameObject);
            oKontrol.BilgiImage.SetActive(false);
        }
    }
}
