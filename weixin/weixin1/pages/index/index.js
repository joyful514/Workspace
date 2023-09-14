

Page({
  data: {
    msg:'你好',
    arr1:['苹果1','小米1','华为1'],
    userList:[
      {id:1,name:'小米1'},
      {id:2,name:'小黄1'},
      {id:3,name:'小鸡1'}
    ]
  },

  inputHandler1(e){
    this.setData({
      msg:e.detail.value
    })
 }



})
