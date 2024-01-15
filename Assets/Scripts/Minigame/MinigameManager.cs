using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : Singleton<MinigameManager>
{
    [SerializeField] private GameObject ui_ExcludeMinigame;
    [SerializeField] private Transform objectParent;
    public Vector2 rect;
    [SerializeField] private Vector2 saftyRect;

    [SerializeField] private Minigame_player player;

    [SerializeField] private GameObject dogSource;
    private List<Minigame_dog> dogs;
    [SerializeField] private int dogCount = 30;
    [SerializeField] private GameObject coinSource;
    private List<Minigame_coin> coins;
    [SerializeField] private int coinCount = 50;
    [SerializeField] private int coinGold = 100;

    protected override void AddListeners()
    {
        base.AddListeners();

        Minigame_coin.GetEvent += OnCoinGet;
        Minigame_dog.DieEvent += OnDie;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();

        Minigame_coin.GetEvent -= OnCoinGet;
        Minigame_dog.DieEvent -= OnDie;
    }

    private void OnCoinGet(object sender, int e)
    {
        GM.Instance.AddGold(coinGold);
    }

    private void OnDie(object sender, int e)
    {
        player.gameObject.SetActive(false);
        // 미니 게임 종료
        GameEnd();
    }

    protected override void Awake()
    {
        base.Awake();
        Init();

    }


    public void GameStart()
    {
        ui_ExcludeMinigame.SetActive(false);
        objectParent.gameObject.SetActive(true);

        player.gameObject.SetActive(true);
        player.transform.position = Vector3.zero;

        for (int i = 0; i < dogs.Count; i++)
        {
            dogs[i].gameObject.SetActive(true);

            Vector2 randomPos = Vector2.zero;
            while (true)
            {
                randomPos.x = UnityEngine.Random.Range(-1f * rect.x, rect.x);
                randomPos.y = UnityEngine.Random.Range(-1f * rect.y, rect.y);

                if (Mathf.Abs(randomPos.x) > saftyRect.x || Mathf.Abs(randomPos.y) > saftyRect.y)
                {
                    break;
                }
            }

            dogs[i].transform.position = randomPos;
            dogs[i].Init(true);
        }

        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].gameObject.SetActive(true);

            Vector2 randomPos = Vector2.zero;
            while (true)
            {
                randomPos.x = UnityEngine.Random.Range(-1f * rect.x, rect.x);
                randomPos.y = UnityEngine.Random.Range(-1f * rect.y, rect.y);

                if (Mathf.Abs(randomPos.x) > saftyRect.x || Mathf.Abs(randomPos.y) > saftyRect.y)
                {
                    break;
                }
            }

            coins[i].transform.position = randomPos;
        }
    }

    public void GameEnd()
    {
        ui_ExcludeMinigame.SetActive(true);
        objectParent.gameObject.SetActive(false);
    }

    private void Init()
    {
        dogs = new List<Minigame_dog>(dogCount);
        for (int i = 0; i < dogCount; i++)
        {
            var obj = Instantiate(dogSource, objectParent);
            Minigame_dog dog = obj.GetComponent<Minigame_dog>();
            dogs.Add(dog);
        }
        coins = new List<Minigame_coin>(coinCount);
        for (int i = 0; i < coinCount; i++)
        {
            var obj = Instantiate(coinSource, objectParent);
            Minigame_coin coin = obj.GetComponent<Minigame_coin>();
            coins.Add(coin);
        }
    }
}
