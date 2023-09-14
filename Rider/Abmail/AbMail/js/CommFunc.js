//==============1、相当于VB中的TRIM()函数===============================================================
//功能：
//         去掉字符串首尾的空格；
//参数说明：
//        str：欲处理的字符串；
//返回值：
//        字符串型；
//======================================================================================================
 function  _$(s){return document.getElementById(s);} 
//  function   _print(){   
//  document.all.WebBrowser.ExecWB(7,1);
//  }   
function javaTrim(str){
		var i=0;
		var j;
		var len=str.length;
		
		trimstr='';
		j=len-1;
		if(j<0) return trimstr;
		flagbegin= true;
		flagend= true;
		while (flagbegin== true){
			if (str.charAt(i)==' '){
				i++;
				if(i>j) return trimstr;
				flagbegin=true;
			}
			else{
				flagbegin=false;
			}
		} 
		while (flagend==true) {
			if (str.charAt(j)==' '){
				j--;flagend=true;
			}
			else{
				flagend=false;
			}
		}
		trimstr=str.substring(i,j+1);
		
		return trimstr;
	}


// 正确的非 HTML 文字串。
	function javaValidString(str)
	{
		var len;
		
		len = str.length;
		for(var i=0; i<len; i++) 
		{
			if(str.charAt(i)=='<' || str.charAt(i)=='>' || str.charAt(i)=='\'' || str.charAt(i)=='\"') 
			{
				return false;
			}
		}
		return true;
	}

// 检查E-Mail是否正确！	
	function javaValidEmail(str)
	{
		var cnt1, cnt2;
		var len1;

		if(javaValidString(str)==false) 
		{
			return false;
		}

		cnt1=0;
		cnt2=0;
		len1 = str.length;
		for(var i=0; i<len1; i++) {
			if(str.charAt(i)=='@') 
			{
				cnt1++;
			}
			if(str.charAt(i)=='.') 
			{
				cnt2++;
			}
			if(str.charAt(i)==' ')
			{
				return false;
			}
		}
		if( cnt1!=1 || cnt2<1)
		{
			return false;
		}
		return true;
	}
	
	// 正确的数字文字串。用于身份证、电话、价格等。
	function javaValidNumber(str)
	{
		var cnt3;
		var len3;

		if(javaValidString(str)==false) 
		{
			return false;
		}

		cnt3=0;
		len3 = str.length;
		for(var i=0; i<len3; i++) {
			if(str.charAt(i)>='0' && str.charAt(i)<='9' || str.charAt(i)=='.') 
			{
				cnt3++;
			}
		}
		if( cnt3!=len3)
		{
			return false;
		}
		return true;
	}

function SpaceEmailNumberCheck(strFrm,strItem,nCheckType,strErrorAlertInfo)
{
	var eitem = eval(strFrm +'.'+ strItem);
	
	
	switch(nCheckType)
	{
		case 0: //check space
			
				if (javaTrim (eitem.value) =='')
					{
						alert(strErrorAlertInfo+'不能为空！');
						eitem.focus();
						return false ;
						}
				else
					return true;
			
		case 1: //check email
			
				if(javaValidEmail(eitem.value))	
				return true;
				else
				{
					alert(strErrorAlertInfo+'不能为空！');
						eitem.focus();
						return false ;
				}
		
		case 2: //check number
			
			if(javaValidNumber(eitem.value))	
				return true;
			else
				{
					alert(strErrorAlertInfo+'不能为空！');
						eitem.focus();
						return false ;
				}
			
	}
}
	//比较两个日期的大小

	//===========判断输入是否为数字类型================================================================
	//		if (form1.period.value!='' + parseFloat(form1.period.value))
	//		{
	//			alert('╳ 建设周期必须输入，并且必须为数字！');
	//			form1.period.focus();
	//			return false;
	//		}
	//=================================================================================================

//==============5、选择所有复选框=======================================================================
//功能：
//         选中/取消具有相同名字的所有复选框；
//参数说明：
//        form      ：表单名称；
//		  chkname   ：欲选择的复选框名字；
//		  chkallname：全选标志复选框；
//返回值：
//        无；
//示例：
// OnClick="CheckAll(this.form,'cb','checkbox_all')"
//======================================================================================================
function CheckAll(formname,chkname,chkallname)
{
  var objstr=eval(formname + '.' + chkname);
  if(objstr == null)
	return;
  var objlen=objstr.length;
  var e,k;
  e = eval(formname + '.'+chkname);
  k = eval(formname + '.'+chkallname);
  if(objlen==null)
  {
	objstr.checked=k.checked;
	return;
  }

  for (var i=0;i<objlen;i++)
       e[i].checked = k.checked;
}

