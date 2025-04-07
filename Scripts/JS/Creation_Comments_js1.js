$(function () {
    $delM = '<button class="Creation_Content_DelM">删除</button>';
    $(document).on("click", ".Creation_Content_DelM", function () {
        $father = $(this).parent().parent().parent();
        var ID = $father.children().children().html();
        $father.hide();

        $.ajax({
            url: "/DeleteR/MyToComments",
            data: { Cid: ID },
            type: "Post",
            success: function (res) {
                layer.msg(res);
            }
        })

    })
    $delT = '<button class="Creation_Content_DelT">删除</button>';
    $(document).on("click", ".Creation_Content_DelT", function () {
        $father = $(this).parent().parent().parent();
        var ID = $father.children().children().html();
        $father.hide();

        $.ajax({
            url: "/DeleteR/ToMyComments",
            data: { Cid: ID },
            type: "Post",
            success: function (res) {
                layer.msg(res);
            }
        })

    })
    $("#Creation_Comments_myto").click(function () {
    
        MyTo();
    })

    $("#Creation_Comments_tomy").click(function () {
  
        ToMy();
    })

    function MyTo() {
        layui.use(function () {
            var table = layui.table, laypage = layui.laypage;
            table.init('Creation_Comments_TB', {

                // 其他属性
                // …
                toolbar: true,
                page: true,
                loading: true,
                limit: 10,
                title: '我的评论',
                skin: 'grid',
                even: true,
                url: "/JsonBlog/GetCommentsMyTo",
                method: "Post",
                cols: [[
                    { field: 'CommentsBID', title: '编号', sort: true },
                    { field: 'BlogTitle', title: '博客标题', sort: true },
                    { field: 'BlogDec', title: '博客简介', sort: true },
                    { field: 'CommentsBContent', title: '评论内容', sort: true },
                    { field: 'CommentsBLike', title: '评论获赞', sort: true },
                    {
                        fixed: 'right', title: '操作',
                        templet: function (d) {
                            // 返回模板内容
                            return '<a href="/Blog/detail?Bid=' + d.BlogID + '" target="_parent " class="layui-table-link">' + "查看" + '</a> ' + $delM;
                        }
                    }
                ]],
                request: {
                    pageName: 'curr', // 页码的参数名称，默认：page
                    limitName: 'nums' // 每页数据条数的参数名，默认：limit
                }
            });

        });

        table.reloadData(id, options, deep);

    }


    function ToMy() {
        layui.use(function () {
            var table = layui.table, laypage = layui.laypage;
            table.init('Creation_Comments_TB', {

                // 其他属性
                // …
                toolbar: true,
                page: true,
                loading: true,
                limit: 10,
                title: '我的评论',
                skin: 'grid',
                even: true,
                url: "/JsonBlog/GetCommentsToMy",
                method: "Post",
                cols: [[
                    { field: 'CommentsBID', title: '编号', sort: true },
                    { field: 'BlogTitle', title: '博客标题', sort: true },
                    { field: 'BlogDec', title: '博客简介', sort: true },
                    { field: 'CommentsBContent', title: '评论内容', sort: true },
                    { field: 'CommentsBLike', title: '评论获赞', sort: true },
                    {
                        title: '评论人', sort: true,
                        templet: function (d) {

                            return '<a  href="/Personal/UserCenter?uid=' + d.UserID + '"  target="_parent "   >' + d.UserName +'</a>'
                        }
                    },
                    {
                        fixed: 'right', title: '操作',
                        templet: function (d) {
                            console.log(d); // 得到当前行数据
                            console.log(this); // 得到表头当前列配置项
                            console.log(d.LAY_NUM); // 得到序号。或其他特定字段

                            // 返回模板内容
                            return '<a href="/Blog/detail?Bid=' + d.BlogID + '" target="_parent " class="layui-table-link">' + "查看" + '</a> ' + $delT;
                        }
                    },

                    // …
                ]],
                request: {
                    pageName: 'curr', // 页码的参数名称，默认：page
                    limitName: 'nums' // 每页数据条数的参数名，默认：limit
                }
            });

        });

        table.reloadData(id, options, deep);

    }

})