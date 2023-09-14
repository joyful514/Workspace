

//在JAVASCRIPT中替换左右尖括号<>   show_Dmarks(show_bracket(
function show_lbracket(s){
	return s.replace(/(<)/g, "&#60;"); 
}
function show_rbracket(s){
	return s.replace(/(>)/g, "&#62;"); 
}
function show_bracket(s){
	show_rbracket(show_lbracket(s));
}

//在JAVASCRIPT中替换双引号"   show_Dmarks
function show_Dmarks(s){
	return s.replace(/(\")/g, "&quot;"); 
}


//****************************************************
//在JAVASCRIPT中实现TRIM（）函数的功能 :用正则表达式将前后空格用空字符串替代。  
function trim(s){ 
return s.replace(/^\s+|\s+$/, ''); 
} 

function ltrim(s){ 
return s.replace(/^\s+/, ''); 
} 

function rtrim(s){ 
return s.replace(/\s+$/, ''); 
} 


/*-------------检查是否是数字；------------------*/

/**
* 检测是否是数字（正整型）
* @param str 被检查的字符串
* @return true; false
*/
function isInteger(str) {
	var Letters = "0123456789";
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			return false;
		}
		if (i == 0 && checkChar == 0) {
			return false;
		}
	}
	return true;
}
function isInteger1(str) {
	var Letters = "0123456789";
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			return false;
		}
		if (i == 0 && checkChar == 0 && str.length>1) {
			return false;
		}
	}
	return true;
}
function isInteger2(str) {
	var Letters = "0123456789.";
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			return false;
		}
		if (i == 0 && checkChar == 0 && str.length>1) {
			return false;
		}
		if (i == 0 && checkChar == '.' && str.length>1) {
			return false;
		}
	}
	return true;
}
//----------------------------------------------------判断字符是否为空
function isEmpty(s)
{
return ((s == null)||(s.length == 0));
}

//---------------------------------------------------字符是否在S中
function isCharsInBag (s, bag)
{
    var i;
    // Search through string's characters one by one.
    // If character is in bag, append to returnString.

    for (i = 0; i < s.length; i++)
    {
        // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) return false;
    }
    return true;
}

//----------------------------------------------------空格判断
function isWhitespace(s)
{
    var whitespace = " \t\n\r";
    var i;
    for (i = 0; i < s.length; i++)
    {
        var c = s.charAt(i);
        if (whitespace.indexOf(c) >= 0)
        {
            return true;
        }
    }
    return false;
}

//----------------------------------------------------除S以外的字符
function isCharsInBagEx (s, bag)
{
    var i,c;
    // Search through string's characters one by one.
    // If character is in bag, append to returnString.
    for (i = 0; i < s.length; i++)
    {
        c = s.charAt(i);
        if (bag.indexOf(c) > -1)  return c;
    }
    return "";
}
//---------------------------------------------------检验用户名
function isUserName(s){
    var errorChar;
    var badChar = "><,[]{}?/+=|\\'\":;~!@#$%^&()`";
    if (isEmpty(s)){
        alert("请输入用户名！");
        return false;
    }
    if ( isWhitespace(s) ){
        alert("输入的用户名中不能包含空格符，请重新输入");
        return false;
    }
    errorChar = isCharsInBagEx( s, badChar)
    if (errorChar != "" ){
        alert("您输入的用户名" + s+"是无效的用户名,\n\n请不要在用户名中输入字符" + errorChar + "!\n\n请重新输入合法的用户名！" );
        return false;
    }
    if (s.length<1 || s.length>20){
        alert("用户名必须在1至20个字符之间");
        return false;
    }

    return true;
}



