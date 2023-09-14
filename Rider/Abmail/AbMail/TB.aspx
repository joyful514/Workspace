<%@ page language="C#" autoeventwireup="true" inherits="TB, App_Web_j5n4br42" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<script>
function CloseWebPage() {     
    if (navigator.userAgent.indexOf("MSIE") > 0) {     
        if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {     
            window.opener = null; window.close();     
        }     
        else {     
            window.open('', '_top'); window.top.close();     
        }     
    }     
    else if (navigator.userAgent.indexOf("Firefox") > 0) {     
        window.location.href = 'about:blank '; //火狐默认状态非window.open的页面window.close是无效的    
        //window.history.go(-2);     
    }     
    else {     
        window.opener = null;      
        window.open('', '_self', '');     
        window.close();     
    }     
}   
</script>  
<center>
<input id="btnClose" type="button" value="关闭本页" onClick="CloseWebPage()" />
</center>
    </div>
    </form>
</body>
</html>
