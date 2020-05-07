$(document).ready(function () {

    $('#get_cwb').click(function () {
        get_cwb_gov();
    });
   

});

function get_cwb_gov() {


    //收集表單欄位資料
    var formData = {
        Authorization: 'CWB-3C826B8A-89CC-4AE3-89A4-803732D1B75A',
        format: 'JSON',
        sort: 'time'
    }


    let AjaxGet = new AjaxPostClass('https://opendata.cwb.gov.tw/api/v1/rest/datastore/O-A0005-001?Authorization=CWB-3C826B8A-89CC-4AE3-89A4-803732D1B75A&format=JSON', formData, callback_cwb_gov_fun);
    AjaxGet.do_ajax_get();

    function callback_cwb_gov_fun(ret) {
        console.clear();  
        console.log(ret['records']);
        var decription = ret['records']['weatherElement']['elementName'];
        var dt = ret['records']['weatherElement']['time']['dataTime'];
        var location_list = ret['records']['weatherElement']['location']
        $('#datasetDescription').html(decription);
        $('#dt').html('[' + dt + ']');

        $("#location").empty();
        $('#location_list').append('<ul>');
        $.each(location_list, function (key, value) {
            console.log(value);
            $('#location_list').append('<li>' +
                value['locationCode'] +
                ' : ' +
                value['value']
             );
        });
        $('#location_list').append('</ul>');
    }

    function add_to_db(dt,location_list) {



    }
}