using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviourPunCallbacks
{
    public static UIManager Instance;

    private UIManager()
    {
    }

    #region Private Variables

    [SerializeField] private InputField roomNameField;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject roomRowPrefab;
    [SerializeField] private Text playerCountText;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject playerCountSelectionPanel;
    [SerializeField] private GameObject waitingPanel;
    [SerializeField] private Text waitingPanelCurrentCountText;
    [SerializeField] private Text waitingPanelExpectedCountText;
    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private Text countdownText;
    private Dictionary<string, RoomInfo> _roomList = new Dictionary<string, RoomInfo>();

    #endregion

    public GameObject PlayerCountSelectionPanel => playerCountSelectionPanel;

    public GameObject WaitingPanel => waitingPanel;

    public Text WaitingPanelCurrentCountText => waitingPanelCurrentCountText;

    public Text WaitingPanelExpectedCountText => waitingPanelExpectedCountText;

    public GameObject CountdownPanel => countdownPanel;

    public Text CountdownText => countdownText;

    private void Start()
    {
        Instance = this;

        if (playerCountText != null)
            playerCountText.text = "1";
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Lobby Scene"))
        {
            if (playerCountText.text.Equals("1"))
            {
                leftArrow.SetActive(false);
            }
            else
            {
                leftArrow.SetActive(true);
            }

            if (playerCountText.text.Equals("5"))
            {
                rightArrow.SetActive(false);
            }
            else
            {
                rightArrow.SetActive(true);
            }
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _roomList.Clear();
        foreach (RoomInfo roomInfo in roomList)
        {
            _roomList[roomInfo.Name] = roomInfo;
        }

        RoomReceived();
    }

    private void RoomReceived()
    {
        //Destroy(content.GetComponentInChildren<GameObject>());

        if(_roomList.Count == 0)
            return;
        
        var item = _roomList.ElementAt(0);
        string roomName = item.Key;

        GameObject newRow = Instantiate(roomRowPrefab, content.transform);

        if (content.transform.childCount > 1)
        {
            Transform[] children = content.transform.GetComponentsInChildren<Transform>();
            Transform previousChild = children[children.Length - 2];

            Debug.Log("Transform: " + previousChild.transform + "\n Scale y: " + previousChild.localScale.y);

            newRow.transform.position =
                previousChild.position - new Vector3(0, previousChild.GetComponent<RectTransform>().rect.height, 0);
        }

        Text text = newRow.GetComponentInChildren<Text>();
        text.text = roomName;
        
    }

    public void OnClickCreateRoomButton()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = Convert.ToByte(playerCountText.text);

        PhotonNetwork.CreateRoom(roomNameField.text, roomOptions, TypedLobby.Default);
    }

    public void OnRightArrowClicked()
    {
        int count = Convert.ToInt32(playerCountText.text);
        playerCountText.text = (count + 1).ToString();
    }

    public void OnLeftArrowClicked()
    {
        int count = Convert.ToInt32(playerCountText.text);
        playerCountText.text = (count - 1).ToString();
    }

    public void OnConfirmationButtonClicked()
    {
    }
}