'use strict';
$(document).ready(function () {
    $('[js-fristKeyword]').children().click(function () {
        let $this = $(this),
            $stuffKeyword = $('[js-checkedKeyword]');

        let addCheckedKeyword = $(
            `<span js-showCheckedKeyword class="badge badge-has-used" style="margin-right:5px;">${$this.text()}
                <small js-remove style = "margin-left:5px;" class="fa fa-times"></small >
            </span >`);
        $stuffKeyword.prepend(addCheckedKeyword);
        $stuffKeyword.css('display', '');

        $('[js-checkedKeywordId]').attr('id', $this.attr('id'));
    });

    $('[js-remove]').click(function () {
        let $showKeywords = $('[js-checkedKeyword]');

        $(this).remove();
        if ($showKeywords.children().length === 0) {
            $showKeywords.css('display', 'none');
        }
    });



});


function errorFedback(a, b, c) {
    console.log('Has some problem now!!!');
}