//---------------------------------------------------检验字符串中是否含有禁止的字符！如： '<>/?&#=
//如果为空或超出长度或含有禁止的字符，则返回 true ； 合法则返回 false
function isBadCharInName(s){
    var errorChar;
    var badChar = "><,[]{}?/+=|\\'\":;~!@#$%^&()`";
    if (isEmpty(s)){
        alert("内容为空，请重新输入！");
        return true;
    }
    errorChar = isCharsInBagEx(s, badChar)
    if (errorChar != "" ){
        alert("您输入的内容" + s+"是无效的,\n\n请不要在其中输入字符" + errorChar + "!\n\n请重新输入合法的内容！" );
        return true;
    }
    if (s.length<1 || s.length>50){
        alert("必须在1至50个字符之间");
        return true;
    }

    return false;
}



//判断时间
function isTime(str){
//alert(str);
if(str=="")return true;//输入可空
var reg = /^(\d{1,2}):(\d{1,2}):(\d{1,2})$/;
var r = str.match(reg);
if(r==null)return false;
var d= new Date(1900,1,1,r[1],r[2], r[3]);
if(d.getHours()!=r[1])return false;
if(d.getMinutes()!=r[2])return false;
if(d.getSeconds()!=r[3])return false;
return true;
}


/**
* 是否是日期的检查(日期格式为"yyyy-mm-dd")
* 格式：年必须输入四位数且必须在1900年以后；月日时分秒要么输入两个数字，要么输入一个数字；
* @param dateStr 被检查的字符串
* @return true(是日期格式"yyyy-mm-dd"); false(不是日期格式"yyyy-mm-dd")
*/
function isDate(dateStr) {
	var re = /^\d{4}-\d{1,2}-\d{1,2}$/;
	var r = dateStr.match(re);
	if (r == null) {
		return false;
	}
	else {
		var s = dateStr.split("-");
		if (s[0].substring(0,2) < 19 || s[1] > 12 || s[1] < 1 || s[2] > 31 || s[2] < 1) {
			return false;
		}
		if ((s[1] == 4 || s[1] == 6 || s[1] == 9 || s[1] == 11) && s[2] == 31) {//月小
			return false;
		}

		if (((s[0] % 4 == 0) && (s[0] % 100 != 0)) || (s[0] % 400 == 0)) { //是闰年
		    if (s[1] == 2 &&  s[2] > 29) {
				return false;
			}
		}
		else {//不是闰年
		    if (s[1] == 2 &&  s[2]>28) {
				return false;
			}
		}
	}
	return true;
}

