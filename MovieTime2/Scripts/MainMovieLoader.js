
function getAllGenres() {
    $.getJSON("/Home/getAllGenresController",
        function (genres) {
            BuildGenres(genres);
        }
    );
    buyButtonNo();
}


function BuildGenres(genre) {
    for (var i in genre) {
        var genreBuilder = "<div><h2 class='display-4 genreHeaders'>" + genre[i].title + "</h2></div><div id='Genre" + genre[i].id + "' class='scrolling-wrapper imageBorderTopBottom maxSize'></div>"
        $("#MovieContainer").append(genreBuilder);
        BuildMovies(genre[i].id);

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
    var imageDiv = $('#' + targetDiv);
    var string = "";
    for (var m in imageMovie) {
        string += "<div class='card cardPadding' > <img class='hovereffect imageRow' id='" + imageMovie[m].id + "'src='" + imageMovie[m].imageURL + "' alt='image' /></div>"
        
    }
    $(imageDiv).append(string);
}

$(function () {
    $(document).on("click", ".imageRow", function () {
        DisplayMovieInfo($(this).attr('id'));
    });
});

function buyButton() {
    $("#alreadyBought").hide();
    $("#buy").show();
}

function buyButtonNo() {
    $("#buy").hide();
    $("#alreadyBought").show();
}

$(function () {
    $("#buy").click(function () {
        addToCart($("#movieTitle").data("movieid"));
    });
})


function DisplayMovieInfo(id) {
    $.ajax({
        url: '/Home/getIfBought/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (string) {
            if (string == "YES") {
                buyButtonNo();
            }
            else buyButton();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }

    });
    $.ajax({
        url: '/Home/displayMovieInfo/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (movie) {
            $("#movieTitle").data("movieid", movie.id);
            $("#movieTitle").html(movie.title);
            $("#moviePrice").html("Price: " + movie.price + " NOK");
            $("#movieSummary").html(movie.summary);
            $("#movieImg").html("<img alt='image' src='" + movie.imageURL + " ' />");
            document.getElementById("overlay").style.display = "block";
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
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
    $.ajax({
        url: '/AddToCart/getCartCount',
        type: 'GET',
        dataType: 'json',
        success: function (number) {
            $("#cartCounter").html(number);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function off() {
    document.getElementById("overlay").style.display = "none";
}
