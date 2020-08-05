var Check = function (text_one, text_two) {
    if (text_one.indexOf(text_two) !== -1) {
        return true;
    }
}

var ajaxLiveSearch_kuruma = function (id, reqUrl, cType, rUrl = "home/index/") {
    $("#" + id).keyup(function () {
        var searchText = $("#" + id).val().toLowerCase();

        $.ajax({
            url: reqUrl + searchText,
            contentType: cType,
            success: function (res) {
                $(".fun-result").remove();

                $.each(res, function (key, val) {
                    $("#" + id).after("<a target='_blank' class='fun-result' href='" + rUrl + val['id'] + "'>" + val['manufacturer'] + "</a>" + " ");
                });

                $(".Search").each(function () {
                    if (!Check($(this).text().toLowerCase(), searchText)) {
                        $(this).hide();
                    }
                    else {
                        $(this).show();
                        PopulationChart(res);
                    }
                });
            },
            error: function () {
                $(".fun-result").remove();
            }
        });
    });
};