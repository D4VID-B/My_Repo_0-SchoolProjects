using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //Inventory
    public GameObject[] itemsArray;
    public List<GameObject> inventoryList;
    public Inventory inventory;


    //health
    public float minHealth = 0f;
    public float maxHealth = 100f;
    public float health;
    //lives
    public int lives;
    public int defaultLives = 3;
    //affinity
    public float affinity = 0f;
    public float minAffinity = -100f;
    public float maxAffinity = 100f;
    //special with cool down
    public bool isSpecialActive;
    public float coolDown = 0f;
    public float coolDownMax = 180f;
    //text
    string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut placerat orci nulla pellentesque. Ut sem nulla pharetra diam sit amet. Ornare massa eget egestas purus. Vitae tortor condimentum lacinia quis vel eros. Lectus quam id leo in vitae turpis. Bibendum est ultricies integer quis auctor elit sed vulputate mi. Amet mattis vulputate enim nulla aliquet. Velit euismod in pellentesque massa placerat duis. Auctor eu augue ut lectus arcu bibendum at. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Venenatis tellus in metus vulputate eu scelerisque felis imperdiet proin. At lectus urna duis convallis convallis tellus id. Lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi. Platea dictumst vestibulum rhoncus est pellentesque. Aliquam vestibulum morbi blandit cursus risus. Mauris pellentesque pulvinar pellentesque habitant.Ridiculus mus mauris vitae ultricies leo integer.Vel quam elementum pulvinar etiam non quam lacus.Sed egestas egestas fringilla phasellus faucibus scelerisque eleifend donec. Et malesuada fames ac turpis egestas. Elementum tempus egestas sed sed risus. Arcu dui vivamus arcu felis bibendum ut tristique. Quisque sagittis purus sit amet volutpat consequat.Purus in mollis nunc sed id. Nec ultrices dui sapien eget.Pretium viverra suspendisse potenti nullam ac tortor.Molestie at elementum eu facilisis sed odio.Massa sapien faucibus et molestie ac feugiat.Tristique senectus et netus et malesuada fames ac turpis egestas. Nunc sed id semper risus.Ante metus dictum at tempor commodo ullamcorper a. Odio euismod lacinia at quis risus sed vulputate odio ut. Congue quisque egestas diam in arcu cursus euismod quis viverra.Quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci. Est pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Vel elit scelerisque mauris pellentesque pulvinar pellentesque habitant morbi tristique. Dictum fusce ut placerat orci.Felis bibendum ut tristique et egestas quis ipsum. Eleifend mi in nulla posuere sollicitudin aliquam ultrices.Facilisi cras fermentum odio eu feugiat pretium nibh. Mauris vitae ultricies leo integer malesuada nunc vel risus commodo. Fusce ut placerat orci nulla pellentesque dignissim enim. Integer vitae justo eget magna fermentum iaculis.Integer vitae justo eget magna fermentum iaculis eu non.Odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam. Id donec ultrices tincidunt arcu non sodales neque sodales ut. Integer vitae justo eget magna fermentum iaculis.In ante metus dictum at tempor commodo ullamcorper a lacus. Condimentum id venenatis a condimentum.Gravida quis blandit turpis cursus.Ipsum faucibus vitae aliquet nec ullamcorper sit amet risus.Malesuada fames ac turpis egestas sed tempus urna et pharetra. Aenean vel elit scelerisque mauris pellentesque. Sapien pellentesque habitant morbi tristique senectus et netus. Enim ut tellus elementum sagittis vitae et.Vitae justo eget magna fermentum iaculis eu.Et netus et malesuada fames ac. Blandit turpis cursus in hac habitasse platea dictumst quisque.Sit amet nulla facilisi morbi tempus iaculis urna. Id aliquet lectus proin nibh.In massa tempor nec feugiat nisl pretium fusce. Maecenas ultricies mi eget mauris pharetra et.Hendrerit gravida rutrum quisque non tellus orci ac auctor.Tristique senectus et netus et malesuada fames ac. Tincidunt tortor aliquam nulla facilisi cras fermentum.Donec ultrices tincidunt arcu non sodales. Pulvinar proin gravida hendrerit lectus a. Nec dui nunc mattis enim ut tellus elementum.Cursus risus at ultrices mi tempus imperdiet.Lorem donec massa sapien faucibus et. Cras fermentum odio eu feugiat pretium nibh ipsum. Quis varius quam quisque id diam. Tortor pretium viverra suspendisse potenti nullam ac tortor vitae.Non odio euismod lacinia at quis risus sed. In tellus integer feugiat scelerisque.Porttitor massa id neque aliquam vestibulum morbi.Ut ornare lectus sit amet est placerat.Et ligula ullamcorper malesuada proin libero nunc consequat interdum.In iaculis nunc sed augue lacus viverra vitae congue eu. Netus et malesuada fames ac turpis egestas sed. Lorem dolor sed viverra ipsum nunc. Suspendisse faucibus interdum posuere lorem ipsum dolor sit. Arcu non odio euismod lacinia at quis.";
    public string[] loremIpsumArray;
    string message = "";
    bool canShowBubble = true;

    //UI elements
    public TextMeshProUGUI messageTF;
    public Image healthFill;
    public GameObject[] livesArray;
    public TextMeshProUGUI bubbleText;


  void Start()
    {
        instance = this;
        Init();
    }
    void Init(){
        //Health
        health = maxHealth;
        //Lives
        lives = defaultLives;
        //Affinity
        affinity = 0;
        //Special(
        isSpecialActive = true;
        //Text
        loremIpsumArray = loremIpsum.Split(' ');
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
        CheckLives();
        //Affinity
        CheckAffinity();
        //Special
        CheckSpecial();
        //Text
        CheckText();
        //Inventory
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
    void CheckLives()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
           RemoveLife();

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddLife();

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
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowBubbleText();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            DisplayWordsOfText();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearMessage();
        }

    }
    void ShowBubbleText()
    {
        if (canShowBubble)
        {
            bubbleText.transform.parent.gameObject.SetActive(true);
            string str = GetLineOfText();
            Debug.Log(GetLineOfText());
            bubbleText.text = str;
            bubbleText.transform.parent.DOScale(0f, 0.5f).From().SetEase(Ease.OutCirc);
            canShowBubble = false;
        }


    }
    public void CloseBubble()
    {
        bubbleText.transform.parent.DOScale(0,0.25F).OnComplete(ResetBubble);
    }
    void ResetBubble()
    {
        canShowBubble = true;
        bubbleText.transform.parent.DOScale(1f, 0f);
        bubbleText.transform.parent.gameObject.SetActive(false);

    }
    void AutoDisplayText()
    {
        message += GetLineOfText() + "\n";
        Debug.Log("****Message****\n"+message);
        if(messageTF!=null)
            messageTF.text = message;
    }
    void ClearMessage()
    {
        message = "";
        if (messageTF != null)
            messageTF.text = message;
    }
    void DisplayWordsOfText()
    {
        StartCoroutine("ShowWords");
    }
    IEnumerator ShowWords()
    {
        string str = GetLineOfText();
        string[] strArray = str.Split(' ');
        string newString = "";
        for(int i = 0; i < strArray.Length; i++)
        {
            newString += strArray[i] + " ";
            Debug.Log(newString);
            yield return new WaitForSeconds(0.5f);
        }

    }

    string GetLineOfText()
    {
        string str="";
        int randomNumWords = Random.Range(4, 21);
        int randomStartPos = Random.Range(0, loremIpsumArray.Length-randomNumWords);
        

        for (int i = randomStartPos; i < randomStartPos + randomNumWords; i++)
        {

            str += loremIpsumArray[i] + " ";
        }
        return str;
        
    }
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
    void RemoveLife()
    {
        lives--;
        if(lives < 0)
        {
            lives = 0;
            EndGame();
        }
        UpdateLivesUI();
    }
    void AddLife()
    {
        lives++;
        UpdateLivesUI();
    }

    void EndGame()
    {
        Debug.Log("EndGame()");
        //do something
    }
    void IncreaseHealth()
    {
        health++;
        if (health > maxHealth) health = maxHealth;
        UpdateHealthUI();
    }
    void DecreaseHealth()
    {
        health--;
        if (health < minHealth) health = minHealth;

        Camera.main.transform.DOShakePosition(1f).OnComplete(ResetCamera);

        UpdateHealthUI();
    }
    void ResetCamera()
    {
        Camera.main.transform.DOMove(new Vector3(0f, 1f, -10f), 0.25f);
    }

    void UpdateHealthUI()
    {
        float per = health / maxHealth;
        healthFill.fillAmount = per;
    }

    void UpdateLivesUI()
    {
        //hide the hearts
        foreach(GameObject life in livesArray)
        {
            life.SetActive(false);
        }
        for(int i =0; i <lives; i++)
        {
            livesArray[i].SetActive(true);
        }
    }
}
