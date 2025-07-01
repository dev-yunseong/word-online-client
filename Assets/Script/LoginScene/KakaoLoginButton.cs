using UnityEngine;

public class KakaoLoginButton : MonoBehaviour
{
    [SerializeField] private KakaoLoginHelper kakaoLoginHelper;
        
    public void OnClickButton()
    {
        kakaoLoginHelper.LoginWithKakao();
    }
}
