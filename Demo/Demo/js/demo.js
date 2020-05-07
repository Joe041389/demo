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
        //console.clear();  
        //console.log(ret['records']);
        var decription = ret['records']['weatherElement']['elementName'];
        var dt = ret['records']['weatherElement']['time']['dataTime'];
        var location_list = ret['records']['weatherElement']['location']
        $('#datasetDescription').html(decription);
        $('#dt').html('[' + dt + ']');

        $("#location").empty();
        $('#location_list').append('<ul>');

        let dt_values = new Array();
        $.each(location_list, function (key, value) {
            //console.log(value);
            $('#location_list').append('<li>' +
                value['locationCode'] +
                ' : ' +
                value['value']
             );
            dt_values.push({ "location_code": value['locationCode'], "location_value": value['value'] });

        });
        $('#location_list').append('</ul>');
        add_to_db(dt, dt_values);
    }

    function add_to_db(dt, dt_values) {

        var formData = {
            dt: dt,
            dt_values: dt_values
        }

        console.log(formData);
        let AjaxPost = new AjaxPostClass('/Home/Demo_add_data', formData, callback_add_value_fun);
        AjaxPost.do_ajax_post();

        function callback_add_value_fun(ret) {
            console.clear();
            console.log(ret);
            (ret ?
            $('#add_data_result').html('資料建立完成') :
            $('#add_data_result').html('資料建立失敗'));
                        
        }
    }
}