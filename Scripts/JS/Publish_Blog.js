$(function () {
    var ImageUrl = "";
    function Submit() {
        document.forms.submit();//表单提交
    }
    $("#Blog_Form").bind("submit", function () {
        var filePos = $("#filePos").html();
        if (filePos == "未上传") {
            event.preventDefault();
            layer.msg('请选择上传的封面！');
        } else {
            layer.msg('封面选择成功！');
        }
    })

    //$("#Blog_sub").click(function () {
    //    Submit();
    //});

    //1定义延时器的ID
    var Blogtimer = null;

    //2定义防抖函数
    function debounceSearch(kw) {
        Blogtimer = setTimeout(function () {
            getSuggestList(kw);
        }, 500)
    }


    $("#Blog_Dec").on("keyup", function () {
        //3清空timer
        clearTimeout(Blogtimer);
        var keywords = $(this).val().trim();
        if (keywords.length <= 0) {
            $("#Blog_Des_Prompt").html(" <p style='color: red;'>&nbsp;&nbsp;&nbsp;*****简介不能为空*****</p>");
        } else {
            debounceSearch(keywords);
        }
    })
    function getSuggestList(kw) {

        $("#Blog_Des_Prompt").html(" <p style='color: green;'>&nbsp;&nbsp;&nbsp;提示:" + kw.length + "/100</p>");

    }




    layui.use('layedit', function () {

        var layedit = layui.layedit, element = layui.element;

        //注意：layedit.set 一定要放在 build 前面，否则配置全局接口将无效。

        //layedit.build('Blog_Text'); //建立编辑器
        //构建一个默认的编辑器


        layedit.build('Blog_Text');
        //自定义工具栏
        var index = layedit.build('Blog_Text', {
            height: 500 //设置编辑器高度
            , tool: ['strong', 'italic', 'underline', 'del', '|', 'left', 'center', 'right', '|', 'link', 'unlink']
        });
        setInterval(function () {
            var Content = layedit.getContent(index);
            if (Content == "") {
                element.progress('Blog_Text_Content', '0%')
                $("#Blog_Text_Content").attr('title', "0/4000");
            } else {
                var title = Content.length + "/4000";
                var outcome = ((Content.length / 4000) * 100) + "0";
                if (outcome.charAt(".")) {
                    outcome = outcome.substr(0,outcome.indexOf(".")+2)+"%";
                }
                $("#Blog_Text_Content").attr('title', title);
                if (Content.length > 4000) {
                    $("#Blog_Text_Progress").removeClass("layui-bg-blue");
                    $("#Blog_Text_Progress").addClass("layui-bg-red");
                } else {
                    $("#Blog_Text_Progress").removeClass("layui-bg-red");
                    $("#Blog_Text_Progress").addClass("layui-bg-blue");
                }
                element.progress('Blog_Text_Content', outcome)
                
            }
        }, 3000);



        $('#Blog_Sub').on('click', function () {

            var LabelID = $("#Blog_select").val();




            var BlogDec = $("#Blog_Dec").val().trim();

            var Blogcontent = layedit.getContent(index);
            $.ajax({
                url: "/api/ApiGetImageName",
                type: "Get",
                success: function (res) {
                    ImageUrl = res;
                }
            })

            if (LabelID == "") {
                layer.msg("请选择文章标题！");
            } else
                /*var Blogcontent = layedit.getContent(index);*/
                if (BlogDec == "") {
                    layer.msg("简介不能为空！");
                    $("#Blog_Des_Prompt").html(" <p style='color: red;'>&nbsp;&nbsp;&nbsp;*****简介不能为空*****</p>");
                } else {
                    var BlogCunText = layedit.getText(index)
                    if (Blogcontent == "" || BlogCunText.length < 10 || Blogcontent.length>4000) {
                        layer.msg("博客内容不能低于10个字或者超过4000字");
                    }
                    else {
                        layer.confirm('确认发布博客吗？', {
                            btn: ['确认', '取消'],
                            btn1: function (index, layero, that) {
                                layer.close(index);//关闭最外边的
                                layer.prompt(
                                    {
                                        formType: 0,
                                        value: '我的博客',
                                        title: '输入博客标题!',
                                    },

                                    function (value, index, elem) {
                                        Blogtitle = value;
                                        layer.close(index); // 关闭层标题


                                        var index3;
                                        setTimeout(() => {
                                            index3 = layer.load(2);
                                        }, 100);

                                        setTimeout(() => {

                                            $.ajax({
                                                type: 'Post',
                                                url: '/api/ApiBlog',
                                                data: { LabelID: LabelID, BlogDec: BlogDec, BlogImageUrl: ImageUrl, BlogContent: Blogcontent, BlogTitle: Blogtitle },
                                                dataType: "json",
                                                success: function (res) {
                                                    if (res == "Yes") {
                                                        layer.msg('发布博客成功了！');
                                                    }
                                                    else if (res == "Login") {
                                                        layer.msg('登录信息失效,请前往登录页面登录!');
                                                    } else {
                                                        layer.msg('发布博客失败了。');
                                                    }
                                                }
                                            })
                                            layer.close(index3);
                                        }, 2000);


                                    }
                                );


                            },
                            btn2: function (index, layero, that) {

                                layer.close(index);
                                // 按钮2 的回调
                                // return false // 点击该按钮后不关闭弹层
                            }
                        });
                    }
                }


        });


    });
})