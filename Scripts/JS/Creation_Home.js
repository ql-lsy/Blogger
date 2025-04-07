$(function () {

    $.ajaxSettings.async = false
    $.ajax({
        url: "/api/ApiRDownLoad",
        type: "Get",
        success: function (res) {
            if (res == "Login") {
                layer.msg('登陆验证失败，请重新登录');
            } else {
                var count = 0;
                $ul = '<ul class="Creation_DownLoad_item">';
                $("#Creation_Home_Download_Box").empty();
                for (var i = 0; i < res.length; i++) {
                    $li1 = '<li><div class="panel-body Home-flex Creation_essay"><ul class="Home-flex"><li><h3>' + res[i].DownloadName + '</h3><p>' + res[i].DownloadDec + '</p></li><li><p>' + res[i].frequency + '</p><p>下载数</p></li><li><p>' + res[i].DownloadKunCoin + '</p><p>价格</p></li><li><p>' + res[i].DownloadKunCoinObtain +'</p><p>收益</p></li></ul></div></li>';
                    if (count < 10) {
                        $ul += $li1;
                    }
                    count++;
                }
                $ul += '</ul>';
                $("#Creation_Home_Download_Box").append($ul);
             
            }
        }
    })
    $.ajax({
        url: "/api/ApiBlog",
        type: "Get",
        success: function (res) {
            if (res == "Login") {
                layer.msg('登陆验证失败，请重新登录');
            } else {
                var ReadingSum = 0;
                var ReadVariation = 0;
                var count = 0;
                $ul = '<ul class="Creation_essay_item">';
                $("#Creation_Home_Blog_Box").empty();
                for (var i = 0; i < res.length; i++) {

                    ReadingSum += res[i].BlogClicks;
                    ReadVariation = res[i].BlogClicks - res[i].LastClicks;
                    var BlogID = res[i].BlogID;
                    $.ajax({
                        url: "/api/ApiBlog",
                        data: { BlogID: BlogID },
                        type: "Get",
                        success: function (data) {
                            if (data == "Login") {
                                layer.msg('登陆验证失败，请重新登录');
                            } else {

                                $li1 = '<li><div class="panel-body Home-flex Creation_essay"><ul class="Home-flex"><li><h3><a href="/Blog/detail?Bid=' + res[i].BlogID + '">' + data[i].BlogTitle + '</a></h3><p>' + data[i].BlogDec + '</p></li><li><p>' + data[i].BlogClicks + '</p><p>阅读量</p></li><li><p>' + data[i].CommentsBCount + '</p><p>评论数</p></li><li><p>' + data[i].BlogLike + '</p><p>点赞数</p></li><li><p>' + data[i].FavoriteCount + '</p><p>收藏数</p></li></ul></div ></li >';
                                if (count < 10) {
                                    $ul += $li1;
                                }
                                count++;
                            }
                        }
                    })



                }
                $ul += '</ul>';
                $("#Creation_Home_Blog_Box").append($ul);



                $("#Creation_Reading").html(ReadingSum);
                if (ReadVariation == 0) {
                    $span = "<span>今日无变化</span>"
                } else {
                    $span = "<span>今日阅读量变化：" + ReadVariation + "</span>"
                }

                $("#Creation_Reading_variation").html($span);
            }
        }
    })

    var LastEarningsVariation = 0;

    var LastFollowersVariation = 0;

    var LastCollectionVariation = 0;
    $.ajax({
        url: "/api/ApiCreationUserInfo",
        type: "Get",
        data: { Type: 0 },
        success: function (res) {
            if (res == "Login") {
                layer.msg('登陆验证失败，请重新登录');
            }
            else {
                LastEarningsVariation = res.DownloadKunCoinObtainCount;
                LastFollowersVariation = res.FollowersCount;
                LastCollectionVariation = res.FavoriteCount;
            }
        }
    })
    var LastEarnings = 0;/*总收益*/
    setTimeout(() => {
        $.ajax({
            url: "/api/ApiCreationUserInfo",
            type: "Get",
            data: { Type: 1 },
            success: function (data) {
                if (data == "Login") {
                    layer.msg('登陆验证失败，请重新登录');
                }
                else {
                    LastEarnings = data;
                    $("#Creation_earnings").html(LastEarnings);
                    if (LastEarnings - LastEarningsVariation == 0) {
                        $span = "<span>今日无变化</span>"
                    } else {
                        $span = "<span>今日收益变化：" + (LastEarnings - LastEarningsVariation) + "</span>"
                    }
                    $("#Creation_earnings_variation").html($span);
                }
            }
        })
    }, 500)

    var LastFollowers = 0;
    setTimeout(() => {
        $.ajax({
            url: "/api/ApiCreationUserInfo",
            type: "Get",
            data: { Type: 2 },
            success: function (data) {
                if (data == "Login") {
                    layer.msg('登陆验证失败，请重新登录');
                }
                else {
                    LastFollowers = data;
                    $("#Creation_followers").html(LastFollowers);
                    if (LastFollowers - LastFollowersVariation == 0) {
                        $span = "<span>今日无变化</span>"
                    } else {
                        $span = "<span>今日粉丝变化：" + (LastFollowers - LastFollowersVariation) + "</span>"
                    }
                    $("#Creation_followers_variation").html($span);
                }
            }
        })
    }, 500)


    var LastCollection = 0;
    setTimeout(() => {
        $.ajax({
            url: "/api/ApiCreationUserInfo",
            type: "Get",
            data: { Type: 3 },
            success: function (data) {
                if (data == "Login") {
                    layer.msg('登陆验证失败，请重新登录');
                }
                else {
                    LastCollection = data;
                    $("#Creation_collection").html(LastCollection);
                    if (LastCollection - LastCollectionVariation == 0) {
                        $span = "<span>今日无变化</span>"
                    } else {
                        $span = "<span>今日收藏变化：" + (LastCollection - LastCollectionVariation) + "</span>"
                    }
                    $("#Creation_collection_variation").html($span);
                }
            }
        })
    }, 500)




})