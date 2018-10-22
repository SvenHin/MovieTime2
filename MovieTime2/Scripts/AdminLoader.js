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
            $("#contentHead").html(utStreng);
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
                utStreng += "<tr id='" + movies[i].id + "'><th scope='row'>" + movies[i].id + "</th><td>" + movies[i].title + "</td><td>" + movies[i].summary + "</td><td>" + movies[i].price + "</td><td>" + movies[i].imageURL + "</td><td><button data-type='" + counter + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + counter + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").html(utStreng);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}
$(function () {
    $(document).on("click", ".removeBtn", function () {
        var id = $(this).attr('data-type');
        removeMovie(id);
    });
});
$(function () {
    $(document).on("click", ".editBtn", function () {
        var id = $(this).attr('data-type');
        editMovieRow(id);
    });
});
$(function () {
    $(document).on("click", ".saveBtn", function () {
        var id = $(this).attr('data-type');
        saveEditedMovie(id);
    });
});
$(function () {
    $(document).on("click", ".searchBtn", function () {
        var movie = $("#searchMovieField").val();
        searchMovie(movie);
    });
});
$(function () {
    $("#Add").click(function () {

        // bygg et js objekt fra input feltene
        var jsInn = {
            title: $("#Title").val(),
            summary: $("#Summary").val(),
            price: $("#Price").val(),
            imageURL: $("#Url").val(),
            genre: $("#Genre1").val(),
            genre2: $("#Genre2").val(),

        }

        $.ajax({
            url: '/Admin/addMovie',
            type: 'POST',
            data: JSON.stringify(jsInn),
            contentType: "application/json;charset=utf-8",
            success: function (ok) {
                // kunne ha feilhåndtert evt. feil i registreringen her
                if (ok == "false") {
                    alert("Could not add movie, needs at least one genre");
                }
                else {
                    window.location.reload();
                }
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    })

});
function removeMovie(id) {
    $.getJSON("/Admin/removeMovie/" + id,
        function (string) {
            alert(string);
            getMovieList();
        }
    );
}

function saveEditedMovie(id) {

        // bygg et js objekt fra input feltene
    var jsIn = {
            id : id,
            title: $("#editTitle").val(),
            summary: $("#editSummary").val(),
            price: $("#editPrice").val(),
            imageURL: $("#editUrl").val(),
            genre: $("#editGenre1").val(),
            genre2: $("#editGenre2").val(),

        }

        $.ajax({
            url: '/Admin/editMovie',
            type: 'POST',
            data: JSON.stringify(jsIn),
            contentType: "application/json;charset=utf-8",
            success: function (ok) {
                // kunne ha feilhåndtert evt. feil i registreringen her
                if (ok == "false") {
                    alert("Could not save edited movie");
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

function editMovieRow(id) {
    var editRow = $('#' + id);
    var dynamicRow = "<th scope='row'>" + id + "</th><td><input type='text' id='editTitle' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editSummary' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editPrice' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editUrl' style='width: 100%;' class='borderStyle' /></td><td><input type='text' id='editGenre1' style='width: 100%;' class='borderStyle' /><input type='text' id='editGenre2' style='width: 100%;' class='borderStyle'/></td><td><button data-type='" + id + "' type='button' class='saveBtn btn btn-success'>Save</button></td>";
    $(editRow).html(dynamicRow);
}

