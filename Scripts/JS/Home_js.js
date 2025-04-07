$(function () {

    $("#Home-Personal_Data").mouseenter(function () {
        $("#Home_UserBox").css("display", "block");
        $("#Home_UserBox dl").css("display", "block");
    });

    $("#Home-Personal_Data").mouseleave(function () {
        $("#Home_UserBox").css("display", "none");
        $("#Home_UserBox dl").css("display", "none");
    });
    $("#Home_Close").click(function () {
        location.href = "../Home/Login";
    })

    //1定义延时器的ID
    var timer = null;

    //2定义防抖函数
    function debounceSearch(kw) {
        timer = setTimeout(function () {
            getSuggestList(kw);
        }, 500)
    }
    function getSuggestList(kw) {

        $.ajax({
            url: "/api/ApiGetSearch",
            type: "Get",
            data: { Name: kw },
            success: function (res) {
                if (res.length > 0) {
                    $("#Search_Box").empty();
                    for (var i = 0; i < res.length; i++) {
                        $li = "<li class='Search_item'>" + res[i].SearchName + "</li>"
                        $("#Search_Box").append($li);
                    }
                } else {
                    $("#Search_Box").empty();
                    $("#Search_Box").hide();
                }
            }
        })

    }
    $(document).on("click", ".Search_item", function () {
        var text = $(this).html();
        $("#Home-input-Search").val(text);
    });
    $("#Home-input-Search").on("keyup", function () {
        //3清空timer
        clearTimeout(timer);
        var keywords = $(this).val().trim();
        if (keywords.length <= 0) {
            $("#Search_Box").hide();
            $("#Search_Box").empty();
        } else {
            $("#Search_Box").show();
            debounceSearch(keywords);
        }
    })

    $.ajax({
        url: "/api/ApiGetUserInfoR",
        type: "Get",
        success: function (res) {

            var UserImage = '/Upload/UserImage/';
            UserImage += res.UserAvatarUrl;
            $("#Personal_Data_Image").attr('title', res.UserName);
            $(".Home_UserImage").attr('src', UserImage);
            $("#Home_Name").html(res.UserName);
            $("#Home_Lable").html(res.UserLabel);
            var LV = "LV0";
            if (res.UserExperience > 0) {
                LV = "LV1";
            }
            if (res.UserExperience > 200) {
                LV = "LV2";
            }
            if (res.UserExperience > 1500) {
                LV = "LV3";
            }
            if (res.UserExperience > 4500) {
                LV = "LV4";
            }
            if (res.UserExperience > 10800) {
                LV = "LV5";
            }
            if (res.UserExperience > 28800) {
                LV = "LV6";
            }
            $("#Home_LV").html(LV);
        }

    })

})