/**
* 是否是日期的检查(日期格式为"yyyy-mm-dd hh:mm:ss")
* 格式：年必须输入四位数且必须在1900年以后；月日时分秒要么输入两个数字，要么输入一个数字；
* @param dateStr 被检查的字符串
* @return true(是日期格式"yyyy-mm-dd hh:mm:ss"); false(不是日期格式"yyyy-mm-dd hh:mm:ss")
*/
function isDateTime(dateStr) {
	dateStr = combChar(dateStr, " ");
	var re = /^(\d{4})\-(\d{1,2})\-(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
	var r = dateStr.match(re);
	if (r == null) {
		return false;
	}
	else {
		var str = dateStr.split(" ");
		var s = str[0].split("-");
		var strTime = str[1].split(":");
		if (s[0].substring(0,2) < 19 || s[1] > 12 || s[1] < 1 || s[2] > 31 || s[2] < 1) {
			return false;
		}
		if ((s[1] == 4 || s[1] == 6 || s[1] == 9 || s[1] == 11) && s[2] == 31) {//月小
			return false;
		}

		if (((s[0] % 4 == 0) && (s[0] % 100 != 0)) || (s[0] % 400 == 0)) { //是闰年
		    if (s[1] == 2 &&  s[2] > 29) {
				return false;
			}
		}
		else {//不是闰年
		    if (s[1] == 2 &&  s[2]>28) {
				return false;
			}
		}
		if (strTime[0] > 23 || strTime[1] > 59 || strTime[2] > 59 ) {
			return false;
		}
	}
	return true;
}

/**
* 判断日期dateStr1是否小于日期dateStr2的(日期格式为"yyyy-mm-dd")
* 格式：年必须输入四位数且必须在1900年以后；月日要么输入两个数字，要么输入一个数字；
* @param dateStr1 第一个字符串
* @param dateStr2 第二个的字符串
* @return null(dateStr1格式不对或dateStr2格式不对); true(dateStr1 < dateStr2); false(dateStr1 >= dateStr2)
*/
function isBeforeDate(dateStr1, dateStr2) {
	if (!isDate(dateStr1) || !isDate(dateStr1)) {
		return null;
	}
	var s1 = dateStr1.split("-");
	var s2 = dateStr2.split("-");
	if (s1[0] < s2[0]) {//年小于
		return true;
	}
	else if (s1[0] == s2[0]) {//年相等
		if (s1[1].charAt(0) == '0') {
			s1[1] = "" + s1[1].charAt(1);
		}
		if (s2[1].charAt(0) == '0') {
			s2[1] = "" + s2[1].charAt(1);
		}
		if (s1[1] < s2[1]) {//月小于
			return true;
		}
		else if (s1[1] == s2[1]) {//月相等
			if (s1[2].charAt(0) == '0') {
				s1[2] = "" + s1[2].charAt(1);
			}
			if (s2[2].charAt(0) == '0') {
				s2[2] = "" + s2[2].charAt(1);
			}
			if (s1[2] < s2[2]) {//日小于
				return true;
			}
		}
	}
	return false;
}

/**
* 判断日期dateStr1是否等于日期dateStr2的(日期格式为"yyyy-mm-dd")
* 格式：年必须输入四位数且必须在1900年以后；月日要么输入两个数字，要么输入一个数字；
* @param dateStr1 第一个字符串
* @param dateStr2 第二个的字符串
* @return null(dateStr1格式不对或dateStr2格式不对); true(dateStr1 = dateStr2); false(dateStr1 != dateStr2)
*/
function isEqualDate(dateStr1, dateStr2) {
	if (!isDate(dateStr1) || !isDate(dateStr1)) {
		return null;
	}
	var s1 = dateStr1.split("-");
	var s2 = dateStr2.split("-");
	if (s1[0] != s2[0]) {//年不相等
		return false;
	}
	else {//年相等
		if (s1[1].charAt(0) == '0') {
			s1[1] = "" + s1[1].charAt(1);
		}
		if (s2[1].charAt(0) == '0') {
			s2[1] = "" + s2[1].charAt(1);
		}
		if (s1[1] != s2[1]) {//月不相等
			return false;
		}
		else {//月相等
			if (s1[2].charAt(0) == '0') {
				s1[2] = "" + s1[2].charAt(1);
			}
			if (s2[2].charAt(0) == '0') {
				s2[2] = "" + s2[2].charAt(1);
			}
			if (s1[2] != s2[2]) {//日不相等
				return false;
			}
		}
	}
	return true;
}

/**
* 判断日期dateStr1是否小于日期dateStr2的(日期格式为"yyyy-mm-dd hh:mm:ss")
* 格式：年必须输入四位数且必须在1900年以后；月日时分秒要么输入两个数字，要么输入一个数字；
* @param dateStr1 第一个字符串
* @param dateStr2 第二个的字符串
* @return null(dateStr1格式不对或dateStr2格式不对); true(dateStr1 < dateStr2); false(dateStr1 >= dateStr2)
*/
function isBeforeDateTime(dateStr1, dateStr2) {
	if (!isDateTime(dateStr1) || !isDateTime(dateStr1)) {
		return null;
	}
	var s1 = dateStr1.split(" ");
	var s2 = dateStr2.split(" ");
	if (isBeforeDate(s1[0], s2[0])) {//年月日小于
		return true;
	}
	else if (isEqualDate(s1[0], s2[0])) {//年月日相等
		var strTime1 = s1[1].split(":");
		var strTime2 = s2[1].split(":");
		if (strTime1[0].charAt(0) == '0') {
			strTime1[0] = "" + strTime1[0].charAt(1);
		}
		if (strTime2[0].charAt(0) == '0') {
			strTime2[0] = "" + strTime2[0].charAt(1);
		}
		if (strTime1[0] < strTime2[0]) {//小时小于
			return true;
		}
		else if (strTime1[0] == strTime2[0]) {//小时相等
			if (strTime1[1].charAt(0) == '0') {
				strTime1[1] = "" + strTime1[1].charAt(1);
			}
			if (strTime2[1].charAt(0) == '0') {
				strTime2[1] = "" + strTime2[1].charAt(1);
			}
			if (strTime1[1] < strTime2[1]) {//分小于
				return true;
			}
			else if (strTime1[1] == strTime2[1]) {//分相等
				if (strTime1[2].charAt(0) == '0') {
					strTime1[2] = "" + strTime1[2].charAt(1);
				}
				if (strTime2[2].charAt(0) == '0') {
					strTime2[2] = "" + strTime2[2].charAt(1);
				}
				if (strTime1[2] < strTime2[2]) {//秒小于
					return true;
				}
			}
		}
	}
	return false;
}

/**
* 判断日期dateStr1是否等于日期dateStr2的(日期格式为"yyyy-mm-dd hh:mm:ss")
* 格式：年必须输入四位数且必须在1900年以后；月日时分秒要么输入两个数字，要么输入一个数字；
* @param dateStr1 第一个字符串
* @param dateStr2 第二个的字符串
* @return null(dateStr1格式不对或dateStr2格式不对); true(dateStr1 = dateStr2); false(dateStr1 != dateStr2)
*/
function isEqualDateTime(dateStr1, dateStr2) {
	if (!isDateTime(dateStr1) || !isDateTime(dateStr1)) {
		return null;
	}
	var s1 = dateStr1.split(" ");
	var s2 = dateStr2.split(" ");
	if (isEqualDate(s1[0], s2[0])) {//年月日相等
		var strTime1 = s1[1].split(":");
		var strTime2 = s2[1].split(":");
		if (strTime1[0].charAt(0) == '0') {
			strTime1[0] = "" + strTime1[0].charAt(1);
		}
		if (strTime2[0].charAt(0) == '0') {
			strTime2[0] = "" + strTime2[0].charAt(1);
		}
		if (strTime1[0] == strTime2[0]) {//小时相等
			if (strTime1[1].charAt(0) == '0') {
				strTime1[1] = "" + strTime1[1].charAt(1);
			}
			if (strTime2[1].charAt(0) == '0') {
				strTime2[1] = "" + strTime2[1].charAt(1);
			}
			if (strTime1[1] == strTime2[1]) {//分相等
				if (strTime1[2].charAt(0) == '0') {
					strTime1[2] = "" + strTime1[2].charAt(1);
				}
				if (strTime2[2].charAt(0) == '0') {
					strTime2[2] = "" + strTime2[2].charAt(1);
				}
				if (strTime1[2] == strTime2[2]) {//秒相等
					return true;
				}
			}
		}
	}
	return false;
}

/**
* 检测是否是数字（正浮点型）
* @param str 被检查的字符串
* @return true; false
*/
function isFloat(str) {
	var Letters = "0123456789";
	var dotNum = 0;
	var dot_place = -1;
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			if (checkChar == '.') {
				dotNum++;
				dot_place = i;
				if (dotNum > 1) {
					return false;
				}
				break;
			}
			return false;
		}
	//	if (i == 0 && checkChar == 0 && str.length<2) {
	//		return false;
	//	}
	}
	if (dot_place == str.length-1){ //此处xiugai验证有问题： 10. 是允许的！，允许有一个点而没有后续！！ 
		return false;
	}
	return true;
}
/**
* 检测是否是数字（可以为负）
* @param str 被检查的字符串
* @return true; false
*/
function isFloat2(str) {
	var Letters = "-0123456789";
	var dotNum = 0;
	var dot_place = -1;
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			if (checkChar == '.') {
				dotNum++;
				dot_place = i;
				if (dotNum > 1) {
					return false;
				}
				break;
			}
			return false;
		}
	//	if (i == 0 && checkChar == 0 && str.length<2) {
	//		return false;
	//	}
	}
	if (dot_place == str.length-1){ //此处xiugai验证有问题： 10. 是允许的！，允许有一个点而没有后续！！ 
		return false;
	}
	return true;
}
/**
* 检测是否是数字（正整型）
* @param str 被检查的字符串
* @return true; false
*/
function isNumber(str) {
	var Letters = "0123456789";
	var dotNum = 0;
	var dot_place = -1;
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			if (checkChar == '.') {
				dotNum++;
				dot_place = i;
				if (dotNum > 1) {
					return false;
				}
				break;
			}
			return false;
		}
		if (i == 0 && checkChar == 0) {
			return false;
		}
	}
	if (dot_place == str.length-1){ //此处xiugai验证有问题： 10. 是允许的！，允许有一个点而没有后续！！ 
		return false;
	}
	return true;
}