function UnCheckAll(formname,chkname)
{
  var objstr=eval(formname + '.' + chkname);
  if(objstr == null)
	return;
  var objlen=objstr.length;
  var e,k;
  e = eval(formname + '.'+chkname);
  //k = eval(formname + '.'+chkallname);
  if(objlen==null)
  {
	objstr.checked=!objstr.checked;
	return;
  }

  for (var i=0;i<objlen;i++)
       e[i].checked = !e[i].checked;
}

//=============判断是否选择了数据项（复选）=============================================================
//功能
//
//参数说明
//
//
//返回值
//
//示例
//
//======================================================================================================
function CheckIsSelected(FormName,chkname)
{
  var e=eval(FormName + '.' + chkname);
  var elen=e.length;
  var selectflag=false;

  if(elen==null)	//只有一条记录的情况；
  {
	if(!e.checked)
	{
		//alert('还没有选择数据项呢！');
		return false;
	}
	else
		selectflag=true;
  }
  else				//有多条记录的情况；
  {
	for(var i=0;i<elen;i++)
		if(e[i].checked)
		{
			selectflag=true;
			break;
		}

	if(!selectflag)		//没有选择删除项；
	{
		//alert('还没有选择数据项呢！');
		return false;
	}
  }

//if (confirm("确认你的选择吗？"))
		return true;
//	else
//		return false;

}


function CheckIsSelected(FormName,chkname)
{
  var e=eval(FormName + '.' + chkname);
  var elen=e.length;
  var selectflag=false;

  if(elen==null)	//只有一条记录的情况；
  {
	if(!e.checked)
	{
		//alert('还没有选择数据项呢！');
		return false;
	}
	else
		selectflag=true;
  }
  else				//有多条记录的情况；
  {
	for(var i=0;i<elen;i++)
		if(e[i].checked)
		{
			selectflag=true;
			break;
		}

	if(!selectflag)		//没有选择删除项；
	{
		//alert('还没有选择数据项呢！');
		return false;
	}
  }

}

//=============================================================================
//功能：
//         提交窗体时的检测与确认操作；
//参数说明：
//        FormName  ：表单名称；
//		  FormAction：Form提交的目标文件（''空串表示当前页面；否则为指定文件）；
//		  chkname   ：欲选择的复选框名字；
//		  Var1Name  ：（Var2Name,Var3Name）Form对象1（Form对象2,Form对象3）；
//		  Var1Value ：（Var2Value,Var3Value）Form对象1的值（Form对象2的值,Form对象3的值）；
//		  DisplayStr：确认提示信息；
//返回值：
//        无；
//示例：
// OnClick="DoSubmit('form1','','chkTaskID','h_submit','D','','','','','真的要删除吗?')"
//======================================================================================================
function DoSubmit(FormName,FormAction,chkname,Var1Name,Var1Value,Var2Name,Var2Value,Var3Name,Var3Value,DisplayStr)
{
  var e=eval(FormName+'.'+chkname);
  var elen=e.length;
  var selectflag=false;

  if(elen==null)	//只有一条记录的情况；
  {
	if(!e.checked)
	{
		DisplayInformation('没有选择数据!');
		return;
	}
	else
		selectflag=true;
  }
  else				//有多条记录的情况；
  {
	for(var i=0;i<elen;i++)
		if(e[i].checked)
		{
			selectflag=true;
			break;
		}

	if(!selectflag)		//没有选择删除项；
	{
		DisplayInformation('没有选择数据!');
		return;
	}
  }

  if(selectflag)		//如果选择则根据参数情况给对象赋值并提交窗体；
  {
	var isconfirm=window.confirm(DisplayStr);
	if(isconfirm)
	{
		if(FormAction!='')		//窗口是否提交到当前页面（为空串为提交到当前页，否则为指定页名称）；
			FormName.action=FormAction;
		if(Var1Name!='')
			eval(FormName+'.'+Var1Name).value=Var1Value;
		if(Var2Name!='')
			eval(FormName+'.'+Var2Name).value=Var2Value;
		if(Var3Name!='')
			eval(FormName+'.'+Var3Name).value=Var3Value;

		eval(FormName + '.submit()');
	}
  }
}

