/*初始化隐藏头像和消息，只有登录后才显示*/
$("#Home-Message").hide();
$("#Home-Personal_Data").hide();


/*页面切换*/
$(function () {
    $("#Home-Blogger").click(function () {
        //$.ajax({
        //    type: "Get",
        //    dataType: "html",
        //    url: "/Home/Blogger",
        //    success: function (res) {
        //        Link(res);
        //    }
        //})
        location.href = "../Home/Blogger";
    })

    $("#Home-input-Btn").click(function () {
        var s = $("#Home-input-Search").val();
        location.href = "../Search/Search_All?search=" + s;
    })

    $("#Home-Download").click(function () {
        //$.ajax({
        //    type: "Get",
        //    dataType: "html",
        //    url: "/Home/Download",
        //    success: function (res) {
        //        Link(res);
        //    }
        //})
        location.href = "../Home/Download";
    })
    $("#Home-Learn").click(function () {
        location.href = "../Learn/Index";
    })
    $("#Home-Community").click(function () {
        location.href = "../Community/Index";
    })
    $("#Home-Seek_help").click(function () {
        location.href = "../QA/Seek_help";
    })
    $("#Home-Member").click(function () {
        //$.ajax({
        //    type: "Get",
        //    dataType: "html",
        //    url: "/Member/Index",
        //    success: function (res) {
        //        Link(res);
        //    }
        //})
        location.href = "../Member/Index";
    })
        $("#Home-Creation").click(function () {
            //$.ajax({
            //    type: "Get",
            //    dataType: "html",
            //    url: "/Home/Creation",
            //    success: function (res) {
            //        Link(res);
            //    }
            //})
            location.href = "../Home/Creation";
        })
        $("#Home-Message").click(function () {
            //$.ajax({
            //    type: "Get",
            //    dataType: "html",
            //    url: "/Home/Message",
            //    success: function (res) {
            //        Link(res);
            //    }
            //})
            location.href = "../Home/Message";
        })
        $("#Personal_Data_Image").click(function () {
            //$.ajax({
            //    type: "Get",
            //    dataType: "html",
            //    url: "/Home/Personal_Data",
            //    success: function (res) {
            //        Link(res);
            //    }
            //})
            location.href = "../Home/Personal_Data";
        })
        $(".layui-nav .layui-nav-item").click(function () {
            $(".layui-nav-item").removeClass("layui-this");
            $(this).addClass("layui-this");
        })
        $("#Home-Login").click(function () {
            location.href = "../Home/Login";
        })
        function Link(res) {
            var help = res;
            var startstr = '<!--记录开始-->';
            var endstr = '<!--记录结束-->';
            var start = help.indexOf(startstr);
            var end = help.lastIndexOf(endstr);
            var outcome = help.substring(start + startstr.length, end);
            $("#app").empty().append(outcome);
        }
    
})