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
    var print = "<thead><tr><td>Order</td><td>Id</td><td>Date</td><td>Username</td><td></td><td></td><td></td></tr></thead>";
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
        var string = "<tbody id='" + orders[i].Id + "'> <tr><td></td><th scope='row'>" + orders[i].Id + "</th><td>" + orders[i].Date + "</td><td>" + orders[i].Customer + "</td><td><button data-type='" + orders[i].Id + "' type='button' class='editBtnOrder btn btn-warning'>Edit</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='removeBtnOrder btn btn-danger'>Remove</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='showMoreBtnOrder btn btn-info'>Show more</button></td></tr></tbody> ";
        $("#contentTable").append(string);
        getLineItems(orders[i].Id);
    }

}
function getLineItems(id) {
    $.getJSON("/Admin/getAllLineItems/", {id: id},
        function (lineitems) {
            var targetBody = $('#' + id);
            var titles = "<tr class='slidedown " + id + "'><td>Line items</td><td>OrderId</td><td>LineItem Id</td><td>Movie Title</td><td></td><td></td><td></td></tr>";
            $(targetBody).append(titles);

            for (var e in lineitems) {
                var newString = "<tr class='slidedown " + id + "'><td></td><th scope='row'>" + lineitems[e].OrderId + "</th><td>" + lineitems[e].Id + "</td > <td>" + lineitems[e].MovieTitle + "</td> <td></td> <td><button data-type='" + lineitems[e].Id + "' type='button' class='removeBtnLineItem btn btn-danger'>Remove</button></td> <td></td></tr > ";
                $(targetBody).append(newString);
            }

        }
    );
}

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
    $(document).on("click", ".showMoreBtnOrder", function () {
        

        var id = $(this).attr('data-type');
        $(".slidedown." + id).toggle();
        if ($(".slidedown." + id).is(":hidden")) {
            $(this).html("Show more");

        }
        else {
            $(this).html("Show less");
        }


    });
});
$(function () {
    $(document).on("click", ".orderSearchBtn", function () {
        var title = $("#searchField").val();
        searchOrder(title);
    });
});
/* Animation, doesnt work like planned
 * 
 * $(function () {
    $(document).on("click", "thead", function () {
        $(this).parent().next("div").slideToggle(200);

    });
});
function getOrderList() {
    $.ajax({
        url: '/Admin/getAllOrders',
        type: 'GET',
        dataType: 'json',
        success: function (orders) {

            for (var i in orders) {
                var string = "";
                var string2 = "";
                string += "<table class='table table-dark'><thead><tr id='" + orders[i].Id + "'><td colspan='2'>" + orders[i].Id + "</td><td colspan='2'>" + orders[i].Date + "</td><td colspan='2'>" + orders[i].Customer + "</td><td colspan='1'><button data-type='" + orders[i].Id + "' type='button' class='editBtnOrder btn btn-warning'>Edit</button></td><td colspan='1'><button data-type='" + orders[i].Id + "' type='button' class='removeBtnOrder btn btn-danger'>Remove</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='showMoreBtnOrder btn btn-info'>Show More</button></td></tr></thead></table>";
                $("#orderList").append(string);

                string2 += "<div><table><tbody><tr><td>ITEM</td><td>ITEM</td><td>ITEM</td></tr></tbody></table></div>";
                $("#orderList").append(string2);

            }
            scrollToTop();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function getOrderList() {
    $.ajax({
        url: '/Admin/getAllOrders',
        type: 'GET',
        dataType: 'json',
        success: function (orders) {
            var string = "";

            for (var i in orders) {
                string += "<tr id='" + orders[i].Id + "'><th scope='row'>" + orders[i].Id + "</th><td>" + orders[i].Date + "</td><td>" + orders[i].Customer + "</td><td><button data-type='" + orders[i].Id + "' type='button' class='editBtnOrder btn btn-warning'>Edit</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='removeBtnOrder btn btn-danger'>Remove</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='showMoreBtnOrder btn btn-info'>Show more</button></td></tr>"
                $.getJSON("/Admin/getAllLineItems/" + orders[i].Id,
                    function (lineitems) {
                        for (var e in lineitems) {
                            string += "<tr id='" + 1 + orders[i].Id + "'><th scope'row'>LineItem</th><td>" + lineitems[e].Id + "</td > <td></td> <td></td> <td></td> <td></td></tr > ";
                        }

                    }
                );
            }
            $("#contentBody").html("");
            $("#contentBody").html(string);

            scrollToTop();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}*/

