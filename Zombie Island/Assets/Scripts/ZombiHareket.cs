using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombiHareket : MonoBehaviour
{
    private GameObject oyuncu;
    public GameObject kalp;
    private Animation animasyon;
    private int zombiCan = 10;
    private float mesafe;
    private OyunKontrol oKontrol;
    private int zombiPuan = 10;
    AudioSource SesKaynak;
    public AudioClip zombiOlumSesi;

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

        if (mesafe >= 3f && zombiCan > 0)
        {
            animasyon.Play("walkzombie");
        }

        if (mesafe <= 2f && zombiCan > 0)
        {
            animasyon.Play("attack01");
        }

    }

    void ZombiOlum()
    {
        gameObject.tag = "dead";
        oKontrol.PuanArttir(zombiPuan);
        GetComponentInChildren<Animation>().Play("die02");
        GetComponent<NavMeshAgent>().isStopped = true;
        Destroy(this.gameObject, 1.2f);
        GameObject can = Instantiate(kalp, transform.position, Quaternion.identity);
        Destroy(can, 8f);
        SesKaynak.Play();
        SesKaynak.clip = zombiOlumSesi;
    }

    public void ZombiHasar(int damage)
    {
        zombiCan -= damage;
        if (zombiCan <= 0)
        {
            ZombiOlum();
        }
    }
}
