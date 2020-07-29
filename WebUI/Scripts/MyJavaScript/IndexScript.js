'use strict'
$().ready(function () {
    $('[js-send]').click(function (e) {
        e.preventDefault();
        var content = $('[js-content]').val();
        var getTo  = null;
        var replayId = $('[js-hiddenReplyId]').attr('id');
        var $this = $(this);
        var $addSuggest = $('[js-hiddenReply]').find('span');

        if (content == "") {
            $addSuggest.parent().removeAttr('hidden');
            $addSuggest.text('Can not input space or nothing');
            return false;
        }//else nothing

        if (replayId == null) {
            getTo = '/Home/_MyChat';
        } else {
            getTo  = '/Home/_MyReplyChat';
        }

        $.ajax({
            url: getTo ,
            method: 'POST',
            data: { 'reply.Id' : replayId, 'content':content },
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
                console.log('complete');
            },
            error: function (a,b,c) {
                console.log('Has some problem now!!!');
            }
        })
    })
});

'use strict'
$('[js-reply]').click(function () {
    var replyId = this.parentElement.id;
    var replyText = $(this).parent().find("[js-showContent]").text();

    $('[js-hiddenReply]').removeAttr('hidden');

    var $addReply = $('[js-hiddenReply]').find('span');
    $addReply.attr('id', replyId);
    $addReply.text(replyText);
})