$(function () {
    //$("#middle-top-geren").click(function () {
    //    location.href = "../Personal/UserCenter";
    //})
    $("#Center_app").empty();

    $.ajax({
        type: "Get",
        dataType: "json",
        url: "/api/ApiUserA",

        success: function (res) {

            $html = '<div id="Home-UserCenter-Header"><div class="UserCenter-Header-img" ><img style="width:100%;height:100%;border-radius:50%;" src="../img/' + res.UserAvatarUrl + '" /></div ><div class="UserCenter-Header-banner"><div class="Header-banner-user">' + res.UserName +'</div><div class="Header-banner-xx"><ul><li>|</li><li>0关注</li><li>|</li><li>0原创</li><li>|</li><li>0粉丝</li></ul></div></div><div><button type="button" id="user-gz" class="layui-btn layui-btn-primary">关注</button></div></div > '

            $("#Center_app").append($html);
        }
    })





})