// Customer Stuff
function getCustomerList() {
    $.ajax({
        url: '/Admin/getAllCustomers',
        type: 'GET',
        dataType: 'json',
        success: function (customers) {
            var utStreng = "";
            var counter = 0;
            for (var i in customers) {
                counter++;
                utStreng += "<tr id='" + customers[i].Id + "'><th scope='row'>" + customers[i].Id + "</th><td>" + customers[i].FirstName + "</td><td>" + customers[i].LastName + "</td><td>" + customers[i].Address + "</td><td>" + customers[i].Location + "</td><td>" + customers[i].ZipCode + "</td><td>" + customers[i].PhoneNumber + "</td><td>" + customers[i].Email + "</td><td>" + customers[i].Username + "</td><td><button data-type='" + counter + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + counter + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").html(utStreng);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}
