'use strict';
$().ready(function () {
    var timeOut = 2000,
        refreshHanderId = 0;
    $('[js-send]').click(function (e) {
        e.preventDefault();
        var $this = $(this),
            $reminder = $('[js-reminder]'),
            $hiddenReply = $('[js-hiddenReplyId]'),

            content = $('[js-content]').val(),
            replyId = $hiddenReply.attr('id');

        if (content === "") {
            $('[js-hiddenReply]').css('display','');
            $reminder.text('Can not input space or nothing');
            clearTimeout(refreshHanderId);
            refreshChat(timeOut);
            return false;
        }//else nothing


        $.ajax({
            url: '/Home/_MyChat',
            method: 'POST',
            data: { 'reply.Id': replyId, 'content': content },
            beforeSend: function () {
                $this.css('display', 'none');
            },
            success: function (data) {
                $('[js-chatRoom]').append(data);

                $hiddenReply.text('').removeAttr('id');
                $('[js-content]').val('');
                $reminder.text('');
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

        $hiddenReply.css('display','');
        $addReply.attr('id', replyId).text(replyText);

        clearTimeout(refreshHanderId);
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
    refreshChat(timeOut);
});

function errorFedback(a, b, c) {
    console.log('Has some problem now!!!');
}