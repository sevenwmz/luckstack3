﻿'use strict';
$(document).ready(function () {
    $('[js-fristKeyword]').children().click(function () {
        let $this = $(this),
            $stuffKeyword = $('[js-checkedKeyword]');

        let addCheckedKeyword = $(
            `<span js-showCheckedKeyword class="badge badge-has-used" style="margin-right:5px;">${$this.text()}
                <small js-remove style = "margin-left:5px;" class="fa fa-times"></small >
            </span >`);
        $stuffKeyword.prepend(addCheckedKeyword);
        $stuffKeyword.find('[js-remove]').first().click(checkedKeywordRemove);
        $stuffKeyword.css('display', '');

        $('[js-checkedKeywordId]').attr('id', $this.attr('id'));
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

function errorFedback(a, b, c) {
    console.log('Has some problem now!!!');
}

