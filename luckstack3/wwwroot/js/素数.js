﻿////作业（一）
////构建一个函数has9(number) ，可以判断number中是否带有数字9；（19 / 98）     
//function hasSpecifiedNum(number, findNum) {

//    if (findNum == undefined) {
//        return false;///  excption
//    }

//    var temp = `${number}`;
//    for (var i = 0; i < temp.length; i++) {
//        if (temp[i] == findNum) {
//            return true;
//        }
//    }
//    return false;
//}

//function has9(number) {
//    return hasSpecifiedNum(number, 9);
//}

////构建一个函数has8(number) ，可以判断number中是否带有数字8；

//function has8(number) {
//    return hasSpecifiedNum(number, 8);
//}

////构建一个函数has6(number) ，可以判断number中是否带有数字6；

//function has6(number) {
//    return hasSpecifiedNum(number, 6);
//}




////使用上述函数，找出10000以内有多少个数字包含：9或者8或者6。
//var count9 = 0,
//    count8 = 0,
//    count6 = 0;

//for (var i = 0; i < 10001; i++) {
//    has9(i) ? count9++ : 0 ;
//    has8(i) ? count8++ : 0 ;
//    has6(i) ? count6++ : 0 ;
//}
//console.log(`In 10000 have ${count9} - 9,and have ${count8} - 8, and ${count6} - 6`);


//让get986()通过调用has9() / has8() / has6() ，能找出number以内有多少个数字包含：9或者8或6。

//function get986(number) {
//    var count9 = 0,
//        count8 = 0,
//        count6 = 0;
//    var temp = `${number}`;

//    for (var i = 0; i < temp; i++) {
//        has9(i) ? count9++ : 0;
//        has8(i) ? count8++ : 0;
//        has6(i) ? count6++ : 0;
//    }
//    console.log(`In ${temp} have ${count9} - 9,and have ${count8} - 8, and ${count6} - 6`);
//    var arr = [count9, count8, count6];
//    return arr;
//}



























///http://17bang.ren/Article/482 将之前“找出素数”的代码封装成一个函数findPrime(max)，可以打印出max以内的所有素数。

//     作业：

//将之前“找出素数”的代码封装成一个函数findPrime(max)，可以打印出max以内的所有素数。

//function findPrime(max) {
//    /// not defense;
//    ///Not inclund max remove (max)+1
//    for (var i = 2; i < max + 1; i++) {
//        var falg = true;
//        for (var j = 2; j < i; j++) {
//            if (i % j == 0) {
//                falg = false;
//            }
//        }
//        //falg为真输出质数
//        if (falg) {
//            console.log(i);
//        }
//    }
//}
//findPrime(20);

//自行设计参数，将之前“累加求和”的代码封装成一个函数Sum()，可以计算任意起始位置、任意步长（如：1,3,5……或者0,5,10,15……）的等差数列之和。

//function Sum(arr,start,step) {
//    //without defense;
//    var result = 0;

//    if (start === undefined) {
//        start = 0;
//    }
//    if (step === undefined) {
//        step = 1;
//    }
//    for (var i = start; i < arr.length; i += step) {
//        result += arr[i];
//    }
//    return result;
//}

//var testArray = [3, 3, 5, 6,8,6,8];
//Sum(testArray,2);



//封装一个函数，建立一个函数getMaxNumber()，可以接受任意多各种类型（整数、小数、正数、负数、字符串、布尔值等）的参数，并找出里面最大的数（忽略其他类型）
//function getMaxNumber(arr) {
//    var result = arr[0];

//    for (var i = 0; i < arr.length; i++) {
//        if (result < arr[i]) {
//            result = arr[i];
//        }
//    }
//    return result;
//}
//var testArray = ['32', 31, 74.7, 25.6, true, -1];
//var show = getMaxNumber(testArray);

////封装一个函数Swap(arr, i, j)，可以交换数组arr里下标 i 和 j 的值
//'use strict';
//function Swap(arr, i, j) {
//    var temp = i;
//    arr[i] = j;
//    arr[j] = temp;
//}


////利用上面的Swap()函数，将“冒泡排序”封装成函数bubbleSort()
//var needBubbleArray = [3, 1, 5, 2, 6, 4, 7];

//function bubbleSort(bubbleSort) {

//    for (var i = 0; i < bubbleSort.length; i++) {
//        for (var j = 0; j < bubbleSort.length; j++) {
//            if (bubbleSort[i] > bubbleSort[j]) {
//                Swap(bubbleSort, bubbleSort[i], bubbleSort[j]);
//            }
//        }
//    }
//    return bubbleSort;
//}
//var afterBubbleArray = bubbleSort(needBubbleArray);





//将源栈同学姓名/昵称装入数组，再根据该数组输出共有多少同学

//var studentName = ["a tai", "wpz", "wpz", "ljp"];
//var studentsCount = 0;
//for (var i = 0; i < studentName.length; i++) {
//    console.log(studentName[i]);
//    studentsCount++;
//}
//console.log(studentsCount);
////console.log(studentName.count());


////在上述数组头部加上小鱼老师，末尾加上大飞哥

//studentName[0] = "xiao yu";
//studentName[studentName.length] = "dfg";

////删除一个数组里面重复的元素
//for (var i = 0; i < studentName.length; i++) {
//    for (var i = 1; i < studentName.length; i++) {
//        if (studentName[i] === studentName[j]) {
//            studentName.splice(j, 1);
//            j--;
//        }
//    }
//}


////使用JavaScript内置字符串函数，处理 “‘源栈’：飞哥小班教学，线下免费收看” ：“飞哥”改成“大神”，“线下”改成“线上”。

//var needReplace = "‘源栈’：飞哥小班教学，线下免费收看";
//needReplace.replace("飞哥","大神");
//needReplace.replace("线下", "线上");



////将数组['why','gIT','vs2019','community','VERSION']规范化，所有字符串：
////    首字母大写开头，其他字母小写
////    截去超过6个字符的部分，如'community'将变成'Commun'

//var needFix = ['why', 'gIT', 'vs2019', 'community', 'VERSION'];
//for (var i of needFix) {
//    i.toUpperCase();
//    i.substring(0, 6);
//}
////创建一个函数getRandomArray(length, max)，能返回一个长度不大于length，每个元素值不大于max的随机整数数组。
//function getRandomArray(length, max) {
//    var result = "";
//    for (var i = 0; i < length; i++) {
//        var temp = Math.floor(Math.random(max) * length);
//        if (max >= temp) {
//            result += temp;
//        } else {
//            i--;
//        }
//    }
//    return result;
//}
//getRandomArray(7,5);

////不使用JavaScript内置函数，将一个字符串顺序颠倒，比如：'hello,yuanzhan' 变成 'nahznauy,olleh'。
//var needSort = 'hello,yuanzhan';
//function sortString(needSort) {
//    var afterSort = "";

//    for (var i = (needSort.length-1); i >= 0; i--) {
//        afterSort += needSort[i];
//    }

//    return afterSort;
//}
//sortString(needSort);



//统计出这段文字中有多少个单词：

//There are two ways to create a RegExp object :
//a literal notation and a constructor.To indicate strings, the parameters to the literal notation
//do not use quotation marks while the parameters to the constructor function do use quotation - marks.So
//the following expressions create the same regular expression

//var needCount = "There are two ways to create a RegExp object : a literal notation and a constructor.To indicate strings, the parameters to the literal notation" +
//    "do not use quotation marks while the parameters to the constructor function do use quotation - marks.So" +
//    "the following expressions create the same regular expression";

//// Separater by speace
//needCount.split(" ");
