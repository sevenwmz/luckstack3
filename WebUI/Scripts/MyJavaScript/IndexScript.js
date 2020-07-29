'use strict'
$().ready(function () {
    var timeOut = 2000;
    var setTimeoutId = 0;
    $('[js-send]').click(function (e) {
        e.preventDefault();
        var content = $('[js-content]').val();
        var getTo = null;
        var replayId = $('[js-hiddenReplyId]').attr('id');
        var $this = $(this);
        var $addSuggest = $('[js-hiddenReply]').find('span');

        if (content == "") {
            $addSuggest.parent().removeAttr('hidden');
            $addSuggest.text('Can not input space or nothing');
            newSetTimeOut(setTimeoutId, timeOut);
            return false;
        }//else nothing

        if (replayId == null) {
            getTo = '/Home/_MyChat';
        } else {
            getTo = '/Home/_MyReplyChat';
        }

        $.ajax({
            url: getTo,
            method: 'POST',
            data: { 'reply.Id': replayId, 'content': content },
            beforeSend: function () {
                $this.attr('disabled', 'disabled');
            },
            success: function (data) {
                $('[js-chatRoom]').append(data);
                $this.removeAttr('disabled');

                $addSuggest.text('');
                $('[js-content]').val('');
            },
            complete: function () {
                $this.removeAttr('disabled');

                newSetTimeOut(setTimeoutId, timeOut);
            },
            error: function (a, b, c) {
                console.log('Has some problem now!!!');
            }
        })
    })

    $('[js-reply]').click(function () {
        var replyId = this.parentElement.id;
        var replyText = $(this).parent().find("[js-showContent]").text();

        $('[js-hiddenReply]').removeAttr('hidden');

        var $addReply = $('[js-hiddenReply]').find('span');
        $addReply.attr('id', replyId);
        $addReply.text(replyText);

        newSetTimeOut(setTimeoutId, timeOut);
    });

    refreshChat(setTimeoutId,timeOut);
});
function refreshChat(setTimeoutId,timeOut) {
    setTimeoutId = setTimeout(function () {
        var lastId = $('[js-chatroom]').children().last().attr('id');
        $.ajax({
            url: '/Home/_ChatRoomAjax?id=' + lastId,
            method: 'GET',
            success: function (data) {
                $('[js-chatRoom]').append(data);
            },
            complete: function () {
                console.log(timeOut);
            },
            error: function (a, b, c) {
                console.log('Has some problem now!!!');
            }
        });
        timeOut += 1000;
        if (timeOut <= 60000) {
            refreshChat(setTimeoutId,timeOut);
        } else {
            alert("longtime you was doing nothing ,now system will break connect. if you wanna connect again ,please refresh current page")
            clearTimeout(setTimeoutId);
        }
    }, timeOut)
}
function newSetTimeOut(setTimeoutId, timeOut) {
    for (var i = setTimeoutId-20; i < setTimeoutId; i++) {
        clearTimeout(i);
    }
    refreshChat(setTimeoutId, timeOut);
}