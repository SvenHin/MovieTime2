function buildMoviePage() {
    getMovieHeaderList();
    getMovieList();
    getMovieAddHeaders();
    getMovieAddBody();
    $("#addTable").show();
    addMovieSearchClass();
    addMoviePlaceHolder();
    addMovieActive();
    scrollToTop();
}
function scrollToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
function addMovieActive() {
    $("#customerPage").removeClass("active");
    $("#orderPage").removeClass("active");
    $("#moviePage").addClass("active");
}

function getMovieAddHeaders() {
    var print = "<tr><td>Title</td><td>Summary</td><td>Price</td><td>Url</td><td>Genre 1</td><td>Genre 2</td></tr>";
    $("#addHead").html(print);
}

function getMovieAddBody() {
    var print = "<tr><td><input type='text' id='Title' class='borderStyle' /></td><td><input type='text' id='Summary' class='borderStyle' /></td><td><input type='text' id='Price' class='borderStyle' /></td><td><input type='text' id='Url' class='borderStyle' /></td><td><input type='text' id='Genre1' class='borderStyle' /></td><td><input type='text' id='Genre2' class='borderStyle' /></td><td><button id='Add' class='btn btn-outline-success'>Add Movie</button></td></tr>";
    $("#addBody").html(print);
}
function addMovieSearchClass() {
    $("#searchBtn").removeClass("customerSearchBtn");
    $("#searchBtn").addClass("movieSearchBtn");
}
function addMoviePlaceHolder() {
    $("#searchField").attr("placeholder", "Movie title");
}

function getMovieHeaderList() {
    $.ajax({
        url: '/Admin/getAllMovieHeaders',
        type: 'GET',
        dataType: 'json',
        success: function (headers) {
            var print = "<thead><tr>";
            for (var i in headers) {
                print += "<th scope='col'>" + headers[i] + "</th>"
            }

            print += "<th schope='col'></th><th schope='col'></th></tr></thead>";
            print += "<tbody id='contentBody'></tbody>";

            $("#contentTable").html(print);
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
            for (var i in movies) {
                utStreng += "<tr id='" + movies[i].id + "'><th scope='row'>" + movies[i].id + "</th><td>" + movies[i].title + "</td><td>" + movies[i].summary + "</td><td>" + movies[i].price + "</td><td>" + movies[i].imageURL + "</td><td><button data-type='" + movies[i].id + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + movies[i].id + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
            }
            $("#contentBody").append(utStreng);
            scrollToTop();

        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
}
function searchMovie(title) {

    $.ajax({
        url: '/Admin/searchMovie',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: { 'title': title },
        success: function (movies) {
            var utStreng = "";
            for (var i in movies) {
                utStreng += "<tr id='" + movies[i].id + "'><th scope='row'>" + movies[i].id + "</th><td>" + movies[i].title + "</td><td>" + movies[i].summary + "</td><td>" + movies[i].price + "</td><td>" + movies[i].imageURL + "</td><td><button data-type='" + movies[i].id + "' type='button' class='editBtn btn btn-warning'>Edit</button></td><td><button data-type='" + movies[i].id + "' type='button' class='removeBtn btn btn-danger'>Remove</button></td></tr>"
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
    $(document).on("click", ".movieSearchBtn", function () {
        var title = $("#searchField").val();
        searchMovie(title);
    });
});
$(function () {
    $('#searchField').keypress(function (e) {
        var key = e.which;
        if (key == 13)
        {
            $('#searchBtn').click();
            return false;
        }
    });
});
$(function () {
    $("#Add").click(function () {
        var jsIn = {
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
            data: JSON.stringify(jsIn),
            contentType: "application/json;charset=utf-8",
            success: function (ok) {
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



