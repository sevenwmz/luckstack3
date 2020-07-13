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
//根据其他同学的JSON获得其个人资料，生成一个表格显示。
//利用新学到的Array函数，重新完成之前的数组相关作业
//使用正则表达式判断某个字符串:
//是否是合格的Email格式
//是否是小数（正负小数都可以）
//将所有以zyf - 开头的属性去掉zyf - （尽可能多的制造测试用例，比如：<a lzyf-old=''， 或者：<span>zyf---+---fyz</span> ……）
