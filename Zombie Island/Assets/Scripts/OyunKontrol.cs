using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject zombi, zombiQuick, zombiBoss,crab;
    public GameObject m1, m1918, thompson;
    public GameObject m1Aktif, m1918Aktif, thompsonAktif;
    public bool m1918Bool = false, thompsonBool = false;
    public GameObject m1918Obj, thompsonObj;
    public GameObject BilgiImage,HizliZombiBilgiImg,GiantZombiBilgiImg;
    private float zamanSayaci;
    private float olusumSureci = 10f;
    public GameObject kalp;
    private int puan;
    public Text puanText;
    private float saniye, dakika;
    public Text sure;
    private AudioSource OyunMuzik;

    void Start()
    {
        zamanSayaci = olusumSureci;
        Invoke("M1918OSpawn", 60);
        Invoke("ThompsonSpawn", 120);
    }

    void Update()
    {
        saniye += Time.deltaTime;
        sure.text = "" + dakika.ToString("00") + ":" + saniye.ToString("00");

        if (saniye > 59)
        {
            dakika += 1;
            saniye = 0;
        }

        if ( dakika == 1 && saniye == 0)
        {
            HizliZombiBilgi();
            saniye += 1f;
            HizliZombiOlustur();
        }

        if (dakika == 2 && saniye == 0)
        {
            GiantZombiBilgi();
            saniye += 1f;
            BossZombiOlustur();
        }

        if (dakika >= 3 && dakika <= 5 && saniye == 0)
        {
            HizliZombiOlustur();
            CrabOlustur();
            BossZombiOlustur();
        }

        if (dakika >= 6 && saniye == 0)
        {
            int x = (int) dakika - 4;
            for (int i = 0; i < x; i++)
            {
                HizliZombiOlustur();
                BossZombiOlustur();
                CrabOlustur();
            }
        }

        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(-41f,60f), 6f, Random.Range(45f,-63f));
            Instantiate(zombi, pos, Quaternion.identity);
            zamanSayaci = olusumSureci;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            M1SilahGec();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && m1918Bool)
        {
            M1918SilahGec();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && thompsonBool)
        {
            ThompsonSilahGec();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            BilgiKapat();
        }

    }

    public void PuanArttir(int p)
    {
        puan += p;
        puanText.text = "" + puan;
    }

    void HizliZombiOlustur()
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-41f, 60f), 6f, Random.Range(45f, -63f));
            Instantiate(zombiQuick, pos, Quaternion.identity);
        }
    }

    void CrabOlustur()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = new Vector3(66 -i,1.5f,-66);
            Instantiate(crab, pos, Quaternion.identity);
        }
    }

    void BossZombiOlustur()
    {
        Vector3 pos = new Vector3(42,2f,8);
        Instantiate(zombiBoss, pos, Quaternion.identity);
    }

    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan",puan);
        PlayerPrefs.SetString("sure", sure.text);
        SceneManager.LoadScene("OyunBitti");
    }

    void M1SilahGec()
    {
        m1.SetActive(true);
        m1Aktif.SetActive(true);

        m1918.SetActive(false);
        m1918Aktif.SetActive(false);

        thompson.SetActive(false);
        thompsonAktif.SetActive(false);


    }

    void M1918SilahGec()
    {
        m1918.SetActive(true);
        m1918Aktif.SetActive(true);

        m1.SetActive(false);
        m1Aktif.SetActive(false);

        thompson.SetActive(false);
        thompsonAktif.SetActive(false);
    }

    void ThompsonSilahGec()
    {
        thompson.SetActive(true);
        thompsonAktif.SetActive(true);

        m1.SetActive(false);
        m1Aktif.SetActive(false);

        m1918.SetActive(false);
        m1918Aktif.SetActive(false);

    }

    void M1918OSpawn()
    {
        Vector3 pos = new Vector3(-7, 20, -11);
        Instantiate(m1918Obj, pos, Quaternion.identity);
        BilgiImage.SetActive(true);
    }

    void ThompsonSpawn()
    {
        Vector3 pos = new Vector3(-7, 20, -11);
        Instantiate(thompsonObj, pos, Quaternion.identity);
        BilgiImage.SetActive(true);
    }

    void HizliZombiBilgi()
    {
        HizliZombiBilgiImg.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    void GiantZombiBilgi()
    {
        GiantZombiBilgiImg.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void BilgiKapat()
    {
        HizliZombiBilgiImg.SetActive(false);
        GiantZombiBilgiImg.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

}
