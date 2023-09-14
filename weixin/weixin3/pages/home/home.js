// pages/home/home.js
Page({

    /**
     * 页面的初始数据
     */
    data: {
        //存放轮播图数组
        swiperList:[]
        //存放9宫格数据
        ,gridList:[]
        ,count:0
    },

    /**
     * 生命周期函数--监听页面加载
     */
    onLoad(options) {
        
    },

    getSwiperList(){
        wx.request({
          url: 'https://www.escook.cn/slides'
          ,"method":"GET"
          ,success:(res)=>{
              this.setData(
                  {
                      swiperList:res.data
                  }
              )
          }
 
        })
    },
    //获取9宫格数据的方法
    getGridList(){
        wx.request({
          url: 'https://www.escook.cn/categories',
          method:'GET'
          ,success:(res)=>{
            //console.info(res)
            var data=res.data;
           
            this.setData({
                gridList:res.data
            })
          }
        })
    },
    gotoInfo2(){
        wx.navigateTo({
          url: '/pages/info2/info2?name=zs&gender=男',
        })
    }
    /**
     * 生命周期函数--监听页面初次渲染完成
     */

    ,incrementCount(){
        this.setData({count:this.data.count+1})
       
    }
    ,onReady() {

    },

    /**
     * 生命周期函数--监听页面显示
     */
    onShow() {

    },

    /**
     * 生命周期函数--监听页面隐藏
     */
    onHide() {

    },

    /**
     * 生命周期函数--监听页面卸载
     */
    onUnload() {

    },

    /**
     * 页面相关事件处理函数--监听用户下拉动作
     */
    onPullDownRefresh() {
        this.setData({count:0})
        wx.stopPullDownRefresh();
    },

    /**
     * 页面上拉触底事件的处理函数
     */
    onReachBottom() {
        console.info("触发了上拉触底事件")
    },

    /**
     * 用户点击右上角分享
     */
    onShareAppMessage() {

    }
})