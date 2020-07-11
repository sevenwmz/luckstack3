//参考求助首页侧边栏关键字，实现：当鼠标移动到关键字上，显示关键字被使用次数
//document.querySelector("[js-usedKeyword]").onmousemove = function () {

//};
function usedKeyword(keywordId,usedCount) {
    //var showKeywordUsed = document.createElement("span");
    //showKeywordUsed.innerText = `已使用${usedCount}次`;
    //showKeywordUsed.className = "js-onMouseOutRemove";

    var section = document.getElementById(keywordId);
    //section.appendChild(showKeywordUsed);
    section.title = `已使用${usedCount}次`;
}

//function removeKeywordUsed() {
//    var section = document.getElementsByClassName("js-onMouseOutRemove");
//    section.innerText = null;
//}




//参考一起帮首页，实现右侧漂浮并底对齐左侧文本框的效果

//参考消息页面：完成勾选全选功能
function messageCheckAll() {
    var message = document.querySelectorAll('[js-messagehascheck]');
    if (document.querySelector("[js-messageCheckAll ]").checked) {
        for (var i = 0; i < message.length; i++) {
            message[i].checked = true;
        }
    } else {
        for (var i = 0; i < message.length; i++) {
            message[i].checked = false;
        }
    }
}

//参考注册页面：
//提交时，如果用户名重复（已有用户名用数组保存），阻止form提交，提示“用户名重复”。
function userNameHasRepeat() {
    var registered = ["wpzwpz", "yefei", "atai", "duande"];

    for (var i of registered) {
        if (document.querySelector("[js-registerUserName]").value == i) {
            var addRemind = document.createElement("span");
            addRemind.setAttribute("js-remindInputWrong","");
            addRemind.style.color = "red";
            var text = document.createTextNode("* Input name already exist ,please try again!");
            addRemind.appendChild(text);

            document.querySelector("[js-addrigstererror]").appendChild(addRemind);
            return false;
        }
    }
}
document.querySelector("[js-registerUserName]").onblur = userNameHasRepeat;


//重新输入用户名，一旦输入用户名部分没有重复，“用户名重复”的提示消失
function removeUserNameRemind() {
    var registered = ["wpzwpz", "yefei", "atai", "duande"];

    for (var i of registered) {
        if (document.querySelector("[js-registerUserName]").value != i) {
            var errorTag = document.querySelector("[js-remindinputwrong]");
            if (errorTag != null) {
                errorTag.remove();
            }
        }
    }
}
document.querySelector("[js-registerUserName]").onkeydown = removeUserNameRemind;

//当用户名或密码等有值时，关闭页面前弹出确认框
window.onbeforeunload = function () {
    if (this.document.querySelector("[js-registerUserName]").value != "") {
        return "";
    }
    if (this.document.querySelector("[js-registerPwd]").value != "") {
        return "";
    }
}

//参考求助首页侧边栏“免费广告发布”弹出Modal，实现（不需要弹出Modal）：

//根据下拉列表选中项，填充“文字内容”和“链接”文本框
//勾选修改的checkbox，实现“文字内容”和“链接”文本框的禁用和启用

//参考发布求助，实现其关键字功能：

//没有选择一级关键字，不能选择二级关键字
//选择一级关键字后，二级关键字只能是一级关键字下的子集
//一级关键字和二级关键字被选中后，会显示在下拉列表上方
//自定义关键字输入完成后（按空格键），输入的关键字显示在下拉列表上方
//后输入的关键字显示在前面

//—— 对尚未学习过CSS的同学，以上作业均不要求样式 