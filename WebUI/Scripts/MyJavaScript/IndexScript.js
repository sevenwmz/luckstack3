$().ready(function () {
    $('[js-send]').click(function (e) {
        e.preventDefault();
        var content = $('[js-content]').val();

        $.ajax({
            url: '/Home/_MyChat',
            method: 'POST',
            data: 'content=' + content,
            success: function (data) {
                $('[js-chatRoom]').append(data);
            },
            error: function (a,b,c) {
                console.log('Has some problem now!!!');
            }
        })
    })
});

$('[js-reply]').click(function () {
    var replyId = this.parentElement.id;
    var replyText = $(this).parent().find("[js-showContent]").text();

    $('[js-hiddenReply]').removeAttr('hidden');

    $addReply = $('[js-hiddenReply]').find('span');
    $addReply.attr('id', replyId);
    $addReply.text(replyText);
})