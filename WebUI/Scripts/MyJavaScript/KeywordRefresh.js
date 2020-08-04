'use strict';
$(document).ready(function () {
    $('[js-fristKeyword]').children().click(function () {
        let $this = $(this);
        checkedKeyword($this);
        $('[js-checkedKeywordId]').attr('id', $this.attr('id'));
        $('[js-keywordReminder]').css('display', 'none');
        $('[js-secendKeywordButton]').css('display','');
    });

    $('[js-secendKeywordButton]').click(function () {
        let $this = $(this),
            $secendKeyword = $('[js-secendKeyword]'),
            takeSecendKeywordById = $('[js-checkedkeywordid]').attr('id');

        $.ajax({
            url: '/Keyword/_SecendKeywordItem?fristKeywordId=' + takeSecendKeywordById,
            method: 'GET',
            beforeSend: function () {
                $secendKeyword.children().remove();
            },
            success: function (data) {
                $secendKeyword.append(data);
                $secendKeyword.children().click(function () {
                    checkedKeyword($(this));
                });
            },
            error: errorFedback
        });
    });
});

function checkedKeywordRemove() {
    let $showKeywords = $('[js-checkedKeyword]');
    $(this).parent().remove();
    //because here 17bang website not do anythin more,when i got time i will make new function here

    if ($showKeywords.children().length === 0) {
        $showKeywords.css('display', 'none');
        $('[js-checkedkeywordid]').removeAttr('id');
    }//else nothing
}

function checkedKeyword($this) {
    let $stuffKeyword = $('[js-checkedKeyword]');

    let addCheckedKeyword = $(
        `<span js-showCheckedKeyword class="text-white badge bg-dark badge-has-used" title="${$this.attr(`title`)}" style="margin-right:5px;">${$this.text()}
                <small js-remove style = "margin-left:5px;" class="fa fa-times"></small >
            </span >`);
    $stuffKeyword.prepend(addCheckedKeyword);
    $stuffKeyword.find('[js-remove]').first().click(checkedKeywordRemove);
    $stuffKeyword.css('display', '');
}

function errorFedback(a, b, c) {
    console.log('Has some problem now!!!');
}

