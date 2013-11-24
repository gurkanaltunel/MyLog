$(document).ready(function () {  
    $("#btnSubmitComment").click(function () {
        var comment = $("#txtComment").val();
        var id = $("#articleId").val();
        var commentOwner = $("#commentOwner").val();
        JSONstring = JSON.stringify(comment);
        $.post('/Home/AddComment', { jsonData: JSONstring, id: id ,commentOwner:commentOwner});
    });
    $(".nav nav-pills nav-stacked a").click(function () {
        var parentTag = $(this).parent();
        parentTag.addClass("active");
    });
});