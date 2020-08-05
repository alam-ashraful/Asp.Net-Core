var ajaxLiveSearch = function (id, reqUrl, cType, rUrl ="home/index/") {
    $("#" + id).keyup(function () {
        $.ajax({
            url: reqUrl + $(this).val(),
            contentType: cType,
            success: function (res) {
                $(".fun-result").remove();
                $.each(res, function (key, val) {
                    $("#" + id).after("<a target='_blank' class='fun-result' href='" + rUrl + val['id'] + "'>" + val['name'] + "</a>");
                });
            },
            error: function () {
                $(".fun-result").remove();
            }
        });
    });
};