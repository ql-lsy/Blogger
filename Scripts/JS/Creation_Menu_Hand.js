$(function () {
    $("#Creation_Home").click(function () {
        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Home/Creation",
            success: function (res) {
                Link(res);
            }
        })

    })
    $("#Creation_Content").click(function () {
        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Creation/Content",
            success: function (res) {
                Link(res);
            }
        })

    })

    $("#Creation_Comments").click(function () {
        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Creation/Comments",
            success: function (res) {
                Link(res);
            }
        })

    })
    $("#Creation_Opus").click(function () {

        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Creation/Opus",
            success: function (res) {
                Link(res);
            }
        })

    })
    $("#Creation_Followers").click(function () {
        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Creation/Followers",
            success: function (res) {
                Link(res);
            }
        })

    })
    $("#Creation_Earnings").click(function () {
        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Creation/Earnings",
            success: function (res) {
                Link(res);
            }
        })

    })
    $("#Creation_Other").click(function () {

        $.ajax({
            type: "Get",
            dataType: "html",
            url: "/Home/Creation",
            success: function (res) {
                Link(res);
            }
        })

    })
    function Link(res) {
        var help = res;
        var startstr = '<!--Creation记录开始-->';
        var endstr = '<!--Creation记录结束-->';
        var start = help.indexOf(startstr);
        var end = help.lastIndexOf(endstr);
        var outcome = help.substring(start + startstr.length, end);
        $("#Creation_app").empty().append(outcome);
    }

})