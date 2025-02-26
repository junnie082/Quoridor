using System.Security.Cryptography;
using System;
using UnityEngine;

// 현재 로그인한 유저의 정보를 담는 싱글톤 클래스
public class CurrentLoginSession : MonoBehaviour
{
    private static CurrentLoginSession _singleton;   // 싱글톤 클래스 구현

    public static CurrentLoginSession Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = FindObjectOfType<CurrentLoginSession>();
                if (_singleton != null)
                {
                    GameObject singleton = new GameObject("CurrentLoginSession");
                    _singleton = singleton.AddComponent<CurrentLoginSession>();
                }
            }
            return _singleton;
        }
    }

    private bool _hasLogined = false;  // 게스트인지 확인하는 변수
    private BlockItUser _user;         // 게스트가 아닐 경우 유저 정보 저장

    public bool HasLogined
    {
        get { return _hasLogined; }
    }

    public BlockItUser User
    {
        get { return _user; }
    }

    // 로그인 시 유저 정보 저장
    public void Login(BlockItUser user)
    {
        _user = user;
        _hasLogined = true;
        BlockItUserDataManager.Singleton.GetUserData(_user);
        BlockItUserDataManager.Singleton.GetProfileImage(_user);
    }

    // 로그아웃 시 유저 정보 삭제
    public void Logout()
    {
        _user = null;
        _hasLogined = false;
        Debug.Log("로그아웃 됨");
    }

    // 게스트 모드 시작
    public void StartGuestMode()
    {
        _hasLogined = true;
        _user = new BlockItUser();
        Debug.Log("게스트 모드 시작: " + _user.Nickname);
    }

    // 복수의 CurrentLoginSession 클래스를 Component로 갖는 GameObject가 없도록
    // 경우에 따라 GameObject 제거
    private void Awake()
    {
        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_singleton == this)
        {
            Destroy(gameObject);
        }
    }
}
