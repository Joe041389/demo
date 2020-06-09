$(function () {
    $('#listPanel').find('li').find('span').each(function () {

        $(this).css("background-color",$(this).html());
    })

})