/**
* 检测是否是英文字母
* @param str 被检查的字符串
* @return true; false
*/
function isEnglish(str) {
	var Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			return false;
		}
	}
	return true;
}

/**
* 检测是否是合法的名字（字母，数字，下划线，且第一个字符不能为数字）
* @param str 被检查的字符串
* @return true; false
*/
function isValidName(str) {
	var Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
	for (i = 0; i < str.length; i++) {
		var checkChar = str.charAt(i);
		if (Letters.indexOf(checkChar) == -1) {
			return false;
		}
		if (i == 0 && isInteger(checkChar)) {
			return false;
		}
	}
	return true;
}

/**
* 判断字符长度
* @param str 被检查的字符串
* @return 检查字符串的长度
*/
function strLength(str) {
    var len = str.length;
    for (i = 0; i < len; i++) {
        if (str.charCodeAt(i) < 0 || str.charCodeAt(i) > 255) {
			len++;
		}
    }
    return len;
}

/**
* 判断字符串是否为空
* @param str 被检查的字符串
* @return true;false
*/
function isNull(str) {
	if (str == null || str == "") {
		return true;
	}
	else {
		return false;
	}
}

/**
* 除去字符串前后的空字符("\r\f\t \n")
* @param str 被检查的字符串
* @return true;false
*/
//去掉空格
String.prototype.trim = function(){
	return this.replace(/(^\s*)|(\s*$)/g, "");
}

