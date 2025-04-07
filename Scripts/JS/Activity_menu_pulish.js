document.addEventListener('DOMContentLoaded', function () {
    // 获取所有下拉菜单的父元素
    var menuItems = document.querySelectorAll('.layui-menu-item-down');

    // 为每个下拉菜单项添加点击事件
    menuItems.forEach(function (item) {
        var arrow = item.querySelector('.layui-icon');  // 获取箭头元素

        item.addEventListener('click', function (event) {
            // 阻止事件冒泡，避免点击子菜单时关闭父菜单
            event.stopPropagation();

            // 切换当前菜单的展开/收起状态
            item.classList.toggle('layui-menu-item-show');
            if (item.classList.contains('layui-menu-item-show')) {
                arrow.classList.remove('layui-icon-up');
                arrow.classList.add('layui-icon-down'); // 改为向下箭头
            } else {
                arrow.classList.remove('layui-icon-down');
                arrow.classList.add('layui-icon-up'); // 改为向上箭头
            }
        });

        // 添加子菜单项点击事件，防止父菜单关闭
        var subMenuItems = item.querySelectorAll('li');
        subMenuItems.forEach(function (subMenuItem) {
            subMenuItem.addEventListener('click', function (event) {
                // 阻止点击子菜单时触发父菜单的收起
                event.stopPropagation();
                // 在这里可以处理子菜单项的其他行为，比如跳转或者显示内容
                console.log('点击了子菜单项: ', subMenuItem.textContent);
            });
        });
    });
});