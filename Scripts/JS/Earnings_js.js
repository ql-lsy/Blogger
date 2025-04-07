$(function () {

    $.ajax({
        url: "/api/ApiRDownLoad",
        type: "Get",
        success: function (res) {

            if (res == "Login") {

            } else {
                if (res.length > 0) {
                    var count = 0;
                    var TimeBig = res[0].BlogTime;
                    var yearBig = TimeBig.substring(0, TimeBig.indexOf("-")) + "年";
                    var TimeBig = TimeBig.substring(0, TimeBig.indexOf("T"));
                    var Mo = TimeBig.substring(TimeBig.indexOf("-") + 1, TimeBig.lastIndexOf("-")) + "月" + TimeBig.substring(TimeBig.lastIndexOf("-") + 1, TimeBig.length) + "日";

                    if (Mo.indexOf("0") == 0) {
                        Mo = Mo.substring(1, Mo.length);
                    }

                    $html = '<div class="layui-timeline">';
                    $html += ' <h1>' + yearBig + '</h1>' + '<hr class="layui-border-green">';



                    for (var i = 0; i < res.length; i++) {
                        var Time = res[i].BlogTime;
                        var start = Time.indexOf("T");
                        var Time = Time.substring(0, start);
                        outcome = Time.substring(Time.indexOf("-") + 1, Time.lastIndexOf("-")) + "月" + Time.substring(Time.lastIndexOf("-") + 1, Time.length) + "日";

                        if (outcome.indexOf("0") == 0) {
                            outcome = outcome.substring(1, outcome.length);
                        }
                        var year = Time.substring(0, Time.indexOf("-")) + "年";
                        if (year != yearBig) {
                            yearBig = year;
                            $html += ' <h1>' + yearBig + '</h1> <hr class="layui-border-green">';
                        }

                        if (Mo == outcome && count == 0) {

                            count++;
                            $html += '<div class="layui-timeline-item"><i class="layui-icon layui-timeline-axis" ></i><div class="layui-timeline-content layui-text">';

                            $html += '<h3 class="layui-timeline-title">' + outcome + '</h3>';
                            $html += '<p>发布博客:<a  target="_blank " href="/Blog/detail?Bid=' + res[i].BlogID + '">' + res[i].BlogTitle + '</a><i class="layui-icon"></i>';
                        } else if (Mo == outcome) {

                            count++;
                            $html += '</br>发布博客:<a  target="_blank "  href="/Blog/detail?Bid=' + res[i].BlogID + '">' + res[i].BlogTitle + '</a></i>';
                        } else {

                            count = 0;
                            Mo = outcome;
                            $html += '</p></div></div > ';

                            count++;
                            $html += '<div class="layui-timeline-item"><i class="layui-icon layui-timeline-axis" ></i><div class="layui-timeline-content layui-text">';

                            $html += '<h3 class="layui-timeline-title">' + outcome + '</h3>';
                            $html += '<p>发布博客:<a  target="_blank "  href="/Blog/detail?Bid=' + res[i].BlogID + '">' + res[i].BlogTitle + '</a><i class="layui-icon"></i>';




                        }
                        if (i == res.length - 1) {
                            $html += '</div>';
                            $html += '</div><div class="layui-timeline-item"><i class="layui-icon layui-timeline-axis" ></i><div class="layui-timeline-content layui-text"><div class="layui-timeline-title">现在</div></div></div > ';
                        }



                    }

                    $("#Earnings_TimeLine").empty().append($html);
                }
            }

        }
    })


})