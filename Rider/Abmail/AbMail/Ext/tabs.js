/*
 * Ext JS Library 2.0
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */

/*
$import("Ext.EventManager");
$import("Ext.Window");
$import("Ext.TabPanel");
 */
Ext.onReady(function(){
    // basic tabs 1, built from existing content
    var tabs = new Ext.TabPanel({
        renderTo: 'info',
        width:550,
        activeTab: 0,
        frame:true,
        defaults:{autoHeight: true},
        items:[
        {contentEl:'info1', title: '最新推荐'},

            {
                title: '关注科研',
                autoLoad:'modalWin.htm'
            },
            {
                title: '关注临床',
                autoLoad:'ext/ajax3.htm'
            },	  
            {
                title: '其它信息 ',
                autoLoad:'ext/ajax4.htm'
            },	  
            {
                title: '下载更新',
                autoLoad:'ext/ajax5.htm'
            }            
        ]
    });


var win = new Array();
var Myjs={};
Myjs.click={
	linkclick:function(title1,autoload1,i,width,height){
		if(!win[i]){
			win[i]= new Ext.Window({
                                title:title1,
elements: 'iframe',				
				layout:'fit',
				width:width,
                                frame: true,

				height:height,
                                 margins:'-100 0 3 3',
                                 cmargins:'20',
				closeAction: 'hide',
                                 autoLoad:autoload1,
             			plain: true,
				modal :true,
				autoScroll:true
				
			});
		}
		win[i].show(this);
	}
};
    var button1 = Ext.get('t1');
        button1.on('click', function(){
		Myjs.click.linkclick("新推出产品——防脱载玻片","sitemap.aspx",1,600,200);
    });
    var button2 = Ext.get('t2');
        button2.on('click', function(){
		Myjs.click.linkclick("全新推出包含近百个基因位点的基因芯片服务","ext/t2.txt",2,500,220);
    });
   

});