using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi,hitSesi;
    public float Menzil;
    public int damage;
    public GameObject kanEfekti;
    int minAngel = -1;
    int maxAngel = 1;

    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer)
        {
            Fire();
            GunTimer = Time.time + TaramaHizi;
        }
    }

    void Fire()
    {

        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = AtesSesi;
            Debug.Log(hit.transform.name);

            if (hit.transform.tag == "zombi")
            {
                hit.transform.GetComponent<ZombiHareket>().ZombiHasar(damage);
                KanEfektiOlustur();
                SesKaynak.PlayOneShot(hitSesi, 0.5f);
            }

            if (hit.transform.tag == "zombiQuick")
            {
                hit.transform.GetComponent<ZombiQuick>().ZombiHasar(damage);
                KanEfektiOlustur();
                SesKaynak.PlayOneShot(hitSesi, 0.5f);
            }

            if (hit.transform.tag == "zombiBoss")
            {
                hit.transform.GetComponent<ZombiBoss>().ZombiHasar(damage);
                KanEfektiOlustur();
                SesKaynak.PlayOneShot(hitSesi, 0.5f);
            }

            if (hit.transform.tag == "crab")
            {
                hit.transform.GetComponent<CrabHareket>().CrabHasar(damage);
                KanEfektiOlustur();
                SesKaynak.PlayOneShot(hitSesi, 0.5f);
            }

        }

        transform.localEulerAngles = new Vector3(Random.Range(minAngel, maxAngel), Random.Range(minAngel, maxAngel), Random.Range(minAngel, maxAngel));



    }

    public void KanEfektiOlustur()
    {
        GameObject kanObjesi = Instantiate(kanEfekti, hit.point, hit.transform.rotation);
        Destroy(kanObjesi, .5f);
    }

}