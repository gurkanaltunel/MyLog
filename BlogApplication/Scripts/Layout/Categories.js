var Category = {
    init: function () {
    },

    GetCategory: function(id) {
            var params = {};
            params["id"] = id;
            $.ajax({
                method: 'POST',
                url: '/Home/ArticleCategory',
                data: params,
                dataType: 'html',
                success: function(response) {
                    $('.span9').empty().html(response);
                },
                error: function(error) {

                },
                complete: function() {

                }
            });
    },
    Search: function (word) {
        var params = {};
        params["SearchWord"] = word;
        $.ajax({
            method: 'POST',
            url: '/Search/Search',
            data: params,
            dataType: 'html',
            success: function (response) {
                $('.span9').empty().html(response);
            },
            error: function (error) {
            },
            complete: function () {
            }
        });
    }  
};

$(document).ready(function () {
    Category.init();
});
