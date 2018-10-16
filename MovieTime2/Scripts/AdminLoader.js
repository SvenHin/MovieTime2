function getMovieHeaderList() {
    $.ajax({
        url: '/Admin/getAllMovieHeaders',
        type: 'GET',
        dataType: 'json',
        success: function (headers) {
            var utStreng = "<tr>";
            for (var i in headers) {
                utStreng += "<th scope='col'>" + headers[i] + "</th>"
            }

            utStreng += "<th schope='col'></th><th schope='col'></th></tr>";
            $("#contentHead").append(utStreng);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function getMovieList() {
    $.ajax({
        url: '/Admin/getAllMovies',
        type: 'GET',
        dataType: 'json',
        success: function (movies) {
            var utStreng = "";
            var counter = 0;
            for (var i in movies) {
                counter++;
                utStreng += "<tr><th scope='row'>" + movies[i].id + "</th><td>" + movies[i].title + "</td><td>" + movies[i].summary + "</td><td>" + movies[i].price + "</td><td>" + movies[i].imageURL + "</td><td><button data-type='" + counter + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + counter + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").append(utStreng);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}
$(function () {
    $(document).on("click", ".removeBtn", function () {
        var id = $(this).attr('data-type');
        alert(id);
    });
});
$(function () {
    $(document).on("click", ".editBtn", function () {
        var id = $(this).attr('data-type');
        alert(id);
    });
});


