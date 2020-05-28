$(document).ready(function () {

    $('#btnDelete').click(function () {
        DeleteCustomer();
    });

});


function DeleteCustomer() {

    //收集表單欄位資料
    var formData = {}

    console.log(formData);
    let AjaxDelete = new AjaxPostClass('/api/Customer/' + encodeURI($("#lbFid").html()), formData, callback_delete_customer_fun);
    AjaxDelete.do_ajax_delete();

    function callback_delete_customer_fun(ret) {

        console.log(ret);
        if (ret) {
            location.href = "/Home/List";
        }
    }
}


