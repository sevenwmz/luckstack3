'use strict';
$(document).ready(function () {
    $('[js-Comments]').click(function (e) {
        e.preventDefault();
        let $this = $(this);
        let $allComment = $('[js-allComments]');
        let $myComment = $('[js-myComment]');
        let $hiddenReply = $('[js-hiddenReply]');
        let $reminderInfo = $('[js-hiddenReplyIdAndText]');

        let comment = $myComment.val();
        let replyId = $reminderInfo.attr('id');
        let currentArticleId = $('[js-articleId]').attr('id');

        ///if only content ...... input anything will be in go in
        if (content === '') {
            $hiddenReply.css('display', '').css('background-color','yellow');
            $reminderInfo.text('Can not input space or nothing');
            return false;
        }

        $.ajax({
            url: '/Comment/_CommentAjax',
            method: 'POST',
            data: { 'Comment': comment, 'ReplyId': replyId, 'BelongArticleId': currentArticleId},
            beforeSend: function () {
                $this.css('display', 'none');
            },
            success: function (data) {
                let $data = $(data);
                //here have some problem ,if other page touch same method,this [$allComment] is preciselly?
                if ($data.ReplyId !== null) {
                    let layer = $allComment.children().first().find('[js-num]').text();
                    
                    $data.find('[js-num]').text(+layer + 1);
                    $data.find('[js-layer]').text($reminderInfo.text());
                }//else nothing

                $('[js-allComments]').prepend($data);
                $myComment.val('');
            },
            complete: function () {
                $this.css('display', '');
                $reminderInfo.text('').removeAttr('id');
            },
            error: errorFedback
        });
    });

    
    //Show reply layer and add void replyId .
    $('[js-reply]').click(function () {
        let currentModel = $(this).parent().parent();
        let replyId = currentModel.attr('id');
        let numText = currentModel.find('[js-num]').text();

        $('[js-hiddenReplyIdAndText]')
            .attr('id', replyId)
            .text(`--- 回复：第 ${numText} 楼 ---`)
            .css('color', 'blue')
            .css('background-color', 'yellow');

        $('[js-hiddenReply]').css('display', '');
    });


    //one thing not solution , is remove comment,but this comment used by other comment...
    //Remove choose comment
    $('[js-commentDelete]').click(function (e) {
        e.preventDefault();
        let $this = $(this);
        var commentAuthorId = $this.attr('id');
        var deleteCommentId = $this.parent().parent().attr('id');

        $.ajax({
            url: '/Comment/_CommentDelete?deleteCommentId=' + deleteCommentId + '&commentAuthorId=' + commentAuthorId,
            method: 'GET',
            beforeSend: function () {
                $this.css('display', 'none');
            },
            success: function () {
                $this.parent().parent().remove();
            },
            complete: function () {
                $this.css('display', '');
            },
            error: errorFedback
        });
    });


    //show delete and reply
    $('[js-addComments]').mouseover(function () {
        let $this = $(this);
        $this.css('background-color', '');
        $this.find('[js-reply]').css('display', '');

        //delete show.
        let deleteId = $this.find('[js-commentDelete]').attr('id');
        let currentId = $('[js-currentUserId]').attr('id');
        if (deleteId === currentId) {
            $this.find('[js-commentDelete]').css('display', '');
        }//else nothing
    });
    $('[js-addComments]').mouseout(function () {
        let $this = $(this);
        $this.css('background-color', 'aliceblue');
        $this.find('[js-reply]').css('display', 'none');
        $this.find('[js-commentDelete]').css('display', 'none');
    });
});


function errorFedback(a, b, c) {
    console.log('Has some problem now!!!');
}

