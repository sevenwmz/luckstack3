//作业：
//生成一个函数toChinese() ，可将传入的日期参数（如：new Date() ）转换成中文日期格式（如：2019年10月4日 16点54分）
function toChinese(date) {
    if (!date) {
        return false;
    }

    var year = date.getFullYear().toString();
    var mouth = date.getMonth().toString();
    var day = date.getDate().toString();
    var hour = date.getHours().toString();
    var minutes = date.getMinutes().toString();
    var seconds = date.getSeconds().toString();

    var result = year + "年" + mouth + "月" + day + "日" + hour + "点" + minutes + "分" + seconds;
    return result;
}

//生成一个函数addDays(number) ，可在当前日期的基础上增加number天

function addDays(number) {
    if (isNaN(number)) {
        return false;
    }

    var result = new Date();
    result.setDate(result.getDate() + number);
    var month = result.getMonth();
    var day = result.getDay();

    return result.getFullYear() + '-' + (result.getMonth() + 1) + '-' + result.getDate();
}

//JSON生成和解析：
//按自己的情况，生成一个JSON字符串，包括真实姓名、QQ昵称、年龄、性别、兴趣爱好、自我介绍……，上传到QQ群：一起帮·有意向（729600626）
wpz = {
    name: 'wpz',
    age: 99,
    isMale: true,
    nickNameOfQQ: 'SEVEN',
    introduce:'none'
}
JSON.stringify(wpz);

//根据其他同学的JSON获得其个人资料，生成一个表格显示。
atai = {
    name: 'atai',
    age: 250,
    isMale: true,
    nickNameOfQQ: 'atai',
    introduce: 'none'
}
var ataitai = JSON.stringify(atai);

function tableMaker(userInfo) {
    var ataiParse = JSON.parse(userInfo);

    var table = document.createElement("table");
    table.setAttribute("border", "1");

    var tr = getTr();
    tr.appendChild(getTh(""));
    tr.appendChild(getTh('userInfo'));
    table.appendChild(tr);

    var tr_1 = getTr();
    tr_1.appendChild(getTd('name: '));
    tr_1.appendChild(getTd(ataiParse.name));
    table.appendChild(tr_1);

    var tr_2 = getTr();
    tr_2.appendChild(getTd('age: '));
    tr_2.appendChild(getTd(ataiParse.age));
    table.appendChild(tr_2);

    var tr_3 = getTr();
    tr_3.appendChild(getTd('isMale: '));
    tr_3.appendChild(getTd(ataiParse.isMale));
    table.appendChild(tr_3);

    var tr_4 = getTr();
    tr_4.appendChild(getTd('nickNameOfQQ: '));
    tr_4.appendChild(getTd(ataiParse.nickNameOfQQ));
    table.appendChild(tr_4);

    var tr_5 = getTr();
    tr_5.appendChild(getTd('introduce: '));
    tr_5.appendChild(getTd(ataiParse.introduce));
    table.appendChild(tr_5);

    document.querySelector("[js-table]").appendChild(table);
}


function getTr() {
    return document.createElement("tr");
}

function getTh(innerText) {
    var th = document.createElement("th");
    th.innerText = innerText;
    return th;
}

function getTd(innerText) {
    var td = document.createElement("td");
    td.innerText = innerText;
    return td;
}


//利用新学到的Array函数，重新完成之前的数组相关作业
//使用正则表达式判断某个字符串:
//是否是合格的Email格式
function isEmail(email) {
    var regMatch = new RegExp("(\w*@\w*)\.[a-z]*", "gim");
    return regMatch.exec(email) != null;
}
//是否是小数（正负小数都可以）
function isEmail(number) {
    var regMatch = new RegExp("((-[0-9]*|[0-9]*)\.[0-9]+");
    return regMatch.exec(number) != null;
}
//将所有以zyf - 开头的属性去掉zyf - （尽可能多的制造测试用例，比如：<a lzyf-old=''， 或者：<span>zyf---+---fyz</span> ……）