//显示错误信息
function showErrorMsg(aa){
  if(aa!="") alert(aa);
}
/**
* 合并紧挨着的相同的字符
* @param str 被合并的字符串
* @param strChar 字符
* @return 完成合并后的字符串
*/
function combChar(str, strChar) {
	if (strChar == null || strChar == "") {
		return str;
	}
	var len = str.length;
	var index = 0;//上次匹配的地方
	var isFirst = "false";//第一个字符开始的子串是否与strChar匹配
	for (i = 0; i < len; i++) {
		if (strChar.length > (len - i)) {
			break;
		}
		var strTemp = str.substring(i, i + strChar.length);
		if (strTemp == strChar) {
			if (i == 0) {
				isFirst = "true";
			}
			//如果这次匹配与上次匹配是连续匹配
			if (index == (i - strChar.length)) {
				//如果上次匹配的地方不为0，或者上次匹配的地方是第一个字符，才是连续匹配
				if (index != 0 || isFirst == "true") {
					str = str.substring(0,index) + str.substring(index + strChar.length);
					len = len - strChar.length;
					i = i - strChar.length;
				}
			}
			index = i;
			i = i + strChar.length - 1;
		}
		else {
			index = 0;
		}
	}
    return str;
}

function urlHandle(urlStr) {
	urlStr = urlStr.replace("%","%25");
	urlStr = urlStr.replace("#","%23");
	urlStr = urlStr.replace("&","%26");
	urlStr = urlStr.replace("+","%2B");
	//urlStr = urlStr.replace("\\","%2F");
	urlStr = urlStr.replace("=","%3D");
	urlStr = urlStr.replace("?","%3F");
	return urlStr;
}

function maskHTMLCode(str) {
  if(str!=null){
      //str = str.replaceAll("&","&amp;");
      str = str.replaceAll("<","&lt;");
      str = str.replaceAll(">","&gt;");
      //str = str.replaceAll("\"","&quot;");
      //str = str.replaceAll("'","&apos;");
  }
  return str;
}

