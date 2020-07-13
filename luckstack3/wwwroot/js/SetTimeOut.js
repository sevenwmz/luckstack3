//作业：
//使用setTimeout() （不是setInterval() ）实现每隔1秒钟显示一次：第n周，源栈同学random人。（n逐次递增，random随机）

// Just see out,I think can't test TDD;

//function weekAndRandom(week) {
//    var randomPerson = Math.floor(Math.random() * 10);
//    week++;
//    console.log(`第${week}周，源栈同学${randomPerson}人。`);
//    setTimeout(weekAndRandom, 1000, week);
//}
//setTimeout(weekAndRandom,1000,0);

////完成猜数字的游戏：
////弹出游戏玩法说明，等待用户点击“确认”，开始游戏；
////浏览器生成一个不大于1000的随机正整数；（Math.floor(Math.random() * 1000) ）
////用户输入猜测；
////如果用户没有猜对，浏览器比较后告知结果：“大了”或者“小了”。如果用户：
////只用了不到6次就猜到，弹出：碉堡了！
////只用了不到8次就猜到，弹出：666！
////用了8 - 10次猜到，弹出：猜到了。
////用了10次都还没猜对，弹出：^ (*￣(oo) ￣)^
//function guessRondomGame() {
//    var rondomNum = Math.floor(Math.random() * 1000);
//    //console.log(rondomNum);

//    var introduce = "弹出游戏玩法说明: 浏览器生成一个不大于1000的随机正整数；用户输入猜测,比较正确答案后告知结果：“大了”或者“小了”，直到猜中或游戏结束。"
//    alert(introduce);
//    if (!confirm("开始游戏")) {
//        return;
//    }
//    for (var i = 0; i < 11; i++) {
//        var userInputNum = prompt("输入猜测0-1000内的整数，否则哐当","例：600");

//        if (!inputIsValid(userInputNum)) {
//            alert("Only input number!!!");
//            return;
//        }

//        if (i <= 10) {
//            if (guessSuggest(userInputNum, rondomNum, i)) {
//                break;
//            }
//            continue;
//        } else {
//            console.log("^ (*￣(oo) ￣)^");
//        }
//    }
//}

//function inputIsValid(input) {
//    if (isNaN(input)) {
//        return false;
//    }

//    for (var i = 0; i < input.length; i++) {
//        if (input[i] == " ") {
//            return false;
//        }
//    }
//    return true;
//    ///Other i don't know.   and not learn throw exception;
//}

//function guessSuggest(inputGuessNum, rondomNum, guessCount) {
//    if (inputGuessNum < rondomNum) {
//        console.log("small");
//    } else if (inputGuessNum > rondomNum) {
//        console.log("Big");
//    } else {
//        return guessResult(guessCount);
//    }
//    return false;
//}

//function guessResult(guessCount) {
//    if (guessCount <= 6) {
//        console.log("碉堡了！");
//    } else if (guessCount <= 8) {
//        console.log("666！");
//    } else {
//        console.log("猜到了。");
//    }
//    return true;
//}








