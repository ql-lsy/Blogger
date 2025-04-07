$(function () {
    $(document).ready(function () {
        // 点击菜单项时切换内容
        $('#Activity_Home').click(function () {
            // 显示活动中心内容，隐藏其他内容
            $('#Creation_app').show();
            $('#volunteer_content, #academic_content, #art_content, #entrepreneurship_content, #management_content, #number_content').hide();
        });

        $('#Creation_Opus').click(function () {
            // 显示志愿活动内容，隐藏其他内容
            $('#volunteer_content').show();
            $('#Creation_app, #academic_content, #art_content, #entrepreneurship_content, #management_content, #number_content').hide();
        });

        $('#Creation_Earnings').click(function () {
            // 显示学术活动内容，隐藏其他内容
            $('#academic_content').show();
            $('#Creation_app, #volunteer_content, #art_content, #entrepreneurship_content, #management_content, #number_content').hide();
        });

        $('#Creation_Other').click(function () {
            // 显示文艺活动内容，隐藏其他内容
            $('#art_content').show();
            $('#Creation_app, #volunteer_content, #academic_content, #entrepreneurship_content, #management_content, #number_content').hide();
        });

        $('#Creation_Followers').click(function () {
            // 显示创新创业活动内容，隐藏其他内容
            $('#entrepreneurship_content').show();
            $('#Creation_app, #volunteer_content, #academic_content, #art_content, #management_content, #number_content').hide();
        });

        $('#Creation_Management').click(function () {
            // 显示内容管理，隐藏其他内容
            $('#management_content').show();
            $('#Creation_app, #volunteer_content, #academic_content, #art_content, #entrepreneurship_content, #number_content').hide();
        });

        $('#Creation_number').click(function () {
            // 显示报名人员，隐藏其他内容
            $('#number_content').show();
            $('#Creation_app, #volunteer_content, #academic_content, #art_content, #entrepreneurship_content, #management_content').hide();
        });

        // 默认显示活动中心内容，其他内容隐藏
        $('#Creation_app').show();
        $('#volunteer_content, #academic_content, #art_content, #entrepreneurship_content, #management_content, #number_content').hide();
    });
});