$(document.body).on("click", "#Id", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductPartialDetail";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});

$(document.body).on("click", "#GetCategoryId", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductsByCategoriy";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});

$(document.body).on("click", "#GetBrandId", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductsByBrand";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});

$(document.body).on("click", "#GetTypeId", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductsByType";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});

$(document.body).on("click", "#GetPriceId", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductsByPrice";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});  
$(document.body).on("click", "#GetColourId", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductsByColour";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});
$(document.body).on("click", "#GetSizeId", function () {
    var Id = $(this).attr("data-Id");
    var url = "/../../Products/ProductsBySize";
    var params = { id: Id };
    $.get(url, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#ProductDiv").html(rData);
        }
    });
});
//$(document.body).on("click", "#ProductId", function () {
//    var Id = $(this).attr("data-Id");
//    var url = "/../../Products/ProductPartialDetailFromCategory";
//    var params = { id: Id };
//    $.get(url, params, function (rData) {
//        if (rData != undefined && rData != "") {
//            $("#ProductDiv").html(rData);
//        }
//    });
//});

//$(document.body).on("click", "#ProducDetailtId", function () {
//    var Id = $(this).attr("data-Id");
//    var url = "/../../Products/ProductsByCategoriy";
//    var params = { id: Id };
//    $.get(url, params, function (rData) {
//        if (rData != undefined && rData != "") {
//            $("#ProductListDiv").html(rData);
//        }
//    });
//});



