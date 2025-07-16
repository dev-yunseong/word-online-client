let popup = null;

mergeInto(LibraryManager.library, {
  OpenKakaoLogin: function(urlPtr) {
    var url = UTF8ToString(urlPtr);
    console.log("Opening Kakao login at:", url);
    
    window.addEventListener("message", (event) => { 
      const data = event.data;
        console.log("JWT 토큰 줄라고 옴");
        console.log(event.origin);
      if (event.origin !== 'http://localhost:8080') return; 
      if (data.token) {
        console.log("JWT 토큰 받음:", data.token);
    
        SendMessage("KakaoLoginHelper", "OnKakaoLoginSuccess", data.token);
      }
    });
    
    popup = window.open(url, "_blank", "width=600,height=700");
    popup.postMessage("SET_OPENER", "http://localhost:8080");
  },
  
  GetUserInfo: function() {
    fetch("http://localhost:8080/api/users/mine", {
      method: "GET",
      credentials: "include"
    })
    .then(response => {
      if (response.ok) {
        return response.text();
      }
      throw new Error('Response was not ok');
    })
    .then(data => {
      console.log(data);
      SendMessage("KakaoLoginHelper", "OnKakaoUserInfoSuccess", data);
    })
    .catch(error => {
      console.error('Error:', error);
    });
  }
});