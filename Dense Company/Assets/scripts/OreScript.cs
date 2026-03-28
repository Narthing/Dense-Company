using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OreScript : MonoBehaviour
{
    public Button button;

    [Header("other scripts")]
    public GameManager gamemanager;

    [Space(6)]
    [Header("Ore Sprites")]
    public Sprite Dirtsprite;
    public Sprite Stonesprite;
    public Sprite Coppersprite;
    public Sprite Coalsprite;
    public Sprite Ironsprite;
    public Sprite Silversprite;
    public Sprite Quartzsprite;
    public Sprite Goldsprite;

    private Item currentitem;

    private Item Dirt;
    private Item Stone;
    private Item Copper;
    private Item Coal;
    private Item Iron;
    private Item Silver;
    private Item Quartz;
    private Item Gold;

    public AudioSource aud;
    public AudioClip mine;
    public AudioClip fullymine;

    Vector2 endPos = new Vector2(0.7861f, 5.825f);
    Vector2 endPos2 = new Vector2(0.7861f, -1098);

    public bool isMoving = false;
    public bool equipped = false;

    public RectTransform Clipboard;
    public TMP_Text orename;
    public TMP_Text oredesc;
    public Button Okbutton;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        aud = GetComponent<AudioSource>();

        Dirt = new Item("dirt", 1, 1, Dirtsprite);
        Stone = new Item("stone", 3, 3, Stonesprite);
        Copper = new Item("copper", 5, 4, Coppersprite);
        Coal = new Item("coal", 4, 4, Coalsprite);
        Iron = new Item("iron", 7, 5, Ironsprite);
        Silver = new Item("silver", 6, 5, Silversprite);
        Quartz = new Item("quartz", 3, 4, Quartzsprite);
        Gold = new Item("gold", 1300, 30, Goldsprite);

        currentitem = Dirt;
        UpdateSprite();
        
        button.onClick.AddListener(OnClick);
        Okbutton.onClick.AddListener(Slideback);
    }

    void OnClick()
    {
        currentitem.hp -= gamemanager.pickaxedmg;

        if (currentitem.hp <= 0)
        {
            aud.PlayOneShot(fullymine);
        }
        if (currentitem.hp >= 1)
        {
            aud.PlayOneShot(mine);
        }

        if (currentitem.hp <= 0)
        {
            int randomnumber = Random.Range(1, 9);
            if (currentitem == Dirt && !gamemanager.dirtfound)
            {
                gamemanager.dirtfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Dirt";
                oredesc.text = "Dirt. What would this world be without a whole... what was it, like 6 handfulls of dirt? i forgot. Kinda reminds me of the one time  my buddy bomb ate dirt. He died from dirt poisoning 3 seconds later.";
            }
            if (currentitem == Stone && !gamemanager.stonefound)
            {
                gamemanager.stonefound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Stone";
                oredesc.text = "The creator of this world wanted something to throw at birds, so he made a hard substance called rock. He didnt like when people invented pickaxes and started breaking the rocks though, so they all got thrown into space.";
            }
            if (currentitem == Copper && !gamemanager.copperfound)
            {
                gamemanager.copperfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Copper";
                oredesc.text = "Someone complained to the creator that all the ores looked the same so he made copper, made out of mint and chocolate icecream. Dont eat it though, theres still mold on it from that one time...";
            }
            if (currentitem == Coal && !gamemanager.coalfound)
            {
                gamemanager.coalfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Coal";
                oredesc.text = "Some IDIOT spilled their pepper shaker all over the world and left these flammable rocks everywhere. i get a sneezing fit just standing near one.";
            }
            if (currentitem == Iron && !gamemanager.ironfound)
            {
                gamemanager.ironfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Iron";
                oredesc.text = "I kinda like these things, they dont do much and make good gum. For some reason the creator hates this one, probably because he likes the shiny silver more.";
            }
            if (currentitem == Silver && !gamemanager.silverfound)
            {
                gamemanager.silverfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Silverrrrr";
                oredesc.text = "My cat fell asleep with his ink pen writing the name, just ignore it. anyways this stuff shiny. 10/10 and also has a myth going around saying its just sawblade turrets disquised as ore, proposterous!";
            }
            if (currentitem == Quartz && !gamemanager.quartzfound)
            {
                gamemanager.quartzfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Quartz";
                oredesc.text = "now the name on this one is pretty lazy, like cmon you just replaced the s in quarts with a z. Its strange look come from the creator's strange inability to make quarts look like itself.";
            }
            if (currentitem == Gold && !gamemanager.goldfound)
            {
                gamemanager.goldfound = true;
                StartCoroutine(Slide());
                gamemanager.clipboardup = true;
                orename.text = "Gold!";
                oredesc.text = "bet i got you thinking the ore was invincible with how durable it is, but no, its the most valuable in the world and definitely is NOT popcorn, dont even bring popcorn up around any gold here. dont.";
            }

            if (randomnumber == 1)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Dirt;
                currentitem.hp = Dirt.hp;
                UpdateSprite();
            }
            if (randomnumber == 2)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Stone;
                currentitem.hp = Stone.hp;
                UpdateSprite();
            }
            if (randomnumber == 3)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Copper;
                currentitem.hp = Copper.hp;
                UpdateSprite();
            }
            if (randomnumber == 4)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Coal;
                currentitem.hp = Coal.hp;
                UpdateSprite();
            }
            if (randomnumber == 5)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Iron;
                currentitem.hp = Iron.hp;
                UpdateSprite();
            }
            if (randomnumber == 6)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Silver;
                currentitem.hp = Silver.hp;
                UpdateSprite();
            }
            if (randomnumber == 7)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Quartz;
                currentitem.hp = Quartz.hp;
                UpdateSprite();
            }
            if (randomnumber == 8)
            {
                gamemanager.moneytotal += currentitem.value;
                currentitem = Gold;
                currentitem.hp = Gold.hp;
                UpdateSprite();
            }
        }

    }
    void UpdateSprite()
    {
        button.GetComponent<Image>().sprite = currentitem.sprite;
    }

    

    IEnumerator Slide()
    {
        isMoving = true;

        float duration = 0.3f;
        float time = 0f;

        // start from current ui position
        Vector2 start = Clipboard.anchoredPosition;

        while (time < duration)
        {
            float t = time / duration;

            // move ui properly
            Clipboard.anchoredPosition = Vector2.Lerp(start, endPos, t);

            time += Time.deltaTime;
            yield return null;
        }

        Clipboard.anchoredPosition = endPos;

        isMoving = false;
        equipped = true;
    }

    void Slideback()
    {
        if (!isMoving)
            StartCoroutine(SlidebackRoutine());
    }

    IEnumerator SlidebackRoutine()
    {
        isMoving = true;

        float duration = 0.3f;
        float time = 0f;

        Vector2 start = Clipboard.anchoredPosition;

        while (time < duration)
        {
            float t = time / duration;

            Clipboard.anchoredPosition = Vector2.Lerp(start, endPos2, t);

            time += Time.deltaTime;
            yield return null;
        }

        Clipboard.anchoredPosition = endPos2;

        isMoving = false;
        equipped = false;
        gamemanager.clipboardup = false;
    }
}


public class Item
{
    public string itemName; 
    public float value;     
    public float hp;
    public Sprite sprite;

    
    public Item(string name, int value, int hp, Sprite sprite)
    {
        this.itemName = name;
        this.value = value;
        this.hp = hp;
        this.sprite = sprite;
    }
}