//==============7、定制新窗口===========================================================================
//功能：
//         按用户要示定制并打开新窗口；
//参数说明：
//        UrlAddr：URL文件；
//		  WinName：窗口名称；
//		  CusFunc：窗口定制参数；
//返回值：
//        无；
//示例：
// OnClick="OpenNewWin('fram_app.asp?infoid=3','newwin','width=300,height=300,top=100,left=100,status,scrollbars')"
//======================================================================================================
function OpenNewWin(UrlAddr,WinName,CusFunc)
{
	var ParStr='';
	window.open(UrlAddr,WinName,CusFunc)
}

//==============8、设置不可用按钮=======================================================================
//功能：
//         可设置多达5个（可为0个）的按钮为不可用状态；
//参数说明：
//        UrlAddr：URL文件；
//		  WinName：窗口名称；
//		  CusFunc：窗口定制参数；
//返回值：
//        无；
//示例：
// OnLoad="SetDisBut('','b_12','','','','')"
//======================================================================================================
function SetDisBut(FormName,Button1Name,Button2Name,Button3Name,Button4Name,Button5Name)
{
	var v1;
	var SPFormName=FormName;
	if (FormName=='')
		SPFormName='form1';

	if (Button1Name!='')
	{
		v1=eval(SPFormName + "." + Button1Name);
		v1.disabled=true;
	}
	if (Button2Name!='')
	{
		v1=eval(SPFormName + "." + Button2Name);
		v1.disabled=true;
	}
	if (Button3Name!='')
	{
		v1=eval(SPFormName + "." + Button3Name);
		v1.disabled=true;
	}
	if (Button4Name!='')
	{
		v1=eval(SPFormName + "." + Button4Name);
		v1.disabled=true;
	}
	if (Button5Name!='')
	{
		v1=eval(SPFormName + "." + Button5Name);
		v1.disabled=true;
	}
}

//==============9、禁止鼠标右键=========================================================================
//功能：
//         禁止使用鼠标右键查看页面源代码；
//返回值：
//        无；
//示例：
// OnMouseDown="RightKeyClick()"
//======================================================================================================
function RightKeyClick()
{
	if (event.button==2)
	{
		window.alert ('对不起，禁止使用此功能！');
	}
}

//==============10、动态产生某年某月的天数==============================================================
//功能：
//         根据选择的年份、月份自动改变天数下拉列表框的选择项；
//参数说明：
//        FormName：Form名称；
//		  YearName：年份下拉列表框名称；
//		  MonthName：月份下拉列表框名称；
//        DayName：天数下拉列表框名称；
//返回值：
//        无；
//示例：
// OnChange="YearChange('form1','by','bm','bd')"
//======================================================================================================
function YearChange(FormName,YearName,MonthName,DayName)
{
	var CurrentMonthDays;
	var bYear;
	var bMonth;
	var YearNameValue=eval(FormName + '.' + YearName);
	var MonthNameValue=eval(FormName + '.' + MonthName);
	var DayNameValue=eval(FormName + '.' + DayName);
	var bDay;
	bYear=parseInt(YearNameValue.options[YearNameValue.selectedIndex].value);
	bMonth=parseInt(MonthNameValue.options[MonthNameValue.selectedIndex].value);
	bDay=parseInt(DayNameValue.options[DayNameValue.selectedIndex].value);

	//alert ('年份：' + YearNameValue.options[YearNameValue.selectedIndex].value);
	//alert ('月份：' + bMonth);

	switch(bMonth){
	case 1:
		CurrentMonthDays=31;
		break;
	case 3:
		CurrentMonthDays=31;
		break;
	case 5:
		CurrentMonthDays=31;
		break;
	case 7:
		CurrentMonthDays=31;
		break;
	case 8:
		CurrentMonthDays=31;
		break;
	case 10:
		CurrentMonthDays=31;
		break;
	case 12:
		CurrentMonthDays=31;
		break;

	case 4:
		CurrentMonthDays=30;
		break;
	case 6:
		CurrentMonthDays=30;
		break;
	case 9:
		CurrentMonthDays=30;
		break;
	case 11:
		CurrentMonthDays=30;
		break;

	case 2:
		if (bYear%4==0 && bYear%100!=0 || bYear%400==0)
			CurrentMonthDays=29
		else
			CurrentMonthDays=28;
		break;
	default:
		CurrentMonthDays=200;
		break;
	}

	//alert('日数：' + CurrentMonthDays);
	DayNameValue.length=0;
	for(var i=1;i<=CurrentMonthDays;i++)
	{
		DayNameValue.options[i-1]=new Option(i);
		DayNameValue.options[i-1].value=i;
		DayNameValue.options[i-1].text='' + i;
		if(i==bDay)
			DayNameValue.options[i-1].selected=true;
	}

	//var kkk=DayNameValue.length;
	//DayNameValue.length=DayNameValue.length+5;
	//for(i=0;i<5;i++)
	//{
	//	DayNameValue.options[kkk+i]=new Option(kkk+i);
	//	DayNameValue.options[kkk+i].value=i+1;
	//	DayNameValue.options[kkk+i].text='adsf'+(i+1);
	//}
}

