using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;

    private string playerPrefabName = "Player";

    //private Vector3 _spawnPos = new Vector3(0,5f,0);
    private Vector3 _spawnPos = new Vector3(54.5f, 0f, -3f);
    private int brickCount;
    private int playerCount;

    [SerializeField] private GameObject stonePrefab;
    

    private GameState currentState;
    [SerializeField]private List<Transform> playerSpawnPositions;
    private List<Transform> emptySpawnPositions;
    [SerializeField] private GameObject spawnPosition1;
    [SerializeField] private GameObject spawnPosition2;
    [SerializeField] private GameObject spawnPosition3;
    [SerializeField] private GameObject spawnPosition4;
    [SerializeField] private GameObject firstPlatform;

    [SerializeField]private List<GameObject> prefabs;

    private GameObject[] players;

    [SerializeField]private GameObject brickPrefab;
    
    public List<Transform> PlayerSpawnPositions
    {
        get => playerSpawnPositions;
        set => playerSpawnPositions = value;
    }

    public int PlayerCount
    {
        get => playerCount;
        set => playerCount = value;
    }

    public int BrickCount
    {
        get => brickCount;
        set => brickCount = value;
    }

    private GameManager()
    {
    }

    private void Awake()
    {
        Instance = this;
    }

    
    void Start()
    {
        emptySpawnPositions = new List<Transform>();

        currentState = GameState.WaitingForPlayers;

        if (PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            //TODO: Waiting panel göster.
            UIManager.Instance.WaitingPanel.SetActive(true);
            UIManager.Instance.WaitingPanelCurrentCountText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
            UIManager.Instance.WaitingPanelExpectedCountText.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        }

        
        //Her player bu scene'i açtığında bu scripte girecek
        //Dolayısıyla her player kendini instantiate edecek
        //Player sadece spawn noktalarına spawnlanabilir
        //Bir player'ın spawn olduğu noktaya spawn olamaz.
        //Dolayısıyla bu script spawn noktalarının dolu mu yoksa boş mu olduğunu kontrol etmeli

        playerSpawnPositions = new List<Transform>();
        emptySpawnPositions = new List<Transform>();
        

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LocalPlayer.TagObject = PhotonNetwork.Instantiate("RedPlayer", spawnPosition1.transform.position, Quaternion.identity);
            ((GameObject) PhotonNetwork.LocalPlayer.TagObject).GetComponent<PlayerController>().color = "Red";
        }
        
        /*
        #region Player Color Assignment

        colorList = new List<Color>();
        colorList.Add(Color.red);
        colorList.Add(Color.blue);
        colorList.Add(Color.green);
        colorList.Add(Color.magenta);
        
        int randomColorIndex = Random.Range(0, 4);

        ((GameObject) PhotonNetwork.LocalPlayer.TagObject).GetComponent<PhotonView>().RPC("UpdateColorList",
            RpcTarget.All, randomColorIndex);

        ((GameObject) PhotonNetwork.LocalPlayer.TagObject).GetComponent<PhotonView>().RPC("UpdateColorList",
            RpcTarget.All, randomColorIndex);

        #endregion
        */
        
        playerCount = PhotonNetwork.CurrentRoom.MaxPlayers;

        int no = 10;

        while (true)
        {
            //brick count hem tamkare olmalı hem de playercount'a bölünebilmeli

            //playerCountun katı olan 10'dan büyük en küçük sayı
            if (no % playerCount == 0)
            {
                brickCount = no * no;
                break;
            }
            else
            {
                no++;
            }
        }
    }

    private bool isInstantiated = false;
    
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Player").Length != 0 && !PhotonNetwork.IsMasterClient && !isInstantiated)
        {
            isInstantiated = true;
            InstantiatePlayer();
        }
        
        if (currentState == GameState.WaitingForPlayers)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                UIManager.Instance.WaitingPanel.SetActive(false);
                currentState = GameState.Start;
            }
        }

        if (currentState == GameState.Start)
        {
            StartCoroutine(StartGame());
            currentState = GameState.Gameplay;

        }

        if (currentState == GameState.Gameplay)
        {
        }
    }

    IEnumerator StartGame()
    {
        if (currentState == GameState.Gameplay)
            yield break;

        int count = 3;
        while (count > 0)
        {
            UIManager.Instance.CountdownPanel.SetActive(true);
            UIManager.Instance.CountdownText.gameObject.SetActive(true);
            UIManager.Instance.CountdownText.text = count.ToString();
            count--;
            yield return new WaitForSeconds(1);
            UIManager.Instance.CountdownText.gameObject.SetActive(false);
        }

        UIManager.Instance.CountdownPanel.SetActive(false);
        //InstantiatePlayer();
        GenerateBricks(firstPlatform.name);
            
    }

    
    public void GenerateBricks(string platformName)
    {
        //TODO: Scene'de olan playerların renklerini al ve her birini ayrı color yap
        //TODO: j içeren for her döndüğünde farklı color kullan
        
        GameObject platform = GameObject.Find(platformName);
        //platformun ortasına generate edecek
        //odadaki player count ne kadarsa toplam miktarı ona bölecek
        //brick count hem 4 ün katı hem de playerCount'ın katı olmak zorunda ve 100'den büyük olmak zorunda
        //4ün ve playerCountun katı olan 100'den büyük ilk sayı
        List<GameObject> brickList = new List<GameObject>();

        int colorCount;

        //playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        colorCount = GameManager.Instance.PlayerCount;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        

        for (int i = 0; i < colorCount; i++)
        {

            Color color = players[i].GetComponentInChildren<SkinnedMeshRenderer>().material.color;

            for (int j = 0; j < GameManager.Instance.BrickCount / GameManager.Instance.PlayerCount; j++)
            {
                //GameObject brick = PhotonNetwork.Instantiate("Brick", Vector3.zero, Quaternion.identity);
                GameObject brick = Instantiate(brickPrefab, Vector3.zero, Quaternion.identity);
                brick.GetComponent<MeshRenderer>().material.color = color;
                brick.tag = players[i].GetComponentInChildren<SkinnedMeshRenderer>().material.name.Substring(0,players[i].GetComponentInChildren<SkinnedMeshRenderer>().material.name.IndexOf("M"));
                brickList.Add(brick);
            }
        }

        GameObject middleBrick = PositionBricks(brickList);

        //brickListteki bütün brickleri emptyParent'a al
        //parentın pozisyonunu platformun ortasına yerleştir

        GameObject parentSquare = new GameObject();
        parentSquare.name = "Square";

        //row/2 - 0.5z ve column/2 + 0.5x => pivot

        parentSquare.transform.position =
            middleBrick.transform.localPosition;

        foreach (GameObject brick in brickList)
        {
            brick.transform.SetParent(parentSquare.transform);
        }

        parentSquare.transform.position =
            platform.transform.position + Vector3.up * platform.transform.localScale.y / 2;
    }
    
    private GameObject PositionBricks(List<GameObject> brickList)
    {
        GameObject middleBrick = null;

        ShuffleBrickList(brickList);

        int row;
        int column;

        row = (int) Mathf.Sqrt(brickList.Count);
        column = (int) Mathf.Sqrt(brickList.Count);

        int index = 0;

        for (int i = 0; i < row; i++)
        {
            float zOffset = i * 1f;

            for (int j = 0; j < column; j++)
            {
                GameObject brick = brickList[index];
                if (index == 0)
                {
                    brick.transform.localPosition = Vector3.zero;
                }
                else
                {
                    brick.transform.localPosition += brickList[index - 1].transform.localPosition + Vector3.right * 1f;
                    brick.transform.localPosition = new Vector3(brick.transform.localPosition.x,
                        brick.transform.localPosition.y, -zOffset);
                    if (j == 0 && index != 1)
                    {
                        brick.transform.localPosition = new Vector3(brickList[0].transform.localPosition.x,
                            brick.transform.localPosition.y, -zOffset);
                    }
                }

                if (i == row / 2 && j == column / 2)
                    middleBrick = brick;

                index++;
            }
        }

        return middleBrick;
    }

    private void ShuffleBrickList(List<GameObject> brickList)
    {
        for (int i = 0; i < brickList.Count / 2; i++)
        {
            GameObject temp;
            int randomIndex = Random.Range(brickList.Count / 2, brickList.Count);

            temp = brickList[i];
            brickList[i] = brickList[randomIndex];
            brickList[randomIndex] = temp;
        }
    }
    

    public void InstantiatePlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        foreach (GameObject player in players)
        {
            Debug.Log("1");
            for (int i = 0; i < prefabs.Count; i++)
            {
                Debug.Log("2");

                if (player.name.StartsWith(prefabs[i].name.Substring(0,2)))
                {
                    Debug.Log("3");

                    prefabs.Remove(prefabs[i]);
                }
                
            }
        }
        Debug.Log("4");

        int randomPrefabIndex = Random.Range(0, prefabs.Count);

        string prefabName = prefabs[randomPrefabIndex].name;
        Debug.Log("5");


        GameObject[] emptySpawnPositionObjects = GameObject.FindGameObjectsWithTag("Empty Spawn Position");
        
        int randomPosIndex = Random.Range(0, emptySpawnPositionObjects.Length);

        _spawnPos = emptySpawnPositionObjects[randomPosIndex].transform.position;

        PhotonNetwork.LocalPlayer.TagObject = PhotonNetwork.Instantiate(prefabName, _spawnPos, Quaternion.identity);
        ((GameObject) PhotonNetwork.LocalPlayer.TagObject).GetComponent<PlayerController>().color =
            prefabName.Substring(0, prefabName.IndexOf("P"));
        Debug.Log(((GameObject) PhotonNetwork.LocalPlayer.TagObject).GetComponent<PlayerController>().color);
        ((GameObject)PhotonNetwork.LocalPlayer.TagObject).GetComponent<PhotonView>().RPC("UpdateSpawnPositionsList",RpcTarget.AllBuffered,randomPosIndex);
    }
    
}

enum GameState
{
    WaitingForPlayers,
    Start,
    Gameplay,
    Pause,
    End
}