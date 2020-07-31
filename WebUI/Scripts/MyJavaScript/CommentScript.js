'use strict';
$(document).ready(function () {
    $('[js-Comments]').click(function (e) {
        e.preventDefault();
        let comment = $('[js-myComment]').val();
        let $this = $(this);
        let $addSuggest = $('[js-hiddenReply]').find('span');
        let replyId = $addSuggest.parent().attr('id');
        if (content) {
            $addSuggest.parent().removeAttr('hidden');
            $addSuggest.text('Can not input space or nothing');
            return false;
        }//else nothing

        $.ajax({
            url: '/Comment/_CommentAjax',
            method: 'POST',
            data: { 'Comment': comment, 'Reply.Id': replyId },
            beforeSend: function () {
                $this.attr('disabled', 'disabled');
            },
            success: function (data) {
                $('[js-allComments]').prepend(data);

                $addSuggest.text('');
                $('[js-myComment]').val('');
            },
            complete: function () {
                $this.removeAttr('disabled');
            },
            error: function (a, b, c) {
                console.log('Has some problem now!!!');
            }
        });
    });

    //$('[js-addComments]').click(function () {
    //    let replyId = this.id;
    //    let replyText = $(this).children.find('[js-layer]').text();

    //    let $hiddenReply = $('[js-hiddenReply]');
    //    $hiddenReply.removeAttr('hidden');

    //    let $addReply = $hiddenReply.find('span');
    //    $addReply.attr('id', replyId);
    //    $addReply.text('---回复：' + replyText);
    //});





    $('[js-reply]').click(function () {
        let currentModel = $(this).parent().parent();
        let replyId = currentModel.attr('id');
        let numText = currentModel.find('[js-num]').text();

        $('[js-hiddenReplyIdAndText]')
            .attr('id', replyId)
            .text('--- 回复：' + numText.substr(3, 20))
            .css('color', 'blue')
            .css('background-color', 'yellow');

        $('[js-hiddenReply]').css('display', '');
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
