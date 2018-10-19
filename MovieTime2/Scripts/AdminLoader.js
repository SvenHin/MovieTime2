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
                utStreng += "<tr><th scope='row'>" + movies[i].id + "</th><td>" + movies[i].title + "</td><td>" + movies[i].summary + "</td><td>" + movies[i].price + "</td><td>" + movies[i].imageURL + "</td><td><button data-type='" + counter + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + counter + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
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
        alert(id);
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
        }

        $.ajax({
            url: '/Admin/addMovie',
            type: 'POST',
            data: JSON.stringify(jsInn),
            contentType: "application/json;charset=utf-8",
            success: function (ok) {
                // kunne ha feilhåndtert evt. feil i registreringen her
                //window.location.reload();
                // reload av vinduet må sje her altså etter at kallet har returnert
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