//=============比较两个时间的大小===================================================================
//功能
//		  比较两个时间（以年、月、日、时、分）的大小；
//参数说明
//        by：第一时间中年；
//        bm：第一时间中月；
//        bd：第一时间中日；
//        bho：第一时间中时；
//        bmi：第一时间中分；
//
//        ey：第二时间中年；
//        em：第二时间中月；
//        ed：第二时间中日；
//        eho：第二时间中时；
//        emi：第二时间中分；
//
//返回值
//		  Time1>=Time2	返回FALSE;
//		  Time1<Time2	返回TRUE;
//==================================================================================================
function CompareTime(by,bm,bd,bho,bmi,ey,em,ed,eho,emi)
{
	var Time1,Time2;
	tbm=(''+bm).length==1?'0'+bm:''+bm;
	tbd=(''+bd).length==1?'0'+bd:''+bd;
	tbho=(''+bho).length==1?'0'+bho:''+bho;
	tbmi=(''+bmi).length==1?'0'+bmi:''+bmi;
	Time1=by+tbm+tbd+tbho+tbmi;

	tem=(''+em).length==1?'0'+em:''+em;
	ted=(''+ed).length==1?'0'+ed:''+ed;
	teho=(''+eho).length==1?'0'+eho:''+eho;
	temi=(''+emi).length==1?'0'+emi:''+emi;
	Time2=ey+tem+ted+teho+temi;

	return Time1>=Time2?false:true;
}

//==============11、打开时间选取窗体函数===================================================================
//功能：
//         对象需要申请时间时，在其OnClick()函数中使用该函数弹出时间选取窗体；
//参数说明：
//        objGetTime：取得时间的对象名称；
//		  TimeType  ：时间类型（DATE表示只要日期，TIME表示只要时间，DATETIME表示既有日期又有时间）；
//返回值：
//        无；
//示例：
// OnClick="SelectTime('BeginTime','DateTime')"
//备注：
//        其要和commfunc/seltime.asp（时间选取窗体）一起使用；
//======================================================================================================
function SelectTime(objGetTime,TimeType)
{
	var TmpTime;
	TmpTime = eval('form1.' + objGetTime + '.value')
	window.open('../commfunc/seltime.asp?objGetTime=' + objGetTime + '&TimeType=' + TimeType + '&CurrentValue=' + TmpTime,'SelTimeWin','width=450,height=150,top=150,left=150,scrollbars=no');
}

//==============12、把选取的时间返回给时间申请对象函数=======================================================
//功能：
//         在弹出的时间选取窗体中选取时间后，赋值给在SelectTime函数参数中传递的需要值的时间对象；
//参数说明：
//        objGetTime：取得时间的对象名称；
//		  TimeType  ：时间类型（DATE表示只要日期，TIME表示只要时间，DATETIME表示既有日期又有时间）；
//返回值：
//        无；
//示例：
// OnClick="SelectTime('BeginTime','DateTime')"
//备注：
//		string.toUpperCase()	将字符串转换成大写；
//		string.toLowerCase()	将字符串转换成小写；
//======================================================================================================
function GetSelectedTime(objGetTime,TimeType)
{
	var SelectedTime,PartDate,PartTime;
	objGetTime=eval('window.opener.form1.' + objGetTime);

	PartDate=frm.by.value + '-' + frm.bm.value + '-' + frm.bd.value;
	PartTime=frm.bho.value + ':' + frm.bmi.value + ':00';

	switch(TimeType.toUpperCase())
	{
	case "DATE":
		SelectedTime=PartDate;
		break;
	case "TIME":
		SelectedTime=PartTime;
		break;
	case "DATETIME":
		SelectedTime=PartDate + ' ' + PartTime;
		break;
	default:	//同DATETIME,所以case "DATETIME"分支可以不要；
		SelectedTime=PartDate + ' ' + PartTime;
	}
	objGetTime.value=SelectedTime;
	self.close();
}