//alert(combChar("2004200420042004aaaa","2004"));
/**
 * 判断是否是文件地址，即是否输入了文件不能解析的字符
 * @param str String
 * @return boolean
 */
function isFileAddress(str) {
    if(str==null)return false;
    if(str.indexOf("/")>=0)return false;
    else if (str.indexOf("\\")>=0)return false;
    else if (str.indexOf(":")>=0)return false;
    else if (str.indexOf("*")>=0)return false;
    else if (str.indexOf("?")>=0)return false;
    else if (str.indexOf("<")>=0)return false;
    else if (str.indexOf(">")>=0)return false;
    else if (str.indexOf("|")>=0)return false;
  return true;
}

/**
 * 判断是否有尖括号和单引号
 * @param str String
 * @return boolean
 */
function hasNotSharpAndSinglequotes(str) {
  if (str == null) {
    return true;
  }
  if (str.indexOf("<") >= 0) {
    return false;
  }
  else if (str.indexOf("'") >= 0) {
    return false;
  }
  return true;
}

/**
*
*/
function isEmail(emailStr){
  if(emailStr==null)return false;
  var re = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/g;//匹配email地址的正则表达式
  if(re.test(emailStr))return true;
  return false;
}

function isURL(url){
  if(url==null)return false;
  url=url.replace("//","AAAAAAAA");
  alert(url);
  var re = /^[a-zA-z]+:A{8}(\w+(-\w+)*)(\.(\w+(-\w+)*))*/g;//匹配url地址的正则表达式
  if(re.test(url))return true;
  return false;
}

function isIP(ip){
  if(ip==null)return false;
  var re=/(\d+)\.(\d+)\.(\d+)\.(\d+)/g;//匹配IP地址的正则表达式
  if(re.test(ip))return true;
  return false;
}

