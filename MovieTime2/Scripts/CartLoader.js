function IsLoggedIn() {
    $.getJSON("/AddToCart/isLoggedIn",
        function (string) {
            if (string == "YES") {
                buyButton();
            }
            else {
                buyButtonNo();
            }
        }
    );
}

function buyButton() {
    $("#pleaseLogInText").hide();
    $("#confirmBuy").show();
}

function buyButtonNo() {
    $("#confirmBuy").hide();
    $("#pleaseLogInText").show();
}

function GetMovies() {
    $.ajax({
        url: '/AddToCart/getMoviesFromCart/',
        type: 'GET',
        dataType: 'json',
        success: function (movie) {
            ListMovies(movie);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
};

function ListMovies(movie) {
    var utStreng = "";
    var counter = 0;
    for (var i in movie) {
        counter++;
        utStreng += "<tr><th scope='row'>" + counter + "</th><td>" + movie[i].title + "</td><td>" + movie[i].price + "</td><td><button id='"+ i + "' type='button' class='removeBtn btn btn-danger'>Remove</button></tr>"
    }
    
    $("#cartTableInput").html(utStreng);
};

$(function () {
    $(document).on("click", ".removeBtn", function () {
        var id = $(this).attr('id');
        RemoveFromCart(id);
    });
});

function RemoveFromCart(id) {
    $.ajax({
        url: '/AddToCart/RemoveFromCart/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (string) {
            GetMovies();
            updateCart();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
};