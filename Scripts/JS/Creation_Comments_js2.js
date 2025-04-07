layui.use(function () {
    var table = layui.table, laypage = layui.laypage;
    $delM = '<button class="Creation_Content_DelM">删除</button>';
    //$(document).on("click", ".Creation_Content_DelM", function () {
    //    $father = $(this).parent().parent().parent();
    //    var ID = $father.children().children().html();
    //    $father.hide();

    //    $.ajax({
    //        url: "/DeleteR/MyToComments",
    //        data: { Cid: ID },
    //        type: "Post",
    //        success: function (res) {
    //            layer.msg(res);
    //        }
    //    })

    //})
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