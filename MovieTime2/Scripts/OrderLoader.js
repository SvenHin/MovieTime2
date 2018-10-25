function buildOrderPage() {
    $("#addTable").hide();
    getOrderHeaders();
    getOrderList();
    addOrderPlaceHolder();
    addOrderSearchClass();
    addOrderActive();
}

function addOrderActive() {
    $("#customerPage").removeClass("active");
    $("#moviePage").removeClass("active");
    $("#orderPage").addClass("active");

}

function addOrderSearchClass() {
    $("#searchBtn").removeClass("movieSearchBtn");
    $("#searchBtn").removeClass("customerSearchBtn");
    $("#searchBtn").addClass("orderSearchBtn");
} 
function addOrderPlaceHolder() {
    $("#searchField").attr("placeholder", "Order Id");
}

function getOrderHeaders() {
    var print = "<thead><tr><td>Id</td><td>Date</td><td>Username</td><td></td><td></td><td></td></tr></thead>";
    $("#contentTable").html(print);
}

function getOrderList() {
    $.getJSON("/Admin/getAllOrders",
        function (orders) {
            buildOrderList(orders);
        }
    );
    scrollToTop();
}
function buildOrderList(orders) {
    $("#contentBody").html("");

    for (var i in orders) {
        var string = "<tbody id='" + orders[i].Id + "'> <tr class='selected " + orders[i].Id + "'><th scope='row'>" + orders[i].Id + "</th><td>" + orders[i].Date + "</td><td>" + orders[i].Customer + "</td><td></td><td><button data-type='" + orders[i].Id + "' type='button' class='removeBtnOrder btn btn-danger'>Remove</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='showMoreBtnOrder btn btn-info'>Show more</button></td></tr></tbody> ";
        $("#contentTable").append(string);
        getLineItems(orders[i].Id);
    }

}
function getLineItems(id) {
    $.getJSON("/Admin/getAllLineItems/", {id: id},
        function (lineitems) {
            var targetBody = $('#' + id);
            var titles = "<tr class='slidedown " + id + "'><td></td><td>OrderId</td><td>LineItem Id</td><td>Movie Title</td><td></td><td></td></tr>";
            $(targetBody).append(titles);

            for (var e in lineitems) {
                var newString = "<tr class='slidedown " + id + " lineitem" + lineitems[e].Id + "'><td>Line item</td><th scope='row'>" + lineitems[e].OrderId + "</th><td>" + lineitems[e].Id + "</td > <td>" + lineitems[e].MovieTitle + "</td>  <td><button id='" + id + "' data-type='" + lineitems[e].Id + "' type='button' class='removeBtnLineItem btn btn-danger'>Remove</button></td> <td></td></tr > ";
                $(targetBody).append(newString);
            }

        }
    );

}
function removeLineItem(id, lineid) {
    $.getJSON("/Admin/removeLineItem/" + id,
        function (string) {
            //getOrderHeaders();
            //getOrderList();
            $(".slidedown." + lineid + ".lineitem" + id).remove();
        }
    );
}
function removeOrder(id) {
    $.getJSON("/Admin/removeOrder/" + id,
        function (string) {
            getOrderHeaders();
            getOrderList();
        }
    );
}
$(function () {
    $(document).on("click", ".removeBtnLineItem", function () {
        var id = $(this).attr('data-type');
        var lineid = $(this).attr('id');

        removeLineItem(id, lineid);
    });
});
$(function () {
    $(document).on("click", ".removeBtnOrder", function () {
        var id = $(this).attr('data-type');
        removeOrder(id);
    });
});
$(function () {
    $(document).on("click", ".editBtnOrder", function () {
        var id = $(this).attr('data-type');
        editOrderRow(id);
    });
});
$(function () {
    $(document).on("click", ".saveBtnOrder", function () {
        var id = $(this).attr('data-type');
        saveOrderMovie(id);
    });
});
$(function () {
    $(document).on("click", ".orderSearchBtn", function () {
        var id = $("#searchField").val();
        searchOrder(id);
    });
});

$(function () {
    $(document).on("click", ".showMoreBtnOrder", function () {
        
        var id = $(this).attr('data-type');
        if ($(".slidedown." + id).is(":hidden")) {
            $(".slidedown." + id).fadeIn(200);
            $(this).html("Show less");
            $(".selected." + id).css("background-color", "#070707");

        }
        else {
            $(".slidedown." + id).fadeOut(200);
            $(this).html("Show more");
            $(".selected." + id).css("background-color", "");

        }


    });
});
function searchOrder(id) {
    $.getJSON("/Admin/searchOrder/" + id,
        function (orders) {
            getOrderHeaders();
            buildOrderList(orders);
        }
    );
}

