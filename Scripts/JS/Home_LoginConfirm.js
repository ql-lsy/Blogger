 /*验证是否以及登录*/
$(function () {
    $.ajax({
        type: "Get",
        url: "/api/ApiLogin",
        dataType: "json",
        success: function (res) {
            if (res == "NO") {
                /*未登录*/
                $("#Home-Login").addClass("layui-nav-item");
                $("#Home-Login").show();
                $("#Home-Message").removeClass("layui-nav-item");
                $("#Home-Message").hide();
                $("#Home-Personal_Data").removeClass("layui-nav-item");
                $("#Home-Personal_Data").hide();
            } else {
                /*登录*/
                $("#Home-Login").removeClass("layui-nav-item");
                $("#Home-Login").hide();
                $("#Home-Message").addClass("layui-nav-item");
                $("#Home-Message").show();
                $("#Home-Personal_Data").addClass("layui-nav-item");
                $("#Home-Personal_Data").show();
            }
        }
    })
})