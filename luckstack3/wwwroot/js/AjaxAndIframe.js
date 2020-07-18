//作业
//根据Ajax动态加载导航栏下的“新消息”

//document.querySelector("[js-changeNewMessage]").onmouseout = function () {
//    var newMessage = new XMLHttpRequest();
//    newMessage.open("POST", "/NavNewMessage");
//    newMessage.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
//    newMessage.send("getNewestMessage=" + true);

//    var that = this;

//    newMessage.onreadystatechange = function () {
//        if (this.readyState === 4 && this.status === 200) {
//            that.innerHTML = this.responseText;
//        }
//    }
//}


//分别通过iframe和Ajax完成侧边栏关键字“换一批”的功能
//document.querySelector("[js-keywordProblemAjax]").onclick = function () {
//    var changeKeyword = new XMLHttpRequest();
//    changeKeyword.open("POST", "/AjaxAndIframe/ChangeOtherKeyword");
//    changeKeyword.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
//    changeKeyword.send("max=5");

//    var that = this;

//    changeKeyword.onreadystatechange = function () {
//        if (this.readyState === 4 && this.status === 200) {
//            that.innerHTML = this.responseText;
//        }
//    }

//}
//document.querySelector("[js-KeywordAjax]").onclick = function () {
//    var changeKeyword = new XMLHttpRequest();
//    changeKeyword.open("POST", "/AjaxAndIframe/ChangeOtherKeyword");
//    changeKeyword.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
//    var randomK = Math.floor(Math.random() * 10);
//    changeKeyword.send("max=" + randomK);

//    var that = this;

//    changeKeyword.onreadystatechange = function () {
//        if (this.readyState === 4 && this.status === 200) {
//            that.innerHTML = this.responseText;
//        }
//    }

//}



//document.querySelector("[js-keywordProblemAjax]").onclick = function () {
//    document.querySelector("iframe").src = "/NavNewMessage";
//};

//能通过Json获得（有无未读消息的）数据，决定是否闪烁铃铛图标（注意：要能闪还能不闪）
function messageBell() {

    if (document.cookie.includes("HasUnreadMessage")) {
        var bellColor = document.querySelector("[js-danceBell]").style;
        if (bellColor.color === "cadetblue") {
            bellColor.color = "blueviolet";
            setTimeout(messageBell, 200);
        }
        else {
            bellColor.color = "cadetblue";
            setTimeout(messageBell, 200);
        }
    }
}

//发布求助时，能够
//根据一级关键字，通过Ajax获取到改一级关键字下的二级关键字，并予以显示





//定向求助时移出焦点，就能找到相关用户
document.querySelector("[js-problemhelpfrom]").onblur = function() {
    var helpFrom = this.value;

    var userArray = ["wpzwpz", "ljpljp", "adaidai", "lzblzb"];

    for (var i = 0; i < userArray.length; i++) {
        if (helpFrom === userArray[i]) {
            var reminder = document.createElement("span");
            reminder.setAttribute("js-findHelper","");
            reminder.innerText = "找到啦，看看是不是他→" + userArray[i]

            var reminderLink = document.createElement("a");
            reminderLink.setAttribute("js-findHelper", "");
            reminderLink.setAttribute("herf", "/");
            reminderLink.innerText = "主页";

            this.parentElement.parentElement.appendChild(reminder);
            this.parentElement.parentElement.appendChild(reminderLink);
            break;
        }
        else {
            document.querySelectorAll("[js-findHelper]").remove();
        }
    }
    

}

//刷新帮帮币
document.querySelector("[js-checkLeft]").onclick = function() {
    // pretent get from service...
    var leftMoney = 23;
    if (document.querySelector("[js-leftMoney]") == null) {
        return GetLeftMoney(this, 23);
    }

    var currentLeft = document.querySelector("[js-leftMoney]");
    if (leftMoney != currentLeft.innerText) {
        currentLeft.remove();
        return GetLeftMoney(this,leftMoney);
    }
}


function GetLeftMoney(that,leftMoney) {
    var temp = document.createElement("span");
    temp.setAttribute("js-leftMoney", "");
    temp.innerText = leftMoney;

    that.parentElement.appendChild(temp);
}




