Ext.namespace("Divo.app");

Divo.app.PortletDemo = function() {
	/* ----------------------- private properties ----------------------- */
	var portId = 'app-portal-demo-res-portal';
	var settingId = 'app-portal-demo-ext-div';

	var portalState;
	var portalMgr;

	/* ----------------------- private method ----------------------- */
	function createLayout() {
		new Ext.Viewport( {
			id : 'app-portal-demo-main-view',
			layout : 'border',
			items : [
					{
						region : 'west',
						id : 'app-portal-demo-settings-panel',
						title : 'Settings',
						split : true,
						width : 230,
						minSize : 275,
						maxSize : 800,
						collapsible : true,
						margins : '5 0 5 5',
						cmargins : '5 5 5 5',
						layout : 'fit',
						items : [{
							html : "<div id='"+settingId+"'></div>",
							id : 'app-portal-demo-settings-exts',
							autoScroll : true,
							border : false,
							iconCls : 'nav'
						}]
					}, {
						region : 'center',
						margins : '5 5 5 0',
						id : 'app-portal-demo-center-regn',
						layout : 'fit',
							items : [{
							xtype : 'portal',
							id : portId,
							items : [ {
								columnWidth : .49,
								style : 'padding:10px 0 10px 10px'
							}, {
								columnWidth : .49,
								style : 'padding:10px 0 10px 10px'
							}]
						}]
					}]
		});
	}

	/* ----------------------- public method ----------------------- */
	return {

		init : function() {
			Ext.state.Manager.setProvider(new Ext.state.CookieProvider( {
				exprires : new Date().add(Date.MONTH, 6)
			}));

			createLayout();

			portalState = new Divo.app.PortalState();
			portalState.init(portId);

			portalMgr = new Divo.app.PortalManager();
			portalMgr.init(settingId,portId,portalState);

			Ext.ComponentMgr.get(portId).on("drop", function() {
				portalState.save();
			});
		}

	}; // return

}();

Ext.onReady(Divo.app.PortletDemo.init, Divo.app.PortletDemo, true);

// EOP