//==============13、判断必输项（并指定长度）、是否为数字====================================================
//功能：
//         在编辑状态下，通常要判断某对象的值是否输入（并判断是否超出指定长度）、
//										是否为数字（并判断是否超出指定长度、还可包括其它哪些字符）；
//参数说明：
//		  FormName	[string]：窗口名称；
//        objID		[string]：欲检测对象的name；
//		  ObjName	[string]：欲检测对象的中文名称；
//		  ObjType	[string]：对象是文本类或下拉选择类，如果是文本类可为""，如果是下拉选择类为"Select"
//		  ValueLen	[ int  ]：对象数据最大长度；如果是0则表示不判断其长度；
//		  HaveFocus	[boolean]：是否让当前对象获得焦点；
//返回值：
//        Boolean	：TRUE/FALSE；
//示例：
// OnClick="GetMustInput('Form1','Select','Title','文件标题',50)"
//======================================================================================================
function GetMustInput(FormName,ObjType,ObjID,ObjName,ValueLen,HaveFocus)
{
	var ObjCheck;
	ObjCheck=eval(FormName + '.' + ObjID);

	if (ObjType == 'Select')
		if (ObjCheck.options[ObjCheck.selectedIndex].value=='')
		{
			window.alert('错误提示\n================================================\n\n[对象名称]：     ' + ObjName + '\n\n[错误描述]：     必须选择数据！');
			if(HaveFocus){ObjCheck.focus();}
			return false;
		}

	if (javaTrim(ObjCheck.value) == '')
	{
		window.alert('错误提示\n================================================\n\n[对象名称]：     ' + ObjName + '\n\n[错误描述]：     必须输入数据！');
		if(HaveFocus){ObjCheck.focus();ObjCheck.select();}
		return false;
	}
	else
	{
		if (ValueLen!=0)
		if (GetStrLen(ObjCheck.value) > ValueLen)
		{
			window.alert('错误提示\n================================================\n\n[对象名称]：     ' + ObjName + '\n\n[错误描述]：     数据输入超过指定长度（' + ValueLen + '），现有数据长度为（' + GetStrLen(ObjCheck.value) + '）！');
			if(HaveFocus){ObjCheck.focus();ObjCheck.select();}
			return false;
		}
	}

	return true;
}

//==============14、判断字符串长度（包括汉字）==============================================================
//功能：
//         取得给定字符串的长度（其包括汉字，一个汉字算两个字符长度）；
//参数说明：
//		  pstr：给定字符串；
//返回值：
//        String；
//示例：
//		window.alert(GetStrLen('江泽民会见日本客人。'))"
//======================================================================================================
function GetStrLen(pstr)
{
		var AscCode;
		var tmpstr=javaTrim(pstr);
		var StrLen=tmpstr.length;
		var nums=0;
		if (StrLen<=0) return 0;

		for (var i=0;i<StrLen;i++){
			AscCode=tmpstr.charCodeAt(i);
			if (AscCode>127) nums+=2;
			else nums+=1;
		} 

		return nums;
}

//==============15、显示指定的字符串=======================================================================
//功能：
//         用JavaScript弹出式显示指定字串；
//参数说明：
//		  DisplayString：给定字符串；
//返回值：
//        无；
//示例：
//		DisplayInformation('江泽民会见日本客人。')
//======================================================================================================
function DisplayInformation(DisplayString)
{
	window.alert('错误提示\n================================================\n\n[错误描述]：     ' + DisplayString);
}

