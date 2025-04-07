layui.use('dropdown', function () {
    var dropdown = layui.dropdown
    dropdown.render({
        elem: '#Creation_publish' //可绑定在任意元素中，此处以上述按钮为例
        , data: [{
            title: '发布博客'
            , id: 1
            , href: '../Publish/Blog'
            , target: '_blank' //新窗口方式打开

        }, {
            title: '上传资源'
            , id: 2
            , href: '../Publish/Update' //开启超链接
            , target: '_blank' //新窗口方式打开  

        }, {
            title: '提出问题'
            , id: 3
            , href: '../QA/Seek_help' //开启超链接
            , target: '_blank' //新窗口方式打开

        }]
        , id: 'Creation_publish'
        //菜单被点击的事件
        , click: function (data) {
            console.log(data.href);
        }
        , style: " width:10%;width:;position:fixed; top:0;left: 0; "
    });
});