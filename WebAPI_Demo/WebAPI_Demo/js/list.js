$(document).ready(function () {

    GetCustomerList();
    $('#btnSerach').click(function () {
        SearchCustomer();
    });

});

function GetCustomerList() {

    var formData = {}
    
    let AjaxGet = new AjaxPostClass('/api/Customer', formData, callback_customer_fun);
    AjaxGet.do_ajax_get();

    function callback_customer_fun(ret) {

        console.log(ret);
        $("#tableshow").empty();

        $.each(ret, function (key, value) {
            $('#tableshow').append('<tr>' +
                '<td>' + value['fId'] + '</td>' +
                '<td>' + value['fName'] + '</td>' +
                '<td>' + value['fPhone'] + '</td>' +
                '<td>' + value['fEmail'] + '</td>' +
                '<td>' + value['fAddress'] + '</td>' +
                '<td>' +
                '<a href="/Home/Edit/' + value['fId'] +'" class="btn btn-success">編輯</a>  ' +
                '<a href="/Home/Delete/' + value['fId'] +'"  class="btn btn-danger">刪除</a>  ' +
                '</td>'+
                '<tr>'
            );

        });
       
    }
}

function SearchCustomer() {

    var formData = {
        Keyword: $("#search").val()
    }

    console.log(formData);
    let AjaxGet = new AjaxPostClass('/api/Customer/', formData, callback_search_customer_fun);
    AjaxGet.do_ajax_get();

    function callback_search_customer_fun(ret) {

        console.log(ret);
        $("#tableshow").empty();

        $.each(ret, function (key, value) {
            $('#tableshow').append('<tr>' +
                '<td>' + value['fId'] + '</td>' +
                '<td>' + value['fName'] + '</td>' +
                '<td>' + value['fPhone'] + '</td>' +
                '<td>' + value['fEmail'] + '</td>' +
                '<td>' + value['fAddress'] + '</td>' +
                '<td>' +
                '<a href="/Home/Edit/' + value['fId'] + '" class="btn btn-success">編輯</a>  ' +
                '<a href="/Home/Delete/' + value['fId'] + '"  class="btn btn-danger">刪除</a>  ' +
                '</td>' +
                '<tr>'
            );

        });

    }
}