//---------------------------------------------------Email判断2
function isEmail2(s){
   if (isEmpty(s)){
      alert("输入的E-mail地址不能为空，请输入！");
      return false;
   }
   //is s contain whitespace
   if (isWhitespace(s)){
      alert("输入的E-mail地址中不能包含空格符，请重新输入！");
      return false;
   }
   var i = 1;
   var len = s.length;

   if (len > 40){
      alert("E-mail地址长度不能超过40位!");
      return false;
   }

   pos1 = s.indexOf("@");
   pos2 = s.indexOf(".");
   pos3 = s.lastIndexOf("@");
   pos4 = s.lastIndexOf(".");
   if ((pos1 <= 0)||(pos1 == len)||(pos2 <= 0)||(pos2 == len)){
      alert("请输入有效的E-mail地址！");
      return false;
   }
   else{                                               //find two @       //. should behind the '@'
      if( (pos1 == pos2 - 1) || (pos1 == pos2 + 1) || ( pos1 != pos3 ) || ( pos4 < pos3 ) ) 
      {
          alert("请输入有效的E-mail地址！");
          return false;
      }
   }

   if ( !isCharsInBag( s, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.-_@"))
   {
      alert("email地址中只能包含字符ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.-_@\n" + "请重新输入" );
      return false;
   }
   return true;
}



//-------------------------------------------------------  【 MD5 加密 】  -----------------------------------------------------------

/*
function show(){  //测试MD5 加密密码
	 var password=document.all("passwd").value;
	 var name=document.all("new_name").value;
	 var org_password=password+"liuliuliu"+name;
	 //alert(org_password);
	 var MD5_password=MD5(org_password);
	 document.all("passwd").value=MD5_password;
	 var test_MD5=document.all("passwd").value;
	 //alert(test_MD5);

}*/

/*
 * Take a string and return the hex representation of its MD5.
 */
function MD5(str)
{
  x = str2blks_MD5(str);
  var a =  1732584193;
  var b = -271733879;
  var c = -1732584194;
  var d =  271733878;

  for(i = 0; i < x.length; i += 16)
  {
    var olda = a;
    var oldb = b;
    var oldc = c;
    var oldd = d;

    a = ff(a, b, c, d, x[i+ 0], 7 , -680876936);
    d = ff(d, a, b, c, x[i+ 1], 12, -389564586);
    c = ff(c, d, a, b, x[i+ 2], 17,  606105819);
    b = ff(b, c, d, a, x[i+ 3], 22, -1044525330);
    a = ff(a, b, c, d, x[i+ 4], 7 , -176418897);
    d = ff(d, a, b, c, x[i+ 5], 12,  1200080426);
    c = ff(c, d, a, b, x[i+ 6], 17, -1473231341);
    b = ff(b, c, d, a, x[i+ 7], 22, -45705983);
    a = ff(a, b, c, d, x[i+ 8], 7 ,  1770035416);
    d = ff(d, a, b, c, x[i+ 9], 12, -1958414417);
    c = ff(c, d, a, b, x[i+10], 17, -42063);
    b = ff(b, c, d, a, x[i+11], 22, -1990404162);
    a = ff(a, b, c, d, x[i+12], 7 ,  1804603682);
    d = ff(d, a, b, c, x[i+13], 12, -40341101);
    c = ff(c, d, a, b, x[i+14], 17, -1502002290);
    b = ff(b, c, d, a, x[i+15], 22,  1236535329);

    a = gg(a, b, c, d, x[i+ 1], 5 , -165796510);
    d = gg(d, a, b, c, x[i+ 6], 9 , -1069501632);
    c = gg(c, d, a, b, x[i+11], 14,  643717713);
    b = gg(b, c, d, a, x[i+ 0], 20, -373897302);
    a = gg(a, b, c, d, x[i+ 5], 5 , -701558691);
    d = gg(d, a, b, c, x[i+10], 9 ,  38016083);
    c = gg(c, d, a, b, x[i+15], 14, -660478335);
    b = gg(b, c, d, a, x[i+ 4], 20, -405537848);
    a = gg(a, b, c, d, x[i+ 9], 5 ,  568446438);
    d = gg(d, a, b, c, x[i+14], 9 , -1019803690);
    c = gg(c, d, a, b, x[i+ 3], 14, -187363961);
    b = gg(b, c, d, a, x[i+ 8], 20,  1163531501);
    a = gg(a, b, c, d, x[i+13], 5 , -1444681467);
    d = gg(d, a, b, c, x[i+ 2], 9 , -51403784);
    c = gg(c, d, a, b, x[i+ 7], 14,  1735328473);
    b = gg(b, c, d, a, x[i+12], 20, -1926607734);

    a = hh(a, b, c, d, x[i+ 5], 4 , -378558);
    d = hh(d, a, b, c, x[i+ 8], 11, -2022574463);
    c = hh(c, d, a, b, x[i+11], 16,  1839030562);
    b = hh(b, c, d, a, x[i+14], 23, -35309556);
    a = hh(a, b, c, d, x[i+ 1], 4 , -1530992060);
    d = hh(d, a, b, c, x[i+ 4], 11,  1272893353);
    c = hh(c, d, a, b, x[i+ 7], 16, -155497632);
    b = hh(b, c, d, a, x[i+10], 23, -1094730640);
    a = hh(a, b, c, d, x[i+13], 4 ,  681279174);
    d = hh(d, a, b, c, x[i+ 0], 11, -358537222);
    c = hh(c, d, a, b, x[i+ 3], 16, -722521979);
    b = hh(b, c, d, a, x[i+ 6], 23,  76029189);
    a = hh(a, b, c, d, x[i+ 9], 4 , -640364487);
    d = hh(d, a, b, c, x[i+12], 11, -421815835);
    c = hh(c, d, a, b, x[i+15], 16,  530742520);
    b = hh(b, c, d, a, x[i+ 2], 23, -995338651);

    a = ii(a, b, c, d, x[i+ 0], 6 , -198630844);
    d = ii(d, a, b, c, x[i+ 7], 10,  1126891415);
    c = ii(c, d, a, b, x[i+14], 15, -1416354905);
    b = ii(b, c, d, a, x[i+ 5], 21, -57434055);
    a = ii(a, b, c, d, x[i+12], 6 ,  1700485571);
    d = ii(d, a, b, c, x[i+ 3], 10, -1894986606);
    c = ii(c, d, a, b, x[i+10], 15, -1051523);
    b = ii(b, c, d, a, x[i+ 1], 21, -2054922799);
    a = ii(a, b, c, d, x[i+ 8], 6 ,  1873313359);
    d = ii(d, a, b, c, x[i+15], 10, -30611744);
    c = ii(c, d, a, b, x[i+ 6], 15, -1560198380);
    b = ii(b, c, d, a, x[i+13], 21,  1309151649);
    a = ii(a, b, c, d, x[i+ 4], 6 , -145523070);
    d = ii(d, a, b, c, x[i+11], 10, -1120210379);
    c = ii(c, d, a, b, x[i+ 2], 15,  718787259);
    b = ii(b, c, d, a, x[i+ 9], 21, -343485551);

    a = add(a, olda);
    b = add(b, oldb);
    c = add(c, oldc);
    d = add(d, oldd);
  }
  return rhex(a) + rhex(b) + rhex(c) + rhex(d);
}




 /*
 * A JavaScript implementation of the RSA Data Security, Inc. MD5 Message
 * Digest Algorithm, as defined in RFC 1321.
 * Copyright (C) Paul Johnston 1999 - 2000.
 * Updated by Greg Holt 2000 - 2001.
 * See http://pajhome.org.uk/site/legal.html for details.
 */

/*
 * Convert a 32-bit number to a hex string with ls-byte first
 */
var hex_chr = "0123456789abcdef";
function rhex(num)
{
  str = "";
  for(j = 0; j <= 3; j++)
    str += hex_chr.charAt((num >> (j * 8 + 4)) & 0x0F) +
           hex_chr.charAt((num >> (j * 8)) & 0x0F);
  return str;
}

/*
 * Convert a string to a sequence of 16-word blocks, stored as an array.
 * Append padding bits and the length, as described in the MD5 standard.
 */
function str2blks_MD5(str)
{
  nblk = ((str.length + 8) >> 6) + 1;
  blks = new Array(nblk * 16);
  for(i = 0; i < nblk * 16; i++) blks[i] = 0;
  for(i = 0; i < str.length; i++)
    blks[i >> 2] |= str.charCodeAt(i) << ((i % 4) * 8);
  blks[i >> 2] |= 0x80 << ((i % 4) * 8);
  blks[nblk * 16 - 2] = str.length * 8;
  return blks;
}

/*
 * Add integers, wrapping at 2^32. This uses 16-bit operations internally
 * to work around bugs in some JS interpreters.
 */
function add(x, y)
{
  var lsw = (x & 0xFFFF) + (y & 0xFFFF);
  var msw = (x >> 16) + (y >> 16) + (lsw >> 16);
  return (msw << 16) | (lsw & 0xFFFF);
}

/*
 * Bitwise rotate a 32-bit number to the left
 */
function rol(num, cnt)
{
  return (num << cnt) | (num >>> (32 - cnt));
}

/*
 * These functions implement the basic operation for each round of the
 * algorithm.
 */
function cmn(q, a, b, x, s, t)
{
  return add(rol(add(add(a, q), add(x, t)), s), b);
}
function ff(a, b, c, d, x, s, t)
{
  return cmn((b & c) | ((~b) & d), a, b, x, s, t);
}
function gg(a, b, c, d, x, s, t)
{
  return cmn((b & d) | (c & (~d)), a, b, x, s, t);
}
function hh(a, b, c, d, x, s, t)
{
  return cmn(b ^ c ^ d, a, b, x, s, t);
}
function ii(a, b, c, d, x, s, t)
{
  return cmn(c ^ (b | (~d)), a, b, x, s, t);
}
//----------------------------------------------------------MD5------------------------------------------------------------------------

