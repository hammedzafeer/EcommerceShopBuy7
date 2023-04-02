
$(function () {
    //console.log($("#search"))
    $("#search").autocomplete({
        source: function (request, response) {
            let Fksubcat = document.getElementById("Fksubcat").value;
            //Fksubcat = "," + Fksubcat
            $.ajax({
                url: '/Home/SearchProduct/',
                data: { "prefix": request.term, "id": Fksubcat },
                type: "POST",
                success: function (data) {
                    response($.map(data, function (item) {
                        console.log(item)
                        return item;
                    }))

                },
                error: function (response) {
                    //alert(response.responseText);
                },
                failure: function (response) {
                    //alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            console.log(i)
            $("#searchId").val(i.item.value);

        },
        minLength: 1
    })
})
function register() {
    var data = $("#regForm").serialize();
    console.log(data);
    //alert(data);
    $.ajax({
        type: 'POST',
        url: '/Home/EmailVerfication',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: data,
        success: function (result) {
            document.getElementById("emailcode").value = result;
            console.log(result)
        },
        error: function () {
        }
    })
}


$(function () {

    $("#exzoom").exzoom({
        // thumbnail nav options
        "navWidth": 80,
        "navHeight": 80,
        "navItemNum": 4,
        "navItemMargin": 7,
        "navBorder": 1,

        // autoplay
        "autoPlay": false,

        // autoplay interval in milliseconds
        "autoPlayTimeout": 2000
    });

});