function DoSearch(FormName,FormAction,Var1Name,Var1Value,Var2Name,Var2Value,Var3Name,Var3Value)
{
		if(FormAction!='')		//窗口是否提交到当前页面（为空串为提交到当前页，否则为指定页名称）；
			FormName.action=FormAction;
		if(Var1Name!='')
			eval(FormName+'.'+Var1Name).value=Var1Value;
		if(Var2Name!='')
			eval(FormName+'.'+Var2Name).value=Var2Value;
		if(Var3Name!='')
			eval(FormName+'.'+Var3Name).value=Var3Value;

		eval(FormName + '.submit()');

}


function GetSpeStr(DispStr,RepStr,DispLens,RepType)
{
	var corpvar = '';
	var varlen = DispStr.length;
	for (var i=0;i<DispLens-varlen;i++)
		corpvar += RepStr;

	switch(RepType.toUpperCase())
	{
	case 'L':	//在左边循环
		corpvar += DispStr;
		break;
	case 'R':	//在右边循环
		corpvar += corpvar;
		break;
	default:	//在左边循环
		corpvar += DispStr;
	}

	return corpvar;
}

/*
function DateCompare(CompareDate,FirstDate,SecondDate,CompareType)
{
	var pCompareDate = new Date(CompareDate);
	var pFirstDate = new Date(FirstDate);
	var pSecondDate = new Date(SecondDate);
	switch(CompareType)
	{
	case '>'：
		if (pCompareDate > pFirstDate){return true;}
		break;
	case '<':
		if (pCompareDate < pFirstDate){return true;}
		break;
	case '=':
		if (pCompareDate = pFirstDate){return true;}
		break;
	case '>=':
		if (pCompareDate >= pFirstDate){return true;}
		break;
	case '<=':
		if (pCompareDate <= pFirstDate){return true;}
		break;
	case 'be':
		if (pCompareDate>=pFirstDate && pCompareDate<=pSecondDate){return true;}
	}
	window.alert('错误提示\n================================================\n\n[错误描述]：     在!');
	return false;
}
*/

function ShowMyLayer(strFrm,obj)
{
	if (eval(strFrm+'.fjmc1').value != "" || eval(strFrm+'.fjmc2').value != ""||eval(strFrm+'.fjmc3').value != "")
	{
	    eval(obj +'.style').visibility="visible";
		eval(strFrm).submit();
	} 
}
//不带参数
function fnOpenModWinL(urlName,winName)
{
	 //return window.showModalDialog(urlName,winName,'dialogWidth=800px;dialogHeight=600px;center=yes;help:no;status:no;scroll:yes');
	 //return fnOpenModWinL1(urlName,winName);
	 return fnOpenModWin(urlName,winName,1024,650);
}
function fnOpenModWinM(urlName,winName)
{
	//return window.showModalDialog(urlName,winName,'dialogWidth=750px;dialogHeight=500px;center=yes;help:no;status:no;scroll:no');
	//return fnOpenModWinM1(urlName,winName);
	return fnOpenModWin(urlName,winName,780,500);
}
function fnOpenModWinS(urlName,winName)
{
	//return window.showModalDialog(urlName,winName,'dialogWidth=400px;dialogHeight=300px;center=yes;help:no;status:no;scroll:no');
	//return fnOpenModWinS1(urlName,winName);
	return fnOpenModWin(urlName,winName,400,400);
}

function fnOpenModWin(urlName,winName,pWidth,pHeight)
{
	//return window.showModalDialog(urlName,winName,'dialogWidth='+pWidth+'px;dialogHeight='+pHeight+'px;center=yes;help:no;status:no;scroll:no')
	if (window.showModalDialog!=null)//IE判断
   {
	return window.showModalDialog(urlName,winName,'dialogWidth='+pWidth+'px;dialogHeight='+pHeight+'px;dialogLeft=160;dialogTop=110;help:no;status:no;scroll:yes')
   }
	else
	{
		return window.open(urlName,"WinNew","Width:"+pWidth+",Height:"+pHeight+",Left=160,Top=110,menubar=no,toolbar=no,location=no,scrollbars=no,status=yes");
	}
	}

function fnOpenModWinNew(pUrl,pParams,pWidth,pHeight)
{
	var retValue;
	var sUrl;
	sUrl = "../js/modalWin.htm?page=" + pUrl;
	if(pParams!='')
		sUrl = sUrl + '?' + pParams;
	retValue = fnOpenModWin(sUrl,'',pWidth,pHeight);
	
	return retValue;
	/*if(retValue!='cancel')
	{
	  document.forms[0].hidReturnValue.value = retValue;
	  document.forms[0].submit();
	}*/
//		self.location.href=self.location.href;
}
//带参数
function fnOpenModWinL1(pUrl,pParams)
{
	return fnOpenModWinNew(pUrl,pParams,830,576);
}
function fnOpenModWinM1(pUrl,pParams)
{
	return fnOpenModWinNew(pUrl,pParams,780,500);
}
function fnOpenModWinS1(pUrl,pParams)
{
	return fnOpenModWinNew(pUrl,pParams,400,400);
}



