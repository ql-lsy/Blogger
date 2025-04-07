$(function () {
    $delB = '<button class="Creation_Content_DelB">删除</button>';
    $(document).on("click", ".Creation_Content_DelB", function () {
        $father = $(this).parent().parent().parent();
        var ID = $father.children().children().html();
        $father.hide();

        $.ajax({
            url: "/DeleteR/Blog",
            data: { Bid: ID },
            type: "Post",
            success: function (res) {
                layer.msg(res);
            }
        })

    })
    $delD = '<button class="Creation_Content_DelD">删除</button>';
    $(document).on("click", ".Creation_Content_DelD", function () {
        $father = $(this).parent().parent().parent();
        var ID = $father.children().children().html();
        $father.hide();

        $.ajax({
            url: "/DeleteR/Down",
            data: { Did: ID },
            type: "Post",
            success: function (res) {
                layer.msg(res);
            }
        })

    })
    $delQ = '<button class="Creation_Content_DelQ">删除</button>';
    $(document).on("click", ".Creation_Content_DelQ", function () {
        $father = $(this).parent().parent().parent();
        var ID = $father.children().children().html();
        $father.hide();

        $.ajax({
            url: "/DeleteR/QA",
            data: { Qid: ID },
            type: "Post",
            success: function (res) {
                layer.msg(res);
            }
        })

    })
    $("#Creation_Content_Blog").click(function () {
        Blog();
    })

    $("#Creation_Content_Down").click(function () {
        Down();
    })
    $("#Creation_Content_QA").click(function () {
        QA();
    })

    function QA() {
        layui.use(function () {
            var table = layui.table, laypage = layui.laypage;
            table.init('Creation_Content_TB', {

                // 其他属性
                // …
                toolbar: true,
                page: true,
                loading: true,
                limit: 10,
                title: '提问',
                skin: 'grid',
                even: true,
                url: "/JsonBlog/GetQA",
                method: "Post",
                cols: [[
                    { field: 'IssueID', title: '编号', sort: true },
                    { field: 'IssueContent', title: '提问内容', sort: true },
                    { field: 'Issuedetails', title: '提问详情', sort: true },
                    { field: 'IssueQuantity', title: '回复数量', sort: true },
                    {
                        fixed: 'right', title: '操作',
                        templet: function (d) {
                            console.log(d); // 得到当前行数据
                            console.log(this); // 得到表头当前列配置项
                            console.log(d.LAY_NUM); // 得到序号。或其他特定字段

                            // 返回模板内容
                            return '<a href="/QA/index?IssueID=' + d.IssueID + '" target="_parent " class="layui-table-link">' + "查看" + '</a> ' + $delQ;
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

    function Down() {
        layui.use(function () {
            var table = layui.table, laypage = layui.laypage;
            table.init('Creation_Content_TB', {

                // 其他属性
                // …
                toolbar: true,
                page: true,
                loading: true,
                limit: 10,
                title: '资源',
                skin: 'grid',
                even: true,
                url: "/JsonBlog/GetDown",
                method: "Post",
                cols: [[
                    { field: 'DownloadID', title: '编号', sort: true },
                    { field: 'DownloadName', title: '资源名称', sort: true },
                    { field: 'DownloadDec', title: '资源简介', sort: true },
                    { field: 'frequency', title: '下载量', sort: true },
                    { field: 'DownloadKunCoin', title: '资源价格', sort: true },
                    { field: 'DownloadKunCoinObtain', title: '收益', sort: true },
                    {
                        fixed: 'right', title: '操作',
                        templet: function (d) {
                            console.log(d); // 得到当前行数据
                            console.log(this); // 得到表头当前列配置项
                            console.log(d.LAY_NUM); // 得到序号。或其他特定字段

                            // 返回模板内容
                            return $delD;
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
    function Blog() {
        layui.use(function () {
            var table = layui.table, laypage = layui.laypage;
            table.init('Creation_Content_TB', {

                // 其他属性
                // …
                toolbar: true,
                page: true,
                loading: true,
                limit: 10,
                title: '博客',
                skin: 'grid',
                even: true,
                url: "/JsonBlog/GetBlog",
                method: "Post",
                cols: [[
                    { field: 'BlogID', title: '编号', sort: true },
                    { field: 'BlogTitle', title: '博客名称', sort: true },
                    { field: 'BlogDec', title: '博客简介', sort: true },
                    { field: 'BlogClicks', title: '阅读量', sort: true },
                    {
                        fixed: 'right', title: '操作',
                        templet: function (d) {
                            console.log(d); // 得到当前行数据
                            console.log(this); // 得到表头当前列配置项
                            console.log(d.LAY_NUM); // 得到序号。或其他特定字段

                            // 返回模板内容
                            return '<a href="/Blog/detail?Bid=' + d.BlogID + '" target="_parent " class="layui-table-link">' + "查看" + '</a> ' + $delB;
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