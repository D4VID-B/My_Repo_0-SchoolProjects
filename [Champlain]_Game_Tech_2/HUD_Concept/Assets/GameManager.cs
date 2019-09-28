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
    //special with cool down
    public bool isSpecialActive;
    public float coolDown = 0f;
    public float coolDownMax = 180f;
    //text
    string message = "";
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
        
        //Ammo
        grenades = defaultGrenades;
        ammo = defaultAmmo;

        //Affinity
        affinity = 0;
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
        if(Input.GetKeyDown(KeyCode.C))
        {
            reloadBattery();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            addAmmo();
        }
    }
    void CheckAffinity()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RemoveAffinity();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddAffinity();

        }
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
            if (coolDown == 0f)
            {
                isSpecialActive = true;
            }
        }
    }
    void CheckText()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    showBubble();
            
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    DisplayWordsOfText();
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    ClearMessage();
        //}

    }

    //void showBubble()
    //{
    //    if(canShowBubble)
    //    {
    //        bubbleText.transform.parent.gameObject.SetActive(true);
    //        string str = GetLineOfText();
    //        Debug.Log(GetLineOfText());
    //        bubbleText.text = str;

    //        bubbleText.transform.parent.DOScale(0f, .5f).From().SetEase(Ease.OutCirc);
    //        canShowBubble = false;
    //    }
        
    //}
    //void resetBubble()
    //{
    //    canShowBubble = true;
    //    bubbleText.transform.parent.DOScale(1f, 0f);
    //    bubbleText.transform.parent.gameObject.SetActive(false);
    //}
    //public void closeBubble()
    //{
    //    bubbleText.transform.parent.DOScale(0f, 0.25f).OnComplete(resetBubble);
    //}

    //void AutoDisplayText()
    //{
    //    message += GetLineOfText() + "\n";
    //    Debug.Log("****Message****\n"+message);
    //    if(messageTF!=null)
    //        messageTF.text = message;
    //}
    //void ClearMessage()
    //{
    //    message = "";
    //    if (messageTF != null)
    //        messageTF.text = message;
    //}
    //void DisplayWordsOfText()
    //{
    //    StartCoroutine("ShowWords");
    //}
    //IEnumerator ShowWords()
    //{
    //    string str = GetLineOfText();
    //    string[] strArray = str.Split(' ');
    //    string newString = "";
    //    for(int i = 0; i < strArray.Length; i++)
    //    {
    //        newString += strArray[i] + " ";
    //        Debug.Log(newString);
    //        yield return new WaitForSeconds(0.5f);
    //    }

    //}

    //string GetLineOfText()
    //{
    //    string str="";
    //    int randomNumWords = Random.Range(4, 21);

    //    int randomStartPos = Random.Range(0, loremIpsumArray.Length-randomNumWords);

    //    for (int i = randomStartPos; i < randomStartPos + randomNumWords; i++)
    //    {

    //        str += loremIpsumArray[i] + " ";
    //    }
    //    return str;
        
    //}

    void DoSpecial()
    {
        Debug.Log("DoSpecial()");
        isSpecialActive = false;
        coolDown = coolDownMax;
        //Do Something
    }
    void RemoveAffinity()
    {
        affinity--;
        if (affinity < minAffinity)
        {
            affinity = minAffinity;
        }
    }
    void AddAffinity()
    {
        affinity++;
        if (affinity > maxAffinity)
        {
            affinity = maxAffinity;
        }
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
        updateHealth();
    }
    void DecreaseHealth()
    {
        health -= healthStep;
        if (health < minHealth) health = minHealth;

        Camera.main.transform.DOShakePosition(1f).OnComplete(resetCamera);

        updateHealth();
    }

    void resetCamera()
    {
        Camera.main.transform.DOMove(new Vector3(0f, 1f, -10f), 0.25f);
    }

    void updateHealth()
    {
        float per = health / maxHealth;
        healthFill.fillAmount = per;
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