//格式化数字，如：FormatNumber(498.8573945,2) 格式化为2位小数
function FormatNumber(srcStr,nAfterDot){
   　　var srcStr,nAfterDot;
   　　var resultStr,nTen;
   　　srcStr = ""+srcStr+"";
   　　strLen = srcStr.length;
   　　dotPos = srcStr.indexOf(".",0);
   　　if (dotPos == -1){
   　　　　resultStr = srcStr+".";
   　　　　for (i=0;i<nAfterDot;i++){
   　　　　　　resultStr = resultStr+"0";
   　　　　}
   　　　　return resultStr;
   　　}
   　　else{
   　　　　if ((strLen - dotPos - 1) >= nAfterDot){
   　　　　　　nAfter = dotPos + nAfterDot + 1;
   　　　　　　nTen =1;
   　　　　　　for(j=0;j<nAfterDot;j++){
   　　　　　　　　nTen = nTen*10;
   　　　　　　}
   　　　　　　resultStr = Math.round(parseFloat(srcStr)*nTen)/nTen;
   　　　　　　return resultStr;
   　　　　}
   　　　　else{
   　　　　　　resultStr = srcStr;
   　　　　　　for (i=0;i<(nAfterDot - strLen + dotPos + 1);i++){
   　　　　　　　　resultStr = resultStr+"0";
   　　　　　　}
   　　　　　　return resultStr;
   　　　　}
   　　}
   } 
   
   
   
   
   


function doGetRetValue() 
{ 
	var retValue;
	retValue = fnOpenModWinM('../Customer/CustomerSel.aspx','winCustomerSel');
	if(retValue==null)
	{
		retValue = '';
	}
	return retValue;
} 


//设置回车键为Tab键
function setHotKey()
{
	var IEKey = window.event.keyCode;
					
	//回车表示进入下一对象(保存按钮除外)
	if(IEKey == 13)
	window.event.keyCode=9;	
}

//全选页面中的checkbox
function fnCheckAllCheckBox(myForm,myChecked)
{
	var frm1 = eval('document.'+ myForm);
	for(var i=0;i<frm1.elements.length;i++)
	{
		//alert(frm1.elements[i].name);
		if((frm1.elements[i].type=='checkbox') && (frm1.elements[i].name != 'chkUnSelect'))
			frm1.elements[i].checked = myChecked;
	}
}

//选择
function SelDataRetValue(pWinSize,pObjName,pObjID,pURL) 
{ 
	var retValue;
	var ObjName,ObjID;
	if(pWinSize=='L')
		retValue = fnOpenModWinL1(pURL,'');
	else if(pWinSize=='M')
		retValue = fnOpenModWinM1(pURL,'');
	else
		retValue = fnOpenModWinS1(pURL,'');
	//retValue = fnOpenModWinM1(pURL,'');
	if(retValue!=null)
	{
		var ary = retValue.split(",");
		ObjName = eval('document.all.' + pObjName);
		ObjID = eval('document.all.' + pObjID);
		
		ObjID.value = ary[0];
		ObjName.value = ary[1];
	}
	return false;
}

//选择（指定）
function SelDataRetValue1(pObjName,pObjID,pURL,pWidth,pHeight) 
{ 
	var retValue;
	var ObjName,ObjID;
	retValue = fnOpenModWinNew(pURL,'',pWidth,pHeight);
	if(retValue!=undefined && retValue!='cancel' && retValue!='')
	{
		var ary = retValue.split(",");
		ObjName = eval('document.all.' + pObjName);
		ObjID = eval('document.all.' + pObjID);
		
		ObjID.value = ary[0];
		ObjName.value = ary[1];
		
		return true;
	}
	else
		return false;
}

//新增窗体，默认焦点移到第一个元素上
function GetFocus(objID)
{
	var ObjName;
	ObjName = _$(objID);
	ObjName.focus();
}