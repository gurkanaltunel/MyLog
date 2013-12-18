$(document).ready(function () {  
    $("#btnSubmitComment").click(function () {
        var comment = $("#txtComment").val();
        var id = $("#articleId").val();
        var commentOwner = $("#commentOwner").val();
        JSONstring = JSON.stringify(comment);
        $.post('/Home/AddComment', { jsonData: JSONstring, id: id ,commentOwner:commentOwner},location.reload());
    });
    $("#categories li").click(function () {
        $("#categories li").removeClass("active");
        $(this).addClass("active");
    });
    $("#MenuItems li").click(function () {
        $("#MenuItems li").removeClass("active");
        $(this).addClass("active");
        Category.ReturnProjectView();
    });
    $("#btnSearch").click(function () {
        var searchWord = $("#txtSearch").val();
        Category.Search(searchWord);
    });
});