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
}

function ListMovies(movie) {
    var utStreng = "";
    for (var i in movie) {
        utStreng += "<tr><th scope='row'>" + i + "</th><td>" + movie[i].title + "</td><td>" + movie[i].price + "</td></tr>"
    }
    $("#cartTableInput").html(utStreng);
}