using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //health
    public float minHealth = 0f;
    public float maxHealth = 100f;
    public float health;
    public float healthStep = 1.0f;
    public Image damage;
    private IEnumerator screenFlash;

    //Grenades + Ammo
    public int grenades;
    public int ammo;
    public int defaultAmmo = 4;
    public int defaultGrenades = 4;

    //Inventory
    public GameObject[] itemsArray;
    public List<GameObject> inventoryList;
    public Inventory inventory;

    //affinity
    public float affinity = 0f;
    public float minAffinity = -100f;
    public float maxAffinity = 100f;
    public Image meter;
    int ammoCount;

    //special with cool down
    public bool isSpecialActive;
    public float coolDown = 0f;
    public float coolDownMax = 180f;
    public Image icon;

    //text
    //string message = "";
    //bool canShowBubble = true;

    //UI elements
    public TextMeshProUGUI messageTF;
    public Image healthFill;
    public GameObject[] grenadesArray;
    public GameObject[] ammoArray;
    public TextMeshProUGUI bubbleText;


  void Start()
    {
        Init();
    }
    void Init(){
        //Health
        health = maxHealth;
        damage.gameObject.SetActive(false);
        //Ammo
        grenades = defaultGrenades;
        ammo = defaultAmmo;

        //Affinity
        affinity = maxAffinity;
        ammoCount = defaultAmmo;

        //Special(
        isSpecialActive = true;
        //Text
        //loremIpsumArray = loremIpsum.Split(' ');
        //InvokeRepeating("AutoDisplayText", 1f, 3f);

        inventoryList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    void CheckInput(){
        //Health
        CheckHealth();
        //Lives
        CheckGrenadesAmmo();
        //Affinity
        CheckAffinity();
        //Special
        CheckSpecial();
        //Text
        CheckText();

        //Stim Inventory
        CheckInventory();

    }


    void CheckInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddRandomItem();
        }
    }
    void AddRandomItem()
    {
        int rNum = Random.Range(0, itemsArray.Length);
        inventoryList.Add(itemsArray[rNum]);
        //inventoryList = inventoryList.OrderBy(go => go.name).ToList();
        inventory.initItemList();

    }


    void CheckHealth()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            IncreaseHealth();
            
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            DecreaseHealth();
        }
    }
    void CheckGrenadesAmmo()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
           throwGrenade();

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            addGrenade();

        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            reloadBattery();
            affinity = maxAffinity;
            updateAffinity();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            addAmmo();
        }
    }
    void CheckAffinity()
    {
        if (Input.GetMouseButton(0))
        {
            RemoveAffinity();

        }
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    AddAffinity();

        //}
    }
    void CheckSpecial()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isSpecialActive)
            {
                DoSpecial();
            }
            else
            {
                //special not available feedback
                Debug.Log("Special Not Available");
            }
           
        }
        if(!isSpecialActive)
        {
            coolDown--;
            //float per = coolDown / coolDownMax;
            
            if (coolDown == 0f)
            {
                isSpecialActive = true;
                icon.DOFade(1f, 0.5f);

            }
        }
    }
    void CheckText()
    {

    }

    

    void DoSpecial()
    {
        Debug.Log("DoSpecial()");
        isSpecialActive = false;
        coolDown = coolDownMax;
        //Do Something
        icon.DOFade(0f, 0.5f);
    }
    void RemoveAffinity()
    {
        affinity--;
        //if (affinity < minAffinity)
        //{
        //    affinity = minAffinity;

        //}

        if(affinity <= 0)
        {
            if(ammoCount != 0)
            {
                reloadBattery();
                affinity = maxAffinity;
                ammoCount -= 1;
            }
            
        }

        if(Input.GetMouseButton(1))
        {
            affinity -= 49f;
        }
        updateAffinity();
    }
    void AddAffinity()
    {
        affinity++;
        if (affinity > maxAffinity)
        {
            affinity = maxAffinity;
        }
        updateAffinity();
    }
    void updateAffinity()
    {
        float per = affinity / maxAffinity;
        meter.fillAmount = per;
    }

    //Spending 'Nades and Ammo
    void throwGrenade()
    {
        grenades--;
        if(grenades < 0)
        {
            grenades = 0;
        }
        updateGrenades();
    }
    void addGrenade()
    {
        grenades++;
        if(grenades >= defaultGrenades)
        {
            grenades = 4;
        }
        updateGrenades();
    }

    void reloadBattery()
    {
        ammo--;
        if(ammo <= 0)
        {
            ammo = 0;
        }
        updateAmmo();
    }
    void addAmmo()
    {
        ammo++;
        if(ammo >= defaultAmmo)
        {
            ammo = 4;
        }
        updateAmmo();
    }

    void IncreaseHealth()
    {
        health += healthStep;
        if (health > maxHealth) health = maxHealth;
        updateHealth(false);
    }
    void DecreaseHealth()
    {
        health -= healthStep;
        if (health < minHealth) health = minHealth;

        //Shake the camera
        //Camera.main.transform.DOShakePosition(1f).OnComplete(resetCamera);

        //Flash screen
        flashScreen();

        updateHealth(true);
    }

    void flashScreen()
    {
        //Color opacue = new Color(1, 1, 1, 1);

        //damage.color = Color.Lerp(damage.color, opacue, 20*Time.deltaTime);

        screenFlash = waitAndReset(.1f);
        StartCoroutine(screenFlash);
    }

    private IEnumerator waitAndReset(float waitTime)
    {
        damage.gameObject.SetActive(true);

        yield return new WaitForSeconds(waitTime);

        //Color transparent = new Color(1, 1, 1, 0);
        //damage.color =  Color.Lerp(damage.color, transparent, 20 * Time.deltaTime);

        damage.gameObject.SetActive(false);

    }

    void resetCamera()
    {
        Camera.main.transform.DOMove(new Vector3(0f, 1f, -10f), 0.25f);
    }

    void updateHealth(bool takenDamage)
    {
        float per = health / maxHealth;
        healthFill.fillAmount = per;

        //if(takenDamage)
        //{
        //    Color transparent = new Color(1, 1, 1, 0);
        //    damage.color = Color.Lerp(damage.color, transparent, 20 * Time.deltaTime);
        //}
    }

    void updateGrenades()
    {
        foreach(GameObject grenade in grenadesArray)
        {
            //grenade.SetActive(false);
            grenade.gameObject.GetComponent<Image>().color = Color.red;
        }

        for(int i = 0; i < grenades; i++)
        {
            //grenadesArray[i].SetActive(true);
            grenadesArray[i].gameObject.GetComponent<Image>().color = Color.green;
        }
        
    }

    void updateAmmo()
    {
        foreach (GameObject battery in ammoArray)
        {
            //battery.SetActive(false);
            battery.gameObject.GetComponent<Image>().color = Color.red;
            
        }

        for (int i = 0; i < ammo; i++)
        {
            //ammoArray[i].SetActive(true);
            ammoArray[i].gameObject.GetComponent<Image>().color = Color.green;
        }

    }
}
