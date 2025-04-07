layui.use(function () {
    var layer = layui.layer;
    //, form = layui.form
    //, laypage = layui.laypage
    //, element = layui.element
    //, laydate = layui.laydate
    //, util = layui.util;
    //欢迎信息
    $.ajax({
        type: "Post",
        url: "/api/ApiSign",
        //data: { act: 3078714009,pwd=123456 },
        dataType: "json",
        success: function (res) {
            if (res == "NO") {
                console.log(res);
            } else {
                
                layer.msg('恭喜' + res + '签到成功,获得2币,4点经验');
                console.log(res);
            }
        }
    })

});