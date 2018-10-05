
function getAllGenres() {
    $.getJSON("/Home/getAllGenresController",
        function (genres) {
            BuildGenres(genres);
        }
    );
}


function BuildGenres(genre) {
    for (var i in genre) {
        var genreBuilder = "<div><h2 class='display-4 genreHeaders'>" + genre[i].title + "</h2></div><div id='Genre" + genre[i].id + "' class='scrolling-wrapper imageBorderTopBottom maxSize'></div>"
        $("#MovieContainer").append(genreBuilder);
        BuildMovies(i);
    }

}

function BuildMovies(i) {
    $.getJSON("/Home/GetMoviesFromGenre", { id: i },
        function (imageMovie) {
            SetMovie(imageMovie, i)
        }
    );
}

function SetMovie(imageMovie, counter) {
    var targetDiv = "Genre" + counter;
    var row = $('#' + targetDiv);
    var string = "";
    for (var m in imageMovie) {
        string += "<div class='card cardPadding' > <img id='" + imageMovie[m].id + "'src='" + imageMovie[m].imageURL + "' alt='image' /></div>"
    }
    $(row).append(string);
    $("#MovieContainer div > img").click(function () {
        DisplayMovieInfo($(this).attr("id"));
    });
}

function DisplayMovieInfo(id) {
    $.ajax({
        url: '/Home/displayMovieInfo/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (movie) {
            $("#movieTitle").html(movie.title);
            $("#moviePrice").html("Price: " + movie.price + " NOK");
            $("#movieSummary").html(movie.summary);
            $("#movieImg").html("<img alt='image' src='" + movie.imageURL + " ' />");
            document.getElementById("overlay").style.display = "block";
            $("#buy").click(function () {
                addToCart(movie.id);
            });
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function addToCart(id) {
    $.ajax({
        url: '/AddToCart/Add/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (string) {
            alert(string);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}

function off() {
    document.getElementById("overlay").style.display = "none";
}