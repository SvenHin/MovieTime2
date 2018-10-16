function getMovieList() {
    $.ajax({
        url: '/Admin/getAllMovies',
        type: 'GET',
        dataType: 'json',
        success: function (movies) {
            var utStreng = "";
            for (var i in movies) {
                utStreng += "<tr><th scope='row'>" + movies[i].id + "</th><td>" + movies[i].title + "</td><td>" + movies[i].summary + "</td><td>" + movies[i].price + "</td><td>" + movies[i].imageURL + "</td><td><button id='" + i + "' type='button' class='editBtn btn btn-warning'>Edit</button><button id='" + i + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").append(utStreng);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}


