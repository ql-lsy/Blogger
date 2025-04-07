$(function () {
    layui.use(function () {
        var layer = layui.layer;
        var util = layui.util;
        var $ = layui.$;
        // 事件
        var End = 1;
        var index = 0;
        function GG() {
            // 弹出位置
            index = layer.open({
                title: false,
                type: 1,
                offset: 'rb' || ['200px', '280px'], // 详细可参考 offset 属性
                id: 'ID-GG-layer-offset', // 防止重复弹出
                content: '<div class="Home_GG_BOX" style="padding: 2px;"><h1>广告位</h1></div>',
                area: '240px',
                anim: 2,
                closeBtn: 1,
                isOutAnim: true,
                time: 5000,
                shade: 0, // 不显示遮罩
                cancel: function (index, layero, that) {
                    layer.close(index);
                },
                end: function () {
                    if (End == 0) {
                        GG1();
                    }
                }

            });

        }


        function GG1() {
            index = layer.open({
                title: false,
                type: 1,
                offset: 'lb' || ['200px', '280px'], // 详细可参考 offset 属性
                id: 'ID-GG-layer-offset', // 防止重复弹出
                content: '<div class="Home_GG_BOX" style="padding: 30px;"><video  muted  autoplay="autoplay" loop="loop" style="height:100%;width:100%;"><source src="../img/jntm.mp4" type="video/mp4" /></video></div>',
                area: '240px',
                anim: 2,
                closeBtn: 1,
                isOutAnim: true,
                time: 5000,
                shade: 0, // 不显示遮罩
                cancel: function (index, layero, that) {
                    layer.close(index);
                },
                end: function () {
                    if (End == 0) {
                        GG();
                    }
                }

            });
        }
        setTimeout(function () {
            GG();
        }, 10000);
 
        var Help = 0;
        $(document).keydown(function (event) {
            if (event.keyCode == 74) {
                Help++;
            } else if (event.keyCode == 78) {
                Help++;
            } else if (event.keyCode == 84) {
                Help++;
            } else if (event.keyCode == 77) {
                Help++;
            } else {
                Help = 0;
            }
            if (Help == 4) {
                End++;
            }

        });


    });
    $(document).mousemove(function (e) {
        $("#mouseXY").css("display", "block");
        $("#mouseXY").css("pointer-events", "none");
        $("#mouseXY").css({ "position": "fixed", "left": e.pageX, "top": e.pageY });
    });

})