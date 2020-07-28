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

/*on('click', function (e)*/