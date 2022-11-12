using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CrabHareket : MonoBehaviour
{
    private GameObject oyuncu;
    private Animation animasyon;
    private int CrabCan = 2;
    private float mesafe;
    private OyunKontrol oKontrol;
    private int CrabPuan = 10;
    AudioSource SesKaynak;

    void Start()
    {
        oyuncu = GameObject.Find("Oyuncu");
        animasyon = GetComponentInChildren<Animation>();
        oKontrol = GameObject.Find("_Script").GetComponent<OyunKontrol>();
        SesKaynak = GetComponent<AudioSource>();
    }


    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);

        if (mesafe > 4f && CrabCan > 0)
        {
            animasyon.Play("run");
        }

        if (mesafe < 3f && CrabCan > 0)
        {
            animasyon.Play("attack1");
        }
    }

    void CrabOlum()
    {
        gameObject.tag = "dead";
        SesKaynak.Stop();
        oKontrol.PuanArttir(CrabPuan);
        GetComponentInChildren<Animation>().Play("deadend");
        GetComponent<NavMeshAgent>().isStopped = true;
        Destroy(this.gameObject, 2f);
    }

    public void CrabHasar(int damage)
    {
        CrabCan -= damage;
        if (CrabCan <= 0)
        {
            CrabOlum();
        }
    }
}
