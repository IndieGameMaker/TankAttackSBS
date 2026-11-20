using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _gameVersion = "1.0";
    [SerializeField] private string _nickName = "Zackiller";
    [SerializeField] private byte _maxPlayers = 20;

    private void Awake()
    {
        PhotonNetwork.GameVersion = _gameVersion;
        PhotonNetwork.NickName = _nickName;
        // 포톤 서버에 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("포톤 서버에 접속 되었습니다.");
    }
}
