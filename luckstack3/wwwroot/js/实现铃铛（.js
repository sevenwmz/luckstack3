////作业：
////实现铃铛（没有学bootstrap的同学用文字代替）闪烁效果
//if (document.querySelector("[js-danceBell]").style.backgroundColor != 'pink') {
//    setInterval(function () {
//        var danceBell = document.querySelector("[js-danceBell]").style;
//        danceBell.backgroundColor = danceBell.backgroundColor == "pink" ? "deepskyblue" : "pink";
//    }, 1000);
//}


////模拟求助首页，并：
////统计有多少个悬赏大于1的求助
//function countReward() {
//    var count = 0,
//        temp = document.querySelectorAll("[js-rewardCount]");
//    for (var i = 0; i < temp.length; i++) {
//        if (temp[i].innerText >= 1) {
//            count++;
//        }
//    }
//    return count;
//}

////将状态为“协助中”的求助背景改成灰黑色
//function changeHelpBackground() {
//    var temp = document.getElementsByTagName('span');
//    for (var i = 0; i < temp.length; i++) {
//        if (temp[i].innerText == "协助中") {
//            temp[i].style.backgroundColor = "black";
//        }
//    }
//}
//changeHelpBackground();


////写一个函数，可以统计某个求助使用了多少关键字
//function countKeywordQuantity(getProblemId) {
//    var temp = document.querySelectorAll("[js-keyword]")[getProblemId],
//        countUseKeyword = 0;
     
//    for (var i = 0; i < temp.children.length; i++) {
//        if (temp.children[i].innerText != "") {
//                countUseKeyword++;
//            }
//    }
//    return --countUseKeyword;
//}
//countKeywordQuantity(0);


////如果总结数为0，将其从DOM树中删除
//function deleteSummaryZero() {
//    var temp = document.querySelectorAll("[js-summaryCount]");
//    for (var i = 0; i < temp.length; i++) {
//        if (temp[i].innerText == 0) {
//            //If this problem summary equel "0" ,remove this problem.....(what crazy thing)!!!
//            temp[i].parentElement.parentElement.parentElement.parentElement.remove()
//        }
//    }
//}

////参考用户注册页面，创建一下函数：
////显示密码的长度
//function showPwdLength() {
//    var temp = document.querySelector("[js-Password]").value,
//        pwdCount = 0;
//    for (var i = 0; i < (temp + '').length; i++) {
//        pwdCount++;
//    }
//    return pwdCount;
//}

//////如果密码和确认密码不一致，弹出提示
//function comfirmAlert() {
//    if (document.querySelector("[js-Password]").value != document.querySelector("[js-ConfirmPassword]").value) {
//        alert("Password Different");
//    }
//}

////参考用户资料页面，控制台显示出用户的：性别 / 出生年月 / 关注（关键字）/ 自我介绍 





