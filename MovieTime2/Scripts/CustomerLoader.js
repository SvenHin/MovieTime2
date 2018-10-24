// Customer Stuff

//when the customer button on the sidebar is clicked


function buildCustomerPage() {
    $("#addTable").hide();
    getCustomerHeaders();
    getCustomerList();
    addCustomerSearchClass();
    addCustomerPlaceHolder();
    addCustomerActive();

}

function addCustomerActive() {
    $("#orderPage").removeClass("active");
    $("#moviePage").removeClass("active");
    $("#customerPage").addClass("active");

}

function addCustomerSearchClass() {
    $("#searchBtn").removeClass("movieSearchBtn");
    $("#searchBtn").removeClass("orderSearchBtn");
    $("#searchBtn").addClass("customerSearchBtn");
}
function addCustomerPlaceHolder() {
    $("#searchField").attr("placeholder", "Username");
}

function getCustomerHeaders() {
    var print = "<tr><td>Id</td><td>Username</td><td>First Name</td><td>Last Name</td><td>Address</td><td>City</td><td>Zip Code</td><td>Phone Number</td><td>Email</td><td></td><td></td></tr>";
    $("#contentHead").html(print);
}

function getCustomerList() {
    $.ajax({
        url: '/Admin/getAllCustomers',
        type: 'GET',
        dataType: 'json',
        success: function (customers) {
            var string = "";
            for (var i in customers) {
                string += "<tr id='" + customers[i].Id + "'><th scope='row'>" + customers[i].Id + "</th><td>" + customers[i].Username + "</td><td>" + customers[i].FirstName + "</td><td>" + customers[i].LastName + "</td><td>" + customers[i].Address + "</td><td>" + customers[i].Location + "</td><td>" + customers[i].ZipCode + "</td><td>" + customers[i].PhoneNumber + "</td><td>" + customers[i].Email + "</td><td><button data-type='" + customers[i].Id + "' type='button' class='editBtnCustomer btn btn-warning'>Edit</button></td><td><button data-type='" + customers[i].Id + "' type='button' class='removeBtnCustomer btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").html(string);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}
function searchCustomer(username) {

    $.ajax({
        url: '/Admin/searchCustomer',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: { 'username': username },
        success: function (customers) {
            var utStreng = "";
            for (var i in customers) {
                utStreng += "<tr id='" + customers[i].Id + "'><th scope='row'>" + customers[i].Id + "</th><td>" + customers[i].Username + "</td><td>" + customers[i].FirstName + "</td><td>" + customers[i].LastName + "</td><td>" + customers[i].Address + "</td><td>" + customers[i].Location + "</td><td>" + customers[i].ZipCode + "</td><td>" + customers[i].PhoneNumber + "</td><td>" + customers[i].Email + "</td><td><button data-type='" + customers[i].Id + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + customers[i].Id + "' type='button' class='removeBtnCustomer btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").html(utStreng);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}


//remove methods
function removeCustomer(id) {
    $.getJSON("/Admin/removeCustomer/" + id,
        function (string) {
            getCustomerList();
        }
    );
}

$(function () {
    $(document).on("click", ".editBtnCustomer", function () {
        var id = $(this).attr('data-type');
        editCustomerRow(id);
    });
});
$(function () {
    $(document).on("click", ".saveBtnCustomer", function () {
        var id = $(this).attr('data-type');
        saveEditedCustomer(id);
    });
});
$(function () {
    $(document).on("click", ".removeBtnCustomer", function () {
        var id = $(this).attr('data-type');
        removeCustomer(id);
    });
});
$(function () {
    $(document).on("click", ".customerSearchBtn", function () {
        var username = $("#searchField").val();
        searchCustomer(username);
    });
});

function saveEditedCustomer(id) {

    var jsIn = {
        Id: id,
        Username: $("#editUsername").val(),
        FirstName: $("#editFirstName").val(),
        LastName: $("#editLastName").val(),
        Address: $("#editAddress").val(),
        Location: $("#editLocation").val(),
        ZipCode: $("#editZipCode").val(),
        PhoneNumber: $("#editPhoneNumber").val(),
        Email: $("#editEmail").val(),

    }

    $.ajax({
        url: '/Admin/editCustomer',
        type: 'POST',
        data: JSON.stringify(jsIn),
        contentType: "application/json;charset=utf-8",
        success: function (ok) {
            if (ok == "false") {
                alert("Could not save edited customer");
            }
            else {
                window.location.reload();
            }
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}

function editCustomerRow(id) {
    var editRow = $('#' + id);
    var dynamicRow = "<th scope='row'>" + id + "</th><td><input type='text' id='editUsername' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editFirstName' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editLastName' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editAddress' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editLocation' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editZipCode' style='width: 100%;' class='borderStyle'/></td><td><input type='text' id='editPhoneNumber' style='width: 100%;' class='borderStyle'/></td><td><input type='text' id='editEmail' style='width: 100%;' class='borderStyle'/></td><td><button data-type='" + id + "' type='button' class='saveBtnCustomer btn btn-success'>Save</button></td>";
    $(editRow).html(dynamicRow);
}