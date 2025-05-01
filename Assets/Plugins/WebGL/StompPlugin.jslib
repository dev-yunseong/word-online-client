mergeInto(LibraryManager.library, {
  ConnectStomp: function (userIdPtr) {
    const userId = UTF8ToString(userIdPtr);

    const socket = new WebSocket('http://localhost:8080/ws');
    const stompClient = Stomp.over(socket);

    stompClient.connect({}, function (frame) {
      console.log('Connected: ' + frame);

      stompClient.subscribe(`/queue/match-status/${userId}`, function (message) {
        SendMessage('StompHandler', 'OnStompMessage', message.body);
      });

      stompClient.send("/app/queue", {}, JSON.stringify({ userId: userId }));
    });
  }
});
