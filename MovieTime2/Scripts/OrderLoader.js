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
    $("#searchField").attr("placeholder", "Username");
}

function getOrderHeaders() {
    var print = "<tr><td>Id</td><td>Date</td><td>Username</td></tr>";
    $("#contentHead").html(print);
}

function getOrderList() {
    $.ajax({
        url: '/Admin/getAllOrders',
        type: 'GET',
        dataType: 'json',
        success: function (orders) {
            var string = "";
            for (var i in orders) {
                string += "<tr id='" + orders[i].Id + "'><th scope='row'>" + orders[i].Id + "</th><td>" + orders[i].Date + "</td><td>" + orders[i].Customer + "</td><td><button data-type='" + orders[i].Id + "' type='button' class='editBtnOrder btn btn-warning'>Edit</button></td><td><button data-type='" + orders[i].Id + "' type='button' class='removeBtnOrder btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").html(string);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}

$(function () {
    $(document).on("click", ".removeBtnOrder", function () {
        var id = $(this).attr('data-type');
        removeOrder(id);
    });
});


function removeOrder(id) {
    $.getJSON("/Admin/removeOrder/" + id,
        function (string) {
            getOrderList();
        }
    );
}



