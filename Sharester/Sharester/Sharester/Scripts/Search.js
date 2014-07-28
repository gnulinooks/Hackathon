$("#SearchLink").click(function () {
    $("#searchTemplate").css(display, "block");
});

$("#SearchSubmit").click(GetSearch);

function GetSearch() {
    $.ajax({
        url: "SearchItem/Search/" + $("#SearchQuery").text + "/" + $("#SearchCategory").text,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            alert(response);
        },
        erro: function (response) {
            alert(response);
        }
    });
}