'use strict';
$().ready(function () {
    var timeOut = 2000,
        refreshHanderId = 0;
    $('[js-send]').click(function (e) {
        e.preventDefault();
        var getTo = null,
            $this = $(this),
            content = $('[js-content]').val(),
            $hiddenReply = $('[js-hiddenReplyId]'),
            replyId = $hiddenReply.attr('id');

        if (content === "") {
            $('[js-reminder]').text('Can not input space or nothing');
            clearTimeout(refreshHanderId);
            refreshChat(timeOut);
            return false;
        }//else nothing

        if (replyId === undefined) {
            getTo = '/Home/_MyChat';
        } else {
            getTo = '/Home/_MyReplyChat';
        }

        $.ajax({
            url: getTo,
            method: 'POST',
            data: { 'reply.Id': replyId, 'content': content },
            beforeSend: function () {
                $this.css('display', 'none');
            },
            success: function (data) {
                $('[js-chatRoom]').append(data);

                $hiddenReply.text('').removeAttr('id');
                $('[js-content]').val('');
            },
            complete: function () {
                $this.css('display', '');

                clearTimeout(refreshHanderId);
                refreshChat(timeOut);
            },
            error: errorFedback
        });
    });

    $('[js-reply]').click(function () {
        let $hiddenReply = $('[js-hiddenReply]');
        var replyId = $(this).parent().attr('id');
        var replyText = $(this).parent().find("[js-showContent]").text();
        var $addReply = $hiddenReply.find('[js-hiddenReplyId]');

        $hiddenReply.removeAttr('hidden');
        $addReply.attr('id', replyId);
        $addReply.text(replyText);

        clearTimeout(refreshHanderId);
        refreshChat(timeOut);
    });

    refreshChat(timeOut);
});
function refreshChat(timeOut) {
    refreshHanderId = setTimeout(function () {
        var lastId = $('[js-chatroom]').children().last().attr('id');
        $.ajax({
            url: '/Home/_ChatRoomAjax?id=' + lastId,
            method: 'GET',
            success: function (data) {
                $('[js-chatRoom]').append(data);
            },
            complete: function () {
            },
            error: errorFedback
        });
        timeOut += 1000;
        if (timeOut <= 60000) {
            refreshChat(timeOut);
        } else {
            alert("longtime you was doing nothing ,now system will break connect. if you wanna connect again ,please refresh current page");
            clearTimeout(refreshHanderId);
        }
    }, timeOut);
}


function errorFedback(a, b, c) {
    console.log('Has some problem now!!!');
}