let popup = null;

mergeInto(LibraryManager.library, {
  OpenKakaoLogin: function(urlPtr) {
    var url = UTF8ToString(urlPtr);
    console.log("Opening Kakao login at:", url);
    popup = window.open(url, "_blank", "width=600,height=700");
    
    const timer = setInterval(() => {
      if (popup.closed) {
        clearInterval(timer);
        console.log("팝업이 닫혔어요!");
        popup.close();
        popup = null;
        
        SendMessage("KakaoLoginHelper", "OnKakaoLoginSuccess", "Success");
      }
    }, 500);
  }
});